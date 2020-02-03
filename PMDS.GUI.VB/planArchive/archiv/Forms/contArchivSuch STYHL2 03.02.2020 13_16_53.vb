Imports System.IO
Imports Infragistics.Win.UltraWinToolbars
Imports System.Windows.Forms
Imports System.Drawing



Public Class contArchivSuch
    Inherits System.Windows.Forms.UserControl


    Private gen As New GeneralArchiv
    Private genMain As New GeneralArchiv
    Private ui As New UIElements()

    Private dataSchränke As New dsPlanArchive
    Private dataFächer As New dsPlanArchive
    Private dataOrdner As New dsPlanArchive

    Public acP As New System.Drawing.Point

    Private dataSchlagwortkatalog As New dsPlanArchive

    Public contOrdnerErgebniss As New contOrdner
    Public contSucheInOrdnern As New contOrdner


    Private dataDokumenteSuchen As New dsPlanArchive
    Private dataPapierkorb As New dsPlanArchive

    Public mainWindow As contArchivMain

    Private FileInfo As New clFileInfo

    Public objects As New ArrayList

    Public isLoaded As Boolean = False
    Public typObjects As New ArrayList



    Friend WithEvents ContextMenuDokumenteExplorerS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MtemSpcihernUnterExplorerS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MItemLöschenOhnePapierkorbExplorerS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MtemInfoDateiDokumentS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MItemVerzeichnisRausspielenBezeichnungS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MItemVerzeichnisRausspielenDateinameOriginalS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuDokumenteListeC As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MItemSpeichernUnterListeS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MItemDokumentLöschenOhnePapierkorbListeS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MItemInfoDokumentListeS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ÖffnenEXToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ÖffnenLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InDenPapierkorbEXToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InDenPapierkorbLIToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DokumentHinzufügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DokumentHinzufügenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblAbgelegtVon As Infragistics.Win.Misc.UltraLabel
    Public WithEvents cboSachbearbeiter As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblBenutzer As System.Windows.Forms.Label
    Friend WithEvents UDateAbgelegtBis As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UDateAbgelegtVon As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UDateGültigBis As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblGültigkeitVon As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UDateGültigVon As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UComboWichtigkeit As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents lblWichtigkeit As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents PanelAnzeigeBaumansicht As System.Windows.Forms.Panel
    Friend WithEvents RButtonOrdnerMitDokumente As System.Windows.Forms.RadioButton
    Friend WithEvents RButtonAlleOrdner As System.Windows.Forms.RadioButton
    Friend WithEvents layUnten As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents UDropDownButtonErweiterteSuche As Infragistics.Win.Misc.UltraDropDownButton
    Friend WithEvents PanelGrid As System.Windows.Forms.Panel
    Friend WithEvents UPopupContErweitSuche As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents UExplBarZeitpunktAbgerechnet As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar
    Friend WithEvents UltraExplorerBarContainerControl3 As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl
    Friend WithEvents layErwSuche As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents lasySucheSchlagwortkatalog As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents laySchnelsuche As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents laySucheInOrdner As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents PanelErweiterteSuchangaben As System.Windows.Forms.Panel
    Friend WithEvents PanelOrdnerErgebniss As System.Windows.Forms.Panel
    Friend WithEvents PanelSucheOrdner As System.Windows.Forms.Panel
    Public WithEvents UltraGroupBoxSchlagwörter As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBoxSucheInOrdnern As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents laySUcheInOrdner2 As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Public WithEvents UltraGroupBoxSucheInOrdner As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents layErwSuchangaben As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents lasySucheSchlagwortkatalog2 As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents grpAnzeigeBaumansicht As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UCheckTypAnhangPlanungssystem2 As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents PanelSucheSchlagwortkatalogOrdner As System.Windows.Forms.Panel
    Friend WithEvents PanelUnten As System.Windows.Forms.Panel
    Public WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents UCheckEditorImGesamtarchivSuchen As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Public WithEvents PanelBenutzerauswahl As System.Windows.Forms.Panel
    Public WithEvents UGridSchlagwortkatalog As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents DokumentenbezeichnungÄndernToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DokumentenbezeichnungÄndernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LayoutmanagerToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As ToolStripSeparator
    Friend WithEvents LayoutmanagerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripSeparator
    Friend WithEvents gridDocuArchive As QS2.Desktop.ControlManagment.BaseGrid



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
    Friend WithEvents UltraTabSharedControlsPage2 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl4 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl6 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UTabDokumenteGefunden As Infragistics.Win.UltraWinTabControl.UltraTabControl
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contArchivSuch))
        Dim UltraExplorerBarGroup1 As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup = New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridBagConstraint4 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim GridBagConstraint2 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridBagConstraint3 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridBagConstraint5 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim EditorButton1 As Infragistics.Win.UltraWinEditors.EditorButton = New Infragistics.Win.UltraWinEditors.EditorButton("Löschen")
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem10 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem11 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem12 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim GridBagConstraint6 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraExplorerBarContainerControl3 = New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarContainerControl()
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.PanelGrid = New System.Windows.Forms.Panel()
        Me.gridDocuArchive = New QS2.Desktop.ControlManagment.BaseGrid()
        Me.ContextMenuDokumenteListeC = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DokumentHinzufügenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÖffnenLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MItemSpeichernUnterListeS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.DokumentenbezeichnungÄndernToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.InDenPapierkorbLIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MItemDokumentLöschenOhnePapierkorbListeS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MItemInfoDokumentListeS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.LayoutmanagerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraTabPageControl6 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.PanelOrdnerErgebniss = New System.Windows.Forms.Panel()
        Me.UExplBarZeitpunktAbgerechnet = New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBar()
        Me.UltraGroupBoxSucheInOrdnern = New Infragistics.Win.Misc.UltraGroupBox()
        Me.PanelSucheOrdner = New System.Windows.Forms.Panel()
        Me.UDropDownButtonErweiterteSuche = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.UGridSchlagwortkatalog = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.UDateAbgelegtBis = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UDateAbgelegtVon = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblAbgelegtVon = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraGroupBoxSchlagwörter = New Infragistics.Win.Misc.UltraGroupBox()
        Me.PanelErweiterteSuchangaben = New System.Windows.Forms.Panel()
        Me.UltraGroupBoxSucheInOrdner = New Infragistics.Win.Misc.UltraGroupBox()
        Me.PanelBenutzerauswahl = New System.Windows.Forms.Panel()
        Me.cboSachbearbeiter = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblBenutzer = New System.Windows.Forms.Label()
        Me.UCheckEditorImGesamtarchivSuchen = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.grpAnzeigeBaumansicht = New Infragistics.Win.Misc.UltraGroupBox()
        Me.PanelAnzeigeBaumansicht = New System.Windows.Forms.Panel()
        Me.UCheckTypAnhangPlanungssystem2 = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.RButtonAlleOrdner = New System.Windows.Forms.RadioButton()
        Me.RButtonOrdnerMitDokumente = New System.Windows.Forms.RadioButton()
        Me.lblGültigkeitVon = New Infragistics.Win.Misc.UltraLabel()
        Me.UDateGültigBis = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblWichtigkeit = New Infragistics.Win.Misc.UltraLabel()
        Me.UDateGültigVon = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UComboWichtigkeit = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UTabDokumenteGefunden = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.ContextMenuDokumenteExplorerS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LayoutmanagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.DokumentHinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÖffnenEXToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MtemSpcihernUnterExplorerS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.DokumentenbezeichnungÄndernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InDenPapierkorbEXToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MItemLöschenOhnePapierkorbExplorerS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MtemInfoDateiDokumentS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.MItemVerzeichnisRausspielenBezeichnungS = New System.Windows.Forms.ToolStripMenuItem()
        Me.MItemVerzeichnisRausspielenDateinameOriginalS = New System.Windows.Forms.ToolStripMenuItem()
        Me.layUnten = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.PanelUnten = New System.Windows.Forms.Panel()
        Me.UPopupContErweitSuche = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.layErwSuche = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.lasySucheSchlagwortkatalog = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.PanelSucheSchlagwortkatalogOrdner = New System.Windows.Forms.Panel()
        Me.laySchnelsuche = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.laySucheInOrdner = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.laySUcheInOrdner2 = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.layErwSuchangaben = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.lasySucheSchlagwortkatalog2 = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.UltraTabPageControl4.SuspendLayout()
        Me.PanelGrid.SuspendLayout()
        CType(Me.gridDocuArchive, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuDokumenteListeC.SuspendLayout()
        Me.UltraTabPageControl6.SuspendLayout()
        Me.PanelOrdnerErgebniss.SuspendLayout()
        CType(Me.UExplBarZeitpunktAbgerechnet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UExplBarZeitpunktAbgerechnet.SuspendLayout()
        CType(Me.UltraGroupBoxSucheInOrdnern, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBoxSucheInOrdnern.SuspendLayout()
        Me.PanelSucheOrdner.SuspendLayout()
        CType(Me.UGridSchlagwortkatalog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDateAbgelegtBis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDateAbgelegtVon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBoxSchlagwörter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBoxSchlagwörter.SuspendLayout()
        Me.PanelErweiterteSuchangaben.SuspendLayout()
        CType(Me.UltraGroupBoxSucheInOrdner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBoxSucheInOrdner.SuspendLayout()
        Me.PanelBenutzerauswahl.SuspendLayout()
        CType(Me.cboSachbearbeiter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UCheckEditorImGesamtarchivSuchen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpAnzeigeBaumansicht, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAnzeigeBaumansicht.SuspendLayout()
        Me.PanelAnzeigeBaumansicht.SuspendLayout()
        CType(Me.UCheckTypAnhangPlanungssystem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDateGültigBis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDateGültigVon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UComboWichtigkeit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UTabDokumenteGefunden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UTabDokumenteGefunden.SuspendLayout()
        Me.ContextMenuDokumenteExplorerS.SuspendLayout()
        CType(Me.layUnten, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelUnten.SuspendLayout()
        CType(Me.layErwSuche, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lasySucheSchlagwortkatalog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSucheSchlagwortkatalogOrdner.SuspendLayout()
        CType(Me.laySchnelsuche, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.laySucheInOrdner, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.laySUcheInOrdner2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layErwSuchangaben, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lasySucheSchlagwortkatalog2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraExplorerBarContainerControl3
        '
        Me.UltraExplorerBarContainerControl3.Location = New System.Drawing.Point(13, 32)
        Me.UltraExplorerBarContainerControl3.Name = "UltraExplorerBarContainerControl3"
        Me.UltraExplorerBarContainerControl3.Size = New System.Drawing.Size(143, 136)
        Me.UltraExplorerBarContainerControl3.TabIndex = 0
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.PanelGrid)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(538, 421)
        '
        'PanelGrid
        '
        Me.PanelGrid.BackColor = System.Drawing.Color.White
        Me.PanelGrid.Controls.Add(Me.gridDocuArchive)
        Me.PanelGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelGrid.Location = New System.Drawing.Point(0, 0)
        Me.PanelGrid.Name = "PanelGrid"
        Me.PanelGrid.Size = New System.Drawing.Size(538, 421)
        Me.PanelGrid.TabIndex = 442
        '
        'gridDocuArchive
        '
        Me.gridDocuArchive.AutoWork = True
        Me.gridDocuArchive.ContextMenuStrip = Me.ContextMenuDokumenteListeC
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.Color.White
        Me.gridDocuArchive.DisplayLayout.Appearance = Appearance1
        Me.gridDocuArchive.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridDocuArchive.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.White
        Me.gridDocuArchive.DisplayLayout.GroupByBox.Appearance = Appearance2
        Me.gridDocuArchive.DisplayLayout.GroupByBox.Prompt = "Ziehen Sie eine Spalte herein welche Sie gruppieren möchten."
        Appearance3.BackColor = System.Drawing.Color.White
        Me.gridDocuArchive.DisplayLayout.GroupByBox.PromptAppearance = Appearance3
        Appearance4.BackColor = System.Drawing.Color.DarkGray
        Appearance4.BackColor2 = System.Drawing.Color.DarkGray
        Appearance4.ForeColor = System.Drawing.Color.White
        Me.gridDocuArchive.DisplayLayout.Override.ActiveRowAppearance = Appearance4
        Appearance5.BackColor = System.Drawing.Color.DarkGray
        Appearance5.BackColor2 = System.Drawing.Color.DarkGray
        Appearance5.ForeColor = System.Drawing.Color.White
        Me.gridDocuArchive.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        Me.gridDocuArchive.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.gridDocuArchive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDocuArchive.Location = New System.Drawing.Point(0, 0)
        Me.gridDocuArchive.Name = "gridDocuArchive"
        Me.gridDocuArchive.Size = New System.Drawing.Size(538, 421)
        Me.gridDocuArchive.TabIndex = 444
        Me.gridDocuArchive.Text = "UltraGrid1"
        '
        'ContextMenuDokumenteListeC
        '
        Me.ContextMenuDokumenteListeC.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DokumentHinzufügenToolStripMenuItem1, Me.ÖffnenLToolStripMenuItem, Me.MItemSpeichernUnterListeS, Me.ToolStripMenuItem5, Me.DokumentenbezeichnungÄndernToolStripMenuItem1, Me.InDenPapierkorbLIToolStripMenuItem, Me.MItemDokumentLöschenOhnePapierkorbListeS, Me.ToolStripMenuItem3, Me.MItemInfoDokumentListeS, Me.ToolStripMenuItem7, Me.LayoutmanagerToolStripMenuItem1})
        Me.ContextMenuDokumenteListeC.Name = "ContextMenuDokumenteExplorerS"
        Me.ContextMenuDokumenteListeC.Size = New System.Drawing.Size(252, 198)
        '
        'DokumentHinzufügenToolStripMenuItem1
        '
        Me.DokumentHinzufügenToolStripMenuItem1.Name = "DokumentHinzufügenToolStripMenuItem1"
        Me.DokumentHinzufügenToolStripMenuItem1.Size = New System.Drawing.Size(251, 22)
        Me.DokumentHinzufügenToolStripMenuItem1.Text = "Dokument hinzufügen"
        Me.DokumentHinzufügenToolStripMenuItem1.Visible = False
        '
        'ÖffnenLToolStripMenuItem
        '
        Me.ÖffnenLToolStripMenuItem.Image = CType(resources.GetObject("ÖffnenLToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ÖffnenLToolStripMenuItem.Name = "ÖffnenLToolStripMenuItem"
        Me.ÖffnenLToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.ÖffnenLToolStripMenuItem.Text = "Datei öffnen"
        '
        'MItemSpeichernUnterListeS
        '
        Me.MItemSpeichernUnterListeS.Image = CType(resources.GetObject("MItemSpeichernUnterListeS.Image"), System.Drawing.Image)
        Me.MItemSpeichernUnterListeS.Name = "MItemSpeichernUnterListeS"
        Me.MItemSpeichernUnterListeS.Size = New System.Drawing.Size(251, 22)
        Me.MItemSpeichernUnterListeS.Text = "Datei speichern"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(248, 6)
        '
        'DokumentenbezeichnungÄndernToolStripMenuItem1
        '
        Me.DokumentenbezeichnungÄndernToolStripMenuItem1.Name = "DokumentenbezeichnungÄndernToolStripMenuItem1"
        Me.DokumentenbezeichnungÄndernToolStripMenuItem1.Size = New System.Drawing.Size(251, 22)
        Me.DokumentenbezeichnungÄndernToolStripMenuItem1.Text = "Dokumentenbezeichnung ändern"
        '
        'InDenPapierkorbLIToolStripMenuItem
        '
        Me.InDenPapierkorbLIToolStripMenuItem.Name = "InDenPapierkorbLIToolStripMenuItem"
        Me.InDenPapierkorbLIToolStripMenuItem.Size = New System.Drawing.Size(251, 22)
        Me.InDenPapierkorbLIToolStripMenuItem.Text = "In den Papierkorb verschieben"
        '
        'MItemDokumentLöschenOhnePapierkorbListeS
        '
        Me.MItemDokumentLöschenOhnePapierkorbListeS.Image = CType(resources.GetObject("MItemDokumentLöschenOhnePapierkorbListeS.Image"), System.Drawing.Image)
        Me.MItemDokumentLöschenOhnePapierkorbListeS.Name = "MItemDokumentLöschenOhnePapierkorbListeS"
        Me.MItemDokumentLöschenOhnePapierkorbListeS.Size = New System.Drawing.Size(251, 22)
        Me.MItemDokumentLöschenOhnePapierkorbListeS.Text = "Löschen"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(248, 6)
        '
        'MItemInfoDokumentListeS
        '
        Me.MItemInfoDokumentListeS.Image = CType(resources.GetObject("MItemInfoDokumentListeS.Image"), System.Drawing.Image)
        Me.MItemInfoDokumentListeS.Name = "MItemInfoDokumentListeS"
        Me.MItemInfoDokumentListeS.Size = New System.Drawing.Size(251, 22)
        Me.MItemInfoDokumentListeS.Text = "Info Dokument"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(248, 6)
        '
        'LayoutmanagerToolStripMenuItem1
        '
        Me.LayoutmanagerToolStripMenuItem1.Name = "LayoutmanagerToolStripMenuItem1"
        Me.LayoutmanagerToolStripMenuItem1.Size = New System.Drawing.Size(251, 22)
        Me.LayoutmanagerToolStripMenuItem1.Text = "Layoutmanager"
        '
        'UltraTabPageControl6
        '
        Me.UltraTabPageControl6.Controls.Add(Me.PanelOrdnerErgebniss)
        Me.UltraTabPageControl6.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl6.Name = "UltraTabPageControl6"
        Me.UltraTabPageControl6.Size = New System.Drawing.Size(538, 421)
        '
        'PanelOrdnerErgebniss
        '
        Me.PanelOrdnerErgebniss.BackColor = System.Drawing.Color.White
        Me.PanelOrdnerErgebniss.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelOrdnerErgebniss.Controls.Add(Me.UExplBarZeitpunktAbgerechnet)
        Me.PanelOrdnerErgebniss.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelOrdnerErgebniss.Location = New System.Drawing.Point(0, 0)
        Me.PanelOrdnerErgebniss.Name = "PanelOrdnerErgebniss"
        Me.PanelOrdnerErgebniss.Size = New System.Drawing.Size(538, 421)
        Me.PanelOrdnerErgebniss.TabIndex = 0
        '
        'UExplBarZeitpunktAbgerechnet
        '
        Me.UExplBarZeitpunktAbgerechnet.AnimationEnabled = False
        Me.UExplBarZeitpunktAbgerechnet.ColumnSpacing = 1
        Me.UExplBarZeitpunktAbgerechnet.Controls.Add(Me.UltraExplorerBarContainerControl3)
        UltraExplorerBarGroup1.Container = Me.UltraExplorerBarContainerControl3
        UltraExplorerBarGroup1.Key = "ZeitpunktAbgerechnet"
        UltraExplorerBarGroup1.Settings.ContainerHeight = 136
        UltraExplorerBarGroup1.Settings.Style = Infragistics.Win.UltraWinExplorerBar.GroupStyle.ControlContainer
        UltraExplorerBarGroup1.Text = "Zeitpunkt Abrechnung"
        Me.UExplBarZeitpunktAbgerechnet.Groups.AddRange(New Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup() {UltraExplorerBarGroup1})
        Me.UExplBarZeitpunktAbgerechnet.GroupSpacing = 0
        Me.UExplBarZeitpunktAbgerechnet.Location = New System.Drawing.Point(40, 45)
        Me.UExplBarZeitpunktAbgerechnet.Margins.Bottom = 0
        Me.UExplBarZeitpunktAbgerechnet.Margins.Left = 0
        Me.UExplBarZeitpunktAbgerechnet.Margins.Right = 0
        Me.UExplBarZeitpunktAbgerechnet.Margins.Top = 0
        Me.UExplBarZeitpunktAbgerechnet.Name = "UExplBarZeitpunktAbgerechnet"
        Me.UExplBarZeitpunktAbgerechnet.Size = New System.Drawing.Size(179, 35)
        Me.UExplBarZeitpunktAbgerechnet.TabIndex = 460
        Me.UExplBarZeitpunktAbgerechnet.Visible = False
        '
        'UltraGroupBoxSucheInOrdnern
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Appearance6.BorderColor = System.Drawing.Color.Black
        Me.UltraGroupBoxSucheInOrdnern.Appearance = Appearance6
        Me.UltraGroupBoxSucheInOrdnern.Controls.Add(Me.PanelSucheOrdner)
        GridBagConstraint4.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint4.Insets.Bottom = 5
        GridBagConstraint4.Insets.Right = 5
        GridBagConstraint4.Insets.Top = 5
        GridBagConstraint4.OriginY = 1
        Me.lasySucheSchlagwortkatalog.SetGridBagConstraint(Me.UltraGroupBoxSucheInOrdnern, GridBagConstraint4)
        Me.UltraGroupBoxSucheInOrdnern.Location = New System.Drawing.Point(0, 242)
        Me.UltraGroupBoxSucheInOrdnern.Name = "UltraGroupBoxSucheInOrdnern"
        Me.lasySucheSchlagwortkatalog.SetPreferredSize(Me.UltraGroupBoxSucheInOrdnern, New System.Drawing.Size(232, 215))
        Me.UltraGroupBoxSucheInOrdnern.Size = New System.Drawing.Size(254, 184)
        Me.UltraGroupBoxSucheInOrdnern.TabIndex = 461
        Me.UltraGroupBoxSucheInOrdnern.Text = "Suchen in Ordnern"
        '
        'PanelSucheOrdner
        '
        Me.PanelSucheOrdner.BackColor = System.Drawing.Color.White
        Me.PanelSucheOrdner.Controls.Add(Me.UDropDownButtonErweiterteSuche)
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Bottom = 5
        GridBagConstraint1.Insets.Left = 5
        GridBagConstraint1.Insets.Right = 5
        GridBagConstraint1.Insets.Top = 5
        Me.laySucheInOrdner.SetGridBagConstraint(Me.PanelSucheOrdner, GridBagConstraint1)
        Me.PanelSucheOrdner.Location = New System.Drawing.Point(8, 21)
        Me.PanelSucheOrdner.Name = "PanelSucheOrdner"
        Me.laySucheInOrdner.SetPreferredSize(Me.PanelSucheOrdner, New System.Drawing.Size(490, 24))
        Me.PanelSucheOrdner.Size = New System.Drawing.Size(238, 155)
        Me.PanelSucheOrdner.TabIndex = 0
        '
        'UDropDownButtonErweiterteSuche
        '
        Me.UDropDownButtonErweiterteSuche.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2007RibbonButton
        Me.UDropDownButtonErweiterteSuche.Location = New System.Drawing.Point(7, 3)
        Me.UDropDownButtonErweiterteSuche.Name = "UDropDownButtonErweiterteSuche"
        Me.UDropDownButtonErweiterteSuche.Size = New System.Drawing.Size(145, 25)
        Me.UDropDownButtonErweiterteSuche.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.UDropDownButtonErweiterteSuche.TabIndex = 454
        Me.UDropDownButtonErweiterteSuche.Text = "Erweiterte Suchkriterien"
        Me.UDropDownButtonErweiterteSuche.Visible = False
        '
        'UGridSchlagwortkatalog
        '
        Appearance8.BackColor = System.Drawing.Color.White
        Appearance8.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UGridSchlagwortkatalog.DisplayLayout.Appearance = Appearance8
        Me.UGridSchlagwortkatalog.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance9.BackColor = System.Drawing.Color.FloralWhite
        Me.UGridSchlagwortkatalog.DisplayLayout.CaptionAppearance = Appearance9
        Me.UGridSchlagwortkatalog.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance10.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridSchlagwortkatalog.DisplayLayout.GroupByBox.Appearance = Appearance10
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridSchlagwortkatalog.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance11
        Me.UGridSchlagwortkatalog.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UGridSchlagwortkatalog.DisplayLayout.GroupByBox.Prompt = "Ziehen Sie eine Spalte herein  nach der Sie gruppieren möchten:"
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance12.BackColor2 = System.Drawing.SystemColors.Control
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridSchlagwortkatalog.DisplayLayout.GroupByBox.PromptAppearance = Appearance12
        Me.UGridSchlagwortkatalog.DisplayLayout.MaxColScrollRegions = 1
        Me.UGridSchlagwortkatalog.DisplayLayout.MaxRowScrollRegions = 1
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.ActiveCellAppearance = Appearance13
        Appearance14.BackColor = System.Drawing.Color.DodgerBlue
        Appearance14.ForeColor = System.Drawing.Color.White
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.ActiveRowAppearance = Appearance14
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.CardAreaAppearance = Appearance15
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.CardSpacing = 0
        Appearance16.BorderColor = System.Drawing.Color.Silver
        Appearance16.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.CellAppearance = Appearance16
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.CellPadding = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.CellSpacing = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.DefaultRowHeight = 1
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.FilterRowSpacingAfter = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.FilterRowSpacingBefore = 0
        Appearance17.BackColor = System.Drawing.SystemColors.Control
        Appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance17.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance17.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.GroupByRowAppearance = Appearance17
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.GroupByRowPadding = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.GroupByRowSpacingAfter = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.GroupByRowSpacingBefore = 0
        Appearance18.TextHAlignAsString = "Left"
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.HeaderAppearance = Appearance18
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.XPThemed
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Appearance19.BorderColor = System.Drawing.Color.Silver
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.RowAppearance = Appearance19
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.RowSizingAutoMaxLines = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.RowSpacingAfter = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.RowSpacingBefore = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.SequenceFilterRow = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.SequenceFixedAddRow = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.SequenceSummaryRow = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.SpecialRowSeparatorHeight = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.SummaryFooterSpacingAfter = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.SummaryFooterSpacingBefore = 0
        Appearance20.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.TemplateAddRowAppearance = Appearance20
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.TemplateAddRowSpacingAfter = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.TemplateAddRowSpacingBefore = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.RowConnectorColor = System.Drawing.Color.FloralWhite
        Me.UGridSchlagwortkatalog.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None
        Me.UGridSchlagwortkatalog.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UGridSchlagwortkatalog.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        GridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint2.Insets.Bottom = 5
        GridBagConstraint2.Insets.Left = 5
        GridBagConstraint2.Insets.Right = 5
        GridBagConstraint2.Insets.Top = 5
        Me.lasySucheSchlagwortkatalog2.SetGridBagConstraint(Me.UGridSchlagwortkatalog, GridBagConstraint2)
        Me.UGridSchlagwortkatalog.Location = New System.Drawing.Point(8, 21)
        Me.UGridSchlagwortkatalog.Name = "UGridSchlagwortkatalog"
        Me.lasySucheSchlagwortkatalog2.SetPreferredSize(Me.UGridSchlagwortkatalog, New System.Drawing.Size(116, 77))
        Me.UGridSchlagwortkatalog.Size = New System.Drawing.Size(238, 198)
        Me.UGridSchlagwortkatalog.TabIndex = 455
        Me.UGridSchlagwortkatalog.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'UDateAbgelegtBis
        '
        Appearance21.BackColor = System.Drawing.Color.White
        Me.UDateAbgelegtBis.Appearance = Appearance21
        Me.UDateAbgelegtBis.BackColor = System.Drawing.Color.White
        Me.UDateAbgelegtBis.DateTime = New Date(2005, 9, 2, 0, 0, 0, 0)
        Me.UDateAbgelegtBis.Location = New System.Drawing.Point(211, 38)
        Me.UDateAbgelegtBis.Name = "UDateAbgelegtBis"
        Me.UDateAbgelegtBis.Size = New System.Drawing.Size(96, 21)
        Me.UDateAbgelegtBis.TabIndex = 1
        Me.UDateAbgelegtBis.Value = New Date(2005, 9, 2, 0, 0, 0, 0)
        '
        'UDateAbgelegtVon
        '
        Appearance22.BackColor = System.Drawing.Color.White
        Me.UDateAbgelegtVon.Appearance = Appearance22
        Me.UDateAbgelegtVon.BackColor = System.Drawing.Color.White
        Me.UDateAbgelegtVon.DateTime = New Date(2005, 9, 2, 0, 0, 0, 0)
        Me.UDateAbgelegtVon.Location = New System.Drawing.Point(90, 38)
        Me.UDateAbgelegtVon.Name = "UDateAbgelegtVon"
        Me.UDateAbgelegtVon.Size = New System.Drawing.Size(96, 21)
        Me.UDateAbgelegtVon.TabIndex = 0
        Me.UDateAbgelegtVon.Value = New Date(2005, 9, 2, 0, 0, 0, 0)
        '
        'UltraLabel7
        '
        Appearance23.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel7.Appearance = Appearance23
        Me.UltraLabel7.Location = New System.Drawing.Point(188, 40)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(24, 16)
        Me.UltraLabel7.TabIndex = 328
        Me.UltraLabel7.Text = "bis"
        '
        'lblAbgelegtVon
        '
        Appearance24.BackColor = System.Drawing.Color.Transparent
        Me.lblAbgelegtVon.Appearance = Appearance24
        Me.lblAbgelegtVon.Location = New System.Drawing.Point(10, 40)
        Me.lblAbgelegtVon.Name = "lblAbgelegtVon"
        Me.lblAbgelegtVon.Size = New System.Drawing.Size(76, 16)
        Me.lblAbgelegtVon.TabIndex = 386
        Me.lblAbgelegtVon.Text = "Abgelegt von"
        '
        'UltraGroupBoxSchlagwörter
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.BorderColor = System.Drawing.Color.Black
        Me.UltraGroupBoxSchlagwörter.Appearance = Appearance7
        Me.UltraGroupBoxSchlagwörter.Controls.Add(Me.UGridSchlagwortkatalog)
        GridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint3.Insets.Bottom = 5
        GridBagConstraint3.Insets.Right = 5
        GridBagConstraint3.Insets.Top = 5
        Me.lasySucheSchlagwortkatalog.SetGridBagConstraint(Me.UltraGroupBoxSchlagwörter, GridBagConstraint3)
        Me.UltraGroupBoxSchlagwörter.Location = New System.Drawing.Point(0, 5)
        Me.UltraGroupBoxSchlagwörter.Name = "UltraGroupBoxSchlagwörter"
        Me.lasySucheSchlagwortkatalog.SetPreferredSize(Me.UltraGroupBoxSchlagwörter, New System.Drawing.Size(265, 264))
        Me.UltraGroupBoxSchlagwörter.Size = New System.Drawing.Size(254, 227)
        Me.UltraGroupBoxSchlagwörter.TabIndex = 462
        Me.UltraGroupBoxSchlagwörter.Text = "Suche nach Schlagwörtern"
        '
        'PanelErweiterteSuchangaben
        '
        Me.PanelErweiterteSuchangaben.BackColor = System.Drawing.Color.Transparent
        Me.PanelErweiterteSuchangaben.Controls.Add(Me.UltraGroupBoxSucheInOrdner)
        Me.PanelErweiterteSuchangaben.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelErweiterteSuchangaben.Location = New System.Drawing.Point(0, 0)
        Me.PanelErweiterteSuchangaben.Name = "PanelErweiterteSuchangaben"
        Me.PanelErweiterteSuchangaben.Size = New System.Drawing.Size(807, 142)
        Me.PanelErweiterteSuchangaben.TabIndex = 0
        '
        'UltraGroupBoxSucheInOrdner
        '
        Appearance25.BackColor = System.Drawing.Color.Transparent
        Appearance25.BorderColor = System.Drawing.Color.Black
        Me.UltraGroupBoxSucheInOrdner.Appearance = Appearance25
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.PanelBenutzerauswahl)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UCheckEditorImGesamtarchivSuchen)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.grpAnzeigeBaumansicht)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UDateAbgelegtBis)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.lblGültigkeitVon)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UDateAbgelegtVon)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UDateGültigBis)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UltraLabel7)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UltraLabel6)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.lblAbgelegtVon)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.lblWichtigkeit)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UDateGültigVon)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UComboWichtigkeit)
        GridBagConstraint5.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint5.Insets.Bottom = 2
        GridBagConstraint5.Insets.Left = 5
        GridBagConstraint5.Insets.Right = 5
        GridBagConstraint5.Insets.Top = 5
        Me.layErwSuchangaben.SetGridBagConstraint(Me.UltraGroupBoxSucheInOrdner, GridBagConstraint5)
        Me.UltraGroupBoxSucheInOrdner.Location = New System.Drawing.Point(5, 5)
        Me.UltraGroupBoxSucheInOrdner.Name = "UltraGroupBoxSucheInOrdner"
        Me.layErwSuchangaben.SetPreferredSize(Me.UltraGroupBoxSucheInOrdner, New System.Drawing.Size(301, 218))
        Me.UltraGroupBoxSucheInOrdner.Size = New System.Drawing.Size(797, 135)
        Me.UltraGroupBoxSucheInOrdner.TabIndex = 0
        Me.UltraGroupBoxSucheInOrdner.Text = "Erweiterte Suchangaben"
        '
        'PanelBenutzerauswahl
        '
        Me.PanelBenutzerauswahl.BackColor = System.Drawing.Color.Transparent
        Me.PanelBenutzerauswahl.Controls.Add(Me.cboSachbearbeiter)
        Me.PanelBenutzerauswahl.Controls.Add(Me.lblBenutzer)
        Me.PanelBenutzerauswahl.Location = New System.Drawing.Point(511, 101)
        Me.PanelBenutzerauswahl.Name = "PanelBenutzerauswahl"
        Me.PanelBenutzerauswahl.Size = New System.Drawing.Size(256, 26)
        Me.PanelBenutzerauswahl.TabIndex = 7
        Me.PanelBenutzerauswahl.Visible = False
        '
        'cboSachbearbeiter
        '
        Me.cboSachbearbeiter.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboSachbearbeiter.AutoSize = False
        Me.cboSachbearbeiter.Location = New System.Drawing.Point(52, 3)
        Me.cboSachbearbeiter.Name = "cboSachbearbeiter"
        Me.cboSachbearbeiter.Size = New System.Drawing.Size(186, 21)
        Me.cboSachbearbeiter.TabIndex = 0
        '
        'lblBenutzer
        '
        Me.lblBenutzer.BackColor = System.Drawing.Color.Transparent
        Me.lblBenutzer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBenutzer.Location = New System.Drawing.Point(1, 2)
        Me.lblBenutzer.Name = "lblBenutzer"
        Me.lblBenutzer.Size = New System.Drawing.Size(52, 23)
        Me.lblBenutzer.TabIndex = 384
        Me.lblBenutzer.Text = "Benutzer"
        Me.lblBenutzer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UCheckEditorImGesamtarchivSuchen
        '
        Me.UCheckEditorImGesamtarchivSuchen.BackColor = System.Drawing.Color.Transparent
        Me.UCheckEditorImGesamtarchivSuchen.BackColorInternal = System.Drawing.Color.Transparent
        Me.UCheckEditorImGesamtarchivSuchen.Location = New System.Drawing.Point(344, 105)
        Me.UCheckEditorImGesamtarchivSuchen.Name = "UCheckEditorImGesamtarchivSuchen"
        Me.UCheckEditorImGesamtarchivSuchen.Size = New System.Drawing.Size(162, 18)
        Me.UCheckEditorImGesamtarchivSuchen.TabIndex = 6
        Me.UCheckEditorImGesamtarchivSuchen.Text = "Im gesamten Archiv suchen"
        Me.UCheckEditorImGesamtarchivSuchen.Visible = False
        '
        'grpAnzeigeBaumansicht
        '
        Appearance26.BackColor = System.Drawing.Color.Transparent
        Me.grpAnzeigeBaumansicht.Appearance = Appearance26
        Me.grpAnzeigeBaumansicht.Controls.Add(Me.PanelAnzeigeBaumansicht)
        Me.grpAnzeigeBaumansicht.Location = New System.Drawing.Point(321, 24)
        Me.grpAnzeigeBaumansicht.Name = "grpAnzeigeBaumansicht"
        Me.grpAnzeigeBaumansicht.Size = New System.Drawing.Size(453, 73)
        Me.grpAnzeigeBaumansicht.TabIndex = 5
        Me.grpAnzeigeBaumansicht.Text = "Anzeige Baumansicht"
        '
        'PanelAnzeigeBaumansicht
        '
        Me.PanelAnzeigeBaumansicht.Controls.Add(Me.UCheckTypAnhangPlanungssystem2)
        Me.PanelAnzeigeBaumansicht.Controls.Add(Me.RButtonAlleOrdner)
        Me.PanelAnzeigeBaumansicht.Controls.Add(Me.RButtonOrdnerMitDokumente)
        Me.PanelAnzeigeBaumansicht.Location = New System.Drawing.Point(15, 24)
        Me.PanelAnzeigeBaumansicht.Name = "PanelAnzeigeBaumansicht"
        Me.PanelAnzeigeBaumansicht.Size = New System.Drawing.Size(426, 41)
        Me.PanelAnzeigeBaumansicht.TabIndex = 0
        '
        'UCheckTypAnhangPlanungssystem2
        '
        Me.UCheckTypAnhangPlanungssystem2.Location = New System.Drawing.Point(226, 4)
        Me.UCheckTypAnhangPlanungssystem2.Name = "UCheckTypAnhangPlanungssystem2"
        Me.UCheckTypAnhangPlanungssystem2.Size = New System.Drawing.Size(197, 34)
        Me.UCheckTypAnhangPlanungssystem2.TabIndex = 2
        Me.UCheckTypAnhangPlanungssystem2.Text = "Suche angehängte Dokumente zu Terminen und Mails"
        '
        'RButtonAlleOrdner
        '
        Me.RButtonAlleOrdner.AutoSize = True
        Me.RButtonAlleOrdner.ForeColor = System.Drawing.Color.Black
        Me.RButtonAlleOrdner.Location = New System.Drawing.Point(8, 19)
        Me.RButtonAlleOrdner.Name = "RButtonAlleOrdner"
        Me.RButtonAlleOrdner.Size = New System.Drawing.Size(123, 17)
        Me.RButtonAlleOrdner.TabIndex = 1
        Me.RButtonAlleOrdner.TabStop = True
        Me.RButtonAlleOrdner.Text = "Alle Ordner anzeigen"
        Me.RButtonAlleOrdner.UseVisualStyleBackColor = False
        '
        'RButtonOrdnerMitDokumente
        '
        Me.RButtonOrdnerMitDokumente.AutoSize = True
        Me.RButtonOrdnerMitDokumente.ForeColor = System.Drawing.Color.Black
        Me.RButtonOrdnerMitDokumente.Location = New System.Drawing.Point(8, 3)
        Me.RButtonOrdnerMitDokumente.Name = "RButtonOrdnerMitDokumente"
        Me.RButtonOrdnerMitDokumente.Size = New System.Drawing.Size(197, 17)
        Me.RButtonOrdnerMitDokumente.TabIndex = 0
        Me.RButtonOrdnerMitDokumente.TabStop = True
        Me.RButtonOrdnerMitDokumente.Text = "Nur Ordner mit Dokumente anzeigen"
        Me.RButtonOrdnerMitDokumente.UseVisualStyleBackColor = False
        '
        'lblGültigkeitVon
        '
        Appearance27.BackColor = System.Drawing.Color.Transparent
        Me.lblGültigkeitVon.Appearance = Appearance27
        Me.lblGültigkeitVon.Location = New System.Drawing.Point(9, 63)
        Me.lblGültigkeitVon.Name = "lblGültigkeitVon"
        Me.lblGültigkeitVon.Size = New System.Drawing.Size(76, 16)
        Me.lblGültigkeitVon.TabIndex = 242
        Me.lblGültigkeitVon.Text = "Gültigkeit von"
        '
        'UDateGültigBis
        '
        Appearance28.BackColor = System.Drawing.Color.White
        Me.UDateGültigBis.Appearance = Appearance28
        Me.UDateGültigBis.AutoSize = False
        Me.UDateGültigBis.BackColor = System.Drawing.Color.White
        Me.UDateGültigBis.DateTime = New Date(2005, 9, 2, 0, 0, 0, 0)
        Me.UDateGültigBis.Location = New System.Drawing.Point(211, 61)
        Me.UDateGültigBis.Name = "UDateGültigBis"
        Me.UDateGültigBis.Size = New System.Drawing.Size(96, 21)
        Me.UDateGültigBis.TabIndex = 3
        Me.UDateGültigBis.Value = New Date(2005, 9, 2, 0, 0, 0, 0)
        '
        'UltraLabel6
        '
        Appearance29.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel6.Appearance = Appearance29
        Me.UltraLabel6.Location = New System.Drawing.Point(188, 63)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(24, 16)
        Me.UltraLabel6.TabIndex = 244
        Me.UltraLabel6.Text = "bis"
        '
        'lblWichtigkeit
        '
        Appearance30.BackColor = System.Drawing.Color.Transparent
        Appearance30.ForeColor = System.Drawing.Color.Black
        Me.lblWichtigkeit.Appearance = Appearance30
        Me.lblWichtigkeit.Location = New System.Drawing.Point(9, 103)
        Me.lblWichtigkeit.Name = "lblWichtigkeit"
        Me.lblWichtigkeit.Size = New System.Drawing.Size(64, 16)
        Me.lblWichtigkeit.TabIndex = 239
        Me.lblWichtigkeit.Text = "Wichtigkeit"
        '
        'UDateGültigVon
        '
        Appearance31.BackColor = System.Drawing.Color.White
        Me.UDateGültigVon.Appearance = Appearance31
        Me.UDateGültigVon.AutoSize = False
        Me.UDateGültigVon.BackColor = System.Drawing.Color.White
        Me.UDateGültigVon.DateTime = New Date(2005, 9, 2, 0, 0, 0, 0)
        Me.UDateGültigVon.Location = New System.Drawing.Point(90, 61)
        Me.UDateGültigVon.Name = "UDateGültigVon"
        Me.UDateGültigVon.Size = New System.Drawing.Size(96, 21)
        Me.UDateGültigVon.TabIndex = 2
        Me.UDateGültigVon.Value = New Date(2005, 9, 2, 0, 0, 0, 0)
        '
        'UComboWichtigkeit
        '
        Appearance32.BackColor = System.Drawing.Color.White
        Me.UComboWichtigkeit.Appearance = Appearance32
        Me.UComboWichtigkeit.AutoSize = False
        Me.UComboWichtigkeit.BackColor = System.Drawing.Color.White
        Me.UComboWichtigkeit.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance33.Image = CType(resources.GetObject("Appearance33.Image"), Object)
        EditorButton1.Appearance = Appearance33
        EditorButton1.Key = "Löschen"
        Me.UComboWichtigkeit.ButtonsRight.Add(EditorButton1)
        Me.UComboWichtigkeit.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem10.DataValue = "H"
        ValueListItem10.DisplayText = "Hoch"
        ValueListItem11.DataValue = "M"
        ValueListItem11.DisplayText = "Mittel"
        ValueListItem12.DataValue = "N"
        ValueListItem12.DisplayText = "Niedrig"
        Me.UComboWichtigkeit.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem10, ValueListItem11, ValueListItem12})
        Me.UComboWichtigkeit.Location = New System.Drawing.Point(90, 101)
        Me.UComboWichtigkeit.Name = "UComboWichtigkeit"
        Me.UComboWichtigkeit.Size = New System.Drawing.Size(96, 21)
        Me.UComboWichtigkeit.TabIndex = 4
        '
        'UTabDokumenteGefunden
        '
        Me.UTabDokumenteGefunden.Controls.Add(Me.UltraTabSharedControlsPage2)
        Me.UTabDokumenteGefunden.Controls.Add(Me.UltraTabPageControl4)
        Me.UTabDokumenteGefunden.Controls.Add(Me.UltraTabPageControl6)
        GridBagConstraint6.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint6.Insets.Bottom = 5
        GridBagConstraint6.Insets.Left = 5
        GridBagConstraint6.Insets.Right = 1
        GridBagConstraint6.Insets.Top = 5
        Me.layUnten.SetGridBagConstraint(Me.UTabDokumenteGefunden, GridBagConstraint6)
        Me.UTabDokumenteGefunden.Location = New System.Drawing.Point(5, 5)
        Me.UTabDokumenteGefunden.Name = "UTabDokumenteGefunden"
        Me.layUnten.SetPreferredSize(Me.UTabDokumenteGefunden, New System.Drawing.Size(214, 327))
        Me.UTabDokumenteGefunden.SharedControlsPage = Me.UltraTabSharedControlsPage2
        Me.UTabDokumenteGefunden.Size = New System.Drawing.Size(538, 421)
        Me.UTabDokumenteGefunden.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard
        Me.UTabDokumenteGefunden.TabIndex = 441
        Appearance34.FontData.Name = "Arial"
        Appearance34.FontData.SizeInPoints = 8.25!
        Appearance34.FontData.UnderlineAsString = "False"
        Appearance34.ForeColor = System.Drawing.Color.Blue
        UltraTab2.ActiveAppearance = Appearance34
        Appearance35.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance35.FontData.UnderlineAsString = "True"
        Appearance35.ForeColor = System.Drawing.Color.Blue
        UltraTab2.HotTrackAppearance = Appearance35
        UltraTab2.Key = "Liste"
        UltraTab2.TabPage = Me.UltraTabPageControl4
        UltraTab2.Text = "Liste"
        Appearance36.FontData.UnderlineAsString = "False"
        Appearance36.ForeColor = System.Drawing.Color.Blue
        UltraTab1.ActiveAppearance = Appearance36
        Appearance37.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance37.FontData.UnderlineAsString = "True"
        Appearance37.ForeColor = System.Drawing.Color.Blue
        UltraTab1.HotTrackAppearance = Appearance37
        UltraTab1.Key = "Explorer"
        UltraTab1.TabPage = Me.UltraTabPageControl6
        UltraTab1.Text = "Explorer"
        Me.UTabDokumenteGefunden.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab2, UltraTab1})
        Me.UTabDokumenteGefunden.UseAppStyling = False
        Me.UTabDokumenteGefunden.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(538, 421)
        '
        'ContextMenuDokumenteExplorerS
        '
        Me.ContextMenuDokumenteExplorerS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LayoutmanagerToolStripMenuItem, Me.ToolStripMenuItem4, Me.DokumentHinzufügenToolStripMenuItem, Me.ÖffnenEXToolStripMenuItem, Me.MtemSpcihernUnterExplorerS, Me.ToolStripMenuItem2, Me.DokumentenbezeichnungÄndernToolStripMenuItem, Me.InDenPapierkorbEXToolStripMenuItem, Me.MItemLöschenOhnePapierkorbExplorerS, Me.ToolStripMenuItem1, Me.MtemInfoDateiDokumentS, Me.ToolStripMenuItem6, Me.MItemVerzeichnisRausspielenBezeichnungS, Me.MItemVerzeichnisRausspielenDateinameOriginalS})
        Me.ContextMenuDokumenteExplorerS.Name = "ContextMenuDokumenteExplorerS"
        Me.ContextMenuDokumenteExplorerS.Size = New System.Drawing.Size(319, 248)
        '
        'LayoutmanagerToolStripMenuItem
        '
        Me.LayoutmanagerToolStripMenuItem.Name = "LayoutmanagerToolStripMenuItem"
        Me.LayoutmanagerToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.LayoutmanagerToolStripMenuItem.Text = "Layoutmanager"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(315, 6)
        '
        'DokumentHinzufügenToolStripMenuItem
        '
        Me.DokumentHinzufügenToolStripMenuItem.Name = "DokumentHinzufügenToolStripMenuItem"
        Me.DokumentHinzufügenToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.DokumentHinzufügenToolStripMenuItem.Text = "Dokument hinzufügen ..."
        Me.DokumentHinzufügenToolStripMenuItem.Visible = False
        '
        'ÖffnenEXToolStripMenuItem
        '
        Me.ÖffnenEXToolStripMenuItem.Image = CType(resources.GetObject("ÖffnenEXToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ÖffnenEXToolStripMenuItem.Name = "ÖffnenEXToolStripMenuItem"
        Me.ÖffnenEXToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.ÖffnenEXToolStripMenuItem.Text = "Datei öffnen"
        '
        'MtemSpcihernUnterExplorerS
        '
        Me.MtemSpcihernUnterExplorerS.Image = CType(resources.GetObject("MtemSpcihernUnterExplorerS.Image"), System.Drawing.Image)
        Me.MtemSpcihernUnterExplorerS.Name = "MtemSpcihernUnterExplorerS"
        Me.MtemSpcihernUnterExplorerS.Size = New System.Drawing.Size(318, 22)
        Me.MtemSpcihernUnterExplorerS.Text = "Datei speichern"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(315, 6)
        '
        'DokumentenbezeichnungÄndernToolStripMenuItem
        '
        Me.DokumentenbezeichnungÄndernToolStripMenuItem.Name = "DokumentenbezeichnungÄndernToolStripMenuItem"
        Me.DokumentenbezeichnungÄndernToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.DokumentenbezeichnungÄndernToolStripMenuItem.Text = "Dokumentenbezeichnung ändern"
        '
        'InDenPapierkorbEXToolStripMenuItem
        '
        Me.InDenPapierkorbEXToolStripMenuItem.Name = "InDenPapierkorbEXToolStripMenuItem"
        Me.InDenPapierkorbEXToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.InDenPapierkorbEXToolStripMenuItem.Text = "In den Papierkorb verschieben"
        '
        'MItemLöschenOhnePapierkorbExplorerS
        '
        Me.MItemLöschenOhnePapierkorbExplorerS.Image = CType(resources.GetObject("MItemLöschenOhnePapierkorbExplorerS.Image"), System.Drawing.Image)
        Me.MItemLöschenOhnePapierkorbExplorerS.Name = "MItemLöschenOhnePapierkorbExplorerS"
        Me.MItemLöschenOhnePapierkorbExplorerS.Size = New System.Drawing.Size(318, 22)
        Me.MItemLöschenOhnePapierkorbExplorerS.Text = "Löschen"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(315, 6)
        '
        'MtemInfoDateiDokumentS
        '
        Me.MtemInfoDateiDokumentS.Image = CType(resources.GetObject("MtemInfoDateiDokumentS.Image"), System.Drawing.Image)
        Me.MtemInfoDateiDokumentS.Name = "MtemInfoDateiDokumentS"
        Me.MtemInfoDateiDokumentS.Size = New System.Drawing.Size(318, 22)
        Me.MtemInfoDateiDokumentS.Text = "Info Dokument"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(315, 6)
        '
        'MItemVerzeichnisRausspielenBezeichnungS
        '
        Me.MItemVerzeichnisRausspielenBezeichnungS.Name = "MItemVerzeichnisRausspielenBezeichnungS"
        Me.MItemVerzeichnisRausspielenBezeichnungS.Size = New System.Drawing.Size(318, 22)
        Me.MItemVerzeichnisRausspielenBezeichnungS.Text = "Ordner mit Dokumenten exportieren"
        '
        'MItemVerzeichnisRausspielenDateinameOriginalS
        '
        Me.MItemVerzeichnisRausspielenDateinameOriginalS.Name = "MItemVerzeichnisRausspielenDateinameOriginalS"
        Me.MItemVerzeichnisRausspielenDateinameOriginalS.Size = New System.Drawing.Size(318, 22)
        Me.MItemVerzeichnisRausspielenDateinameOriginalS.Text = "Verzeichnis exportieren (mit orig. Dateinamen)"
        Me.MItemVerzeichnisRausspielenDateinameOriginalS.Visible = False
        '
        'layUnten
        '
        Me.layUnten.ContainerControl = Me.PanelUnten
        Me.layUnten.ExpandToFitHeight = True
        Me.layUnten.ExpandToFitWidth = True
        '
        'PanelUnten
        '
        Me.PanelUnten.BackColor = System.Drawing.Color.Transparent
        Me.PanelUnten.Controls.Add(Me.UTabDokumenteGefunden)
        Me.PanelUnten.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelUnten.Location = New System.Drawing.Point(0, 0)
        Me.PanelUnten.Name = "PanelUnten"
        Me.PanelUnten.Size = New System.Drawing.Size(544, 431)
        Me.PanelUnten.TabIndex = 1
        '
        'layErwSuche
        '
        Me.layErwSuche.ExpandToFitHeight = True
        Me.layErwSuche.ExpandToFitWidth = True
        '
        'lasySucheSchlagwortkatalog
        '
        Me.lasySucheSchlagwortkatalog.ContainerControl = Me.PanelSucheSchlagwortkatalogOrdner
        Me.lasySucheSchlagwortkatalog.ExpandToFitHeight = True
        Me.lasySucheSchlagwortkatalog.ExpandToFitWidth = True
        '
        'PanelSucheSchlagwortkatalogOrdner
        '
        Me.PanelSucheSchlagwortkatalogOrdner.BackColor = System.Drawing.Color.Transparent
        Me.PanelSucheSchlagwortkatalogOrdner.Controls.Add(Me.UltraGroupBoxSucheInOrdnern)
        Me.PanelSucheSchlagwortkatalogOrdner.Controls.Add(Me.UltraGroupBoxSchlagwörter)
        Me.PanelSucheSchlagwortkatalogOrdner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelSucheSchlagwortkatalogOrdner.Location = New System.Drawing.Point(0, 0)
        Me.PanelSucheSchlagwortkatalogOrdner.Name = "PanelSucheSchlagwortkatalogOrdner"
        Me.PanelSucheSchlagwortkatalogOrdner.Size = New System.Drawing.Size(259, 431)
        Me.PanelSucheSchlagwortkatalogOrdner.TabIndex = 464
        '
        'laySchnelsuche
        '
        Me.laySchnelsuche.ExpandToFitHeight = True
        Me.laySchnelsuche.ExpandToFitWidth = True
        '
        'laySucheInOrdner
        '
        Me.laySucheInOrdner.ContainerControl = Me.UltraGroupBoxSucheInOrdnern
        Me.laySucheInOrdner.ExpandToFitHeight = True
        Me.laySucheInOrdner.ExpandToFitWidth = True
        '
        'laySUcheInOrdner2
        '
        Me.laySUcheInOrdner2.ExpandToFitHeight = True
        Me.laySUcheInOrdner2.ExpandToFitWidth = True
        '
        'layErwSuchangaben
        '
        Me.layErwSuchangaben.ContainerControl = Me.PanelErweiterteSuchangaben
        Me.layErwSuchangaben.ExpandToFitHeight = True
        Me.layErwSuchangaben.ExpandToFitWidth = True
        '
        'lasySucheSchlagwortkatalog2
        '
        Me.lasySucheSchlagwortkatalog2.ContainerControl = Me.UltraGroupBoxSchlagwörter
        Me.lasySucheSchlagwortkatalog2.ExpandToFitHeight = True
        Me.lasySucheSchlagwortkatalog2.ExpandToFitWidth = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.PanelUnten)
        Me.SplitContainer1.Panel1MinSize = 0
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PanelSucheSchlagwortkatalogOrdner)
        Me.SplitContainer1.Panel2MinSize = 0
        Me.SplitContainer1.Size = New System.Drawing.Size(807, 431)
        Me.SplitContainer1.SplitterDistance = 544
        Me.SplitContainer1.TabIndex = 466
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.SplitContainer1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 142)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(807, 431)
        Me.Panel2.TabIndex = 467
        '
        'contArchivSuch
        '
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PanelErweiterteSuchangaben)
        Me.Name = "contArchivSuch"
        Me.Size = New System.Drawing.Size(807, 573)
        Me.UltraTabPageControl4.ResumeLayout(False)
        Me.PanelGrid.ResumeLayout(False)
        CType(Me.gridDocuArchive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuDokumenteListeC.ResumeLayout(False)
        Me.UltraTabPageControl6.ResumeLayout(False)
        Me.PanelOrdnerErgebniss.ResumeLayout(False)
        CType(Me.UExplBarZeitpunktAbgerechnet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UExplBarZeitpunktAbgerechnet.ResumeLayout(False)
        CType(Me.UltraGroupBoxSucheInOrdnern, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBoxSucheInOrdnern.ResumeLayout(False)
        Me.PanelSucheOrdner.ResumeLayout(False)
        CType(Me.UGridSchlagwortkatalog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDateAbgelegtBis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDateAbgelegtVon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBoxSchlagwörter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBoxSchlagwörter.ResumeLayout(False)
        Me.PanelErweiterteSuchangaben.ResumeLayout(False)
        CType(Me.UltraGroupBoxSucheInOrdner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBoxSucheInOrdner.ResumeLayout(False)
        Me.UltraGroupBoxSucheInOrdner.PerformLayout()
        Me.PanelBenutzerauswahl.ResumeLayout(False)
        CType(Me.cboSachbearbeiter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UCheckEditorImGesamtarchivSuchen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpAnzeigeBaumansicht, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAnzeigeBaumansicht.ResumeLayout(False)
        Me.PanelAnzeigeBaumansicht.ResumeLayout(False)
        Me.PanelAnzeigeBaumansicht.PerformLayout()
        CType(Me.UCheckTypAnhangPlanungssystem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDateGültigBis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDateGültigVon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UComboWichtigkeit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UTabDokumenteGefunden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UTabDokumenteGefunden.ResumeLayout(False)
        Me.ContextMenuDokumenteExplorerS.ResumeLayout(False)
        CType(Me.layUnten, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelUnten.ResumeLayout(False)
        CType(Me.layErwSuche, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lasySucheSchlagwortkatalog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSucheSchlagwortkatalogOrdner.ResumeLayout(False)
        CType(Me.laySchnelsuche, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.laySucheInOrdner, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.laySUcheInOrdner2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layErwSuchangaben, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lasySucheSchlagwortkatalog2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub DokumentSuchen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        End Try
    End Sub
    Public Sub initForm()
        Try
            If Me.isLoaded Then Exit Sub

            Me.MItemDokumentLöschenOhnePapierkorbListeS.Visible = True
            Me.MItemLöschenOhnePapierkorbExplorerS.Visible = True

            Me.UDropDownButtonErweiterteSuche.PopupItem = Me.UPopupContErweitSuche

            Me.LoadOrdnerIntoPanels()

            Me.resetForm()

            Me.RButtonOrdnerMitDokumente.Checked = True

            Dim d_evHandDoubleMouseUp As New dArchiv.Funct(AddressOf Me.ArchivOrdnerErgebniss_MouseUp)
            Me.contOrdnerErgebniss.delMouseUp.RegisterDelegate(d_evHandDoubleMouseUp)

            Dim d_evHandClick As New dArchiv.Funct(AddressOf Me.ArchivOrdnerErgebniss_Click)
            Me.contOrdnerErgebniss.delClick.RegisterDelegate(d_evHandClick)

            Me.genMain.getAllUserCbo(Me.cboSachbearbeiter)
            'Me.Show()
            'Me.ResizeControl(Me.Height, Me.Width)

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("initForm: " + ex.ToString())
        End Try
    End Sub
    Public Sub LoadOrdnerIntoPanels()
        Try
            Me.PanelOrdnerErgebniss.Controls.Add(Me.contOrdnerErgebniss)
            Me.contOrdnerErgebniss.ResizeControl(Me.PanelOrdnerErgebniss.Width, Me.PanelOrdnerErgebniss.Height)
            Me.contOrdnerErgebniss.resizeForSucherergebnisse()
            Me.contOrdnerErgebniss.initTree_icons(True)

            Me.PanelSucheOrdner.Controls.Add(contSucheInOrdnern)
            Me.contSucheInOrdnern.ResizeControl(Me.PanelSucheOrdner.Width, Me.PanelSucheOrdner.Height)
            Me.contSucheInOrdnern.fill_DockStyle()
            Me.contSucheInOrdnern.initTree_icons(False)

        Catch ex As Exception
            Throw New Exception("LoadOrdnerIntoPanels: " + ex.ToString())
        End Try
    End Sub

    Public Function DokumenteSuchenMitObjects(ByVal ob As ArrayList, ByVal Dummy As Boolean, doInit As Boolean)
        Try
            Me.objects = ob
            Me.DokumentSuchen(Dummy, False, doInit)

        Catch ex As Exception
            Throw New Exception("DokumenteSuchenMitObjects: " + ex.ToString())
        End Try
    End Function

    Public Sub resetForm()
        Try
            Me.FileInfo = New clFileInfo

            Me.LoadSchlagwortkatalog()

            Me.LoadOrdner()

            Me.gridDocuArchive.DataSource = Nothing
            Me.gridDocuArchive.DataBind()

            Me.gridDocuArchive.DataSource = Nothing
            Me.gridDocuArchive.DataBind()

            Me.UDateGültigVon.Value = Nothing
            Me.UDateGültigBis.Value = Nothing
            Me.UDateAbgelegtVon.Value = Nothing
            Me.UDateAbgelegtBis.Value = Nothing

            Me.UComboWichtigkeit.Value = Nothing

            Me.UTabDokumenteGefunden.Tabs(0).Text = "Liste"

            Me.cboSachbearbeiter.Value = ""
            Me.cboSachbearbeiter.Text = ""

            Me.UCheckTypAnhangPlanungssystem2.Checked = False

            Me.DokumentSuchen(True, False, False)
            Me.setSuchtext("")

        Catch ex As Exception
            Throw New Exception("resetForm: " + ex.ToString())
        End Try
    End Sub
    Public Sub LoadSchlagwortkatalog()
        Try

            Dim db_ThemenSchlagw As New compSql
            Me.dataSchlagwortkatalog = db_ThemenSchlagw.LesenAllerThemenUndSchlagwörter()

            Me.UGridSchlagwortkatalog.DataSource = Me.dataSchlagwortkatalog
            Me.UGridSchlagwortkatalog.DataBind()
            Me.initSchlagwortkatalog(Me.dataSchlagwortkatalog)

            Me.UGridSchlagwortkatalog.Refresh()
            Me.UGridSchlagwortkatalog.Rows.ExpandAll(True)

        Catch ex As Exception
            Throw New Exception("LoadSchlagwortkatalog: " + ex.ToString())
        End Try
    End Sub
    Public Sub initSchlagwortkatalog(ByRef dataThemen As dsPlanArchive)
        Try

            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(0).Columns("ID").Hidden = True
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(0).Columns("ErstelltAm").Hidden = True
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(0).Columns("ErstelltVon").Hidden = True
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).Columns("ID").Hidden = True
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).Columns("IDThema").Hidden = True
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).Columns("ErstelltAm").Hidden = True
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).Columns("ErstelltVon").Hidden = True

            dataThemen.tblSchlagwörter.Columns.Add(New DataColumn("Gültig", GetType(System.Boolean)))

            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).Columns("Gültig").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).Columns("Gültig").DefaultCellValue = False

            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(0).Columns("Thema").Width = 110
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).Columns("Schlagwort").Width = 50

            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(0).Columns("Thema").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).Columns("Schlagwort").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            For Each r As dsPlanArchive.tblSchlagwörterRow In dataThemen.tblSchlagwörter.Rows
                r("Gültig") = False
            Next
            'For Each itm As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.UGridSchlagwortkatalog.Rows
            '    itm.Cells("Gültig").Value = False
            'Next

            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(0).HeaderVisible = False
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(0).ColHeadersVisible = False
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).HeaderVisible = False
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).ColHeadersVisible = False
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(0).Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None

            UGridSchlagwortkatalog.DisplayLayout.Bands(0).Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None
            UGridSchlagwortkatalog.DisplayLayout.Bands(0).Override.RowAppearance.BorderColor = System.Drawing.Color.White

            'Me.UGridSchlagwortkatalog.DisplayLayout.Bands(0).HeaderVisible = False
            'Me.UGridSchlagwortkatalog.DisplayLayout.Bands(0).ColHeadersVisible = False
            'Me.UGridSchlagwortkatalog.DisplayLayout.Bands(0).Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None
            'Me.UGridSchlagwortkatalog.DisplayLayout.Bands(0).Override.RowAppearance.BorderColor = System.Drawing.Color.White

            'Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).HeaderVisible = False
            'Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).ColHeadersVisible = False
            'Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None
            'Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).Override.RowAppearance.BorderColor = System.Drawing.Color.White

            Me.UGridSchlagwortkatalog.DisplayLayout.Appearance.BackColor = Color.White

        Catch ex As Exception
            Throw New Exception("initSchlagwortkatalog: " + ex.ToString())
        End Try
    End Sub

    Public Sub LoadOrdner()
        Try

            Me.contSucheInOrdnern.LoadOrdnerbaum(contOrdner.etyp.AuswahlSuche, Nothing)

        Catch ex As Exception
            Throw New Exception("LoadOrdner: " + ex.ToString())
        End Try
    End Sub


    Private Sub UltraComboSchrank_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)

    End Sub
    Private Sub UltraComboFach_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)

    End Sub

    Public Sub DokumentSuchen(ByVal leerAnzeigen As Boolean, ByVal nurPapierkorb As Boolean, doInit As Boolean)
        Try
            Me.dataDokumenteSuchen.Clear()
            Me.gridDocuArchive.Visible = False

            Me.UTabDokumenteGefunden.Tabs(0).Text = "Liste"
            Dim IDSchlagwörter As New ArrayList
            Dim compSuche As New compSql

            Dim data As New dsPlanArchive
            If leerAnzeigen And Not nurPapierkorb Then
                Dim id As New System.Guid : id = System.Guid.NewGuid
                IDSchlagwörter.Add(id)
                compSuche.qryDokumenteSuchen(Trim(id.ToString), Me.contSucheInOrdnern.GetCheckedOrdner(), IDSchlagwörter,
                                                                Me.UDateGültigVon.Value, Me.UDateGültigBis.Value, Me.UComboWichtigkeit.Value, Me.objects, Me.typObjects,
                                                                compSql.etyp.dokumente,
                                                                Me.UDateAbgelegtVon.Value, Me.UDateAbgelegtBis.Value, Me.cboSachbearbeiter.Text, False,
                                                                Me.UCheckTypAnhangPlanungssystem2.Checked, False, Me.UCheckEditorImGesamtarchivSuchen.Checked,
                                                                data, doInit)
            ElseIf Not leerAnzeigen And nurPapierkorb Then
                Dim arr As New ArrayList
                compSuche.qryDokumenteSuchen("", arr, arr, Nothing, Nothing, "", arr, arr, compSql.etyp.dokumente,
                                                 Nothing, Nothing, "", True, False, True, True, data, doInit)
            Else
                For Each r As dsPlanArchive.tblSchlagwörterRow In Me.dataSchlagwortkatalog.tblSchlagwörter
                    If r("Gültig") = True Then
                        IDSchlagwörter.Add(r.ID)
                    End If
                Next
                Dim arrcheckedOrdner As ArrayList = Me.contSucheInOrdnern.GetCheckedOrdner()
                'If arrcheckedOrdner.Count = 0 And IDSchlagwörter.Count = 0 And gen.IsNull(Trim(Me.UTextBezeichnung.Text)) And _
                '            gen.IsNull(Me.UDateGültigVon.Value) And gen.IsNull(Me.UDateGültigBis.Value) And _
                '            gen.IsNull(Me.UComboWichtigkeit.Value) And _
                '            gen.IsNull(Me.UDateAbgelegtVon.Value) And gen.IsNull(Me.UDateAbgelegtBis.Value) And _
                '            gen.IsNull(Trim(Me.cboSachbearbeiter.Text)) Then

                'End If

                compSuche.qryDokumenteSuchen(Trim(Me.getSuchtext), arrcheckedOrdner, IDSchlagwörter,
                                                    Me.UDateGültigVon.Value, Me.UDateGültigBis.Value, Me.UComboWichtigkeit.Value, Me.objects, Me.typObjects,
                                                    compSql.etyp.dokumente,
                                                    Me.UDateAbgelegtVon.Value, Me.UDateAbgelegtBis.Value, Me.cboSachbearbeiter.Text, False,
                                                    Me.UCheckTypAnhangPlanungssystem2.Checked, False, Me.UCheckEditorImGesamtarchivSuchen.Checked,
                                                    data, doInit)
            End If

            Me.dataDokumenteSuchen = data

            If dataDokumenteSuchen.tblDokumenteSuchen.Rows.Count > 1000 Then
                If MsgBox("Es wurden mehr als 1000 Dokumente gefunden!" + vbNewLine + vbNewLine +
                        "Soll die Suche trotzdem durchgeführt werden?" + vbNewLine +
                        "(Hinweis: Wenn viele Dokumente gefunden wurden, kann die Suche bis zu einigen Minuten in Anspruch nehmen!)", MsgBoxStyle.YesNo, "Suche Archiv") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            Me.gridDocuArchive.DataSource = Me.dataDokumenteSuchen
            Me.gridDocuArchive.DataBind()

            Dim UIElements1 As New UIElements()
            Dim lstTablesNotDelete As New System.Collections.Generic.List(Of String)()
            lstTablesNotDelete.Add(Me.dataDokumenteSuchen.tblDokumenteSuchen.TableName.Trim())
            UIElements1.deleteTablesFromDataSet(Me.dataDokumenteSuchen, lstTablesNotDelete)

            Me.initGridDokumenteGefunden(Me.dataDokumenteSuchen)
            Me.contOrdnerErgebniss.LoadSuchergebnis(Me.dataDokumenteSuchen, contOrdner.etyp.SuchergebnisseAnzeigen, Me.RButtonOrdnerMitDokumente.Checked)
            Me.checkRechteGrid()

            'If Me.dataDokumenteSuchen.tblDokumente.Rows.Count > 0 Then
            'Else
            'MsgBox(ui.GetResString("KeineDokumenteGefunden"), MsgBoxStyle.Information, "Archivsystem")
            'End If

            Me.setCaptionButtSuchen(Me.dataDokumenteSuchen.tblDokumenteSuchen.Rows.Count)

            If nurPapierkorb Then
                If Me.dataDokumenteSuchen.tblDokumenteSuchen.Rows.Count = 0 Then
                    MsgBox("Der Papierkorb ist leer!", MsgBoxStyle.Information, "Papierkorb öffnen")
                End If
            End If

            Dim LayoutFound As Boolean = False
            Dim compLayout1 As QS2.core.vb.compLayout = New QS2.core.vb.compLayout()
            compLayout1.initControl()
            compLayout1.doLayoutGrid(Me.gridDocuArchive, Me.gridDocuArchive.Name.Trim(), Nothing, LayoutFound, True, Not PMDS.Global.ENV.IntDeactivated, PMDS.Global.ENV.AutoAddNewRessources)

            Me.gridDocuArchive.Visible = True

        Catch ex As Exception
            Me.gridDocuArchive.Visible = False
            Throw New Exception("DokumentSuchen: " + ex.ToString())
        End Try
    End Sub


    Public Sub setCaptionButtSuchen(ByVal anz As Integer)
        Try
            If Not mainWindow Is Nothing Then
                If Me.mainWindow.UToolbarsManagerMain.Visible Then
                    If anz = 0 Then
                        Me.mainWindow.UToolbarsManagerMain.Tools("Suchen").SharedProps.Caption = "Suchen"
                    Else
                        Me.mainWindow.UToolbarsManagerMain.Tools("Suchen").SharedProps.Caption = "Suchen (" + anz.ToString + ")"
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("setCaptionButtSuchen: " + ex.ToString())
        End Try
    End Sub

    Public Function getSuchtext() As String
        Try
            Dim txtTool As TextBoxTool = Me.mainWindow.UToolbarsManagerMain.Tools("txtDokumentname")
            If txtTool.Text = "Schnellsuche (Strg+S)" Then
                Return ""
            Else
                Return txtTool.Text
            End If

        Catch ex As Exception
            Throw New Exception("getSuchtext: " + ex.ToString())
        End Try
    End Function
    Public Sub setSuchtext(ByVal txt As String)
        Try
            If Not Me.mainWindow Is Nothing Then
                If Me.mainWindow.UToolbarsManagerMain.Visible Then
                    Dim txtTool As TextBoxTool = Me.mainWindow.UToolbarsManagerMain.Tools("txtDokumentname")
                    txtTool.Text = txt
                End If
            End If

        Catch ex As Exception
            Throw New Exception("setSuchtext: " + ex.ToString())
        End Try
    End Sub
    Public Function Papierkorb_ladenxyxy(ByVal withMsgBox As Boolean) As Boolean
        Try
            '    Me.dataPapierkorb.Clear()
            '    Dim compSuche As New compDokumentSuchen

            '    ' daten lesen
            '    Dim arr As New ArrayList
            '    compSuche.qryDokumenteSuchen("", arr, arr, Nothing, Nothing, "", arr, arr, compDokumentSuchen.etyp.dokumente, _
            '                                     Nothing, Nothing, "", True, False, True, True)
            '    If Me.UOptionSetAnzeige.Value = "beziehungen" Then
            '        compSuche.qryDokumenteSuchen("", arr, arr, Nothing, Nothing, "", arr, arr, compDokumentSuchen.etyp.objekte, _
            '                                         Nothing, Nothing, "", True, False, True, True)
            '    ElseIf Me.UOptionSetAnzeige.Value = "schlagwörter" Then
            '        compSuche.qryDokumenteSuchen("", arr, arr, Nothing, Nothing, "", arr, arr, compDokumentSuchen.etyp.Schlagwörter, _
            '                                        Nothing, Nothing, "", True, False, True, True)
            '    End If

            '    Me.dataPapierkorb = compSuche.data

            '    Dim rel_schlagw As New DataRelation("relSucheSchlagw", Me.dataPapierkorb.tblDokumente.Columns("IDDokumenteintrag"), Me.dataPapierkorb.tblDokumenteneintragSchlagwörter.Columns("IDDokueintrSchl"))
            '    Me.dataPapierkorb.Relations.Add(rel_schlagw)

            '    Me.contOrdnerErgebniss.LoadSuchergebnis(Me.dataPapierkorb, contOrdner.etyp.SuchergebnisseAnzeigen, True)
            '    If withMsgBox Then
            '        If Me.dataPapierkorb.tblDokumente.Rows.Count = 0 Then
            '            MsgBox("Der Papierkorb ist leer!", MsgBoxStyle.Information, "Archivsystem")
            '            Return False
            '        Else
            '        End If
            '    End If
            '    Return True

        Catch ex As Exception
            Throw New Exception("Papierkorb_laden: " + ex.ToString())
        End Try
    End Function


    Public Function checkRechteGrid()
        Try

            'For Each item As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.UGridDokumenteGefunden.Rows
            '    Dim cl As New S2ArchivWork.clRecht
            '    Dim IDOrdner As New System.Guid(item.Cells("IDOrdner").Value.ToString)
            '    If Not cl.ArchivRechtJaNein("App_ArchivDokumenteSuchen", "", False, IDOrdner) Then
            '        'item.Delete(False)
            '    End If
            'Next

            Dim gef As Integer = 0
            For Each r As dsPlanArchive.tblDokumenteSuchenRow In Me.dataDokumenteSuchen.tblDokumenteSuchen
                Dim IDOrdner As New System.Guid(r.IDOrdner.ToString)
                gef += 1
            Next

            Me.UTabDokumenteGefunden.Tabs(0).Text = "Liste:" + gef.ToString

        Catch ex As Exception
            Throw New Exception("checkRechteGrid: " + ex.ToString())
        End Try
    End Function

    Public Sub initGridDokumenteGefunden(ByRef dataDokumenteSuchen As dsPlanArchive)
        Try

            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Bezeichnung").Width = 350
            ''Me.UGridDokumenteGefunden3.DisplayLayout.Bands(0).Columns("").Header.Appearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
            ''Me.UGridDokumenteGefunden3.DisplayLayout.Bands(0).Columns("").Header.Appearance.BackColor = System.Drawing.Color.Wheat
            ''Me.UGridDokumenteGefunden3.DisplayLayout.Bands(0).Columns("").Header.Appearance.ForeColor = System.Drawing.Color.Black
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Bezeichnung").Header.Caption = "Bezeichnung"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Bezeichnung").DataType.GetType("System.String")

            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DokumentGröße").Width = 80
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DokumentGröße").Header.Caption = "Grösse (Byte)"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DokumentGröße").DataType.GetType("System.Int32")
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DokumentGröße").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DokumentGröße").Format = "###,###,##0"

            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("ErstelltAm").Width = 110
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("ErstelltAm").Header.Caption = "Abgelegt am"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("ErstelltAm").DataType.GetType("System.Date")
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("ErstelltAm").Format = "yyyy-MM-dd HH:mm"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("ErstelltAm").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center

            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("ErstelltVon").Width = 150
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("ErstelltVon").Header.Caption = "Von"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("ErstelltVon").DataType.GetType("System.String")

            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Wichtigkeit").Width = 80
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Wichtigkeit").Header.Caption = "Wichtigkeit"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Wichtigkeit").DataType.GetType("System.String")
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Wichtigkeit").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center

            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Winzip").Width = 50
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Winzip").Header.Caption = "Winzip"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Winzip").DataType.GetType("System.Boolean")
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Winzip").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Winzip").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Extern").Width = 50
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Extern").Header.Caption = "Extern"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Extern").DataType.GetType("System.Boolean")
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Extern").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Extern").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox

            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DokumentErstellt").Width = 100
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DokumentErstellt").Header.Caption = "Datei erstellt am"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DokumentErstellt").DataType.GetType("System.Date")
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DokumentErstellt").Format = "yyyy-MM-dd"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DokumentErstellt").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            '' Me.UGridDokumenteGefunden3.DisplayLayout.Bands(0).Columns("DokumentErstellt").Header.Appearance.Image = ImageList.Images(10)

            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DokumentGeändert").Width = 110
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DokumentGeändert").Header.Caption = "Letzt Änderung am"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DokumentGeändert").DataType.GetType("System.Date")
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DokumentGeändert").Format = "yyyy-MM-dd"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DokumentGeändert").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            '' Me.UGridDokumenteGefunden3.DisplayLayout.Bands(0).Columns("DokumentGeändert").Header.Appearance.Image = ImageList.Images(10)

            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("GültigVon").Width = 80
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("GültigVon").Header.Caption = "Gültig von"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("GültigVon").DataType.GetType("System.Date")
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("GültigVon").Format = "yyyy-MM-dd"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("GültigVon").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center

            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("GültigBis").Width = 80
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("GültigBis").Header.Caption = "Gültig bis"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("GültigBis").DataType.GetType("System.Date")
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("GültigBis").Format = "yyyy-MM-dd"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("GültigBis").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center

            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("BezeichnungOrdner").Width = 140
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("BezeichnungOrdner").Header.Caption = "Gültig bis"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("BezeichnungOrdner").DataType.GetType("System.String")
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("BezeichnungOrdner").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("BezeichnungOrdner").Header.Caption = "Ordner"

            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DateinameTyp").Width = 50
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DateinameTyp").Header.Caption = "Typ"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DateinameTyp").DataType.GetType("System.String")
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DateinameTyp").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center

            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DateinameOrig").Hidden = True
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("VerzeichnisOrig").Hidden = True
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("IDDokumenteintrag").Hidden = True
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("IDDokument").Hidden = True
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("IDOrdner").Hidden = True

            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Archivordner").Hidden = True
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DateinameArchiv").Hidden = True
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Notiz").Hidden = True
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Winzip").Hidden = True
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Extern").Hidden = True

            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DokumentGröße").Hidden = True
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Wichtigkeit").Hidden = True
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Winzip").Hidden = True

            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Extern").Hidden = True
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DokumentErstellt").Hidden = True
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("DokumentGeändert").Hidden = True
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("IDObject").Hidden = True
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("ID_guid").Hidden = True

            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Patient").Width = 170
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Patient").Header.Caption = "Klient"
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Patient").DataType.GetType("System.String")
            'Me.gridDocuArchive.DisplayLayout.Bands(0).Columns("Patient").CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left

            ''Me.UGridDokumenteGefunden3.DisplayLayout.Bands(0).HeaderVisible = False
            ''Me.UGridDokumenteGefunden3.DisplayLayout.Bands(0).ColHeadersVisible = False
            ''Me.UGridDokumenteGefunden3.DisplayLayout.Bands(0).Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None

            ''UGridDokumenteGefunden3.DisplayLayout.Bands(0).Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None
            ''UGridDokumenteGefunden3.DisplayLayout.Bands(0).Override.RowAppearance.BorderColor = System.Drawing.Color.White

            Me.gridDocuArchive.DisplayLayout.Appearance.BackColor = Color.White
            Me.gridDocuArchive.DisplayLayout.Appearance.BackColor2 = Color.White
            Me.gridDocuArchive.UseOsThemes = Infragistics.Win.DefaultableBoolean.True
            Me.gridDocuArchive.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.White

        Catch ex As Exception
            Throw New Exception("initGridDokumenteGefunden: " + ex.ToString())
        End Try
    End Sub


    Public Function DateiLöschenSchnell(ByVal IDDokumenteintrag As System.Guid, ByVal physisch As Boolean) As Boolean
        Try
            Dim compPfad As New compSql
            If Not gen.IsNull(IDDokumenteintrag) Then
                Dim comp As New compSql
                Dim r_Dokumente As dsPlanArchive.tblDokumenteSmallRow
                r_Dokumente = comp.LesenDokument_IDDokueintrag(IDDokumenteintrag)
                If Not gen.IsNull(r_Dokumente) Then
                    Dim fileToDelete As String = compPfad.pfadLesen() + "\" + r_Dokumente.Archivordner + "\" + r_Dokumente.DateinameArchiv
                    If physisch Then
                        If System.IO.File.Exists(fileToDelete) Then
                            System.IO.File.Delete(fileToDelete)
                        End If
                    End If
                    If comp.DokumenteneintragLöschen(r_Dokumente.IDDokumenteintrag) Then
                        Me.contOrdnerErgebniss.DeleteDokument(r_Dokumente.IDDokumenteintrag, True, Nothing)
                        Return True
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("DateiLöschenSchnell: " + ex.ToString())
        End Try
    End Function
    Public Function PapierkorbLeeren() As Boolean
        Try
            Dim compPfad As New compSql
            If gen.IsNull(compPfad.pfadLesen()) Then
                MsgBox("Es wurd kein Dokumentenpfad angegeben!", MsgBoxStyle.Information, "Archivsystem")
                Return False
            End If
            If Not System.IO.Directory.Exists(compPfad.pfadLesen()) Then
                MsgBox("Es wurd kein Dokumentenpfad angegeben!", MsgBoxStyle.Information, "Archivsystem")
                Return False
            End If

            If MsgBox("Wollen Sie den Papierkorb wirklich leeren?", MsgBoxStyle.YesNo, "Archivsystem") = MsgBoxResult.Yes Then
                Dim IDordner As New System.Guid
                Dim comp As New compSql
                IDordner = comp.GetIDOrdnerPapierkorb()
                If Not gen.IsNull(IDordner) Then
                    Dim physisch As Boolean = True
                    'If MsgBox("Sollen die Dateien auch physisch aus dem Archiv gelöscht werden?", MsgBoxStyle.YesNo, "Papierkorb leeren ...") = MsgBoxResult.Yes Then
                    '    physisch = True
                    'End If
                    Dim data As New dsPlanArchive
                    data = comp.AlleDateienAusPapierkorbLesen()
                    For Each r As dsPlanArchive.tblDokumentePapierkorbRow In data.tblDokumentePapierkorb
                        Try
                            If Not Me.DateiLöschenSchnell(r.IDDokumenteintrag, physisch) Then
                                Throw New Exception("PapierkorbLeeren: Fehler beim leeren des Papierkorbs!")
                            End If
                        Catch ex As Exception
                            gen.GetEcxeptionArchiv(ex)
                        Finally
                        End Try
                    Next
                    'Me.Show_Tab(0)
                    'Me.DokumentSuchen(False, False)

                    MsgBox("Der Papierkorb wurde geleert! (" + data.tblDokumentePapierkorb.Rows.Count.ToString + " Dokumente)", MsgBoxStyle.Information, "Archivsystem")
                Else
                    MsgBox("Es wurde kein Papierkorb im Archivsystem angelegt!" + vbNewLine +
                            "Bitte legen Sie unter Stammdaten\Ordner einen Papierkorb an!", MsgBoxStyle.Information, "Archivsystem")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("PapierkorbLeeren: " + ex.ToString())
        End Try
    End Function


    Private Sub UltraTabPageControl5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub UltraTabPageControl1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub ArchivDokumentSuchen_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        'Me.ResizeControl(Me.Height, Me.Width)
    End Sub
    Public Sub ResizeControl(ByVal h As Double, ByVal w As Double)
        Dim gen As New GeneralArchiv
        Try
            Me.contSucheInOrdnern.ResizeControl(Me.PanelSucheOrdner.Width, Me.PanelSucheOrdner.Height)
            Me.contOrdnerErgebniss.ResizeControl(Me.PanelOrdnerErgebniss.Width, Me.PanelOrdnerErgebniss.Height)

        Catch ex As Exception
            Throw New Exception("ResizeControl: " + ex.ToString())
        End Try
    End Sub



    Private Sub MItemSpeichernUnterListe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub MItemDokumentLöschenListe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ArchivOrdnerErgebniss_MouseUp()
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.contOrdnerErgebniss.ContextMenuStrip = Me.ContextMenuDokumenteExplorerS
            Me.ContextMenuDokumenteExplorerS.Show()

        Catch ex As Exception
            Throw New Exception("ArchivOrdnerErgebniss_MouseUp: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub ArchivOrdnerErgebniss_Click()
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            'Dim fInfo As New S2ArchivWork.clFileInfo
            'Dim cTag As New S2ArchivWork.clTagSchrankFachOrdner
            'cTag = Me.ArchivOrdnerSuchergebnisse.GetSelTagInfo()
            'If gen.IsNull(cTag) Then Exit Sub
            'If cTag.typ = S2ArchivWork.clTagSchrankFachOrdner.eTyp.typDateiSuchen Then
            '    fInfo = cTag.fileInfo
            '    If Not gen.IsNull(fInfo) Then

            '    End If
            'End If

            'Me.ContextMenuDokumenteExplorerS.Show(Me, Me.acP)

        Catch ex As Exception
            Throw New Exception("ArchivOrdnerErgebniss_Click: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub DateiÖffnenExplorer()
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim cTag As New clTagSchrankFachOrdner
            cTag = Me.contOrdnerErgebniss.GetSelTagInfo
            If gen.IsNull(cTag) Then Exit Sub
            If cTag.typ = clTagSchrankFachOrdner.eTyp.typDateiSuchen Then
                If Not gen.IsNull(cTag.ID) Then
                    If Not gen.IsNull(cTag.ID) Then
                        Me.contOrdnerErgebniss.DokumentÖffnenSpeichern(cTag.ID, "O")
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("DateiÖffnenExplorer: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Function LoadInfoDokument(ByVal IDDokumenteintrag As System.Guid) As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim compPfad As New compSql
            If Not gen.IsNull(IDDokumenteintrag) Then
                Dim comp As New compSql
                Dim r_Dokumenteintrag As dsPlanArchive.tblDokumenteintragRow
                r_Dokumenteintrag = comp.LesenDokumenteintrag(IDDokumenteintrag)
                If Not gen.IsNull(r_Dokumenteintrag) Then
                    Dim r_Dokumente As dsPlanArchive.tblDokumenteSmallRow
                    r_Dokumente = comp.LesenDokument_IDDokueintrag(r_Dokumenteintrag.ID)
                    If Not gen.IsNull(r_Dokumente) Then

                        Dim Info As String = ""
                        Info += "Bezeichnung: " + r_Dokumenteintrag.Bezeichnung + vbNewLine + vbNewLine

                        Info += "ErstelltVon: " + r_Dokumenteintrag.ErstelltVon.ToString + vbNewLine
                        Info += "ErstelltAm: " + r_Dokumenteintrag.ErstelltAm.ToString + vbNewLine + vbNewLine

                        If Not r_Dokumenteintrag.IsGültigVonNull Then
                            Info += "GültigVon: " + r_Dokumenteintrag.GültigVon.ToString + vbNewLine
                        End If
                        If Not r_Dokumenteintrag.IsGültigBisNull Then
                            Info += "GültigBis: " + r_Dokumenteintrag.GültigBis.ToString + vbNewLine
                        End If
                        Info += "Wichtigkeit: " + r_Dokumenteintrag.Wichtigkeit + vbNewLine + vbNewLine

                        Info += "Typ: " + r_Dokumente.DateinameTyp + vbNewLine
                        Info += "Grösse (Byte): " + r_Dokumente.DokumentGröße.ToString + vbNewLine
                        Info += "Dokument wurde erstellt: " + r_Dokumente.DokumentErstellt.ToString + vbNewLine
                        Info += "Winzip: " + r_Dokumente.Winzip.ToString + vbNewLine + vbNewLine

                        Info += "Dateiname Archiv: " + r_Dokumente.DateinameArchiv + vbNewLine
                        Info += "Archivordner: " + r_Dokumente.Archivordner + vbNewLine + vbNewLine

                        Info += "Notiz: " + vbNewLine + r_Dokumenteintrag.Notiz
                        Dim clOb As New compSql()
                        Info += vbNewLine + vbNewLine + clOb.Info_ReadObjekteSuche(IDDokumenteintrag)
                        Dim frm As New frmInfoDoku
                        frm.TextInfoDatei2.Text = Info
                        frm.ShowDialog(Me)

                    Else
                        MsgBox("Es wurde kein Dokuemte gefunden!", MsgBoxStyle.Information, "Archivsystem")
                    End If
                Else
                    MsgBox("Es wurde kein Dokuemte gefunden!", MsgBoxStyle.Information, "Archivsystem")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("LoadInfoDokument: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Private Sub MItemInfoDokumentListe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub MItemWechselnZu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SpecihernToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MtemSpcihernUnterExplorerS.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim cTag As New clTagSchrankFachOrdner
            cTag = Me.contOrdnerErgebniss.GetSelTagInfo
            If gen.IsNull(cTag) Then Exit Sub
            If cTag.typ = clTagSchrankFachOrdner.eTyp.typDateiSuchen Then
                If Not gen.IsNull(cTag.ID) Then
                    If Not gen.IsNull(cTag.ID) Then
                        Me.contOrdnerErgebniss.DokumentÖffnenSpeichern(cTag.ID, "S")
                    End If
                End If
            End If
        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub MtemInfoDateiDokumentS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MtemInfoDateiDokumentS.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim fInfo As New clFileInfo
            Dim cTag As New clTagSchrankFachOrdner
            cTag = Me.contOrdnerErgebniss.GetSelTagInfo()
            If gen.IsNull(cTag) Then Exit Sub
            If cTag.typ = clTagSchrankFachOrdner.eTyp.typDateiSuchen Then
                Me.LoadInfoDokument(cTag.ID)
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MItemVerzeichnisRausspielenBezeichnungS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MItemVerzeichnisRausspielenBezeichnungS.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.contOrdnerErgebniss.VerzeichnisRausspielen(contOrdner.eDateiRausspielenName.Bezeichnung)

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MItemVerzeichnisRausspielenDateinameOriginalS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MItemVerzeichnisRausspielenDateinameOriginalS.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.contOrdnerErgebniss.VerzeichnisRausspielen(contOrdner.eDateiRausspielenName.originalName)

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MItemSpeichernUnterListeS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MItemSpeichernUnterListeS.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            If Not gen.IsNull(Me.gridDocuArchive.ActiveRow) Then
                If Not gen.IsNull(Me.gridDocuArchive.ActiveRow.Cells("IDDokumenteintrag").Value) Then
                    Dim ID_DokuSEARCH As New System.Guid(CStr(Me.gridDocuArchive.ActiveRow.Cells("IDDokumenteintrag").Value))
                    Me.contOrdnerErgebniss.DokumentÖffnenSpeichern(ID_DokuSEARCH, "S")
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MItemInfoDokumentListeS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MItemInfoDokumentListeS.Click
        Dim General As New GeneralArchiv
        Try

            Me.Cursor = Cursors.WaitCursor

            If Not General.IsNull(Me.gridDocuArchive.ActiveRow) Then
                Dim text As String = ""
                If Not General.IsNull(Me.gridDocuArchive.ActiveRow.Cells("IDDokumenteintrag").Value) Then
                    Dim IDDoku As New System.Guid(Me.gridDocuArchive.ActiveRow.Cells("IDDokumenteintrag").Value.ToString)
                    Me.LoadInfoDokument(IDDoku)
                End If
            End If


        Catch ex As Exception
            General.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub PanelOrdnerErgebisse_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PanelOrdnerErgebisse_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub
    Private Sub PanelOrdnerErgebisse_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            'Me.ArchivOrdnerSuchergebnisse.Width = Me.PanelOrdnerErgebisse.Width
            'Me.ArchivOrdnerSuchergebnisse.Height = Me.PanelOrdnerErgebisse.Height

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub ÖffnenLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÖffnenLToolStripMenuItem.Click
        Try
            Me.dokuÖffnenGrid()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        End Try
    End Sub
    Public Sub dokuÖffnenGrid()
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not gen.IsNull(Me.gridDocuArchive.ActiveRow) Then
                If Me.gridDocuArchive.ActiveRow.Cells.Exists("IDDokumenteintrag") Then
                    If Not gen.IsNull(Me.gridDocuArchive.ActiveRow.Cells("IDDokumenteintrag").Value) Then
                        Dim ID_DokuSEARCH As New System.Guid(CStr(Me.gridDocuArchive.ActiveRow.Cells("IDDokumenteintrag").Value))
                        Me.contOrdnerErgebniss.DokumentÖffnenSpeichern(ID_DokuSEARCH, "O")
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("dokuÖffnenGrid: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub ÖffnenEXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÖffnenEXToolStripMenuItem.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.DateiÖffnenExplorer()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub InDenPapierkorbEXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InDenPapierkorbEXToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim IDOrdner As New System.Guid
            IDOrdner = Me.contOrdnerErgebniss.GetSelectedOrd_dokument()
            If gen.IsNull(IDOrdner) Then Exit Sub

            Dim cTag As New clTagSchrankFachOrdner
            cTag = Me.contOrdnerErgebniss.GetSelTagInfo
            If gen.IsNull(cTag) Then Exit Sub
            If cTag.typ = clTagSchrankFachOrdner.eTyp.typDateiSuchen Then
                If Not gen.IsNull(cTag.ID) Then
                    If Not gen.IsNull(cTag.ID) Then
                        Dim clDelete As New cArchive
                        If clDelete.dateiInDenPapierkorbVerschieben(cTag.ID) Then
                            Me.contOrdnerErgebniss.deleteSelectedFile()
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub InDenPapierkorbLIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InDenPapierkorbLIToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If gen.IsNull(Me.gridDocuArchive.ActiveRow.Cells("IDOrdner").Value) Then Exit Sub
            Dim IDOrdner As New System.Guid(Me.gridDocuArchive.ActiveRow.Cells("IDOrdner").Value.ToString)

            If gen.IsNull(IDOrdner) Then Exit Sub

            Me.Cursor = Cursors.WaitCursor
            If Not gen.IsNull(Me.gridDocuArchive.ActiveRow) Then
                Dim IDDokumenteneintrag As New System.Guid(Me.gridDocuArchive.ActiveRow.Cells("IDDokumenteintrag").Value.ToString)
                Dim clDelete As New cArchive
                If clDelete.dateiInDenPapierkorbVerschieben(IDDokumenteneintrag) Then
                    Me.gridDocuArchive.ActiveRow.Delete()
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MItemLöschenOhnePapierkorbExplorerS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MItemLöschenOhnePapierkorbExplorerS.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim IDOrdner As New System.Guid
            IDOrdner = Me.contOrdnerErgebniss.GetSelectedOrd_dokument()
            If gen.IsNull(IDOrdner) Then Exit Sub

            Dim cTag As New clTagSchrankFachOrdner
            cTag = Me.contOrdnerErgebniss.GetSelTagInfo
            If gen.IsNull(cTag) Then Exit Sub
            If cTag.typ = clTagSchrankFachOrdner.eTyp.typDateiSuchen Then
                If Not gen.IsNull(cTag.ID) Then
                    If Not gen.IsNull(cTag.ID) Then
                        Dim clDelete As New cArchive
                        If clDelete.dateiAusArchivLöschen(cTag.ID, True) Then
                            Me.contOrdnerErgebniss.deleteSelectedFile()
                            Me.contOrdnerErgebniss.DeleteDokument(cTag.ID, True, Nothing)
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub MItemDokumentLöschenOhnePapierkorbListeS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MItemDokumentLöschenOhnePapierkorbListeS.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If Not gen.IsNull(Me.gridDocuArchive.ActiveRow) Then
                Dim IDDokument As New System.Guid(Me.gridDocuArchive.ActiveRow.Cells("IDDokumenteintrag").Value.ToString)
                Dim clDelete As New cArchive
                If clDelete.dateiAusArchivLöschen(IDDokument, True) Then
                    Me.gridDocuArchive.ActiveRow.Delete()
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub



    Private Sub DokumentHinzufügenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DokumentHinzufügenToolStripMenuItem.Click
        Dim General As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim IDOrdner As New System.Guid
            IDOrdner = Nothing
            IDOrdner = Me.contOrdnerErgebniss.GetSelectedOrd()
            Me.DokumentHinzufügen(IDOrdner)

        Catch ex As Exception
            General.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub DokumentHinzufügen(ByVal IDOrdner As System.Guid)
        Dim General As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim frm As New frmArchivAbleg
            frm.IDOrdnerToSelect = IDOrdner
            frm.contArchivDokumentAblegen.objects = Me.objects
            'frm.selectOrdner(IDOrdner)
            frm.ShowDialog(Me)

            If frm.contArchivDokumentAblegen.dokumentAbgelegt Then
                If Me.mainWindow.startTyp = contArchivMain.eStart.Search Then
                    Me.DokumentSuchen(False, False, False)
                End If
            End If

        Catch ex As Exception
            Throw New Exception("DokumentHinzufügen: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Exploerer_Click()
        Try
            Me.Cursor = Cursors.WaitCursor

            'If e.Item.Key = "AllgAngaben" Then
            '    Me.ShowTab(0)
            'ElseIf e.Item.Key = "OrdnerAusw" Then
            '    Me.ShowTab(1)
            'ElseIf e.Item.Key = "Schlagwortkatalog" Then
            '    Me.ShowTab(2)
            'ElseIf e.Item.Key = "GefDoku" Then
            '    Me.ShowTab(3)
            'ElseIf e.Item.Key = "NeueSuche" Then
            '    Me.resetForm()
            '    Me.ShowTab(0)

            'End If

        Catch ex As Exception
            Throw New Exception("Exploerer_Click: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DokumentHinzufügenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DokumentHinzufügenToolStripMenuItem1.Click
        Dim General As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim IDOrdner As New System.Guid
            IDOrdner = Nothing
            If Not gen.IsNull(Me.gridDocuArchive.ActiveRow.Cells("IDOrdner").Value) Then
                IDOrdner = New System.Guid(Me.gridDocuArchive.ActiveRow.Cells("IDOrdner").Value.ToString)
            End If
            Me.DokumentHinzufügen(IDOrdner)

        Catch ex As Exception
            General.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub RButtonAlleOrdner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelAnzeigeBaumansicht.Paint

    End Sub

    Private Sub PanelOrdnerErgebniss_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelOrdnerErgebniss.DoubleClick

    End Sub

    Private Sub PanelOrdnerErgebniss_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelOrdnerErgebniss.Paint

    End Sub

    Public Sub showErgebniss_ansicht(ByVal iTab As Integer)
        Try
            Select Case iTab
                Case 0
                    Me.UTabDokumenteGefunden.SelectedTab = Me.UTabDokumenteGefunden.Tabs(0)

                Case 1
                    Me.UTabDokumenteGefunden.SelectedTab = Me.UTabDokumenteGefunden.Tabs(1)

            End Select

        Catch ex As Exception
            Throw New Exception("showErgebniss_ansicht: " + ex.ToString())
        End Try
    End Sub

    Private Sub UDropDownButtonErweiterteSuche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UDropDownButtonErweiterteSuche.Click

    End Sub

    Private Sub UOptionSetAnzeige_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub UComboWichtigkeit_EditorButtonClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles UComboWichtigkeit.EditorButtonClick
        Try
            Select Case e.Button.Key
                Case "Löschen"
                    Me.UComboWichtigkeit.Value = Nothing
            End Select

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub SplitContainer1_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved

    End Sub

    Private Sub UCheckEditorImGesamtarchivSuchen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UCheckEditorImGesamtarchivSuchen.CheckedChanged
        Try
            If Me.UCheckEditorImGesamtarchivSuchen.Focus Then
                If Me.UCheckEditorImGesamtarchivSuchen.Checked = True Then
                    Me.PanelBenutzerauswahl.Visible = True
                    Me.cboSachbearbeiter.Value = Nothing
                Else
                    Me.PanelBenutzerauswahl.Visible = False
                    Me.cboSachbearbeiter.Value = Nothing
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub UCheckTypAnhangPlanungssystem2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UCheckTypAnhangPlanungssystem2.CheckedChanged

    End Sub

    Private Sub UGridSchlagwortkatalog_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles UGridSchlagwortkatalog.CellChange
        Try
            Me.UGridSchlagwortkatalog.UpdateData()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub UGridSchlagwortkatalog_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UGridSchlagwortkatalog.InitializeLayout

    End Sub


    Private Sub PanelErweiterteSuchangaben_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelErweiterteSuchangaben.Paint
        Try

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub


    Private Sub UGridDokumenteGefunden3_BeforeCellActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles gridDocuArchive.BeforeCellActivate
        Try
            e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            'If e.Cell.Column.ToString() = "ProzentsatzBerechnungsbasis" Then
            '    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            'ElseIf e.Cell.Column.ToString() = "Ab" Then
            'End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub UGridDokumenteGefunden3_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridDocuArchive.BeforeRowsDeleted
        Try
            e.DisplayPromptMsg = False

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub UGridDokumenteGefunden3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridDocuArchive.DoubleClick
        Try
            Me.dokuÖffnenGrid()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub UGridDokumenteGefunden3_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridDocuArchive.InitializeLayout
        Try

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub DokumentenbezeichnungÄndernToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DokumentenbezeichnungÄndernToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim IDOrdner As New System.Guid
            IDOrdner = Me.contOrdnerErgebniss.GetSelectedOrd_dokument()
            If gen.IsNull(IDOrdner) Then Exit Sub

            Dim cTag As New clTagSchrankFachOrdner
            cTag = Me.contOrdnerErgebniss.GetSelTagInfo
            If gen.IsNull(cTag) Then Exit Sub
            If cTag.typ = clTagSchrankFachOrdner.eTyp.typDateiSuchen Then
                If Not gen.IsNull(cTag.ID) Then
                    If Not gen.IsNull(cTag.ID) Then
                        Dim frm As New frmDocuEdit()
                        frm.initForm(cTag.ID)
                        frm.ShowDialog()
                        If Not frm.abort Then
                            Me.DokumentSuchen(False, False, False)
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub DokumentenbezeichnungÄndernToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DokumentenbezeichnungÄndernToolStripMenuItem1.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If Not gen.IsNull(Me.gridDocuArchive.ActiveRow) Then
                Dim IDDokument As New System.Guid(Me.gridDocuArchive.ActiveRow.Cells("IDDokumenteintrag").Value.ToString)
                Dim frm As New frmDocuEdit()
                frm.initForm(IDDokument)
                frm.ShowDialog()
                If Not frm.abort Then
                    Me.DokumentSuchen(False, False, False)
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub LayoutmanagerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LayoutmanagerToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            QS2.Desktop.ControlManagment.ControlManagment.openLayoutmanager(Me.gridDocuArchive, Me.gridDocuArchive.Name)

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub LayoutmanagerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LayoutmanagerToolStripMenuItem1.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            QS2.Desktop.ControlManagment.ControlManagment.openLayoutmanager(Me.gridDocuArchive, Me.gridDocuArchive.Name)

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class
