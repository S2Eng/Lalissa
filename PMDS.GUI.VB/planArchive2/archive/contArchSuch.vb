Imports System.IO
Imports Infragistics.Win.UltraWinToolbars
Imports Infragistics.Win.UltraWinGrid
Imports System.Windows.Forms
Imports System.Drawing





Public Class contArchSuch
    Inherits System.Windows.Forms.UserControl

    Private gen As New General
    Private genMain As New General

    Public acP As New System.Drawing.Point

    Public contOrdnerErgebniss As New contOrdner2
    Public contSucheInOrdnern As New contOrdner2

    Public mainWindow As contArchMain

    Private FileInfo As New clFileInfo

    Public tArchObjects As New dbArchiv.archObjectDataTable()

    Public isLoaded As Boolean = False
    Private compDoku1 As New compDoku()


    Public ui1 As New UI

    Public lstColSmallViewGrid As New System.Collections.Generic.List(Of String)
    Public lstColBigViewGridDeaktivate As New System.Collections.Generic.List(Of String)
    Public styleDropDown As Infragistics.Win.UltraWinGrid.ColumnStyle = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
    Public doUI1 As New doUI()

    Public Enum eDoAction
        WebFreigebenAgent = 0
        WebSperrenAgent = 1

        WebFreigebenKunde = 2
        WebSperrenKunde = 3

        selection = 10
        AllSelectedDocusOpenAsOneIntEditor = 11
        getSelectedRows = 12
    End Enum

    Public LayoutName As String = "Documents"
    Public IsInitializedVisible As Boolean = False


    Public colObject As String = "Object"
    Public colIDObject As String = "IDObject"
    Public colContract As String = "Contract"
    Public colIDContract As String = "IDContract"
    Public colInsurance As String = "Insurance"





    Friend WithEvents contMenüTree As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MtemSpcihernUnterExplorerS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MItemLöschenOhnePapierkorbExplorerS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MtemInfoDateiDokumentS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents contMenüGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MItemSpeichernUnterListeS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MItemDokumentLöschenOhnePapierkorbListeS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MItemInfoDokumentListeS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ÖffnenEXToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ÖffnenLToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InDenPapierkorbEXToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InDenPapierkorbLIToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DokumentHinzufügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DokumentHinzufügenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraLabel11 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents cboSachbearbeiter As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UDateAbgelegtBis As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UDateAbgelegtVon As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UDateGültigBis As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UDateGültigVon As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents cboPriorität As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel9 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RButtonOrdnerMitDokumente As System.Windows.Forms.RadioButton
    Friend WithEvents RButtonAlleOrdner As System.Windows.Forms.RadioButton
    Friend WithEvents layUnten As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents UDropDownButtonErweiterteSuche As Infragistics.Win.Misc.UltraDropDownButton
    Friend WithEvents PanelGrid As System.Windows.Forms.Panel
    Friend WithEvents UPopupContErweitSuche As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents layErwSuche As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents lasySucheSchlagwortkatalog As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents laySchnelsuche As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents laySucheInOrdner As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents PanelErweiterteSuchangaben As System.Windows.Forms.Panel
    Friend WithEvents PanelOrdnerErgebniss As System.Windows.Forms.Panel
    Friend WithEvents PanelSucheOrdner As System.Windows.Forms.Panel
    Friend WithEvents UltraGroupBoxSchlagwörter As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBoxSucheInOrdnern As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents laySUcheInOrdner2 As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents UltraGroupBoxSucheInOrdner As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents layErwSuchangaben As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents lasySucheSchlagwortkatalog2 As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents UltraGroupBox1 As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents PanelSucheSchlagwortkatalogOrdner As System.Windows.Forms.Panel
    Friend WithEvents PanelUnten As System.Windows.Forms.Panel
    Public WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents UCheckEditorImGesamtarchivSuchen As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Public WithEvents PanelBenutzerauswahl As System.Windows.Forms.Panel
    Public WithEvents gridSchlagwortkatalog As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gridDocus As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents DbArchiv2 As dbArchiv
    Friend WithEvents DsDokuSearch1 As dsDokuSearch
    Friend WithEvents DsAuswahllisten1 As dsAuswahllisten
    Friend WithEvents ContextMenuStripExportOrdner As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GruppierungToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WechselnZuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents InNeuemTabÖffnenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents WechselnZuToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InNeuemTabÖffnenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DateiÖffnenMitInternemEditorGridToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DateiÖffnenMitInternemEditorTreeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageListSmall As System.Windows.Forms.ImageList
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AusgewählteDokumenteFürDasWebFreigebenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AusgewählteDokumenteFürDasWebSperrenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AlleAuswählenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeineAuswählenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PanelEditorToWork As System.Windows.Forms.Panel
    Friend WithEvents TextControlToWork As TXTextControl.TextControl
    Friend WithEvents AlleAusgewähltenInternenDokumenteAlsEinDokumentÖffnenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItemSpacePrint As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DruckenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ToolStripMenuItem14 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AusgewählteDokumenteFürDenKundenImWebFreigebenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AusgewählteDokumenteFürDenKundenImWebSperrenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LayoutManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DokumentEditierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DokumentEditierenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrdnerMitDokumentenExportierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem




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
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("archDoku", -1)
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Bezeichnung", -1, Nothing, 1, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, False)
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Notiz")
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GültigVon")
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GültigBis")
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Wichtigkeit")
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Größe")
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AbgelegtVon")
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("AbgelegtAm", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Descending, False)
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Winzip")
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Archivordner")
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DateinameArchiv")
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DateinameTyp")
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Ordner")
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("OrdnerExtern")
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDSystemordner")
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOrdner")
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDDoku")
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("dokuOrig")
        Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("RechNr")
        Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDActivity")
        Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("db")
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDStatus")
        Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDTyp", -1, 159556169)
        Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("anzObject")
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("intReleased", -1, 176391470)
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("binIntern", -1, 176391938)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Object", 0)
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Contract", 1)
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDObject", 2)
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDContract", 3)
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Insurance", 4)
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueList1 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(176391470)
        Dim ValueList2 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(176391938)
        Dim ValueList3 As Infragistics.Win.ValueList = New Infragistics.Win.ValueList(159556169)
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridBagConstraint4 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridBagConstraint3 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("SelListHelper", -1)
        Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnInt")
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnStr")
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRessource")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn80 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Auswahl", 0)
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
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridBagConstraint5 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem10 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem11 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem12 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridBagConstraint6 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.UltraTabPageControl4 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.PanelGrid = New System.Windows.Forms.Panel()
        Me.gridDocus = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.contMenüGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DokumentHinzufügenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÖffnenLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateiÖffnenMitInternemEditorGridToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlleAusgewähltenInternenDokumenteAlsEinDokumentÖffnenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripSeparator()
        Me.MItemSpeichernUnterListeS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSpacePrint = New System.Windows.Forms.ToolStripSeparator()
        Me.DruckenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.AusgewählteDokumenteFürDasWebFreigebenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AusgewählteDokumenteFürDasWebSperrenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripSeparator()
        Me.AusgewählteDokumenteFürDenKundenImWebFreigebenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AusgewählteDokumenteFürDenKundenImWebSperrenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripSeparator()
        Me.InDenPapierkorbLIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MItemDokumentLöschenOhnePapierkorbListeS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.DokumentEditierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MItemInfoDokumentListeS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.AlleAuswählenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.KeineAuswählenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripSeparator()
        Me.WechselnZuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InNeuemTabÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.FilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GruppierungToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LayoutManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DsDokuSearch1 = New PMDS.GUI.VB.dsDokuSearch()
        Me.UltraTabPageControl6 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.PanelOrdnerErgebniss = New System.Windows.Forms.Panel()
        Me.ImageListSmall = New System.Windows.Forms.ImageList(Me.components)
        Me.UltraGroupBoxSucheInOrdnern = New Infragistics.Win.Misc.UltraGroupBox()
        Me.PanelSucheOrdner = New System.Windows.Forms.Panel()
        Me.UDropDownButtonErweiterteSuche = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.UDateAbgelegtBis = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UDateAbgelegtVon = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel11 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraGroupBoxSchlagwörter = New Infragistics.Win.Misc.UltraGroupBox()
        Me.gridSchlagwortkatalog = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsAuswahllisten1 = New PMDS.GUI.VB.dsAuswahllisten()
        Me.PanelErweiterteSuchangaben = New System.Windows.Forms.Panel()
        Me.UltraGroupBoxSucheInOrdner = New Infragistics.Win.Misc.UltraGroupBox()
        Me.UDateGültigVon = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.cboPriorität = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.PanelEditorToWork = New System.Windows.Forms.Panel()
        Dim currentCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        Me.TextControlToWork = New TXTextControl.TextControl()
        System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo
        Me.PanelBenutzerauswahl = New System.Windows.Forms.Panel()
        Me.cboSachbearbeiter = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UCheckEditorImGesamtarchivSuchen = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.UltraGroupBox1 = New Infragistics.Win.Misc.UltraGroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RButtonAlleOrdner = New System.Windows.Forms.RadioButton()
        Me.RButtonOrdnerMitDokumente = New System.Windows.Forms.RadioButton()
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel()
        Me.UDateGültigBis = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel9 = New Infragistics.Win.Misc.UltraLabel()
        Me.UTabDokumenteGefunden = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage2 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me.contMenüTree = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DokumentHinzufügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÖffnenEXToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DateiÖffnenMitInternemEditorTreeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripSeparator()
        Me.MtemSpcihernUnterExplorerS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.InDenPapierkorbEXToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MItemLöschenOhnePapierkorbExplorerS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DokumentEditierenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MtemInfoDateiDokumentS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator()
        Me.WechselnZuToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.InNeuemTabÖffnenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.ContextMenuStripExportOrdner = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.OrdnerMitDokumentenExportierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.DbArchiv2 = New PMDS.GUI.VB.dbArchiv()
        Me.UltraTabPageControl4.SuspendLayout()
        Me.PanelGrid.SuspendLayout()
        CType(Me.gridDocus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.contMenüGrid.SuspendLayout()
        CType(Me.DsDokuSearch1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabPageControl6.SuspendLayout()
        CType(Me.UltraGroupBoxSucheInOrdnern, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBoxSucheInOrdnern.SuspendLayout()
        Me.PanelSucheOrdner.SuspendLayout()
        CType(Me.UDateAbgelegtBis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDateAbgelegtVon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBoxSchlagwörter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBoxSchlagwörter.SuspendLayout()
        CType(Me.gridSchlagwortkatalog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAuswahllisten1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelErweiterteSuchangaben.SuspendLayout()
        CType(Me.UltraGroupBoxSucheInOrdner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBoxSucheInOrdner.SuspendLayout()
        CType(Me.UDateGültigVon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPriorität, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBenutzerauswahl.SuspendLayout()
        CType(Me.cboSachbearbeiter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UCheckEditorImGesamtarchivSuchen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.UDateGültigBis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UTabDokumenteGefunden, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UTabDokumenteGefunden.SuspendLayout()
        Me.contMenüTree.SuspendLayout()
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
        Me.ContextMenuStripExportOrdner.SuspendLayout()
        CType(Me.DbArchiv2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraTabPageControl4
        '
        Me.UltraTabPageControl4.Controls.Add(Me.PanelGrid)
        Me.UltraTabPageControl4.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabPageControl4.Name = "UltraTabPageControl4"
        Me.UltraTabPageControl4.Size = New System.Drawing.Size(514, 325)
        '
        'PanelGrid
        '
        Me.PanelGrid.BackColor = System.Drawing.Color.White
        Me.PanelGrid.Controls.Add(Me.gridDocus)
        Me.PanelGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelGrid.Location = New System.Drawing.Point(0, 0)
        Me.PanelGrid.Name = "PanelGrid"
        Me.PanelGrid.Size = New System.Drawing.Size(514, 325)
        Me.PanelGrid.TabIndex = 442
        '
        'gridDocus
        '
        Me.gridDocus.ContextMenuStrip = Me.contMenüGrid
        Me.gridDocus.DataMember = "archDoku"
        Me.gridDocus.DataSource = Me.DsDokuSearch1
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BackColor2 = System.Drawing.Color.White
        Me.gridDocus.DisplayLayout.Appearance = Appearance1
        UltraGridColumn41.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn41.Header.Caption = "Dokument"
        UltraGridColumn41.Header.VisiblePosition = 3
        UltraGridColumn41.Width = 289
        UltraGridColumn42.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn42.Header.VisiblePosition = 4
        UltraGridColumn42.Hidden = True
        UltraGridColumn43.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn43.Header.Caption = "Gültig von"
        UltraGridColumn43.Header.VisiblePosition = 7
        UltraGridColumn43.Width = 81
        UltraGridColumn44.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn44.Header.Caption = "Gültig bis"
        UltraGridColumn44.Header.VisiblePosition = 8
        UltraGridColumn45.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn45.Header.VisiblePosition = 6
        UltraGridColumn45.Width = 85
        UltraGridColumn46.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn46.Header.VisiblePosition = 10
        UltraGridColumn46.Hidden = True
        UltraGridColumn47.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn47.Header.Caption = "Abgelegt von"
        UltraGridColumn47.Header.VisiblePosition = 26
        UltraGridColumn48.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn48.Header.Caption = "Abgelegt am"
        UltraGridColumn48.Header.VisiblePosition = 2
        UltraGridColumn48.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DateTime
        UltraGridColumn48.Width = 115
        UltraGridColumn49.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn49.Header.VisiblePosition = 13
        UltraGridColumn49.Hidden = True
        UltraGridColumn50.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn50.Header.VisiblePosition = 14
        UltraGridColumn50.Hidden = True
        UltraGridColumn51.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn51.Header.VisiblePosition = 15
        UltraGridColumn51.Hidden = True
        UltraGridColumn52.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn52.Header.Caption = "Datei-Typ"
        UltraGridColumn52.Header.VisiblePosition = 25
        UltraGridColumn53.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn53.Header.VisiblePosition = 5
        UltraGridColumn53.Width = 159
        UltraGridColumn54.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn54.Header.Caption = "Ext. Ordner"
        UltraGridColumn54.Header.VisiblePosition = 24
        UltraGridColumn55.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn55.Header.VisiblePosition = 16
        UltraGridColumn55.Hidden = True
        UltraGridColumn56.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn56.Header.VisiblePosition = 17
        UltraGridColumn56.Hidden = True
        UltraGridColumn57.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn57.Header.VisiblePosition = 19
        UltraGridColumn57.Hidden = True
        UltraGridColumn58.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn58.Header.VisiblePosition = 18
        UltraGridColumn58.Hidden = True
        UltraGridColumn59.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn59.Header.VisiblePosition = 20
        UltraGridColumn59.Hidden = True
        UltraGridColumn60.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn60.Header.VisiblePosition = 21
        UltraGridColumn60.Hidden = True
        UltraGridColumn61.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn61.Header.VisiblePosition = 22
        UltraGridColumn61.Hidden = True
        UltraGridColumn62.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn62.Header.Caption = "Status"
        UltraGridColumn62.Header.VisiblePosition = 23
        UltraGridColumn62.Width = 131
        UltraGridColumn63.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn63.Header.Caption = "Typ"
        UltraGridColumn63.Header.VisiblePosition = 1
        UltraGridColumn63.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn63.Width = 44
        UltraGridColumn64.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn64.Header.Caption = "Anz. Beziehungen"
        UltraGridColumn64.Header.VisiblePosition = 27
        UltraGridColumn66.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn66.Header.Caption = "Web"
        UltraGridColumn66.Header.VisiblePosition = 0
        UltraGridColumn66.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn66.Width = 44
        UltraGridColumn67.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Append
        UltraGridColumn67.Header.Caption = "Internes Dokument"
        UltraGridColumn67.Header.ToolTipText = "Interne Dokumente können editiert werden"
        UltraGridColumn67.Header.VisiblePosition = 28
        UltraGridColumn67.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList
        UltraGridColumn67.Width = 105
        UltraGridColumn1.Header.VisiblePosition = 9
        UltraGridColumn1.Width = 218
        UltraGridColumn2.Header.VisiblePosition = 11
        UltraGridColumn2.Width = 219
        UltraGridColumn3.DataType = GetType(Object)
        UltraGridColumn3.Header.VisiblePosition = 29
        UltraGridColumn3.Hidden = True
        UltraGridColumn4.DataType = GetType(Object)
        UltraGridColumn4.Header.VisiblePosition = 30
        UltraGridColumn4.Hidden = True
        UltraGridColumn5.Header.Caption = "Versicherung"
        UltraGridColumn5.Header.VisiblePosition = 12
        UltraGridColumn5.Width = 220
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn66, UltraGridColumn67, UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5})
        Me.gridDocus.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridDocus.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridDocus.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance2.BackColor = System.Drawing.Color.White
        Me.gridDocus.DisplayLayout.GroupByBox.Appearance = Appearance2
        Me.gridDocus.DisplayLayout.GroupByBox.Prompt = "Ziehen Sie eine Spalte herein welche Sie gruppieren möchten."
        Appearance3.BackColor = System.Drawing.Color.White
        Me.gridDocus.DisplayLayout.GroupByBox.PromptAppearance = Appearance3
        Appearance4.BackColor = System.Drawing.Color.DarkGray
        Appearance4.BackColor2 = System.Drawing.Color.DarkGray
        Appearance4.ForeColor = System.Drawing.Color.White
        Me.gridDocus.DisplayLayout.Override.ActiveRowAppearance = Appearance4
        Me.gridDocus.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        Me.gridDocus.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridDocus.DisplayLayout.Override.RowSpacingAfter = 2
        Me.gridDocus.DisplayLayout.Override.RowSpacingBefore = 0
        Appearance5.BackColor = System.Drawing.Color.DarkGray
        Appearance5.BackColor2 = System.Drawing.Color.DarkGray
        Appearance5.ForeColor = System.Drawing.Color.White
        Me.gridDocus.DisplayLayout.Override.SelectedRowAppearance = Appearance5
        ValueList1.Key = "intReleased"
        ValueList2.Key = "binIntern"
        ValueList3.Key = "IDTyp"
        Me.gridDocus.DisplayLayout.ValueLists.AddRange(New Infragistics.Win.ValueList() {ValueList1, ValueList2, ValueList3})
        Me.gridDocus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDocus.Location = New System.Drawing.Point(0, 0)
        Me.gridDocus.Name = "gridDocus"
        Me.gridDocus.Size = New System.Drawing.Size(514, 325)
        Me.gridDocus.TabIndex = 444
        '
        'contMenüGrid
        '
        Me.contMenüGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DokumentHinzufügenToolStripMenuItem1, Me.ÖffnenLToolStripMenuItem, Me.DateiÖffnenMitInternemEditorGridToolStripMenuItem1, Me.AlleAusgewähltenInternenDokumenteAlsEinDokumentÖffnenToolStripMenuItem1, Me.ToolStripMenuItem13, Me.MItemSpeichernUnterListeS, Me.ToolStripMenuItemSpacePrint, Me.DruckenToolStripMenuItem, Me.ToolStripMenuItem5, Me.AusgewählteDokumenteFürDasWebFreigebenToolStripMenuItem1, Me.AusgewählteDokumenteFürDasWebSperrenToolStripMenuItem1, Me.ToolStripMenuItem14, Me.AusgewählteDokumenteFürDenKundenImWebFreigebenToolStripMenuItem, Me.AusgewählteDokumenteFürDenKundenImWebSperrenToolStripMenuItem, Me.ToolStripMenuItem10, Me.InDenPapierkorbLIToolStripMenuItem, Me.MItemDokumentLöschenOhnePapierkorbListeS, Me.ToolStripMenuItem3, Me.DokumentEditierenToolStripMenuItem, Me.MItemInfoDokumentListeS, Me.ToolStripMenuItem8, Me.NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem1, Me.ToolStripMenuItem4, Me.AlleAuswählenToolStripMenuItem, Me.KeineAuswählenToolStripMenuItem, Me.ToolStripMenuItem11, Me.WechselnZuToolStripMenuItem, Me.InNeuemTabÖffnenToolStripMenuItem, Me.ToolStripMenuItem6, Me.FilterToolStripMenuItem, Me.GruppierungToolStripMenuItem, Me.LayoutManagerToolStripMenuItem})
        Me.contMenüGrid.Name = "ContextMenuDokumenteExplorerS"
        Me.contMenüGrid.Size = New System.Drawing.Size(416, 548)
        '
        'DokumentHinzufügenToolStripMenuItem1
        '
        Me.DokumentHinzufügenToolStripMenuItem1.Name = "DokumentHinzufügenToolStripMenuItem1"
        Me.DokumentHinzufügenToolStripMenuItem1.Size = New System.Drawing.Size(415, 22)
        Me.DokumentHinzufügenToolStripMenuItem1.Tag = "ResID.AddDocument"
        Me.DokumentHinzufügenToolStripMenuItem1.Text = "Dokument hinzufügen"
        Me.DokumentHinzufügenToolStripMenuItem1.Visible = False
        '
        'ÖffnenLToolStripMenuItem
        '
        Me.ÖffnenLToolStripMenuItem.Name = "ÖffnenLToolStripMenuItem"
        Me.ÖffnenLToolStripMenuItem.Size = New System.Drawing.Size(415, 22)
        Me.ÖffnenLToolStripMenuItem.Tag = "ResID.OpenFile"
        Me.ÖffnenLToolStripMenuItem.Text = "Datei öffnen"
        '
        'DateiÖffnenMitInternemEditorGridToolStripMenuItem1
        '
        Me.DateiÖffnenMitInternemEditorGridToolStripMenuItem1.Name = "DateiÖffnenMitInternemEditorGridToolStripMenuItem1"
        Me.DateiÖffnenMitInternemEditorGridToolStripMenuItem1.Size = New System.Drawing.Size(415, 22)
        Me.DateiÖffnenMitInternemEditorGridToolStripMenuItem1.Tag = "ResID.OpenFileInternEditor"
        Me.DateiÖffnenMitInternemEditorGridToolStripMenuItem1.Text = "Datei öffnen (Mit internen Editor)"
        '
        'AlleAusgewähltenInternenDokumenteAlsEinDokumentÖffnenToolStripMenuItem1
        '
        Me.AlleAusgewähltenInternenDokumenteAlsEinDokumentÖffnenToolStripMenuItem1.Name = "AlleAusgewähltenInternenDokumenteAlsEinDokumentÖffnenToolStripMenuItem1"
        Me.AlleAusgewähltenInternenDokumenteAlsEinDokumentÖffnenToolStripMenuItem1.Size = New System.Drawing.Size(415, 22)
        Me.AlleAusgewähltenInternenDokumenteAlsEinDokumentÖffnenToolStripMenuItem1.Tag = "ResID.AllSelectedInternalDocumentsOpenAsOneDocument"
        Me.AlleAusgewähltenInternenDokumenteAlsEinDokumentÖffnenToolStripMenuItem1.Text = "Alle ausgewählten internen Dokumente als ein Dokument öffnen"
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(412, 6)
        '
        'MItemSpeichernUnterListeS
        '
        Me.MItemSpeichernUnterListeS.Name = "MItemSpeichernUnterListeS"
        Me.MItemSpeichernUnterListeS.Size = New System.Drawing.Size(415, 22)
        Me.MItemSpeichernUnterListeS.Tag = "ResID.SaveFileAs"
        Me.MItemSpeichernUnterListeS.Text = "Datei speichern unter"
        '
        'ToolStripMenuItemSpacePrint
        '
        Me.ToolStripMenuItemSpacePrint.Name = "ToolStripMenuItemSpacePrint"
        Me.ToolStripMenuItemSpacePrint.Size = New System.Drawing.Size(412, 6)
        '
        'DruckenToolStripMenuItem
        '
        Me.DruckenToolStripMenuItem.Name = "DruckenToolStripMenuItem"
        Me.DruckenToolStripMenuItem.Size = New System.Drawing.Size(415, 22)
        Me.DruckenToolStripMenuItem.Tag = "ResID.Print"
        Me.DruckenToolStripMenuItem.Text = "Drucken"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(412, 6)
        '
        'AusgewählteDokumenteFürDasWebFreigebenToolStripMenuItem1
        '
        Me.AusgewählteDokumenteFürDasWebFreigebenToolStripMenuItem1.Name = "AusgewählteDokumenteFürDasWebFreigebenToolStripMenuItem1"
        Me.AusgewählteDokumenteFürDasWebFreigebenToolStripMenuItem1.Size = New System.Drawing.Size(415, 22)
        Me.AusgewählteDokumenteFürDasWebFreigebenToolStripMenuItem1.Tag = "ResID.ReleaseAllSelectedDocumentsForTheWeb"
        Me.AusgewählteDokumenteFürDasWebFreigebenToolStripMenuItem1.Text = "Ausgewählte Dokumente für die Vermittler im Web freigeben"
        '
        'AusgewählteDokumenteFürDasWebSperrenToolStripMenuItem1
        '
        Me.AusgewählteDokumenteFürDasWebSperrenToolStripMenuItem1.Name = "AusgewählteDokumenteFürDasWebSperrenToolStripMenuItem1"
        Me.AusgewählteDokumenteFürDasWebSperrenToolStripMenuItem1.Size = New System.Drawing.Size(415, 22)
        Me.AusgewählteDokumenteFürDasWebSperrenToolStripMenuItem1.Tag = "ResID.BlockAllSelectedDocumentsForTheWeb"
        Me.AusgewählteDokumenteFürDasWebSperrenToolStripMenuItem1.Text = "Ausgewählte Dokumente für die Vermittler im Web sperren"
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        Me.ToolStripMenuItem14.Size = New System.Drawing.Size(412, 6)
        '
        'AusgewählteDokumenteFürDenKundenImWebFreigebenToolStripMenuItem
        '
        Me.AusgewählteDokumenteFürDenKundenImWebFreigebenToolStripMenuItem.Name = "AusgewählteDokumenteFürDenKundenImWebFreigebenToolStripMenuItem"
        Me.AusgewählteDokumenteFürDenKundenImWebFreigebenToolStripMenuItem.Size = New System.Drawing.Size(415, 22)
        Me.AusgewählteDokumenteFürDenKundenImWebFreigebenToolStripMenuItem.Tag = "ResID.ReleaseAllSelectedDocumentsForCustomerInTheWeb"
        Me.AusgewählteDokumenteFürDenKundenImWebFreigebenToolStripMenuItem.Text = "Ausgewählte Dokumente für die Kunden im Web freigeben"
        '
        'AusgewählteDokumenteFürDenKundenImWebSperrenToolStripMenuItem
        '
        Me.AusgewählteDokumenteFürDenKundenImWebSperrenToolStripMenuItem.Name = "AusgewählteDokumenteFürDenKundenImWebSperrenToolStripMenuItem"
        Me.AusgewählteDokumenteFürDenKundenImWebSperrenToolStripMenuItem.Size = New System.Drawing.Size(415, 22)
        Me.AusgewählteDokumenteFürDenKundenImWebSperrenToolStripMenuItem.Tag = "ResID.BlockAllSelectedDocumentsForTheCustomersInTheWeb"
        Me.AusgewählteDokumenteFürDenKundenImWebSperrenToolStripMenuItem.Text = "Ausgewählte Dokumente für die Kunden im Web sperren"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(412, 6)
        '
        'InDenPapierkorbLIToolStripMenuItem
        '
        Me.InDenPapierkorbLIToolStripMenuItem.Name = "InDenPapierkorbLIToolStripMenuItem"
        Me.InDenPapierkorbLIToolStripMenuItem.Size = New System.Drawing.Size(415, 22)
        Me.InDenPapierkorbLIToolStripMenuItem.Tag = "ResID.MoveToTrash"
        Me.InDenPapierkorbLIToolStripMenuItem.Text = "In den Papierkorb verschieben"
        '
        'MItemDokumentLöschenOhnePapierkorbListeS
        '
        Me.MItemDokumentLöschenOhnePapierkorbListeS.Name = "MItemDokumentLöschenOhnePapierkorbListeS"
        Me.MItemDokumentLöschenOhnePapierkorbListeS.Size = New System.Drawing.Size(415, 22)
        Me.MItemDokumentLöschenOhnePapierkorbListeS.Tag = "ResID.Delete"
        Me.MItemDokumentLöschenOhnePapierkorbListeS.Text = "Löschen"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(412, 6)
        '
        'DokumentEditierenToolStripMenuItem
        '
        Me.DokumentEditierenToolStripMenuItem.Name = "DokumentEditierenToolStripMenuItem"
        Me.DokumentEditierenToolStripMenuItem.Size = New System.Drawing.Size(415, 22)
        Me.DokumentEditierenToolStripMenuItem.Tag = "ResID.EditDocument"
        Me.DokumentEditierenToolStripMenuItem.Text = "Dokument editieren"
        '
        'MItemInfoDokumentListeS
        '
        Me.MItemInfoDokumentListeS.Name = "MItemInfoDokumentListeS"
        Me.MItemInfoDokumentListeS.Size = New System.Drawing.Size(415, 22)
        Me.MItemInfoDokumentListeS.Tag = "ResID.InfoDocument"
        Me.MItemInfoDokumentListeS.Text = "Info Dokument"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(412, 6)
        '
        'NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem1
        '
        Me.NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem1.Name = "NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem1"
        Me.NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem1.Size = New System.Drawing.Size(415, 22)
        Me.NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem1.Tag = "ResID.NewPlanningResourcesWit DocumentAsAppendix"
        Me.NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem1.Text = "Neuen Planungseintrag erstellen (mit Dokument als Anhang)"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(412, 6)
        '
        'AlleAuswählenToolStripMenuItem
        '
        Me.AlleAuswählenToolStripMenuItem.Name = "AlleAuswählenToolStripMenuItem"
        Me.AlleAuswählenToolStripMenuItem.Size = New System.Drawing.Size(415, 22)
        Me.AlleAuswählenToolStripMenuItem.Tag = "ResID.SelectAll"
        Me.AlleAuswählenToolStripMenuItem.Text = "Alle auswählen"
        '
        'KeineAuswählenToolStripMenuItem
        '
        Me.KeineAuswählenToolStripMenuItem.Name = "KeineAuswählenToolStripMenuItem"
        Me.KeineAuswählenToolStripMenuItem.Size = New System.Drawing.Size(415, 22)
        Me.KeineAuswählenToolStripMenuItem.Tag = "ResID.SelectNone"
        Me.KeineAuswählenToolStripMenuItem.Text = "Keine auswählen"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(412, 6)
        '
        'WechselnZuToolStripMenuItem
        '
        Me.WechselnZuToolStripMenuItem.Name = "WechselnZuToolStripMenuItem"
        Me.WechselnZuToolStripMenuItem.Size = New System.Drawing.Size(415, 22)
        Me.WechselnZuToolStripMenuItem.Tag = "ResID.SwitchTo"
        Me.WechselnZuToolStripMenuItem.Text = "Wechseln zu"
        '
        'InNeuemTabÖffnenToolStripMenuItem
        '
        Me.InNeuemTabÖffnenToolStripMenuItem.Name = "InNeuemTabÖffnenToolStripMenuItem"
        Me.InNeuemTabÖffnenToolStripMenuItem.Size = New System.Drawing.Size(415, 22)
        Me.InNeuemTabÖffnenToolStripMenuItem.Tag = "ResID.OpenInANewTab"
        Me.InNeuemTabÖffnenToolStripMenuItem.Text = "In neuem Tab öffnen"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(412, 6)
        '
        'FilterToolStripMenuItem
        '
        Me.FilterToolStripMenuItem.CheckOnClick = True
        Me.FilterToolStripMenuItem.Name = "FilterToolStripMenuItem"
        Me.FilterToolStripMenuItem.Size = New System.Drawing.Size(415, 22)
        Me.FilterToolStripMenuItem.Tag = "ResID.Filter"
        Me.FilterToolStripMenuItem.Text = "Filter"
        '
        'GruppierungToolStripMenuItem
        '
        Me.GruppierungToolStripMenuItem.CheckOnClick = True
        Me.GruppierungToolStripMenuItem.Name = "GruppierungToolStripMenuItem"
        Me.GruppierungToolStripMenuItem.Size = New System.Drawing.Size(415, 22)
        Me.GruppierungToolStripMenuItem.Tag = "ResID.Grouping"
        Me.GruppierungToolStripMenuItem.Text = "Gruppierung"
        '
        'LayoutManagerToolStripMenuItem
        '
        Me.LayoutManagerToolStripMenuItem.Name = "LayoutManagerToolStripMenuItem"
        Me.LayoutManagerToolStripMenuItem.Size = New System.Drawing.Size(415, 22)
        Me.LayoutManagerToolStripMenuItem.Tag = "ResID.LayoutManager"
        Me.LayoutManagerToolStripMenuItem.Text = "Layout-Manager"
        '
        'DsDokuSearch1
        '
        Me.DsDokuSearch1.DataSetName = "dsDokuSearch"
        Me.DsDokuSearch1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UltraTabPageControl6
        '
        Me.UltraTabPageControl6.Controls.Add(Me.PanelOrdnerErgebniss)
        Me.UltraTabPageControl6.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl6.Name = "UltraTabPageControl6"
        Me.UltraTabPageControl6.Size = New System.Drawing.Size(514, 325)
        '
        'PanelOrdnerErgebniss
        '
        Me.PanelOrdnerErgebniss.BackColor = System.Drawing.Color.White
        Me.PanelOrdnerErgebniss.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelOrdnerErgebniss.Location = New System.Drawing.Point(0, 0)
        Me.PanelOrdnerErgebniss.Name = "PanelOrdnerErgebniss"
        Me.PanelOrdnerErgebniss.Size = New System.Drawing.Size(514, 325)
        Me.PanelOrdnerErgebniss.TabIndex = 0
        '
        'ImageListSmall
        '
        Me.ImageListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageListSmall.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageListSmall.TransparentColor = System.Drawing.Color.Transparent
        '
        'UltraGroupBoxSucheInOrdnern
        '
        Appearance6.BackColor = System.Drawing.Color.Transparent
        Me.UltraGroupBoxSucheInOrdnern.Appearance = Appearance6
        Me.UltraGroupBoxSucheInOrdnern.Controls.Add(Me.PanelSucheOrdner)
        GridBagConstraint4.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint4.Insets.Bottom = 5
        GridBagConstraint4.Insets.Right = 5
        GridBagConstraint4.Insets.Top = 5
        GridBagConstraint4.OriginY = 1
        Me.lasySucheSchlagwortkatalog.SetGridBagConstraint(Me.UltraGroupBoxSucheInOrdnern, GridBagConstraint4)
        Me.UltraGroupBoxSucheInOrdnern.Location = New System.Drawing.Point(0, 189)
        Me.UltraGroupBoxSucheInOrdnern.Name = "UltraGroupBoxSucheInOrdnern"
        Me.lasySucheSchlagwortkatalog.SetPreferredSize(Me.UltraGroupBoxSucheInOrdnern, New System.Drawing.Size(232, 215))
        Me.UltraGroupBoxSucheInOrdnern.Size = New System.Drawing.Size(254, 141)
        Me.UltraGroupBoxSucheInOrdnern.TabIndex = 461
        Me.UltraGroupBoxSucheInOrdnern.Tag = "ResID.SearchInFolders"
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
        Me.PanelSucheOrdner.Size = New System.Drawing.Size(238, 112)
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
        'UDateAbgelegtBis
        '
        Appearance21.BackColor = System.Drawing.Color.White
        Me.UDateAbgelegtBis.Appearance = Appearance21
        Me.UDateAbgelegtBis.BackColor = System.Drawing.Color.White
        Me.UDateAbgelegtBis.DateTime = New Date(2005, 9, 2, 0, 0, 0, 0)
        Me.UDateAbgelegtBis.Location = New System.Drawing.Point(223, 38)
        Me.UDateAbgelegtBis.Name = "UDateAbgelegtBis"
        Me.UDateAbgelegtBis.Size = New System.Drawing.Size(92, 21)
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
        Me.UDateAbgelegtVon.Size = New System.Drawing.Size(92, 21)
        Me.UDateAbgelegtVon.TabIndex = 0
        Me.UDateAbgelegtVon.Value = New Date(2005, 9, 2, 0, 0, 0, 0)
        '
        'UltraLabel7
        '
        Appearance23.BackColor = System.Drawing.Color.Transparent
        Appearance23.TextHAlignAsString = "Center"
        Me.UltraLabel7.Appearance = Appearance23
        Me.UltraLabel7.Location = New System.Drawing.Point(188, 40)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(29, 16)
        Me.UltraLabel7.TabIndex = 328
        Me.UltraLabel7.Tag = "ResID.To"
        Me.UltraLabel7.Text = "bis"
        '
        'UltraLabel11
        '
        Appearance24.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel11.Appearance = Appearance24
        Me.UltraLabel11.Location = New System.Drawing.Point(9, 40)
        Me.UltraLabel11.Name = "UltraLabel11"
        Me.UltraLabel11.Size = New System.Drawing.Size(93, 16)
        Me.UltraLabel11.TabIndex = 386
        Me.UltraLabel11.Tag = "ResID.FiledFrom"
        Me.UltraLabel11.Text = "Abgelegt von"
        '
        'UltraGroupBoxSchlagwörter
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.BorderColor = System.Drawing.Color.Black
        Me.UltraGroupBoxSchlagwörter.Appearance = Appearance7
        Me.UltraGroupBoxSchlagwörter.Controls.Add(Me.gridSchlagwortkatalog)
        GridBagConstraint3.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint3.Insets.Bottom = 5
        GridBagConstraint3.Insets.Right = 5
        GridBagConstraint3.Insets.Top = 5
        Me.lasySucheSchlagwortkatalog.SetGridBagConstraint(Me.UltraGroupBoxSchlagwörter, GridBagConstraint3)
        Me.UltraGroupBoxSchlagwörter.Location = New System.Drawing.Point(0, 5)
        Me.UltraGroupBoxSchlagwörter.Name = "UltraGroupBoxSchlagwörter"
        Me.lasySucheSchlagwortkatalog.SetPreferredSize(Me.UltraGroupBoxSchlagwörter, New System.Drawing.Size(265, 264))
        Me.UltraGroupBoxSchlagwörter.Size = New System.Drawing.Size(254, 174)
        Me.UltraGroupBoxSchlagwörter.TabIndex = 462
        Me.UltraGroupBoxSchlagwörter.Tag = "ResID.SearchCatchwords"
        Me.UltraGroupBoxSchlagwörter.Text = "Suche nach Schlagwörtern"
        '
        'gridSchlagwortkatalog
        '
        Me.gridSchlagwortkatalog.DataMember = "SelListHelper"
        Me.gridSchlagwortkatalog.DataSource = Me.DsAuswahllisten1
        Appearance8.BackColor = System.Drawing.Color.White
        Appearance8.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridSchlagwortkatalog.DisplayLayout.Appearance = Appearance8
        Me.gridSchlagwortkatalog.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        UltraGridColumn68.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn68.Header.VisiblePosition = 0
        UltraGridColumn68.Hidden = True
        UltraGridColumn6.Header.VisiblePosition = 1
        UltraGridColumn6.Hidden = True
        UltraGridColumn7.Header.VisiblePosition = 2
        UltraGridColumn7.Hidden = True
        UltraGridColumn8.Header.VisiblePosition = 3
        UltraGridColumn8.Hidden = True
        UltraGridColumn9.Header.VisiblePosition = 5
        UltraGridColumn9.Hidden = True
        UltraGridColumn10.Header.VisiblePosition = 6
        UltraGridColumn80.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn80.DataType = GetType(Boolean)
        UltraGridColumn80.Header.VisiblePosition = 4
        UltraGridColumn80.Width = 66
        UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn68, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn80})
        Me.gridSchlagwortkatalog.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
        Me.gridSchlagwortkatalog.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance9.BackColor = System.Drawing.Color.FloralWhite
        Me.gridSchlagwortkatalog.DisplayLayout.CaptionAppearance = Appearance9
        Me.gridSchlagwortkatalog.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance10.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance10.BorderColor = System.Drawing.SystemColors.Window
        Me.gridSchlagwortkatalog.DisplayLayout.GroupByBox.Appearance = Appearance10
        Appearance11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridSchlagwortkatalog.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance11
        Me.gridSchlagwortkatalog.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridSchlagwortkatalog.DisplayLayout.GroupByBox.Prompt = "Ziehen Sie eine Spalte herein  nach der Sie gruppieren möchten:"
        Appearance12.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance12.BackColor2 = System.Drawing.SystemColors.Control
        Appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance12.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridSchlagwortkatalog.DisplayLayout.GroupByBox.PromptAppearance = Appearance12
        Me.gridSchlagwortkatalog.DisplayLayout.MaxColScrollRegions = 1
        Me.gridSchlagwortkatalog.DisplayLayout.MaxRowScrollRegions = 1
        Appearance13.BackColor = System.Drawing.SystemColors.Window
        Appearance13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridSchlagwortkatalog.DisplayLayout.Override.ActiveCellAppearance = Appearance13
        Appearance14.BackColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance14.ForeColor = System.Drawing.Color.White
        Me.gridSchlagwortkatalog.DisplayLayout.Override.ActiveRowAppearance = Appearance14
        Me.gridSchlagwortkatalog.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridSchlagwortkatalog.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance15.BackColor = System.Drawing.SystemColors.Window
        Me.gridSchlagwortkatalog.DisplayLayout.Override.CardAreaAppearance = Appearance15
        Me.gridSchlagwortkatalog.DisplayLayout.Override.CardSpacing = 0
        Appearance16.BorderColor = System.Drawing.Color.Silver
        Appearance16.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridSchlagwortkatalog.DisplayLayout.Override.CellAppearance = Appearance16
        Me.gridSchlagwortkatalog.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridSchlagwortkatalog.DisplayLayout.Override.CellPadding = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.CellSpacing = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.DefaultRowHeight = 1
        Me.gridSchlagwortkatalog.DisplayLayout.Override.FilterRowSpacingAfter = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.FilterRowSpacingBefore = 0
        Appearance17.BackColor = System.Drawing.SystemColors.Control
        Appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance17.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance17.BorderColor = System.Drawing.SystemColors.Window
        Me.gridSchlagwortkatalog.DisplayLayout.Override.GroupByRowAppearance = Appearance17
        Me.gridSchlagwortkatalog.DisplayLayout.Override.GroupByRowPadding = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.GroupByRowSpacingAfter = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.GroupByRowSpacingBefore = 0
        Appearance18.TextHAlignAsString = "Left"
        Me.gridSchlagwortkatalog.DisplayLayout.Override.HeaderAppearance = Appearance18
        Me.gridSchlagwortkatalog.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridSchlagwortkatalog.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.XPThemed
        Appearance19.BackColor = System.Drawing.SystemColors.Window
        Appearance19.BorderColor = System.Drawing.Color.Silver
        Me.gridSchlagwortkatalog.DisplayLayout.Override.RowAppearance = Appearance19
        Me.gridSchlagwortkatalog.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.gridSchlagwortkatalog.DisplayLayout.Override.RowSizingAutoMaxLines = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.RowSpacingAfter = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.RowSpacingBefore = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.[Single]
        Me.gridSchlagwortkatalog.DisplayLayout.Override.SequenceFilterRow = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.SequenceFixedAddRow = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.SequenceSummaryRow = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.SpecialRowSeparatorHeight = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.SummaryFooterSpacingAfter = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.SummaryFooterSpacingBefore = 0
        Appearance20.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridSchlagwortkatalog.DisplayLayout.Override.TemplateAddRowAppearance = Appearance20
        Me.gridSchlagwortkatalog.DisplayLayout.Override.TemplateAddRowSpacingAfter = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.TemplateAddRowSpacingBefore = 0
        Me.gridSchlagwortkatalog.DisplayLayout.RowConnectorColor = System.Drawing.Color.FloralWhite
        Me.gridSchlagwortkatalog.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None
        Me.gridSchlagwortkatalog.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridSchlagwortkatalog.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        GridBagConstraint2.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint2.Insets.Bottom = 5
        GridBagConstraint2.Insets.Left = 5
        GridBagConstraint2.Insets.Right = 5
        GridBagConstraint2.Insets.Top = 5
        Me.lasySucheSchlagwortkatalog2.SetGridBagConstraint(Me.gridSchlagwortkatalog, GridBagConstraint2)
        Me.gridSchlagwortkatalog.Location = New System.Drawing.Point(8, 21)
        Me.gridSchlagwortkatalog.Name = "gridSchlagwortkatalog"
        Me.lasySucheSchlagwortkatalog2.SetPreferredSize(Me.gridSchlagwortkatalog, New System.Drawing.Size(116, 77))
        Me.gridSchlagwortkatalog.Size = New System.Drawing.Size(238, 145)
        Me.gridSchlagwortkatalog.TabIndex = 455
        Me.gridSchlagwortkatalog.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'DsAuswahllisten1
        '
        Me.DsAuswahllisten1.DataSetName = "dsAuswahllisten"
        Me.DsAuswahllisten1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PanelErweiterteSuchangaben
        '
        Me.PanelErweiterteSuchangaben.BackColor = System.Drawing.Color.Transparent
        Me.PanelErweiterteSuchangaben.Controls.Add(Me.UltraGroupBoxSucheInOrdner)
        Me.PanelErweiterteSuchangaben.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelErweiterteSuchangaben.Location = New System.Drawing.Point(0, 0)
        Me.PanelErweiterteSuchangaben.Name = "PanelErweiterteSuchangaben"
        Me.PanelErweiterteSuchangaben.Size = New System.Drawing.Size(783, 142)
        Me.PanelErweiterteSuchangaben.TabIndex = 0
        '
        'UltraGroupBoxSucheInOrdner
        '
        Appearance25.BackColor = System.Drawing.Color.Transparent
        Appearance25.BorderColor = System.Drawing.Color.Black
        Me.UltraGroupBoxSucheInOrdner.Appearance = Appearance25
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UDateAbgelegtVon)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UDateGültigVon)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.cboPriorität)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.PanelEditorToWork)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.TextControlToWork)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.PanelBenutzerauswahl)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UCheckEditorImGesamtarchivSuchen)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UltraGroupBox1)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UDateAbgelegtBis)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UltraLabel8)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UDateGültigBis)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UltraLabel7)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UltraLabel6)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UltraLabel11)
        Me.UltraGroupBoxSucheInOrdner.Controls.Add(Me.UltraLabel9)
        GridBagConstraint5.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint5.Insets.Bottom = 2
        GridBagConstraint5.Insets.Left = 5
        GridBagConstraint5.Insets.Right = 5
        GridBagConstraint5.Insets.Top = 5
        Me.layErwSuchangaben.SetGridBagConstraint(Me.UltraGroupBoxSucheInOrdner, GridBagConstraint5)
        Me.UltraGroupBoxSucheInOrdner.Location = New System.Drawing.Point(5, 5)
        Me.UltraGroupBoxSucheInOrdner.Name = "UltraGroupBoxSucheInOrdner"
        Me.layErwSuchangaben.SetPreferredSize(Me.UltraGroupBoxSucheInOrdner, New System.Drawing.Size(301, 218))
        Me.UltraGroupBoxSucheInOrdner.Size = New System.Drawing.Size(773, 135)
        Me.UltraGroupBoxSucheInOrdner.TabIndex = 0
        Me.UltraGroupBoxSucheInOrdner.Tag = "ResID.ExtendedSearchDetails"
        Me.UltraGroupBoxSucheInOrdner.Text = "Erweiterte Suchangaben"
        '
        'UDateGültigVon
        '
        Appearance26.BackColor = System.Drawing.Color.White
        Me.UDateGültigVon.Appearance = Appearance26
        Me.UDateGültigVon.AutoSize = False
        Me.UDateGültigVon.BackColor = System.Drawing.Color.White
        Me.UDateGültigVon.DateTime = New Date(2005, 9, 2, 0, 0, 0, 0)
        Me.UDateGültigVon.Location = New System.Drawing.Point(90, 61)
        Me.UDateGültigVon.Name = "UDateGültigVon"
        Me.UDateGültigVon.Size = New System.Drawing.Size(92, 21)
        Me.UDateGültigVon.TabIndex = 2
        Me.UDateGültigVon.Value = New Date(2005, 9, 2, 0, 0, 0, 0)
        '
        'cboPriorität
        '
        Appearance27.BackColor = System.Drawing.Color.White
        Me.cboPriorität.Appearance = Appearance27
        Me.cboPriorität.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboPriorität.AutoSize = False
        Me.cboPriorität.BackColor = System.Drawing.Color.White
        Me.cboPriorität.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        ValueListItem10.DataValue = "H"
        ValueListItem10.DisplayText = "Hoch"
        ValueListItem11.DataValue = "M"
        ValueListItem11.DisplayText = "Mittel"
        ValueListItem12.DataValue = "N"
        ValueListItem12.DisplayText = "Niedrig"
        Me.cboPriorität.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem10, ValueListItem11, ValueListItem12})
        Me.cboPriorität.Location = New System.Drawing.Point(90, 101)
        Me.cboPriorität.Name = "cboPriorität"
        Me.cboPriorität.Size = New System.Drawing.Size(96, 21)
        Me.cboPriorität.TabIndex = 4
        '
        'PanelEditorToWork
        '
        Me.PanelEditorToWork.BackColor = System.Drawing.Color.Transparent
        Me.PanelEditorToWork.Location = New System.Drawing.Point(218, 89)
        Me.PanelEditorToWork.Name = "PanelEditorToWork"
        Me.PanelEditorToWork.Size = New System.Drawing.Size(43, 32)
        Me.PanelEditorToWork.TabIndex = 388
        '
        'TextControlToWork
        '
        Me.TextControlToWork.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.TextControlToWork.Location = New System.Drawing.Point(225, 95)
        Me.TextControlToWork.Name = "TextControlToWork"
        Me.TextControlToWork.PageMargins.Bottom = 79.03R
        Me.TextControlToWork.PageMargins.Left = 79.03R
        Me.TextControlToWork.PageMargins.Right = 79.03R
        Me.TextControlToWork.PageMargins.Top = 79.03R
        Me.TextControlToWork.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextControlToWork.Size = New System.Drawing.Size(26, 18)
        Me.TextControlToWork.TabIndex = 387
        '
        'PanelBenutzerauswahl
        '
        Me.PanelBenutzerauswahl.BackColor = System.Drawing.Color.Transparent
        Me.PanelBenutzerauswahl.Controls.Add(Me.cboSachbearbeiter)
        Me.PanelBenutzerauswahl.Controls.Add(Me.UltraLabel1)
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
        Me.cboSachbearbeiter.Location = New System.Drawing.Point(90, 3)
        Me.cboSachbearbeiter.Name = "cboSachbearbeiter"
        Me.cboSachbearbeiter.Size = New System.Drawing.Size(151, 21)
        Me.cboSachbearbeiter.TabIndex = 0
        '
        'UltraLabel1
        '
        Appearance28.BackColor = System.Drawing.Color.Transparent
        Appearance28.TextHAlignAsString = "Right"
        Me.UltraLabel1.Appearance = Appearance28
        Me.UltraLabel1.Location = New System.Drawing.Point(5, 6)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(81, 16)
        Me.UltraLabel1.TabIndex = 389
        Me.UltraLabel1.Tag = "ResID.User"
        Me.UltraLabel1.Text = "Benutzer"
        '
        'UCheckEditorImGesamtarchivSuchen
        '
        Me.UCheckEditorImGesamtarchivSuchen.BackColor = System.Drawing.Color.Transparent
        Me.UCheckEditorImGesamtarchivSuchen.BackColorInternal = System.Drawing.Color.Transparent
        Me.UCheckEditorImGesamtarchivSuchen.Location = New System.Drawing.Point(344, 105)
        Me.UCheckEditorImGesamtarchivSuchen.Name = "UCheckEditorImGesamtarchivSuchen"
        Me.UCheckEditorImGesamtarchivSuchen.Size = New System.Drawing.Size(162, 18)
        Me.UCheckEditorImGesamtarchivSuchen.TabIndex = 6
        Me.UCheckEditorImGesamtarchivSuchen.Tag = "ResID.SearchInEntireArchive"
        Me.UCheckEditorImGesamtarchivSuchen.Text = "Im gesamten Archiv suchen"
        Me.UCheckEditorImGesamtarchivSuchen.Visible = False
        '
        'UltraGroupBox1
        '
        Appearance29.BackColor = System.Drawing.Color.Transparent
        Me.UltraGroupBox1.Appearance = Appearance29
        Me.UltraGroupBox1.Controls.Add(Me.Panel1)
        Me.UltraGroupBox1.Location = New System.Drawing.Point(321, 24)
        Me.UltraGroupBox1.Name = "UltraGroupBox1"
        Me.UltraGroupBox1.Size = New System.Drawing.Size(428, 73)
        Me.UltraGroupBox1.TabIndex = 5
        Me.UltraGroupBox1.Tag = "ResID.DisplayTreeView"
        Me.UltraGroupBox1.Text = "Anzeige Baumansicht"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RButtonAlleOrdner)
        Me.Panel1.Controls.Add(Me.RButtonOrdnerMitDokumente)
        Me.Panel1.Location = New System.Drawing.Point(15, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(426, 41)
        Me.Panel1.TabIndex = 0
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
        Me.RButtonAlleOrdner.Tag = "ResID.ViewAllFolders"
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
        Me.RButtonOrdnerMitDokumente.Tag = "ResID.ShowOnlyFoldersWithDocuments"
        Me.RButtonOrdnerMitDokumente.Text = "Nur Ordner mit Dokumente anzeigen"
        Me.RButtonOrdnerMitDokumente.UseVisualStyleBackColor = False
        '
        'UltraLabel8
        '
        Appearance30.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel8.Appearance = Appearance30
        Me.UltraLabel8.Location = New System.Drawing.Point(9, 63)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(93, 16)
        Me.UltraLabel8.TabIndex = 242
        Me.UltraLabel8.Tag = "ResID.ValidFrom"
        Me.UltraLabel8.Text = "Gültigkeit von"
        '
        'UDateGültigBis
        '
        Appearance31.BackColor = System.Drawing.Color.White
        Me.UDateGültigBis.Appearance = Appearance31
        Me.UDateGültigBis.AutoSize = False
        Me.UDateGültigBis.BackColor = System.Drawing.Color.White
        Me.UDateGültigBis.DateTime = New Date(2005, 9, 2, 0, 0, 0, 0)
        Me.UDateGültigBis.Location = New System.Drawing.Point(223, 61)
        Me.UDateGültigBis.Name = "UDateGültigBis"
        Me.UDateGültigBis.Size = New System.Drawing.Size(92, 21)
        Me.UDateGültigBis.TabIndex = 3
        Me.UDateGültigBis.Value = New Date(2005, 9, 2, 0, 0, 0, 0)
        '
        'UltraLabel6
        '
        Appearance32.BackColor = System.Drawing.Color.Transparent
        Appearance32.TextHAlignAsString = "Center"
        Me.UltraLabel6.Appearance = Appearance32
        Me.UltraLabel6.Location = New System.Drawing.Point(188, 63)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(29, 16)
        Me.UltraLabel6.TabIndex = 244
        Me.UltraLabel6.Tag = "ResID.To"
        Me.UltraLabel6.Text = "bis"
        '
        'UltraLabel9
        '
        Appearance33.BackColor = System.Drawing.Color.Transparent
        Appearance33.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel9.Appearance = Appearance33
        Me.UltraLabel9.Location = New System.Drawing.Point(9, 103)
        Me.UltraLabel9.Name = "UltraLabel9"
        Me.UltraLabel9.Size = New System.Drawing.Size(93, 16)
        Me.UltraLabel9.TabIndex = 239
        Me.UltraLabel9.Tag = "ResID.Important"
        Me.UltraLabel9.Text = "Wichtigkeit"
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
        Me.UTabDokumenteGefunden.Size = New System.Drawing.Size(514, 325)
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
        Me.UTabDokumenteGefunden.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'UltraTabSharedControlsPage2
        '
        Me.UltraTabSharedControlsPage2.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage2.Name = "UltraTabSharedControlsPage2"
        Me.UltraTabSharedControlsPage2.Size = New System.Drawing.Size(514, 325)
        '
        'contMenüTree
        '
        Me.contMenüTree.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DokumentHinzufügenToolStripMenuItem, Me.ÖffnenEXToolStripMenuItem, Me.DateiÖffnenMitInternemEditorTreeToolStripMenuItem, Me.ToolStripMenuItem12, Me.MtemSpcihernUnterExplorerS, Me.ToolStripMenuItem2, Me.InDenPapierkorbEXToolStripMenuItem, Me.MItemLöschenOhnePapierkorbExplorerS, Me.ToolStripMenuItem1, Me.DokumentEditierenToolStripMenuItem1, Me.MtemInfoDateiDokumentS, Me.ToolStripMenuItem7, Me.NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem, Me.ToolStripMenuItem9, Me.WechselnZuToolStripMenuItem1, Me.InNeuemTabÖffnenToolStripMenuItem1})
        Me.contMenüTree.Name = "ContextMenuDokumenteExplorerS"
        Me.contMenüTree.Size = New System.Drawing.Size(396, 276)
        '
        'DokumentHinzufügenToolStripMenuItem
        '
        Me.DokumentHinzufügenToolStripMenuItem.Name = "DokumentHinzufügenToolStripMenuItem"
        Me.DokumentHinzufügenToolStripMenuItem.Size = New System.Drawing.Size(395, 22)
        Me.DokumentHinzufügenToolStripMenuItem.Tag = "ResID.AddDocument"
        Me.DokumentHinzufügenToolStripMenuItem.Text = "Dokument hinzufügen ..."
        Me.DokumentHinzufügenToolStripMenuItem.Visible = False
        '
        'ÖffnenEXToolStripMenuItem
        '
        Me.ÖffnenEXToolStripMenuItem.Name = "ÖffnenEXToolStripMenuItem"
        Me.ÖffnenEXToolStripMenuItem.Size = New System.Drawing.Size(395, 22)
        Me.ÖffnenEXToolStripMenuItem.Tag = "ResID.OpenFile"
        Me.ÖffnenEXToolStripMenuItem.Text = "Datei öffnen"
        '
        'DateiÖffnenMitInternemEditorTreeToolStripMenuItem
        '
        Me.DateiÖffnenMitInternemEditorTreeToolStripMenuItem.Name = "DateiÖffnenMitInternemEditorTreeToolStripMenuItem"
        Me.DateiÖffnenMitInternemEditorTreeToolStripMenuItem.Size = New System.Drawing.Size(395, 22)
        Me.DateiÖffnenMitInternemEditorTreeToolStripMenuItem.Tag = "ResID.OpenFileInternEditor"
        Me.DateiÖffnenMitInternemEditorTreeToolStripMenuItem.Text = "Datei öffnen (Mit internen Editor)"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(392, 6)
        '
        'MtemSpcihernUnterExplorerS
        '
        Me.MtemSpcihernUnterExplorerS.Name = "MtemSpcihernUnterExplorerS"
        Me.MtemSpcihernUnterExplorerS.Size = New System.Drawing.Size(395, 22)
        Me.MtemSpcihernUnterExplorerS.Tag = "ResID.SaveFileAs"
        Me.MtemSpcihernUnterExplorerS.Text = "Datei speichern unter"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(392, 6)
        '
        'InDenPapierkorbEXToolStripMenuItem
        '
        Me.InDenPapierkorbEXToolStripMenuItem.Name = "InDenPapierkorbEXToolStripMenuItem"
        Me.InDenPapierkorbEXToolStripMenuItem.Size = New System.Drawing.Size(395, 22)
        Me.InDenPapierkorbEXToolStripMenuItem.Tag = "ResID.MoveToTrash"
        Me.InDenPapierkorbEXToolStripMenuItem.Text = "In den Papierkorb verschieben"
        '
        'MItemLöschenOhnePapierkorbExplorerS
        '
        Me.MItemLöschenOhnePapierkorbExplorerS.Name = "MItemLöschenOhnePapierkorbExplorerS"
        Me.MItemLöschenOhnePapierkorbExplorerS.Size = New System.Drawing.Size(395, 22)
        Me.MItemLöschenOhnePapierkorbExplorerS.Tag = "ResID.Delete"
        Me.MItemLöschenOhnePapierkorbExplorerS.Text = "Löschen"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(392, 6)
        '
        'DokumentEditierenToolStripMenuItem1
        '
        Me.DokumentEditierenToolStripMenuItem1.Name = "DokumentEditierenToolStripMenuItem1"
        Me.DokumentEditierenToolStripMenuItem1.Size = New System.Drawing.Size(395, 22)
        Me.DokumentEditierenToolStripMenuItem1.Tag = "ResID.EditDocument"
        Me.DokumentEditierenToolStripMenuItem1.Text = "Dokument editieren"
        Me.DokumentEditierenToolStripMenuItem1.Visible = False
        '
        'MtemInfoDateiDokumentS
        '
        Me.MtemInfoDateiDokumentS.Name = "MtemInfoDateiDokumentS"
        Me.MtemInfoDateiDokumentS.Size = New System.Drawing.Size(395, 22)
        Me.MtemInfoDateiDokumentS.Tag = "ResID.InfoDocument"
        Me.MtemInfoDateiDokumentS.Text = "Info Dokument"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(392, 6)
        '
        'NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem
        '
        Me.NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem.Name = "NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem"
        Me.NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem.Size = New System.Drawing.Size(395, 22)
        Me.NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem.Tag = "ResID.NewPlanningResourcesWit DocumentAsAppendix"
        Me.NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem.Text = "Neuen Planungseintrag erstellen (mit Dokument als Anhang)"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(392, 6)
        '
        'WechselnZuToolStripMenuItem1
        '
        Me.WechselnZuToolStripMenuItem1.Name = "WechselnZuToolStripMenuItem1"
        Me.WechselnZuToolStripMenuItem1.Size = New System.Drawing.Size(395, 22)
        Me.WechselnZuToolStripMenuItem1.Tag = "ResID.SwitchTo"
        Me.WechselnZuToolStripMenuItem1.Text = "Wechseln zu"
        '
        'InNeuemTabÖffnenToolStripMenuItem1
        '
        Me.InNeuemTabÖffnenToolStripMenuItem1.Name = "InNeuemTabÖffnenToolStripMenuItem1"
        Me.InNeuemTabÖffnenToolStripMenuItem1.Size = New System.Drawing.Size(395, 22)
        Me.InNeuemTabÖffnenToolStripMenuItem1.Tag = "ResID.OpenInANewTab"
        Me.InNeuemTabÖffnenToolStripMenuItem1.Text = "In neuem Tab öffnen"
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
        Me.PanelUnten.Size = New System.Drawing.Size(520, 335)
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
        Me.PanelSucheSchlagwortkatalogOrdner.Size = New System.Drawing.Size(259, 335)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(783, 335)
        Me.SplitContainer1.SplitterDistance = 520
        Me.SplitContainer1.TabIndex = 466
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.SplitContainer1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 142)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(783, 335)
        Me.Panel2.TabIndex = 467
        '
        'ContextMenuStripExportOrdner
        '
        Me.ContextMenuStripExportOrdner.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OrdnerMitDokumentenExportierenToolStripMenuItem})
        Me.ContextMenuStripExportOrdner.Name = "ContextMenuStripExportOrdner"
        Me.ContextMenuStripExportOrdner.Size = New System.Drawing.Size(174, 26)
        '
        'OrdnerMitDokumentenExportierenToolStripMenuItem
        '
        Me.OrdnerMitDokumentenExportierenToolStripMenuItem.Name = "OrdnerMitDokumentenExportierenToolStripMenuItem"
        Me.OrdnerMitDokumentenExportierenToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.OrdnerMitDokumentenExportierenToolStripMenuItem.Tag = "ResID.ExportFolders"
        Me.OrdnerMitDokumentenExportierenToolStripMenuItem.Text = "Ordner exportieren"
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'DbArchiv2
        '
        Me.DbArchiv2.DataSetName = "dbArchiv"
        Me.DbArchiv2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'contArchSuch
        '
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PanelErweiterteSuchangaben)
        Me.DoubleBuffered = True
        Me.Name = "contArchSuch"
        Me.Size = New System.Drawing.Size(783, 477)
        Me.UltraTabPageControl4.ResumeLayout(False)
        Me.PanelGrid.ResumeLayout(False)
        CType(Me.gridDocus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.contMenüGrid.ResumeLayout(False)
        CType(Me.DsDokuSearch1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabPageControl6.ResumeLayout(False)
        CType(Me.UltraGroupBoxSucheInOrdnern, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBoxSucheInOrdnern.ResumeLayout(False)
        Me.PanelSucheOrdner.ResumeLayout(False)
        CType(Me.UDateAbgelegtBis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDateAbgelegtVon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBoxSchlagwörter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBoxSchlagwörter.ResumeLayout(False)
        CType(Me.gridSchlagwortkatalog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAuswahllisten1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelErweiterteSuchangaben.ResumeLayout(False)
        CType(Me.UltraGroupBoxSucheInOrdner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBoxSucheInOrdner.ResumeLayout(False)
        Me.UltraGroupBoxSucheInOrdner.PerformLayout()
        CType(Me.UDateGültigVon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPriorität, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBenutzerauswahl.ResumeLayout(False)
        CType(Me.cboSachbearbeiter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UCheckEditorImGesamtarchivSuchen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.UDateGültigBis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UTabDokumenteGefunden, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UTabDokumenteGefunden.ResumeLayout(False)
        Me.contMenüTree.ResumeLayout(False)
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
        Me.ContextMenuStripExportOrdner.ResumeLayout(False)
        CType(Me.DbArchiv2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub DokumentSuchen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception

        End Try
    End Sub
    Public Sub initForm()
        Try
            If Me.isLoaded Then Exit Sub

            Dim newRessourcesAdded As Integer = 0
            'Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)
            Me.doUI1.runComponents_rek(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, Nothing)

            Me.DokumentHinzufügenToolStripMenuItem1.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.ÖffnenLToolStripMenuItem.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_folder, 32, 32)
            Me.MItemSpeichernUnterListeS.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)
            Me.InDenPapierkorbLIToolStripMenuItem.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_trash, 32, 32)
            Me.MItemDokumentLöschenOhnePapierkorbListeS.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)
            Me.MItemInfoDokumentListeS.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_about, 32, 32)
            Me.NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem1.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Message, 32, 32)
            Me.DruckenToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Drucken, 32, 32)

            Me.DokumentHinzufügenToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.ÖffnenEXToolStripMenuItem.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_folder, 32, 32)
            Me.MtemSpcihernUnterExplorerS.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)
            Me.InDenPapierkorbEXToolStripMenuItem.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_trash, 32, 32)
            Me.MItemLöschenOhnePapierkorbExplorerS.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)
            Me.MtemInfoDateiDokumentS.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_about, 32, 32)
            Me.NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Message, 32, 32)

            Me.DruckenToolStripMenuItem.Visible = False
            Me.ToolStripMenuItemSpacePrint.Visible = False

            Me.AusgewählteDokumenteFürDasWebFreigebenToolStripMenuItem1.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_earth, 32, 32)
            Me.AusgewählteDokumenteFürDenKundenImWebFreigebenToolStripMenuItem.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_earth, 32, 32)
            Dim bRechtArchivLöschen As Boolean = True
            If bRechtArchivLöschen Then
                Me.MItemDokumentLöschenOhnePapierkorbListeS.Visible = True
                Me.MItemLöschenOhnePapierkorbExplorerS.Visible = True
            Else
                Me.MItemDokumentLöschenOhnePapierkorbListeS.Visible = False
                Me.MItemLöschenOhnePapierkorbExplorerS.Visible = False
            End If

            Me.setUIGrid()

            Dim dropDownStatus As New dropDownGridSelList()
            dropDownStatus.initControl()
            dropDownStatus.loadSelLists("STATPA", General.eKeyCol.IDStr)
            Me.gridDocus.DisplayLayout.Bands(0).Columns(Me.DsDokuSearch1.archDoku.IDStatusColumn.ColumnName).ValueList = dropDownStatus.dropDownSelList
            Me.gridDocus.DisplayLayout.Bands(0).Columns(Me.DsDokuSearch1.archDoku.IDStatusColumn.ColumnName).Style = Me.styleDropDown

            'Dim dropDownTyp As New ITSCont.dialogs.dropDownGridSelList()
            'dropDownTyp.initControl()
            'dropDownTyp.loadSelList("TYPPA", ITSCont.core.SystemDb.Enums.eKeyCol.IDStr)
            'Me.gridDocus.DisplayLayout.Bands(0).Columns(Me.DsDokuSearch1.archDoku.IDTypColumn.ColumnName).ValueList = dropDownTyp.dropDownSelList
            'Me.gridDocus.DisplayLayout.Bands(0).Columns(Me.DsDokuSearch1.archDoku.IDTypColumn.ColumnName).Style = Me.styleDropDown

            Me.UDropDownButtonErweiterteSuche.PopupItem = Me.UPopupContErweitSuche

            Me.LoadOrdnerIntoPanels()

            Me.resetForm()

            Me.RButtonOrdnerMitDokumente.Checked = True

            Dim d_evHandDoubleMouseUp As New dArchiv.Funct(AddressOf Me.ArchivOrdnerErgebniss_MouseUp)
            Me.contOrdnerErgebniss.delMouseUp.RegisterDelegate(d_evHandDoubleMouseUp)

            Dim d_evHandClick As New dArchiv.Funct(AddressOf Me.ArchivOrdnerErgebniss_Click)
            Me.contOrdnerErgebniss.delClick.RegisterDelegate(d_evHandClick)

            'Me.Show()
            'Me.ResizeControl(Me.Height, Me.Width)

            Me.ui1.setMergeStyle(Me.gridDocus, True, True)

            Me.ImageListSmall.Images.Clear()
            Me.ImageListSmall.Images.Add(qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_earth, 32, 32))
            Me.ImageListSmall.Images.Add(QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Bearbeiten, 32, 32))
            Me.ui1.loadLstIntReleased(Me.ImageListSmall, Me.gridDocus)
            Me.ui1.loadLstIDTyp(Me.ImageListSmall, Me.gridDocus)

            Me.gridDocus.DisplayLayout.Bands(0).Columns(Me.DsDokuSearch1.archDoku.intReleasedColumn.ColumnName).Header.Caption = doUI.getRes("Agent")
            Me.gridDocus.DisplayLayout.Bands(0).Columns(Me.DsDokuSearch1.archDoku.IDTypColumn.ColumnName).Header.Caption = doUI.getRes("Customer")

            'Me.ui1.loadLstBinIntern(Me.ImageListSmall, Me.gridDocus)

            Dim IsAussendienstmitarbeiter As Boolean = False
            If IsAussendienstmitarbeiter Then
                Me.AusgewählteDokumenteFürDasWebFreigebenToolStripMenuItem1.Visible = False
                Me.AusgewählteDokumenteFürDasWebSperrenToolStripMenuItem1.Visible = False
                Me.ToolStripMenuItem14.Visible = False
                Me.AusgewählteDokumenteFürDenKundenImWebFreigebenToolStripMenuItem.Visible = False
                Me.AusgewählteDokumenteFürDenKundenImWebSperrenToolStripMenuItem.Visible = False
                Me.ToolStripMenuItem10.Visible = False
                Me.InDenPapierkorbLIToolStripMenuItem.Visible = False
                Me.MItemDokumentLöschenOhnePapierkorbListeS.Visible = False
                Me.ToolStripMenuItem3.Visible = False

                Me.MItemLöschenOhnePapierkorbExplorerS.Visible = False
                Me.InDenPapierkorbEXToolStripMenuItem.Visible = False
                Me.ToolStripMenuItem2.Visible = False
            End If

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("contArchSuch.initForm: " + ex.ToString())
        End Try
    End Sub

    Public Sub setUIGrid()
        Try
            Me.lstColSmallViewGrid.Clear()
            Me.lstColSmallViewGrid.Add(Me.DsDokuSearch1.archDoku.BezeichnungColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsDokuSearch1.archDoku.OrdnerColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsDokuSearch1.archDoku.WichtigkeitColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsDokuSearch1.archDoku.GültigVonColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsDokuSearch1.archDoku.GültigBisColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsDokuSearch1.archDoku.AbgelegtVonColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsDokuSearch1.archDoku.AbgelegtAmColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsDokuSearch1.archDoku.IDTypColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsDokuSearch1.archDoku.OrdnerColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsDokuSearch1.archDoku.IDStatusColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsDokuSearch1.archDoku.OrdnerExternColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsDokuSearch1.archDoku.DateinameTypColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsDokuSearch1.archDoku.anzObjectColumn.ColumnName)
            Me.lstColSmallViewGrid.Add(Me.DsDokuSearch1.archDoku.intReleasedColumn.ColumnName)
            'Me.lstColSmallViewGrid.Add(Me.DsDokuSearch1.archDoku.binInternColumn.ColumnName)

            Me.ui1.gridErwSicht(False, Me.gridDocus, lstColSmallViewGrid, Me.lstColBigViewGridDeaktivate)

        Catch ex As Exception
            Throw New Exception("contArchSuch.setUIGrid: " + ex.ToString())
        End Try
    End Sub
    Public Sub LoadOrdnerIntoPanels()
        Try
            Me.PanelOrdnerErgebniss.Controls.Add(Me.contOrdnerErgebniss)
            contOrdnerErgebniss.Dock = DockStyle.Fill
            Me.contOrdnerErgebniss.initTree_icons(True)
            Me.contOrdnerErgebniss.initControl()

            Me.PanelSucheOrdner.Controls.Add(contSucheInOrdnern)
            contSucheInOrdnern.Dock = DockStyle.Fill

            Me.contSucheInOrdnern.hidePanelUnten()
            Me.contSucheInOrdnern.initTree_icons(False)
            Me.contSucheInOrdnern.initControl()

        Catch ex As Exception
            Throw New Exception("contArchSuch.LoadOrdnerIntoPanels: " + ex.ToString())
        End Try
    End Sub

    Public Function DokumenteSuchen(ByVal Dummy As Boolean)
        Try
            Me.DokumentSuchen(Dummy, False)

        Catch ex As Exception
            Throw New Exception("contArchSuch.DokumenteSuchen: " + ex.ToString())
        End Try
    End Function

    Public Sub resetForm()
        Try
            Me.FileInfo = New clFileInfo

            Me.LoadSchlagwortkatalog()

            Me.LoadOrdner()

            Me.UDateGültigVon.Value = Nothing
            Me.UDateGültigBis.Value = Nothing
            Me.UDateAbgelegtVon.Value = Nothing
            Me.UDateAbgelegtBis.Value = Nothing

            Me.cboPriorität.Value = Nothing

            Me.UTabDokumenteGefunden.Tabs(0).Text = doUI.getRes("List")

            Me.cboSachbearbeiter.Value = ""
            Me.cboSachbearbeiter.Text = ""

            Me.DokumentSuchen(True, False)
            Me.setSuchtext("")

        Catch ex As Exception
            Throw New Exception("contArchSuch.resetForm: " + ex.ToString())
        End Try
    End Sub
    Public Sub LoadSchlagwortkatalog()
        Try
            Me.compDoku1.getAuswahlisten2(Me.DsAuswahllisten1, "SW", General.eKeyCol.Guid)
            Me.gridSchlagwortkatalog.Refresh()

        Catch ex As Exception
            Throw New Exception("contArchSuch.LoadSchlagwortkatalog: " + ex.ToString())
        End Try
    End Sub

    Public Sub LoadOrdner()
        Try
            Me.contSucheInOrdnern.LoadOrdnerbaum(contOrdner.etyp.AuswahlSuche, Nothing)

        Catch ex As Exception
            Throw New Exception("contArchSuch.LoadOrdner: " + ex.ToString())
        End Try
    End Sub

    Public Sub DokumentSuchen(ByVal leerAnzeigen As Boolean, ByVal nurPapierkorb As Boolean)
        Try
            Me.DsDokuSearch1.Clear()

            Me.UTabDokumenteGefunden.Tabs(0).Text = doUI.getRes("List")
            Dim IDSchlagwörter As New ArrayList
            Dim clSuchen As New sucheDoku

            If leerAnzeigen And Not nurPapierkorb Then
                Dim id As New System.Guid : id = System.Guid.NewGuid
                clSuchen.searchDocu(Me.DsDokuSearch1, Trim(id.ToString), Me.contSucheInOrdnern.GetCheckedOrdner(), IDSchlagwörter,
                                                                Me.UDateGültigVon.Value, Me.UDateGültigBis.Value,
                                                                Me.cboPriorität.Text, Me.tArchObjects,
                                                                  Me.UDateAbgelegtVon.Value, Me.UDateAbgelegtBis.Value,
                                                                  Me.cboSachbearbeiter.Text, False,
                                                                  Me.UCheckEditorImGesamtarchivSuchen.Checked)
            ElseIf Not leerAnzeigen And nurPapierkorb Then
                Dim arr As New ArrayList
                Dim tArchObjectsTemp As New dbArchiv.archObjectDataTable()
                clSuchen.searchDocu(Me.DsDokuSearch1, "", arr, arr, Nothing, Nothing, "", tArchObjectsTemp,
                                                 Nothing, Nothing, "", True, True)
            Else
                For Each rGrid As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridSchlagwortkatalog.Rows
                    Dim v As DataRowView = rGrid.ListObject
                    Dim rAuswList As dsAuswahllisten.SelListHelperRow = v.Row
                    If rGrid.Cells("Auswahl").Value = True Then
                        IDSchlagwörter.Add(rAuswList.Description.Trim())
                    End If
                Next

                Dim arrcheckedOrdner As ArrayList = Me.contSucheInOrdnern.GetCheckedOrdner()
                clSuchen.searchDocu(Me.DsDokuSearch1, Trim(Me.getSuchtext), arrcheckedOrdner, IDSchlagwörter,
                                                    Me.UDateGültigVon.Value, Me.UDateGültigBis.Value,
                                                    Me.cboPriorität.Text, Me.tArchObjects,
                                                    Me.UDateAbgelegtVon.Value, Me.UDateAbgelegtBis.Value,
                                                    Me.cboSachbearbeiter.Text, False,
                                                    Me.UCheckEditorImGesamtarchivSuchen.Checked)
            End If

            Me.gridDocus.Refresh()

            If DsDokuSearch1.archDoku.Rows.Count <= 1000 Then
                Me.contOrdnerErgebniss.LoadSuchergebnis(Me.DsDokuSearch1, contOrdner.etyp.SuchergebnisseAnzeigen,
                        Me.RButtonOrdnerMitDokumente.Checked, nurPapierkorb)
            Else
                If Me.UTabDokumenteGefunden.ActiveTab.Index = 1 Then
                    If DsDokuSearch1.archDoku.Rows.Count > 1000 Then

                        'Me.contOrdnerErgebniss.LoadSuchergebnis(Me.DsDokuSearch1, contOrdner.etyp.SuchergebnisseAnzeigen, _
                        '                                        Me.RButtonOrdnerMitDokumente.Checked, nurPapierkorb)

                        Me.showErgebniss_ansicht(0)
                        Me.mainWindow.toolBarLocked = True
                        Dim statButt As StateButtonTool = Me.mainWindow.UToolbarsManagerMain.Tools("statButtTabelle")
                        statButt.Checked = True
                        Me.mainWindow.toolBarLocked = False
                    End If
                End If
            End If

            Me.genMain.GarbColl()
            Dim b As New PMDS.db.PMDSBusiness()
            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                'Dim tBenutzer As IQueryable(Of PMDS.db.Entities.Benutzer) = b.getAllUsers(db)
                For Each rRowGridDocu As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridDocus.Rows
                    Dim v As DataRowView = rRowGridDocu.ListObject
                    Dim rDocu As dsDokuSearch.archDokuRow = v.Row

                    Dim tArchObject As IQueryable(Of PMDS.db.Entities.archObject) = b.getDocumentObjects(rDocu.IDDoku, db)
                    Dim cIDObjects As New General.cObjectsRow()
                    Dim cIDContracts As New General.cObjectsRow()
                    Dim txtInsurance As String = ""
                    For Each rArchObject As PMDS.db.Entities.archObject In tArchObject
                        If b.checkPatientExists(rArchObject.IDObject, db) Then
                            Dim rPatient As PMDS.db.Entities.Patient = b.getPatient2(rArchObject.IDObject, db)
                            cIDObjects.lstObjects.Add(rArchObject.IDObject)
                            cIDObjects.txt += "" + rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim() + vbNewLine
                        Else
                            Dim bIsOtherObject As Boolean = True
                        End If
                    Next

                    rRowGridDocu.Cells(Me.colObject).Value = cIDObjects.txt.Trim()
                    rRowGridDocu.Cells(Me.colIDObject.Trim()).Value = cIDObjects

                    rRowGridDocu.Cells(Me.colContract).Value = cIDContracts.txt.Trim()
                    rRowGridDocu.Cells(Me.colIDContract.Trim()).Value = cIDContracts
                    rRowGridDocu.Cells(Me.colInsurance).Value = txtInsurance.Trim()
                Next
            End Using

            Me.mainWindow.toolBarLocked = False

            'If Me.dataDokumenteSuchen.tblDokumente.Rows.Count > 0 Then
            'Else
            'MsgBox(ui.GetResString("KeineDokumenteGefunden"), MsgBoxStyle.Information, "Archivsystem")
            'End If

            Me.setCaptionButtSuchen(Me.DsDokuSearch1.archDoku.Rows.Count)

            If nurPapierkorb Then
                If Me.DsDokuSearch1.archDoku.Rows.Count = 0 Then
                    doUI.doMessageBox2("TheTrashIsEmpty", "", "!")
                End If
            End If

        Catch ex As Exception
            Me.mainWindow.toolBarLocked = False
            Throw New Exception("contArchSuch.DokumentSuchen: " + ex.ToString())
        End Try
    End Sub

    Public Sub setCaptionButtSuchen(ByVal anz As Integer)
        Try
            If Not mainWindow Is Nothing Then
                If Me.mainWindow.UToolbarsManagerMain.Visible Then
                    If anz = 0 Then
                        Me.mainWindow.UToolbarsManagerMain.Tools("Suchen").SharedProps.Caption = doUI.getRes("Search")
                    Else
                        Me.mainWindow.UToolbarsManagerMain.Tools("Suchen").SharedProps.Caption = doUI.getRes("Search") + " (" + anz.ToString + ")"
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contArchSuch.setCaptionButtSuchen: " + ex.ToString())
        End Try
    End Sub

    Public Function getSuchtext() As String
        Try
            Dim txtTool As TextBoxTool = Me.mainWindow.UToolbarsManagerMain.Tools("txtDokumentname")
            If txtTool.Text = doUI.getRes("QuickSearchStrgF") Then
                Return ""
            Else
                Return txtTool.Text
            End If

        Catch ex As Exception
            Throw New Exception("contArchSuch.getSuchtext: " + ex.ToString())
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
            Throw New Exception("contArchSuch.setSuchtext: " + ex.ToString())
        End Try
    End Sub

    Public Function DateiLöschenSchnell(ByVal IDDoku As System.Guid, ByVal physisch As Boolean) As Boolean
        Try
            If Not gen.IsNull(IDDoku) Then
                Dim comp As New compDoku

                Dim rDoku As dbArchiv.archDokuRow = Me.compDoku1.getDokuRow(IDDoku, New dbArchiv)
                If Not rDoku Is Nothing Then
                    If Me.compDoku1.deleteDoku(rDoku.ID) Then
                        Me.contOrdnerErgebniss.DeleteDokument(rDoku.ID, True, Nothing)
                        Return True
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contArchSuch.DateiLöschenSchnell: " + ex.ToString())
        End Try
    End Function
    Public Function PapierkorbLeeren() As Boolean
        Try
            If doUI.doMessageBox3("DoYouRealyWantToClearTheTrash", "", MsgBoxStyle.YesNo, "?") = MsgBoxResult.Yes Then
                Dim IDordner As New System.Guid
                Dim rOrdPapierk As dbArchiv.archOrdnerRow = Me.compDoku1.getOrdnerRow(Nothing, compDoku.eTypSelOrd.getIDSys, New dbArchiv(), 1)
                If Not rOrdPapierk Is Nothing Then
                    Dim physisch As Boolean = True
                    Dim clSuchen As New sucheDoku()
                    Dim arr As New ArrayList
                    Dim DsDokuSearch1 As New dsDokuSearch()
                    Dim tArchObjectTemp As New dbArchiv.archObjectDataTable()
                    clSuchen.searchDocu(DsDokuSearch1, "", arr, arr, Nothing, Nothing, "", tArchObjectTemp,
                                                     Nothing, Nothing, "", True, True)
                    For Each r As dsDokuSearch.archDokuRow In DsDokuSearch1.archDoku
                        Try
                            If Not Me.DateiLöschenSchnell(r.IDDoku, physisch) Then
                                Throw New Exception("PapierkorbLeeren: error clear trash!")
                            End If
                        Catch ex As Exception
                            gen.GetEcxeptionGeneral(ex)
                        Finally
                        End Try
                    Next
                    Dim strTitle As String = doUI.getRes("Delete")
                    Dim strText As String = doUI.getRes("TrahsWasCleared") + vbNewLine + vbNewLine + doUI.getRes("ActivityPerformed2")
                    strText = String.Format(strText, DsDokuSearch1.archDoku.Rows.Count.ToString)
                    doUI.doMessageBoxTranslated(strText, strTitle, "!")

                Else
                    Throw New Exception("PapierkorbLeeren: No Trash existing!")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contArchSuch.PapierkorbLeeren: " + ex.ToString())
        End Try
    End Function

    Private Sub ArchivDokumentSuchen_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize

    End Sub
    Public Sub ResizeControl(ByVal h As Double, ByVal w As Double)
        Try

        Catch ex As Exception
            Throw New Exception("contArchSuch.ResizeControl: " + ex.ToString())
        End Try
    End Sub

    Private Sub ArchivOrdnerErgebniss_MouseUp()
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.contOrdnerErgebniss.ContextMenuStrip = Me.contMenüTree
            Me.contMenüTree.Show()

        Catch ex As Exception
            Throw New Exception("contArchSuch.ArchivOrdnerErgebniss_MouseUp: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub ArchivOrdnerErgebniss_Click()
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim IDOrdner As New System.Guid
            IDOrdner = Me.contOrdnerErgebniss.GetSelectedOrd()
            If Not gen.IsNull(IDOrdner) Then
                Me.contOrdnerErgebniss.ContextMenuStrip = Me.ContextMenuStripExportOrdner
            Else
                Me.contOrdnerErgebniss.ContextMenuStrip = Me.contMenüTree
                'Me.ContextMenuDokumenteExplorerS.Show()
            End If

        Catch ex As Exception
            Throw New Exception("contArchSuch.ArchivOrdnerErgebniss_Click: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub DateiÖffnenExplorer(ByVal openIntern As Boolean, ByVal withMsgBox As Boolean)
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim cTag As New General.clTagOrdner
            cTag = Me.contOrdnerErgebniss.GetSelTagInfo
            If gen.IsNull(cTag) Then Exit Sub
            If cTag.typ = General.clTagOrdner.eTyp.typDateiSuchen Then
                If Not gen.IsNull(cTag.ID) Then
                    If Not gen.IsNull(cTag.ID) Then
                        Me.contOrdnerErgebniss.openSaveDocu(cTag.ID, "O", openIntern, withMsgBox, False)
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contArchSuch.DateiÖffnenExplorer: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Function LoadInfoDokument(ByVal IDDoku As System.Guid) As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not gen.IsNull(IDDoku) Then
                Dim rDoku As dbArchiv.archDokuRow = Me.compDoku1.getDokuRow(IDDoku, New dbArchiv())
                If Not rDoku Is Nothing Then

                    Dim Info As String = ""
                    Info += doUI.getRes("Description") + ": " + rDoku.Bezeichnung + vbNewLine + vbNewLine

                    Info += doUI.getRes("ErstelltVon") + ": " + rDoku.AbgelegtVon.ToString + vbNewLine
                    Info += doUI.getRes("   ") + ": " + rDoku.AbgelegtAm.ToString + vbNewLine + vbNewLine

                    If Not rDoku.IsGültigVonNull() Then
                        Info += doUI.getRes("ValidFrom") + ": " + rDoku.GültigVon.ToString + vbNewLine
                    End If
                    If Not rDoku.IsGültigBisNull() Then
                        Info += doUI.getRes("ValidTo") + ": " + rDoku.GültigBis.ToString + vbNewLine
                    End If
                    Info += doUI.getRes("Importance") + ": " + rDoku.Wichtigkeit + vbNewLine + vbNewLine

                    Info += doUI.getRes("Type") + ": " + rDoku.DateinameTyp + vbNewLine
                    Info += doUI.getRes("SizeInByte") + ": " + rDoku.Größe.ToString + vbNewLine
                    Info += doUI.getRes("Zip") + ": " + rDoku.Winzip.ToString + vbNewLine + vbNewLine

                    'Info += "Dateiname Archiv: " + rDoku.DateinameArchiv + vbNewLine
                    'Info += "Archivordner: " + rDoku.Archivordner + vbNewLine + vbNewLine

                    Info += doUI.getRes("       ") + ": " + vbNewLine + rDoku.Notiz
                    Info += vbNewLine + vbNewLine + Me.gen.getInfo(rDoku.ID)
                    Dim frm As New frmInfo
                    frm.TextInfoDatei2.Text = Info
                    frm.ShowDialog(Me)
                Else
                    Throw New Exception("LoadInfoDokument: No Document found!")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contArchSuch.LoadInfoDokument: " + ex.ToString())
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

            Dim cTag As New General.clTagOrdner
            cTag = Me.contOrdnerErgebniss.GetSelTagInfo
            If gen.IsNull(cTag) Then Exit Sub
            If cTag.typ = General.clTagOrdner.eTyp.typDateiSuchen Then
                If Not gen.IsNull(cTag.ID) Then
                    If Not gen.IsNull(cTag.ID) Then
                        Me.contOrdnerErgebniss.openSaveDocu(cTag.ID, "S", False, True, False)
                    End If
                End If
            End If
        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MtemInfoDateiDokumentS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MtemInfoDateiDokumentS.Click
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim fInfo As New clFileInfo
            Dim cTag As New General.clTagOrdner
            cTag = Me.contOrdnerErgebniss.GetSelTagInfo()
            If gen.IsNull(cTag) Then Exit Sub
            If cTag.typ = General.clTagOrdner.eTyp.typDateiSuchen Then
                Me.LoadInfoDokument(cTag.ID)
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MItemSpeichernUnterListeS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MItemSpeichernUnterListeS.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            If Not gen.IsNull(Me.gridDocus.ActiveRow) Then
                Me.contOrdnerErgebniss.openSaveDocu(Me.gridDocus.ActiveRow.Cells("IDDoku").Value, "S", False, True, False)
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MItemInfoDokumentListeS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MItemInfoDokumentListeS.Click
        Dim General As New General()
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not General.IsNull(Me.gridDocus.ActiveRow) Then
                Dim text As String = ""
                Me.LoadInfoDokument(Me.gridDocus.ActiveRow.Cells("IDDoku").Value)
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub PanelOrdnerErgebisse_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PanelOrdnerErgebisse_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub
    Private Sub PanelOrdnerErgebisse_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor

            'Me.ArchivOrdnerSuchergebnisse.Width = Me.PanelOrdnerErgebisse.Width
            'Me.ArchivOrdnerSuchergebnisse.Height = Me.PanelOrdnerErgebisse.Height

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ÖffnenLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÖffnenLToolStripMenuItem.Click
        Try
            Me.dokuÖffnenGrid(False, True, False)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Public Sub dokuÖffnenGrid(ByVal openIntern As Boolean, ByVal withMsgBox As Boolean, ByVal printDocu As Boolean)
        Try
            Me.Cursor = Cursors.WaitCursor

            If Not gen.IsNull(Me.gridDocus.ActiveRow) Then
                If Not Me.gridDocus.ActiveRow.IsGroupByRow And Not Me.gridDocus.ActiveRow.IsFilterRow Then
                    If Me.gridDocus.ActiveRow.Cells.Exists("IDDoku") Then
                        If Not gen.IsNull(Me.gridDocus.ActiveRow.Cells("IDDoku").Value) Then
                            Me.contOrdnerErgebniss.openSaveDocu(Me.gridDocus.ActiveRow.Cells("IDDoku").Value, "O", openIntern, withMsgBox, printDocu)
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
    Private Sub ÖffnenEXToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÖffnenEXToolStripMenuItem.Click
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.DateiÖffnenExplorer(False, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
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

            Dim cTag As New General.clTagOrdner
            cTag = Me.contOrdnerErgebniss.GetSelTagInfo
            If gen.IsNull(cTag) Then Exit Sub
            If cTag.typ = General.clTagOrdner.eTyp.typDateiSuchen Then
                If Not gen.IsNull(cTag.ID) Then
                    If Not gen.IsNull(cTag.ID) Then
                        Dim cArchiv As New cArchive
                        If cArchiv.dokuInPapierkorb(cTag.ID, True) Then
                            Me.contOrdnerErgebniss.deleteSelectedFile()
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
    Private Sub InDenPapierkorbLIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InDenPapierkorbLIToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If gen.IsNull(Me.gridDocus.ActiveRow.Cells("IDOrdner").Value) Then Exit Sub
            Dim IDOrdner As New System.Guid(Me.gridDocus.ActiveRow.Cells("IDOrdner").Value.ToString)

            If gen.IsNull(IDOrdner) Then Exit Sub

            Me.deleteRowsGrid(True)
            'Me.Cursor = Cursors.WaitCursor
            'If Not gen.IsNull(Me.UGridDokumenteGefunden3.ActiveRow) Then
            '    Dim cArchiv As New ITSCont.core.SystemDb.cArchiv
            '    If cArchiv.dokuInPapierkorb(Me.UGridDokumenteGefunden3.ActiveRow.Cells("IDDoku").Value) Then
            '        Me.UGridDokumenteGefunden3.ActiveRow.Delete()
            '    End If
            'End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
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

            Dim cTag As New General.clTagOrdner
            cTag = Me.contOrdnerErgebniss.GetSelTagInfo
            If gen.IsNull(cTag) Then Exit Sub
            If cTag.typ = General.clTagOrdner.eTyp.typDateiSuchen Then
                If Not gen.IsNull(cTag.ID) Then
                    If Not gen.IsNull(cTag.ID) Then
                        Dim cArchiv As New cArchive
                        If cArchiv.deleteDokument(cTag.ID, True) Then
                            Me.contOrdnerErgebniss.deleteSelectedFile()
                            Me.contOrdnerErgebniss.DeleteDokument(cTag.ID, True, Nothing)
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
    Private Sub MItemDokumentLöschenOhnePapierkorbListeS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MItemDokumentLöschenOhnePapierkorbListeS.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            'If Not gen.IsNull(Me.UGridDokumenteGefunden3.ActiveRow) Then
            '    Dim cArchiv As New ITSCont.core.SystemDb.cArchiv
            '    If cArchiv.deleteDoku(Me.UGridDokumenteGefunden3.ActiveRow.Cells("IDDoku").Value, True) Then
            '        Me.UGridDokumenteGefunden3.ActiveRow.Delete()
            '    End If
            'End If
            Me.deleteRowsGrid(False)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Function deleteRowsGrid(ByVal Papierkorb As Boolean) As Boolean
        Try
            Dim cArchiv As New cArchive
            Dim rSelected As New System.Collections.Generic.List(Of Infragistics.Win.UltraWinGrid.UltraGridRow)
            PMDS.Global.generic.getSelectedGridRows(Me.gridDocus, rSelected, False)
            If rSelected.Count > 0 Then
                Dim txt As String = ""
                If Not Papierkorb Then
                    txt = doUI.getRes("WouldYouRealyWantToDeleteTheDocuments")
                Else
                    txt = doUI.getRes("WouldYouRealyWantToMoveTheDocumentsToTheTrash") '"Wollen Sie die Dokumente wirklich in den Papierkorb verschieben?"
                End If

                If MsgBox(txt, MsgBoxStyle.YesNo, "Delete") = MsgBoxResult.Yes Then
                    Dim cArchive1 As New cArchive()
                    For Each rGrid As Infragistics.Win.UltraWinGrid.UltraGridRow In rSelected
                        Dim v As DataRowView = rGrid.ListObject
                        Dim rDoku As dsDokuSearch.archDokuRow = v.Row

                        If Not Papierkorb Then
                            If cArchive1.deleteDokument(rDoku.IDDoku, False) Then
                                rDoku.Delete()
                            End If
                        Else
                            If cArchive1.dokuInPapierkorb(rDoku.IDDoku, False) Then
                                rDoku.Delete()
                            End If
                        End If
                    Next

                    Me.gridDocus.Refresh()
                    Return True
                End If
            Else
                doUI.doMessageBox2("NoEntrySelected", "", "!")
            End If

        Catch ex As Exception
            Throw New Exception("contArchSuch.deleteRowsGrid: " + ex.ToString())
        End Try
    End Function

    Public Sub neueNachricht_tree()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim IDOrdner As New System.Guid
            IDOrdner = Me.contOrdnerErgebniss.GetSelectedOrd_dokument()
            If gen.IsNull(IDOrdner) Then Exit Sub

            Dim cTag As New General.clTagOrdner
            cTag = Me.contOrdnerErgebniss.GetSelTagInfo
            If gen.IsNull(cTag) Then Exit Sub
            If cTag.typ = General.clTagOrdner.eTyp.typDateiSuchen Then
                If Not gen.IsNull(cTag.ID) Then
                    If Not gen.IsNull(cTag.ID) Then
                        Me.contOrdnerErgebniss.neueNachrichtZuDokumentErstellen(cTag.ID)
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contArchSuch.neueNachricht_tree: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub neueNachricht_grid()
        Try
            Me.Cursor = Cursors.WaitCursor

            If gen.IsNull(Me.gridDocus.ActiveRow.Cells("IDOrdner").Value) Then Exit Sub
            Dim IDOrdner As New System.Guid(Me.gridDocus.ActiveRow.Cells("IDOrdner").Value.ToString)

            If gen.IsNull(IDOrdner) Then Exit Sub

            Me.Cursor = Cursors.WaitCursor
            If Not gen.IsNull(Me.gridDocus.ActiveRow) Then
                Me.contOrdnerErgebniss.neueNachrichtZuDokumentErstellen(Me.gridDocus.ActiveRow.Cells("IDDoku").Value)
            End If

        Catch ex As Exception
            Throw New Exception("contArchSuch.neueNachricht_grid: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DokumentHinzufügenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DokumentHinzufügenToolStripMenuItem.Click
        Dim General As New General()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim IDOrdner As New System.Guid
            IDOrdner = Nothing
            IDOrdner = Me.contOrdnerErgebniss.GetSelectedOrd()
            Me.DokumentHinzufügen(IDOrdner)

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub DokumentHinzufügen(ByVal IDOrdner As System.Guid)
        Dim General As New General()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim frm As New frmArchAbleg
            frm.IDOrdnerToSelect = IDOrdner
            Dim FileToAdd As New clFileInfo
            Me.tArchObjects.CopyToDataTable(FileToAdd.tArchObject, LoadOption.OverwriteChanges)
            frm.ContArchAbleg1.arrFilesToSave.Add(FileToAdd)
            'frm.selectOrdner(IDOrdner)
            frm.ShowDialog(Me)

            If frm.ContArchAbleg1.dokumentAbgelegtCount > 0 Then
                If Me.mainWindow.startTyp = contArchMain.eStart.Search Then
                    Me.DokumentSuchen(False, False)
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contArchSuch.DokumentHinzufügen: " + ex.ToString())
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
            Throw New Exception("contArchSuch.Exploerer_Click: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub DokumentHinzufügenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DokumentHinzufügenToolStripMenuItem1.Click
        Dim General As New General()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim IDOrdner As New System.Guid
            IDOrdner = Nothing
            If Not gen.IsNull(Me.gridDocus.ActiveRow.Cells("IDOrdner").Value) Then
                IDOrdner = New System.Guid(Me.gridDocus.ActiveRow.Cells("IDOrdner").Value.ToString)
            End If
            Me.DokumentHinzufügen(IDOrdner)

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub RButtonAlleOrdner_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub PanelOrdnerErgebniss_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelOrdnerErgebniss.DoubleClick
        Try

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
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
            Throw New Exception("contArchSuch.showErgebniss_ansicht: " + ex.ToString())
        End Try
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

    Private Sub UGridSchlagwortkatalog_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles gridSchlagwortkatalog.CellChange
        Try
            Me.gridSchlagwortkatalog.UpdateData()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            neueNachricht_tree()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NeuenTerminErstellenmitDokumentAlsAnhangToolStripMenuItem1.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.neueNachricht_grid()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UGridDokumenteGefunden3_BeforeCellActivate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles gridDocus.BeforeCellActivate
        Try
            If e.Cell.Row.IsGroupByRow Or e.Cell.Row.IsFilterRow Then
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            Else
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If

            'If e.Cell.Column.ToString() = "ProzentsatzBerechnungsbasis" Then
            '    e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            'ElseIf e.Cell.Column.ToString() = "Ab" Then
            'End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub UGridDokumenteGefunden3_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles gridDocus.BeforeRowsDeleted
        Try
            e.DisplayPromptMsg = False

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub UGridDokumenteGefunden3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridDocus.DoubleClick
        Try
            Dim UIGlobal1 As New PMDS.Global.UIGlobal()
            If UIGlobal1.evDoubleClickOK(sender, e, Me.gridDocus) Then
                Me.dokuÖffnenGrid(False, True, False)
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub PanelOrdnerErgebniss_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PanelOrdnerErgebniss.Click
        Try

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub OrdnerMitDokumentenExportierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdnerMitDokumentenExportierenToolStripMenuItem.Click
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.contOrdnerErgebniss.VerzeichnisRausspielen(contOrdner.eDateiRausspielenName.Bezeichnung)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UGridSchlagwortkatalog_BeforeCellActivate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CancelableCellEventArgs) Handles gridSchlagwortkatalog.BeforeCellActivate
        Try
            If e.Cell.Column.ToString() = "Auswahl" Then
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
            Else
                e.Cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub FilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilterToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim ui As New UI()
            ui.setFilterGridKomplex(Me.gridDocus, Me.FilterToolStripMenuItem.Checked, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub GruppierungToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GruppierungToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            If Not Me.GruppierungToolStripMenuItem.Checked Then
                Me.gridDocus.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Vertical
            Else
                Me.gridDocus.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub WechselnZuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WechselnZuToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.WechselnZuGrid(False)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub InNeuemTabÖffnenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InNeuemTabÖffnenToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.WechselnZuGrid(True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Sub WechselnZuGrid(ByVal neuesTab As Boolean)
        Try
            If Not gen.IsNull(Me.gridDocus.ActiveRow) Then
                If Not Me.gridDocus.ActiveRow.IsGroupByRow And Not Me.gridDocus.ActiveRow.IsFilterRow Then
                    If Me.gridDocus.ActiveRow.Cells.Exists("IDDoku") Then
                        If Not gen.IsNull(Me.gridDocus.ActiveRow.Cells("IDDoku").Value) Then
                            'Dim obj As ITSCont.core.SystemDb.UI.cObjectsRow = Me.gridDocus.ActiveRow.Cells(Me.colIDObject.Trim()).Value         'lthNotPossibleAK
                            'Dim contract As ITSCont.core.SystemDb.UI.cObjectsRow = Me.gridDocus.ActiveRow.Cells(Me.colIDContract.Trim()).Value

                            'ui1.wechselnZuObjectDocuUI(Me.gridDocus.ActiveRow.Cells("IDDoku").Value, neuesTab, True, obj, contract)
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contArchSuch.WechselnZuGrid: " + ex.ToString())
        End Try
    End Sub

    Private Sub WechselnZuToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WechselnZuToolStripMenuItem1.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.WechselnZuTree(True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub InNeuemTabÖffnenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InNeuemTabÖffnenToolStripMenuItem1.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.WechselnZuTree(True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Sub WechselnZuTree(ByVal neuesTab As Boolean)
        Try
            Dim cTag As New General.clTagOrdner
            cTag = Me.contOrdnerErgebniss.GetSelTagInfo
            If gen.IsNull(cTag) Then Exit Sub
            If cTag.typ = General.clTagOrdner.eTyp.typDateiSuchen Then
                If Not gen.IsNull(cTag.ID) Then
                    If Not gen.IsNull(cTag.ID) Then
                        'Dim appManag1 As New ITSCont.core.SystemDb.appManag       'lthNotPossibleAK
                        'appManag1.wechselnZuObjectDocu(cTag.ID, neuesTab, True)
                    End If
                End If
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub DateiÖffnenMitInternemEditorTreeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateiÖffnenMitInternemEditorTreeToolStripMenuItem.Click
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.DateiÖffnenExplorer(True, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub DateiÖffnenMitInternemEditorGridToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateiÖffnenMitInternemEditorGridToolStripMenuItem1.Click
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.dokuÖffnenGrid(True, True, False)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub doActionDocusGrid(ByVal bSelect As Boolean, ByVal typAction As eDoAction, ByVal withMsgBox As Boolean,
                                 ByRef lstSelRowsDocus As System.Collections.Generic.List(Of dsDokuSearch.archDokuRow))
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim compDokuWork As compDoku
            Dim dbArchivRead As dbArchiv

            'Dim selRowDocu As UltraGridRow = Nothing
            'Dim rSelDocu As dsDokuSearch.archDokuRow = Me.getSelectedDocu(withMsgBox, selRowDocu)
            Dim retMsgBox As MsgBoxResult = MsgBoxResult.Yes
            If withMsgBox Then

                If typAction = eDoAction.WebFreigebenAgent Then
                    retMsgBox = doUI.doMessageBox3("ReleaseAllSelectedDocumentsForTheWeb", "", MsgBoxStyle.YesNo, "?")
                ElseIf typAction = eDoAction.WebSperrenAgent Then
                    retMsgBox = doUI.doMessageBox3("BlockAllSelectedDocumentsForTheWeb", "", MsgBoxStyle.YesNo, "?")

                ElseIf typAction = eDoAction.WebFreigebenKunde Then
                    retMsgBox = doUI.doMessageBox3("ReleaseAllSelectedDocumentsForCustomerInTheWeb", "", MsgBoxStyle.YesNo, "?")
                ElseIf typAction = eDoAction.WebSperrenKunde Then
                    retMsgBox = doUI.doMessageBox3("BlockAllSelectedDocumentsForTheCustomersInTheWeb", "", MsgBoxStyle.YesNo, "?")
                End If

            End If

            If typAction = eDoAction.AllSelectedDocusOpenAsOneIntEditor Then
                compDokuWork = New compDoku()
                dbArchivRead = New dbArchiv()
            End If

            If retMsgBox <> MsgBoxResult.Yes Then
                Exit Sub
            End If

            Dim bSelectedOnly As Boolean = False
            If typAction <> eDoAction.selection Then
                bSelectedOnly = True
            End If

            Dim anz As Integer = 0
            Dim selectedRows As UltraGridRow() = PMDS.Global.generic.GetAllRowsFromGroupedUltraGrid(Me.gridDocus, bSelectedOnly, True)
            If selectedRows.Count > 0 Then
                For Each r As UltraGridRow In selectedRows
                    If PMDS.Global.generic.IsInExpandedGroup(r) Then
                        Dim v As DataRowView = r.ListObject
                        Dim rActuellDocu As dsDokuSearch.archDokuRow = v.Row

                        If typAction = eDoAction.selection Then
                            r.Selected = bSelect
                            anz += 1

                        ElseIf typAction = eDoAction.getSelectedRows Then
                            lstSelRowsDocus.Add(rActuellDocu)
                            anz += 1

                        ElseIf typAction = eDoAction.AllSelectedDocusOpenAsOneIntEditor Then
                            If Not rActuellDocu.IsbinInternNull() Then
                                compDokuWork.getDoku(rActuellDocu.IDDoku, compDoku.eTypSelDoku.id, dbArchivRead, "")
                                anz += 1
                            End If

                        ElseIf typAction = eDoAction.WebFreigebenAgent Or typAction = eDoAction.WebSperrenAgent Then

                            Dim intReleasedAgent As Boolean = False
                            If typAction = eDoAction.WebFreigebenAgent Then
                                intReleasedAgent = True
                            ElseIf typAction = eDoAction.WebSperrenAgent Then
                                intReleasedAgent = False
                            End If
                            Me.compDoku1.UpdateDokuIntReleased(rActuellDocu.IDDoku, intReleasedAgent)
                            rActuellDocu.intReleased = intReleasedAgent
                            anz += 1

                        ElseIf typAction = eDoAction.WebFreigebenKunde Or typAction = eDoAction.WebSperrenKunde Then

                            Dim IDTyp As String = ""
                            If typAction = eDoAction.WebFreigebenKunde Then
                                IDTyp = "K"
                            ElseIf typAction = eDoAction.WebSperrenKunde Then
                                IDTyp = ""
                            End If
                            Me.compDoku1.UpdateDokuIDTyp(rActuellDocu.IDDoku, IDTyp)
                            rActuellDocu.IDTyp = IDTyp
                            anz += 1

                        End If
                    End If
                Next

                If typAction <> eDoAction.selection Then
                    If anz > 0 Then
                        Me.gridDocus.Refresh()
                        Me.gridDocus.UpdateData()
                    End If
                End If

                If withMsgBox Then
                    If typAction = eDoAction.WebFreigebenAgent Or typAction = eDoAction.WebSperrenAgent Or
                        typAction = eDoAction.WebFreigebenKunde Or typAction = eDoAction.WebSperrenKunde Then

                        Dim strTitle As String = doUI.getRes("Save")
                        Dim strText As String = doUI.getRes("ActivityPerformed2")
                        strText = String.Format(strText, anz.ToString())
                        doUI.doMessageBoxTranslated(strText, strTitle, "!")
                        If anz > 0 Then
                            'Me.searchEntriesForActivity(rSelActivity.ID)
                        End If

                    ElseIf typAction = eDoAction.AllSelectedDocusOpenAsOneIntEditor Then
                        Me.gen.openDocus(dbArchivRead, doUI.getRes("SelectedDocumentsFromArchive"), Me.TextControlToWork)
                    End If
                End If

            Else
                If withMsgBox Then
                    doUI.doMessageBox2("NoEntrySelected", "", "!")
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contArchSuch.doActionDocusGrid: " + ex.ToString())
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Function getSelectedDocu(ByVal withMsgBox As Boolean, ByRef rowGrid As UltraGridRow) As dsDokuSearch.archDokuRow
        Try
            If Not Me.gridDocus.ActiveRow Is Nothing Then
                If Me.gridDocus.ActiveRow.IsGroupByRow Or Me.gridDocus.ActiveRow.IsFilterRow Then
                    If withMsgBox Then
                        doUI.doMessageBox2("NoEntrySelected", "", "!")
                        Me.gridDocus.Focus()
                    End If
                    rowGrid = Nothing
                    Return Nothing
                Else
                    Dim v As DataRowView = Me.gridDocus.ActiveRow.ListObject
                    Dim rSelDocu As dsDokuSearch.archDokuRow = v.Row
                    rowGrid = Me.gridDocus.ActiveRow
                    Return rSelDocu
                End If
            Else
                If withMsgBox Then
                    doUI.doMessageBox2("NoEntrySelected", "", "!")
                    Me.gridDocus.Focus()
                End If
                rowGrid = Nothing
                Return Nothing
            End If

        Catch ex As Exception
            Throw New Exception("contArchSuch.getSelectedDocu: " + ex.ToString())
        End Try
    End Function
    Private Sub AusgewählteDokumenteFürDasWebFreigebenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AusgewählteDokumenteFürDasWebFreigebenToolStripMenuItem1.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim lstSelRowsDocus As New System.Collections.Generic.List(Of dsDokuSearch.archDokuRow)()
            Me.doActionDocusGrid(False, eDoAction.WebFreigebenAgent, True, lstSelRowsDocus)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub AusgewählteDokumenteFürDasWebSperrenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AusgewählteDokumenteFürDasWebSperrenToolStripMenuItem1.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim lstSelRowsDocus As New System.Collections.Generic.List(Of dsDokuSearch.archDokuRow)()
            Me.doActionDocusGrid(False, eDoAction.WebSperrenAgent, True, lstSelRowsDocus)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub AlleAuswählenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlleAuswählenToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim lstSelRowsDocus As New System.Collections.Generic.List(Of dsDokuSearch.archDokuRow)()
            Me.doActionDocusGrid(True, eDoAction.selection, False, lstSelRowsDocus)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub KeineAuswählenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeineAuswählenToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim lstSelRowsDocus As New System.Collections.Generic.List(Of dsDokuSearch.archDokuRow)()
            Me.doActionDocusGrid(False, eDoAction.selection, False, lstSelRowsDocus)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub AlleAusgewähltenInternenDokumenteAlsEinDokumentÖffnenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlleAusgewähltenInternenDokumenteAlsEinDokumentÖffnenToolStripMenuItem1.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim lstSelRowsDocus As New System.Collections.Generic.List(Of dsDokuSearch.archDokuRow)()
            Me.doActionDocusGrid(False, eDoAction.AllSelectedDocusOpenAsOneIntEditor, True, lstSelRowsDocus)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub DruckenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DruckenToolStripMenuItem.Click
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.dokuÖffnenGrid(False, True, True)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub AusgewählteDokumenteFürDenKundenImWebFreigebenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AusgewählteDokumenteFürDenKundenImWebFreigebenToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim lstSelRowsDocus As New System.Collections.Generic.List(Of dsDokuSearch.archDokuRow)()
            Me.doActionDocusGrid(False, eDoAction.WebFreigebenKunde, True, lstSelRowsDocus)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub AusgewählteDokumenteFürDenKundenImWebSperrenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AusgewählteDokumenteFürDenKundenImWebSperrenToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim lstSelRowsDocus As New System.Collections.Generic.List(Of dsDokuSearch.archDokuRow)()
            Me.doActionDocusGrid(False, eDoAction.WebSperrenKunde, True, lstSelRowsDocus)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub LayoutManagerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LayoutManagerToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor


        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub DokumentEditierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DokumentEditierenToolStripMenuItem.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Dim lstSelRowsDocus As New System.Collections.Generic.List(Of dsDokuSearch.archDokuRow)()
            Me.doActionDocusGrid(False, eDoAction.getSelectedRows, False, lstSelRowsDocus)
            If lstSelRowsDocus.Count > 0 Then
                Dim bOK As Boolean = Me.editDokument(lstSelRowsDocus)
                'If newDocumentName.Trim() <> "" Then
                '    Me.gridDocus.ActiveRow.Cells("Bezeichnung").Value = newDocumentName.Trim()
                'End If
            End If

            'If Not gen.IsNull(Me.gridDocus.ActiveRow) Then
            '    If Not Me.gridDocus.ActiveRow.IsGroupByRow And Not Me.gridDocus.ActiveRow.IsFilterRow Then
            '        If Me.gridDocus.ActiveRow.Cells.Exists("IDDoku") Then
            '            Dim view As DataRowView = Me.gridDocus.ActiveRow.ListObject
            '            Dim rArchDoku As dsDokuSearch.archDokuRow = view.Row
            '            If Not gen.IsNull(Me.gridDocus.ActiveRow.Cells("IDDoku").Value) Then
            '                Dim newDocumentName As String = Me.editDokument(Me.gridDocus.ActiveRow.Cells("IDDoku").Value).Trim()
            '                If newDocumentName.Trim() <> "" Then
            '                    Me.gridDocus.ActiveRow.Cells("Bezeichnung").Value = newDocumentName.Trim()
            '                End If
            '            End If
            '        End If
            '    End If
            'End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub DokumentEditierenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DokumentEditierenToolStripMenuItem1.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            'Dim fInfo As New ITSCont.core.SystemDb.clFileInfo
            'Dim cTag As New ITSCont.core.SystemDb.clTagOrdner
            'cTag = Me.contOrdnerErgebniss.GetSelTagInfo()
            'If gen.IsNull(cTag) Then Exit Sub
            'If cTag.typ = ITSCont.core.SystemDb.clTagOrdner.eTyp.typDateiSuchen Then
            '    If Me.editDokument(cTag.ID).Trim() <> "" Then

            '    End If
            'End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Public Function editDokument(ByRef lstSelRowsDocus As System.Collections.Generic.List(Of dsDokuSearch.archDokuRow)) As Boolean
        Try
            Dim frmEditDocu1 As New frmEditDocu()
            frmEditDocu1.initControl()
            frmEditDocu1.ContEditDocument1.loadData(lstSelRowsDocus)
            frmEditDocu1.ShowDialog(Me)
            If Not frmEditDocu1.ContEditDocument1.abort Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("contArchSuch.editDokument: " + ex.ToString())
        End Try
    End Function

    Private Sub contArchSuch_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Not Me.IsInitializedVisible And Me.Visible Then
                Dim newRessourcesAdded As Integer = 0
                'Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)
                'Me.doUI1.runComponents_rek(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, Nothing)
                Me.IsInitializedVisible = True
            End If

        Catch ex As Exception
            Me.gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

End Class
