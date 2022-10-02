Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing



Public Class contArchAbleg
    Inherits System.Windows.Forms.UserControl

    Private gen As New General

    Public mainWindow As frmArchAbleg

    Private ArchivOrdnerAblegen As New contOrdner2

    Public Enum eTyp
        Benutzer = 0
    End Enum

    Public compDoku1 As New compDoku

    'Public tArchivObjectsxy As New ITSCont.core.SystemDb.dbArchiv.archObjectDataTable()

    'Public contZwischenablage As contZwischenablage
    Public parentWindow As frmArchAbleg

    Public dokumentAbgelegtCount As Integer = 0
    Public acP As New System.Drawing.Point
    Public arrFilesToDelete As New ArrayList
    Public ui1 As New UI

    Public typSaveDocu As New doDoc.eTypSaveDocu
    Public arrFilesToSave As New System.Collections.Generic.List(Of clFileInfo)

    Public anzFilesToAdded As Integer = 0
    Public doUI1 As New doUI()





    'Friend WithEvents ArchivOrdner1 As S2Archivsystem.ArchivOrdner
    Friend WithEvents contextMenü1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuItemDokumentAuswählenS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MItemAusPostboxHinzufügenS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuItemDokumentLöschenS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelOrdnerAblegen As System.Windows.Forms.Panel
    Friend WithEvents AusZwischenablageEinfügenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents UDateGültigBis As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UDateGültigVon As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UComboWichtigkeit As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UTextNotiz As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Public WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Public WithEvents UltraButtonAbbrechen As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ArchivDokumentAblegen_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents gridSchlagwortkatalog As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraExpandableGroupBox1 As Infragistics.Win.Misc.UltraExpandableGroupBox
    Friend WithEvents UltraExpandableGroupBoxPanel1 As Infragistics.Win.Misc.UltraExpandableGroupBoxPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PanelUnten As System.Windows.Forms.Panel
    Friend WithEvents PanelUntenButton As System.Windows.Forms.Panel
    Friend WithEvents layButtonUnten As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents DsAuswahllisten1 As dsAuswahllisten
    Friend WithEvents ImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ObjektdokumenteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents UltraButtonSpeichern As Infragistics.Win.Misc.UltraButton
    Friend WithEvents NachVertragsNrToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PoliccenNrToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboStatus As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents cboTyp As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblActivities As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents UltraLabel8 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblFoldersTitle As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents VertragsdokumenteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem




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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contArchAbleg))
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem9 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("SelListHelper", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ID")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDGuid")
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnInt")
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDOwnStr")
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IDRessource")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Description")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Auswahl", 0)
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.PanelOrdnerAblegen = New System.Windows.Forms.Panel()
        Me.contextMenü1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuItemDokumentAuswählenS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MItemAusPostboxHinzufügenS = New System.Windows.Forms.ToolStripMenuItem()
        Me.AusZwischenablageEinfügenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ObjektdokumenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VertragsdokumenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NachVertragsNrToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PoliccenNrToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuItemDokumentLöschenS = New System.Windows.Forms.ToolStripMenuItem()
        Me.UDateGültigBis = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.UDateGültigVon = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UComboWichtigkeit = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.UTextNotiz = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.UltraButtonAbbrechen = New Infragistics.Win.Misc.UltraButton()
        Me.ArchivDokumentAblegen_Fill_Panel = New System.Windows.Forms.Panel()
        Me.PanelUnten = New System.Windows.Forms.Panel()
        Me.PanelUntenButton = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.UltraExpandableGroupBox1 = New Infragistics.Win.Misc.UltraExpandableGroupBox()
        Me.UltraExpandableGroupBoxPanel1 = New Infragistics.Win.Misc.UltraExpandableGroupBoxPanel()
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblActivities = New Infragistics.Win.Misc.UltraLabel()
        Me.cboStatus = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.cboTyp = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.gridSchlagwortkatalog = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.DsAuswahllisten1 = New PMDS.GUI.VB.dsAuswahllisten()
        Me.UltraLabel8 = New Infragistics.Win.Misc.UltraLabel()
        Me.lblFoldersTitle = New Infragistics.Win.Misc.UltraLabel()
        Me.layButtonUnten = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.UltraButtonSpeichern = New Infragistics.Win.Misc.UltraButton()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.contextMenü1.SuspendLayout()
        CType(Me.UDateGültigBis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDateGültigVon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UComboWichtigkeit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UTextNotiz, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ArchivDokumentAblegen_Fill_Panel.SuspendLayout()
        Me.PanelUnten.SuspendLayout()
        Me.PanelUntenButton.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.UltraExpandableGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraExpandableGroupBox1.SuspendLayout()
        Me.UltraExpandableGroupBoxPanel1.SuspendLayout()
        CType(Me.cboStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTyp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridSchlagwortkatalog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAuswahllisten1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layButtonUnten, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelOrdnerAblegen
        '
        Me.PanelOrdnerAblegen.BackColor = System.Drawing.Color.White
        Me.PanelOrdnerAblegen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelOrdnerAblegen.ContextMenuStrip = Me.contextMenü1
        Me.PanelOrdnerAblegen.Location = New System.Drawing.Point(11, 25)
        Me.PanelOrdnerAblegen.Name = "PanelOrdnerAblegen"
        Me.PanelOrdnerAblegen.Size = New System.Drawing.Size(337, 450)
        Me.PanelOrdnerAblegen.TabIndex = 0
        '
        'contextMenü1
        '
        Me.contextMenü1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemDokumentAuswählenS, Me.ToolStripMenuItem2, Me.MItemAusPostboxHinzufügenS, Me.AusZwischenablageEinfügenToolStripMenuItem, Me.ImportToolStripMenuItem, Me.ToolStripMenuItem1, Me.MenuItemDokumentLöschenS})
        Me.contextMenü1.Name = "ContextMenuDokumentAngebenS"
        Me.contextMenü1.Size = New System.Drawing.Size(233, 126)
        '
        'MenuItemDokumentAuswählenS
        '
        Me.MenuItemDokumentAuswählenS.Name = "MenuItemDokumentAuswählenS"
        Me.MenuItemDokumentAuswählenS.Size = New System.Drawing.Size(232, 22)
        Me.MenuItemDokumentAuswählenS.Tag = "ResID.SelectADocument"
        Me.MenuItemDokumentAuswählenS.Text = "Dokument auswählen"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(229, 6)
        '
        'MItemAusPostboxHinzufügenS
        '
        Me.MItemAusPostboxHinzufügenS.Name = "MItemAusPostboxHinzufügenS"
        Me.MItemAusPostboxHinzufügenS.Size = New System.Drawing.Size(232, 22)
        Me.MItemAusPostboxHinzufügenS.Tag = "ResID.AddFromPostbox"
        Me.MItemAusPostboxHinzufügenS.Text = "Aus Postbox hinzufügen"
        '
        'AusZwischenablageEinfügenToolStripMenuItem
        '
        Me.AusZwischenablageEinfügenToolStripMenuItem.Name = "AusZwischenablageEinfügenToolStripMenuItem"
        Me.AusZwischenablageEinfügenToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.AusZwischenablageEinfügenToolStripMenuItem.Tag = "ResID.PasteFromClipboard"
        Me.AusZwischenablageEinfügenToolStripMenuItem.Text = "Aus Zwischenablage einfügen"
        Me.AusZwischenablageEinfügenToolStripMenuItem.Visible = False
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ObjektdokumenteToolStripMenuItem, Me.VertragsdokumenteToolStripMenuItem})
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(232, 22)
        Me.ImportToolStripMenuItem.Tag = "ResID.Import"
        Me.ImportToolStripMenuItem.Text = "Import"
        '
        'ObjektdokumenteToolStripMenuItem
        '
        Me.ObjektdokumenteToolStripMenuItem.Name = "ObjektdokumenteToolStripMenuItem"
        Me.ObjektdokumenteToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.ObjektdokumenteToolStripMenuItem.Tag = "ResID.DocumentsForObjects"
        Me.ObjektdokumenteToolStripMenuItem.Text = "Dokumente für Objekte"
        '
        'VertragsdokumenteToolStripMenuItem
        '
        Me.VertragsdokumenteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NachVertragsNrToolStripMenuItem, Me.PoliccenNrToolStripMenuItem})
        Me.VertragsdokumenteToolStripMenuItem.Name = "VertragsdokumenteToolStripMenuItem"
        Me.VertragsdokumenteToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.VertragsdokumenteToolStripMenuItem.Tag = "ResID.DocumentsForContracts"
        Me.VertragsdokumenteToolStripMenuItem.Text = "Dokumente für Verträge"
        '
        'NachVertragsNrToolStripMenuItem
        '
        Me.NachVertragsNrToolStripMenuItem.Name = "NachVertragsNrToolStripMenuItem"
        Me.NachVertragsNrToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.NachVertragsNrToolStripMenuItem.Tag = "ResID.ContractNo"
        Me.NachVertragsNrToolStripMenuItem.Text = "Vertrags-Nr"
        '
        'PoliccenNrToolStripMenuItem
        '
        Me.PoliccenNrToolStripMenuItem.Name = "PoliccenNrToolStripMenuItem"
        Me.PoliccenNrToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.PoliccenNrToolStripMenuItem.Tag = "ResID.PolicyNr"
        Me.PoliccenNrToolStripMenuItem.Text = "PoliccenNr"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(229, 6)
        '
        'MenuItemDokumentLöschenS
        '
        Me.MenuItemDokumentLöschenS.Name = "MenuItemDokumentLöschenS"
        Me.MenuItemDokumentLöschenS.Size = New System.Drawing.Size(232, 22)
        Me.MenuItemDokumentLöschenS.Tag = "ResID.Delete"
        Me.MenuItemDokumentLöschenS.Text = "Löschen"
        '
        'UDateGültigBis
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.UDateGültigBis.Appearance = Appearance1
        Me.UDateGültigBis.BackColor = System.Drawing.Color.White
        Me.UDateGültigBis.Location = New System.Drawing.Point(82, 52)
        Me.UDateGültigBis.Name = "UDateGültigBis"
        Me.UDateGültigBis.Size = New System.Drawing.Size(104, 21)
        Me.UDateGültigBis.TabIndex = 1
        '
        'UltraLabel6
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Appearance2.TextHAlignAsString = "Right"
        Me.UltraLabel6.Appearance = Appearance2
        Me.UltraLabel6.Location = New System.Drawing.Point(-16, 54)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(92, 16)
        Me.UltraLabel6.TabIndex = 464
        Me.UltraLabel6.Tag = "ResID.ValidTo"
        Me.UltraLabel6.Text = "bis"
        '
        'UltraLabel2
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.TextHAlignAsString = "Right"
        Me.UltraLabel2.Appearance = Appearance3
        Me.UltraLabel2.Location = New System.Drawing.Point(-16, 33)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(92, 16)
        Me.UltraLabel2.TabIndex = 462
        Me.UltraLabel2.Tag = "ResID.ValidFrom"
        Me.UltraLabel2.Text = "Gültigkeit von"
        '
        'UDateGültigVon
        '
        Appearance4.BackColor = System.Drawing.Color.White
        Me.UDateGültigVon.Appearance = Appearance4
        Me.UDateGültigVon.BackColor = System.Drawing.Color.White
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        Me.UDateGültigVon.DropDownAppearance = Appearance5
        Me.UDateGültigVon.Location = New System.Drawing.Point(82, 31)
        Me.UDateGültigVon.Name = "UDateGültigVon"
        Me.UDateGültigVon.Size = New System.Drawing.Size(104, 21)
        Me.UDateGültigVon.TabIndex = 0
        '
        'UComboWichtigkeit
        '
        Appearance6.BackColor = System.Drawing.Color.White
        Me.UComboWichtigkeit.Appearance = Appearance6
        Me.UComboWichtigkeit.BackColor = System.Drawing.Color.White
        Me.UComboWichtigkeit.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UComboWichtigkeit.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        ValueListItem7.DataValue = "H"
        ValueListItem7.DisplayText = "Hoch"
        ValueListItem8.DataValue = "M"
        ValueListItem8.DisplayText = "Mittel"
        ValueListItem9.DataValue = "N"
        ValueListItem9.DisplayText = "Niedrig"
        Me.UComboWichtigkeit.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem7, ValueListItem8, ValueListItem9})
        Me.UComboWichtigkeit.Location = New System.Drawing.Point(267, 32)
        Me.UComboWichtigkeit.Name = "UComboWichtigkeit"
        Me.UComboWichtigkeit.Size = New System.Drawing.Size(89, 19)
        Me.UComboWichtigkeit.TabIndex = 2
        '
        'UltraLabel3
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.ForeColor = System.Drawing.Color.Black
        Appearance7.TextHAlignAsString = "Right"
        Me.UltraLabel3.Appearance = Appearance7
        Me.UltraLabel3.Location = New System.Drawing.Point(189, 33)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(75, 16)
        Me.UltraLabel3.TabIndex = 459
        Me.UltraLabel3.Tag = "ResID.Importance"
        Me.UltraLabel3.Text = "Wichtigkeit"
        '
        'UTextNotiz
        '
        Appearance8.BackColor = System.Drawing.Color.White
        Appearance8.FontData.SizeInPoints = 10.0!
        Me.UTextNotiz.Appearance = Appearance8
        Me.UTextNotiz.BackColor = System.Drawing.Color.White
        Me.UTextNotiz.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UTextNotiz.Location = New System.Drawing.Point(8, 188)
        Me.UTextNotiz.Multiline = True
        Me.UTextNotiz.Name = "UTextNotiz"
        Me.UTextNotiz.Scrollbars = System.Windows.Forms.ScrollBars.Both
        Me.UTextNotiz.Size = New System.Drawing.Size(349, 79)
        Me.UTextNotiz.TabIndex = 6
        Me.UTextNotiz.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'UltraLabel1
        '
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel1.Appearance = Appearance9
        Me.UltraLabel1.Location = New System.Drawing.Point(7, 171)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(156, 16)
        Me.UltraLabel1.TabIndex = 466
        Me.UltraLabel1.Tag = "ResID.Notice"
        Me.UltraLabel1.Text = "Notiz"
        '
        'btnSave
        '
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.Location = New System.Drawing.Point(19, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(102, 27)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Tag = "ResID.Save"
        Me.btnSave.Text = "Speichern"
        '
        'UltraButtonAbbrechen
        '
        Me.UltraButtonAbbrechen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UltraButtonAbbrechen.Location = New System.Drawing.Point(121, 3)
        Me.UltraButtonAbbrechen.Name = "UltraButtonAbbrechen"
        Me.UltraButtonAbbrechen.Size = New System.Drawing.Size(81, 27)
        Me.UltraButtonAbbrechen.TabIndex = 1
        Me.UltraButtonAbbrechen.Tag = "ResID.Abort"
        Me.UltraButtonAbbrechen.Text = "Abbrechen"
        '
        'ArchivDokumentAblegen_Fill_Panel
        '
        Me.ArchivDokumentAblegen_Fill_Panel.BackColor = System.Drawing.Color.White
        Me.ArchivDokumentAblegen_Fill_Panel.Controls.Add(Me.PanelUnten)
        Me.ArchivDokumentAblegen_Fill_Panel.Controls.Add(Me.Panel2)
        Me.ArchivDokumentAblegen_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ArchivDokumentAblegen_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ArchivDokumentAblegen_Fill_Panel.Location = New System.Drawing.Point(0, 0)
        Me.ArchivDokumentAblegen_Fill_Panel.Name = "ArchivDokumentAblegen_Fill_Panel"
        Me.ArchivDokumentAblegen_Fill_Panel.Size = New System.Drawing.Size(754, 512)
        Me.ArchivDokumentAblegen_Fill_Panel.TabIndex = 2
        '
        'PanelUnten
        '
        Me.PanelUnten.Controls.Add(Me.PanelUntenButton)
        Me.PanelUnten.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelUnten.Location = New System.Drawing.Point(0, 479)
        Me.PanelUnten.Name = "PanelUnten"
        Me.PanelUnten.Size = New System.Drawing.Size(754, 33)
        Me.PanelUnten.TabIndex = 2
        '
        'PanelUntenButton
        '
        Me.PanelUntenButton.Controls.Add(Me.btnSave)
        Me.PanelUntenButton.Controls.Add(Me.UltraButtonAbbrechen)
        Me.PanelUntenButton.Location = New System.Drawing.Point(274, 0)
        Me.PanelUntenButton.Name = "PanelUntenButton"
        Me.PanelUntenButton.Size = New System.Drawing.Size(205, 33)
        Me.PanelUntenButton.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.PanelOrdnerAblegen)
        Me.Panel2.Controls.Add(Me.UltraExpandableGroupBox1)
        Me.Panel2.Controls.Add(Me.lblFoldersTitle)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(754, 512)
        Me.Panel2.TabIndex = 0
        '
        'UltraExpandableGroupBox1
        '
        Me.UltraExpandableGroupBox1.Controls.Add(Me.UltraExpandableGroupBoxPanel1)
        Me.UltraExpandableGroupBox1.Expanded = False
        Me.UltraExpandableGroupBox1.ExpandedSize = New System.Drawing.Size(390, 450)
        Appearance31.FontData.SizeInPoints = 10.0!
        Me.UltraExpandableGroupBox1.HeaderAppearance = Appearance31
        Me.UltraExpandableGroupBox1.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion
        Me.UltraExpandableGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.LeftInsideBorder
        Me.UltraExpandableGroupBox1.Location = New System.Drawing.Point(352, 25)
        Me.UltraExpandableGroupBox1.Name = "UltraExpandableGroupBox1"
        Me.UltraExpandableGroupBox1.Size = New System.Drawing.Size(29, 450)
        Me.UltraExpandableGroupBox1.TabIndex = 1
        Me.UltraExpandableGroupBox1.Tag = "ResID.AdvancedInformation"
        Me.UltraExpandableGroupBox1.Text = "Erweiterte Angaben"
        Me.UltraExpandableGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP
        '
        'UltraExpandableGroupBoxPanel1
        '
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel5)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel4)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.lblActivities)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.cboStatus)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.cboTyp)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UComboWichtigkeit)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel3)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UDateGültigVon)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.gridSchlagwortkatalog)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UTextNotiz)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel2)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UDateGültigBis)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel6)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel1)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel8)
        Me.UltraExpandableGroupBoxPanel1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraExpandableGroupBoxPanel1.Name = "UltraExpandableGroupBoxPanel1"
        Me.UltraExpandableGroupBoxPanel1.Size = New System.Drawing.Size(363, 444)
        Me.UltraExpandableGroupBoxPanel1.TabIndex = 0
        Me.UltraExpandableGroupBoxPanel1.Visible = False
        '
        'UltraLabel5
        '
        Appearance10.BackColor = System.Drawing.Color.Transparent
        Appearance10.TextHAlignAsString = "Right"
        Me.UltraLabel5.Appearance = Appearance10
        Me.UltraLabel5.Location = New System.Drawing.Point(-16, 111)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(92, 16)
        Me.UltraLabel5.TabIndex = 478
        Me.UltraLabel5.Tag = "ResID.Status"
        Me.UltraLabel5.Text = "Status"
        '
        'UltraLabel4
        '
        Appearance11.BackColor = System.Drawing.Color.Transparent
        Appearance11.TextHAlignAsString = "Right"
        Me.UltraLabel4.Appearance = Appearance11
        Me.UltraLabel4.Location = New System.Drawing.Point(-16, 89)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(92, 16)
        Me.UltraLabel4.TabIndex = 477
        Me.UltraLabel4.Tag = "ResID.Type"
        Me.UltraLabel4.Text = "Typ"
        Me.UltraLabel4.Visible = False
        '
        'lblActivities
        '
        Appearance12.BackColor = System.Drawing.Color.Transparent
        Appearance12.ForeColor = System.Drawing.Color.Black
        Appearance12.ForeColorDisabled = System.Drawing.Color.Black
        Appearance12.TextHAlignAsString = "Right"
        Appearance12.TextVAlignAsString = "Middle"
        Me.lblActivities.Appearance = Appearance12
        Me.lblActivities.Location = New System.Drawing.Point(-16, 137)
        Me.lblActivities.Name = "lblActivities"
        Me.lblActivities.Size = New System.Drawing.Size(92, 17)
        Me.lblActivities.TabIndex = 476
        Me.lblActivities.Tag = "ResID.Activities"
        Me.lblActivities.Text = "Aktivitäten"
        '
        'cboStatus
        '
        Appearance13.FontData.Name = "Microsoft Sans Serif"
        Me.cboStatus.Appearance = Appearance13
        Me.cboStatus.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboStatus.AutoSize = False
        Me.cboStatus.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched
        Me.cboStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance14.BackColor = System.Drawing.Color.White
        Appearance14.BackColorDisabled = System.Drawing.Color.White
        Appearance14.BorderColor = System.Drawing.Color.Black
        Appearance14.ForeColor = System.Drawing.Color.Black
        Appearance14.ForeColorDisabled = System.Drawing.Color.Black
        Me.cboStatus.ItemAppearance = Appearance14
        Me.cboStatus.Location = New System.Drawing.Point(82, 108)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(190, 23)
        Me.cboStatus.TabIndex = 4
        '
        'cboTyp
        '
        Appearance15.FontData.Name = "Microsoft Sans Serif"
        Me.cboTyp.Appearance = Appearance15
        Me.cboTyp.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboTyp.AutoSize = False
        Me.cboTyp.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched
        Me.cboTyp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance16.BackColor = System.Drawing.Color.White
        Appearance16.BackColorDisabled = System.Drawing.Color.White
        Appearance16.BorderColor = System.Drawing.Color.Black
        Appearance16.ForeColor = System.Drawing.Color.Black
        Appearance16.ForeColorDisabled = System.Drawing.Color.Black
        Me.cboTyp.ItemAppearance = Appearance16
        Me.cboTyp.Location = New System.Drawing.Point(82, 82)
        Me.cboTyp.Name = "cboTyp"
        Me.cboTyp.Size = New System.Drawing.Size(190, 23)
        Me.cboTyp.TabIndex = 3
        Me.cboTyp.Visible = False
        '
        'gridSchlagwortkatalog
        '
        Me.gridSchlagwortkatalog.DataMember = "SelListHelper"
        Me.gridSchlagwortkatalog.DataSource = Me.DsAuswahllisten1
        Appearance17.BackColor = System.Drawing.Color.White
        Appearance17.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.gridSchlagwortkatalog.DisplayLayout.Appearance = Appearance17
        Me.gridSchlagwortkatalog.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        UltraGridColumn1.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn1.Header.VisiblePosition = 0
        UltraGridColumn1.Hidden = True
        UltraGridColumn14.Header.VisiblePosition = 1
        UltraGridColumn14.Hidden = True
        UltraGridColumn2.Header.VisiblePosition = 2
        UltraGridColumn2.Hidden = True
        UltraGridColumn16.Header.VisiblePosition = 3
        UltraGridColumn16.Hidden = True
        UltraGridColumn17.Header.VisiblePosition = 5
        UltraGridColumn17.Hidden = True
        UltraGridColumn18.Header.VisiblePosition = 6
        UltraGridColumn13.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.None
        UltraGridColumn13.DataType = GetType(Boolean)
        UltraGridColumn13.Header.VisiblePosition = 4
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn14, UltraGridColumn2, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn13})
        Me.gridSchlagwortkatalog.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.gridSchlagwortkatalog.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance18.BackColor = System.Drawing.Color.FloralWhite
        Me.gridSchlagwortkatalog.DisplayLayout.CaptionAppearance = Appearance18
        Me.gridSchlagwortkatalog.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[True]
        Appearance19.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance19.BorderColor = System.Drawing.SystemColors.Window
        Me.gridSchlagwortkatalog.DisplayLayout.GroupByBox.Appearance = Appearance19
        Appearance20.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridSchlagwortkatalog.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance20
        Me.gridSchlagwortkatalog.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.gridSchlagwortkatalog.DisplayLayout.GroupByBox.Prompt = "Ziehen Sie eine Spalte herein  nach der Sie gruppieren möchten:"
        Appearance21.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance21.BackColor2 = System.Drawing.SystemColors.Control
        Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance21.ForeColor = System.Drawing.SystemColors.GrayText
        Me.gridSchlagwortkatalog.DisplayLayout.GroupByBox.PromptAppearance = Appearance21
        Me.gridSchlagwortkatalog.DisplayLayout.MaxColScrollRegions = 1
        Me.gridSchlagwortkatalog.DisplayLayout.MaxRowScrollRegions = 1
        Appearance22.BackColor = System.Drawing.SystemColors.Window
        Appearance22.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gridSchlagwortkatalog.DisplayLayout.Override.ActiveCellAppearance = Appearance22
        Appearance23.BackColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(255, Byte), Integer))
        Appearance23.ForeColor = System.Drawing.Color.White
        Me.gridSchlagwortkatalog.DisplayLayout.Override.ActiveRowAppearance = Appearance23
        Me.gridSchlagwortkatalog.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.gridSchlagwortkatalog.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance24.BackColor = System.Drawing.SystemColors.Window
        Me.gridSchlagwortkatalog.DisplayLayout.Override.CardAreaAppearance = Appearance24
        Me.gridSchlagwortkatalog.DisplayLayout.Override.CardSpacing = 0
        Appearance25.BorderColor = System.Drawing.Color.Silver
        Appearance25.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.gridSchlagwortkatalog.DisplayLayout.Override.CellAppearance = Appearance25
        Me.gridSchlagwortkatalog.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.gridSchlagwortkatalog.DisplayLayout.Override.CellPadding = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.CellSpacing = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.DefaultRowHeight = 1
        Me.gridSchlagwortkatalog.DisplayLayout.Override.FilterRowSpacingAfter = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.FilterRowSpacingBefore = 0
        Appearance26.BackColor = System.Drawing.SystemColors.Control
        Appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance26.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance26.BorderColor = System.Drawing.SystemColors.Window
        Me.gridSchlagwortkatalog.DisplayLayout.Override.GroupByRowAppearance = Appearance26
        Me.gridSchlagwortkatalog.DisplayLayout.Override.GroupByRowPadding = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.GroupByRowSpacingAfter = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.GroupByRowSpacingBefore = 0
        Appearance27.TextHAlignAsString = "Left"
        Me.gridSchlagwortkatalog.DisplayLayout.Override.HeaderAppearance = Appearance27
        Me.gridSchlagwortkatalog.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.gridSchlagwortkatalog.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.XPThemed
        Appearance28.BackColor = System.Drawing.SystemColors.Window
        Appearance28.BorderColor = System.Drawing.Color.Silver
        Me.gridSchlagwortkatalog.DisplayLayout.Override.RowAppearance = Appearance28
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
        Appearance29.BackColor = System.Drawing.SystemColors.ControlLight
        Me.gridSchlagwortkatalog.DisplayLayout.Override.TemplateAddRowAppearance = Appearance29
        Me.gridSchlagwortkatalog.DisplayLayout.Override.TemplateAddRowSpacingAfter = 0
        Me.gridSchlagwortkatalog.DisplayLayout.Override.TemplateAddRowSpacingBefore = 0
        Me.gridSchlagwortkatalog.DisplayLayout.RowConnectorColor = System.Drawing.Color.FloralWhite
        Me.gridSchlagwortkatalog.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None
        Me.gridSchlagwortkatalog.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.gridSchlagwortkatalog.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.gridSchlagwortkatalog.Location = New System.Drawing.Point(8, 270)
        Me.gridSchlagwortkatalog.Name = "gridSchlagwortkatalog"
        Me.gridSchlagwortkatalog.Size = New System.Drawing.Size(349, 171)
        Me.gridSchlagwortkatalog.TabIndex = 7
        Me.gridSchlagwortkatalog.Tag = "ResID.Catchword"
        Me.gridSchlagwortkatalog.Text = "Schlagwörter"
        '
        'DsAuswahllisten1
        '
        Me.DsAuswahllisten1.DataSetName = "dsAuswahllisten"
        Me.DsAuswahllisten1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UltraLabel8
        '
        Appearance30.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel8.Appearance = Appearance30
        Me.UltraLabel8.Location = New System.Drawing.Point(3, 6)
        Me.UltraLabel8.Name = "UltraLabel8"
        Me.UltraLabel8.Size = New System.Drawing.Size(297, 16)
        Me.UltraLabel8.TabIndex = 479
        Me.UltraLabel8.Tag = "ResID.GeneralInformationAboutTheDocument"
        Me.UltraLabel8.Text = "Allgemeine Angaben zum Dokument"
        '
        'lblFoldersTitle
        '
        Appearance32.BackColor = System.Drawing.Color.Transparent
        Me.lblFoldersTitle.Appearance = Appearance32
        Me.lblFoldersTitle.Location = New System.Drawing.Point(13, 10)
        Me.lblFoldersTitle.Name = "lblFoldersTitle"
        Me.lblFoldersTitle.Size = New System.Drawing.Size(293, 14)
        Me.lblFoldersTitle.TabIndex = 478
        Me.lblFoldersTitle.Tag = "ResID.ClickAFolderAndSelectADocument"
        Me.lblFoldersTitle.Text = "Ordner anklicken und Dokument auswählen"
        '
        'layButtonUnten
        '
        Me.layButtonUnten.ContainerControl = Me.PanelUnten
        Me.layButtonUnten.ExpandToFitHeight = True
        Me.layButtonUnten.ExpandToFitWidth = True
        '
        'UltraButtonSpeichern
        '
        Me.UltraButtonSpeichern.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UltraButtonSpeichern.Location = New System.Drawing.Point(19, 3)
        Me.UltraButtonSpeichern.Name = "UltraButtonSpeichern"
        Me.UltraButtonSpeichern.Size = New System.Drawing.Size(102, 27)
        Me.UltraButtonSpeichern.TabIndex = 0
        Me.UltraButtonSpeichern.Text = "Speichern"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'contArchAbleg
        '
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ArchivDokumentAblegen_Fill_Panel)
        Me.DoubleBuffered = True
        Me.Name = "contArchAbleg"
        Me.Size = New System.Drawing.Size(754, 512)
        Me.contextMenü1.ResumeLayout(False)
        CType(Me.UDateGültigBis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDateGültigVon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UComboWichtigkeit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UTextNotiz, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ArchivDokumentAblegen_Fill_Panel.ResumeLayout(False)
        Me.PanelUnten.ResumeLayout(False)
        Me.PanelUntenButton.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.UltraExpandableGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraExpandableGroupBox1.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.PerformLayout()
        CType(Me.cboStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTyp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridSchlagwortkatalog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAuswahllisten1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layButtonUnten, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub Dokument_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub


    Public Sub initForm(ByVal IDOrdner As System.Guid)
        Try
            'Dim uiMenü As New clUIElements
            'Me.contZwischenablage = New contZwischenablage
            'uiMenü.Menu_loadContainer(Me.UltraToolbarsManager1, 0, Me.contZwischenablage, "Zwischenablage")

            'ImportVerzeichnisseToolStripMenuItem.Visible = True

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.UltraButtonSpeichern.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)
            Me.MenuItemDokumentAuswählenS.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_folder, 32, 32)
            Me.MenuItemDokumentLöschenS.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)
            Me.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)

            Dim dsAuswahList As New dsAuswahllisten()
            Dim MaxIDSelListEntryReturn As Integer = -1
            Dim tSelListEntriesReturn As System.Collections.Generic.List(Of PMDS.db.Entities.tblSelListEntries) = Nothing
            Me.gen.loadSelList(Nothing, Me.cboStatus, "STATPA", tSelListEntriesReturn, General.eKeyCol.IDStr, MaxIDSelListEntryReturn)

            Me.LoadOrdnerIntoPanels()
            Me.resetForm(IDOrdner)

            Dim d_evHandClick As New dArchiv.Funct(AddressOf Me.ArchivOrdner_Click)
            Me.ArchivOrdnerAblegen.delClick.RegisterDelegate(d_evHandClick)

            Dim d_evHandDragDrop As New dArchiv.Funct(AddressOf Me.DateiEinfügenDragDrop)
            Me.ArchivOrdnerAblegen.delDragDrop.RegisterDelegate(d_evHandDragDrop)
            Me.ArchivOrdnerAblegen.initTree_icons(False)

            If Me.arrFilesToSave.Count = 1 Then
                If Me.arrFilesToSave(0).tArchObject.Rows.Count = 1 Then
                    Dim rArchObject As dbArchiv.archObjectRow = Me.arrFilesToSave(0).tArchObject.Rows(0)
                    Dim b As New PMDS.db.PMDSBusiness()
                    Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                        Dim rPatient As PMDS.db.Entities.Patient = b.getPatient2(rArchObject.IDObject, db)
                        Me.mainWindow.Text = doUI.getRes("SaveDocumentFor") + " " + rPatient.Nachname.Trim() + " " + rPatient.Vorname.Trim()
                    End Using
                ElseIf Me.arrFilesToSave(0).tArchObject.Rows.Count > 1 Then
                    Dim txt As String = doUI.getRes("StoreDocumentsForXRelationships")
                    txt = String.Format(txt, Me.arrFilesToSave(0).tArchObject.Rows.Count.ToString())
                    Me.mainWindow.Text = txt
                End If

            ElseIf Me.arrFilesToSave.Count > 1 Then
                Dim countBeziehungen As Integer = 0
                For Each fileInfo As clFileInfo In Me.arrFilesToSave
                    countBeziehungen += 1
                Next
                Dim txt As String = doUI.getRes("StoreDocumentsForXRelationships")
                txt = String.Format(txt, Me.arrFilesToSave(0).tArchObject.Rows.Count.ToString())
                Me.mainWindow.Text = txt
            Else
                Throw New Exception("initForm: arrFilesToSave.Count=0, no Documents for save!")
            End If

            If Me.typSaveDocu = doDoc.eTypSaveDocu.addFiles Then
                'Me.arrFilesToSave.Clear()

            ElseIf Me.typSaveDocu = doDoc.eTypSaveDocu.selectOrdner Then
                Me.PanelOrdnerAblegen.ContextMenu = Nothing
                Me.lblFoldersTitle.Text = doUI.getRes("SelectFolder")

            End If

        Catch ex As Exception
            Throw New Exception("contArchAbleg.initForm: " + ex.ToString())
        End Try
    End Sub

    Public Sub LoadOrdnerIntoPanels()
        Try

            Me.ArchivOrdnerAblegen = New contOrdner2
            Me.PanelOrdnerAblegen.Controls.Add(Me.ArchivOrdnerAblegen)
            Me.ArchivOrdnerAblegen.Dock = DockStyle.Fill
            Me.ArchivOrdnerAblegen.modalusrCont = Me
            Me.ArchivOrdnerAblegen.hidePanelUnten()

            Me.ArchivOrdnerAblegen.initControl()

        Catch ex As Exception
            Throw New Exception("contArchAbleg.LoadOrdnerIntoPanels: " + ex.ToString())
        End Try
    End Sub

    Public Sub resetForm(ByVal IDOrdner As System.Guid)
        Try

            Me.LoadOrdner(IDOrdner)
            Me.UDateGültigVon.Value = Nothing
            Me.UDateGültigBis.Value = Nothing
            Me.UComboWichtigkeit.SelectedIndex = 1
            Me.UTextNotiz.Text = ""
            Me.LoadSchlagwortkatalog()
            Me.arrFilesToDelete.Clear()
            Me.arrFilesToDelete = New ArrayList

        Catch ex As Exception
            Throw New Exception("contArchAbleg.resetForm: " + ex.ToString())
        End Try
    End Sub

    Public Sub LoadOrdner(ByVal IDOrdner As System.Guid)
        Try

            Me.ArchivOrdnerAblegen.LoadOrdnerbaum(contOrdner.etyp.Ablegen, IDOrdner)

        Catch ex As Exception
            Throw New Exception("contArchAbleg.LoadOrdner: " + ex.ToString())
        End Try
    End Sub

    Public Sub LoadSchlagwortkatalog()
        Try
            Me.compDoku1.getAuswahlisten2(Me.DsAuswahllisten1, "SW", General.eKeyCol.Guid)
            Me.gridSchlagwortkatalog.Refresh()
            Me.gridSchlagwortkatalog.Rows.ExpandAll(True)

        Catch ex As Exception
            Throw New Exception("contArchAbleg.LoadSchlagwortkatalog: " + ex.ToString())
        End Try
    End Sub

    Private Sub UltraTabControl1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs)
        Try

            If e.Tab.Index = 4 Then
                Application.DoEvents()
                Me.UTextNotiz.Focus()
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Public Sub AusPostboxHinzufügenxy(ByVal typ As eTyp)
        Try

            'If Not gen.IsNull(Me.ArchivOrdnerAblegen.GetSelectedOrdner()) Then
            '    Dim frmPost As New FrmPostbox2()

            '    frmPost.IDOrdner = Me.ArchivOrdnerAblegen.GetSelectedOrdner()
            '    frmPost.ShowDialog(Me)
            '    If Not frmPost.apport Then

            '        For Each file As String In frmPost.arrÜbernehmen
            '            Me.loadFile(file)
            '        Next
            '        Dim bDeleteFiles As Boolean = False
            '        If frmPost.UCheckEditorDateienLöschen.Checked Then
            '            bDeleteFiles = True
            '            For Each file As String In frmPost.arrÜbernehmen
            '                Me.arrFilesToDelete.Add(file)
            '            Next
            '        End If
            '    End If
            'Else
            '    doUI.doMessageBox("NoFolderSelected", "", "!")
            'End If

        Catch ex As Exception
            Throw New Exception("contArchAbleg.AusPostboxHinzufügenxy: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub clearErrorProvider()
        Try
            Me.ErrorProvider1.SetError(Me.cboTyp, "")
            Me.ErrorProvider1.SetError(Me.cboStatus, "")
            Me.ErrorProvider1.SetError(Me.PanelOrdnerAblegen, "")

        Catch ex As Exception
            Throw New Exception("contArchAbleg.clearErrorProvider: " + ex.ToString())
        End Try
    End Sub
    Public Function checkInput() As Boolean
        Try

            If Me.typSaveDocu = doDoc.eTypSaveDocu.addFiles Then

            ElseIf Me.typSaveDocu = doDoc.eTypSaveDocu.selectOrdner Then
                Dim IDOrdnerSelected As System.Guid = Me.ArchivOrdnerAblegen.GetSelectedOrd()
                If Me.gen.IsNull(IDOrdnerSelected) Then
                    Dim txtErr As String = doUI.getRes("NoFolderSelected")
                    Me.ErrorProvider1.SetError(Me.PanelOrdnerAblegen, "Fehler Eingabe")
                    doUI.doMessageBox2("NoFolderSelected", "", "!")
                    Return False
                End If
            End If

            If Not Me.ui1.checkComboBox(Me.cboTyp, False) Then
                Me.cboTyp.Focus()
                Me.ErrorProvider1.SetError(Me.cboTyp, doUI.getRes("ErrorInput"))
                Return False
            End If

            If Not Me.ui1.checkComboBox(Me.cboStatus, False) Then
                Me.cboStatus.Focus()
                Me.ErrorProvider1.SetError(Me.cboStatus, doUI.getRes("ErrorInput"))
                Return False
            End If


            Return True

        Catch ex As Exception
            Throw New Exception("contArchAbleg.checkInput: " + ex.ToString())
        End Try
    End Function
    Public Function DokumentSichern() As Integer
        Try
            Dim genMain As New General
            genMain.GarbColl()

            If Me.typSaveDocu = doDoc.eTypSaveDocu.addFiles Then
                Me.arrFilesToSave.Clear()
                Me.arrFilesToSave = Me.ArchivOrdnerAblegen.GetFileInfoDateiAblegen_rek(Nothing, True)

            ElseIf Me.typSaveDocu = doDoc.eTypSaveDocu.selectOrdner Then
                Dim IDOrdnerSelected As System.Guid = Me.ArchivOrdnerAblegen.GetSelectedOrd()
                For Each info As clFileInfo In Me.arrFilesToSave
                    info.file_IDOrdner = IDOrdnerSelected
                Next

            End If

            Dim Schlagwörter As New ArrayList()
            For Each rGrid As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.gridSchlagwortkatalog.Rows
                Dim v As DataRowView = rGrid.ListObject
                Dim rAuswList As dsAuswahllisten.SelListHelperRow = v.Row
                If rGrid.Cells("Auswahl").Value = True Then
                    Schlagwörter.Add(rAuswList.Description.Trim())
                End If
            Next

            Dim sTyp As String = ""
            If Not Me.gen.IsNull(Me.cboTyp.Value) Then
                sTyp = Me.cboTyp.Value
            End If
            Dim sStatus As String = ""
            If Not Me.gen.IsNull(Me.cboStatus.Value) Then
                sStatus = Me.cboStatus.Value
            End If

            Dim IDActivity As System.Guid = Nothing

            Dim clSave As New cArchive
            Dim ret As New cArchive.clRet
            ret = clSave.saveDoku(Me.arrFilesToSave, Me.UTextNotiz.Text, UDateGültigVon.Value, UDateGültigBis.Value,
                                                  Me.UComboWichtigkeit.Text,
                                                  Me.arrFilesToDelete, Schlagwörter, sTyp, sStatus, IDActivity)
            If ret.OK Then
                'MsgBox("Das Dokument wurde ins Archiv abgelegt!" + vbNewLine + _
                '            "Anzahl" + " " + arrInfo.Count.ToString, MsgBoxStyle.Information, "Archivsystem")

                'arrInfo = Nothing
                Me.resetForm(Nothing)
                Me.arrFilesToDelete = New ArrayList
                ' Me.contZwischenablage.loadClipboard()
                Me.dokumentAbgelegtCount = Me.arrFilesToSave.Count
                Return Me.arrFilesToSave.Count
            Else
                Throw New Exception("DokumentSichern: Error save a Document!")
            End If

            Me.dokumentAbgelegtCount = 0
            Return 0

        Catch ex As Exception
            Throw New Exception("contArchAbleg.DokumentSichern: " + ex.ToString())
        End Try
    End Function

    Public Function DateiPhysischSpeichern(ByVal DateinameArchiv As String, ByVal fileB() As Byte) As Boolean
        Try

            Dim fileToSave As New FileStream(DateinameArchiv, FileMode.CreateNew)
            Dim bw As New BinaryWriter(fileToSave)
            bw.Write(fileB)

            Dim info As New System.IO.FileInfo(DateinameArchiv)
            info.IsReadOnly = False

            bw.Close()
            fileToSave.Close()
            Return True

        Catch ex As Exception
            Throw New Exception("contArchAbleg.DateiPhysischSpeichern: " + ex.ToString())
        End Try
    End Function


    Public Function loadFile(ByVal file As String) As Boolean
        Try
            Dim funct1 As New QS2.functions.vb.FileFunctions()
            If System.IO.File.Exists(file) Then
                If System.IO.Directory.Exists(funct1.GetDir(file)) Then
                    If gen.IsNull(funct1.GetFiletyp(file)) Then
                        Throw New Exception("loadFile: Error reading File - No File-Type!")
                        Return False
                    End If
                    If gen.IsNull(funct1.GetFileName(file, False)) Then
                        Throw New Exception("loadFile: Error reading FileName!")
                        Return False
                    End If
                    Dim doDoc1 As New doDoc()
                    'If Me.arrFilesToSave.Count > 0 Then
                    '    Throw New Exception("loadFile: arrFilesToSave.Count > 0!")
                    'End If

                    Dim FileToAddFirst As clFileInfo = Me.arrFilesToSave(0)
                    If Me.anzFilesToAdded = 0 Then
                        Dim FileToAdd As clFileInfo = Me.arrFilesToSave(0)
                        doDoc1.setFileInfo(file, FileToAdd.tArchObject, FileToAdd)

                        Dim frm As New frmSelectDocuName()
                        If FileToAdd.bezeichnung.Trim() <> "" Then
                            frm.initControl(FileToAdd.bezeichnung.Trim())
                        Else
                            frm.initControl(FileToAdd.file_name.Trim())
                        End If
                        frm.ShowDialog(Me)
                        If Not frm.ContSelectDocuName1.abort Then
                            Me.ArchivOrdnerAblegen.AddDokumenteToInsertxy(FileToAdd, frm.ContSelectDocuName1.cboDocumentNames.Text.Trim())
                            Me.anzFilesToAdded += 1
                            Return True
                        End If

                    ElseIf Me.arrFilesToSave.Count > 0 Then
                        Dim FileNewToAdd As New clFileInfo()
                        FileToAddFirst.tArchObject.CopyToDataTable(FileNewToAdd.tArchObject, LoadOption.OverwriteChanges)
                        doDoc1.setFileInfo(file, FileNewToAdd.tArchObject, FileNewToAdd)
                        Me.arrFilesToSave.Add(FileNewToAdd)

                        Dim frm As New frmSelectDocuName()
                        If FileNewToAdd.bezeichnung.Trim() <> "" Then
                            frm.initControl(FileNewToAdd.bezeichnung.Trim())
                        Else
                            frm.initControl(FileNewToAdd.file_name.Trim())
                        End If
                        frm.ShowDialog(Me)
                        If Not frm.ContSelectDocuName1.abort Then
                            Me.ArchivOrdnerAblegen.AddDokumenteToInsertxy(FileNewToAdd, frm.ContSelectDocuName1.cboDocumentNames.Text.Trim())
                            Me.anzFilesToAdded += 1
                            Return True
                        End If

                    Else
                        Throw New Exception("contArchAbleg.loadFile: Me.arrFilesToSave.Count=0!")
                    End If
                Else
                    Throw New Exception("contArchAbleg.loadFile: Error reading File - File-Folder not exists!")
                End If
            Else
                Throw New Exception("contArchAbleg.loadFile: Error reading File - Filenot exists!")
            End If

        Catch ex As Exception
            Throw New Exception("contArchAbleg.loadFile: " + ex.ToString())
        End Try
    End Function

    Private Sub ArchivOrdner_Click()
        Dim gen As New General
        Try
            If Me.typSaveDocu = doDoc.eTypSaveDocu.addFiles Then
                Me.Cursor = Cursors.WaitCursor

                Dim fInfo As New clFileInfo
                Dim cTag As New General.clTagOrdner
                cTag = Me.ArchivOrdnerAblegen.GetSelTagInfo()
                Dim IDOrdner As New System.Guid
                IDOrdner = Me.ArchivOrdnerAblegen.GetSelectedOrd()
                If Not gen.IsNull(IDOrdner) Then
                    Me.contextMenü1.Show(Me, acP)
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contArchAbleg.ArchivOrdner_Click: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub ResizeControl(ByVal h As Double, ByVal w As Double)
        Dim gen As New General
        Try
            Me.Width = w
            Me.Height = h

        Catch ex As Exception
            Throw New Exception("contArchAbleg.ResizeControl: " + ex.ToString())
        End Try
    End Sub

    Private Sub MenuItemDokumentAuswählenS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDokumentAuswählenS.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim IDOrdner As New System.Guid
            IDOrdner = Me.ArchivOrdnerAblegen.GetSelectedOrd()
            If gen.IsNull(IDOrdner) Then
                doUI.doMessageBox2("NoEntrySelected", "", "!")
                Exit Sub
            End If
            If Me.checkRechtOrdnerFürDokumentAblegen(IDOrdner) Then
                Me.SelectFile()
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Function SelectFile() As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim funct1 As New QS2.functions.vb.FileFunctions()
            Dim selectedFile As String = ""
            selectedFile = funct1.SelectFileDialog("All Files (*.*)|*.*|" +
                        "Microsoft Word Files (*.doc)|*.doc|" +
                        "Microsoft Excel Files (*.xls)|*.xls|" +
                        "Text Files (*.txt)|*.txt|" +
                        "pdf Files (*.pdf)|*.pdf|" +
                        "rtf Files (*.Rtf)|*.rtf", "")

            If Not gen.IsNull(selectedFile) Then
                Me.loadFile(selectedFile)
            End If

        Catch ex As Exception
            Throw New Exception("contArchAbleg.SelectFile: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Public Function checkRechtOrdnerFürDokumentAblegen(ByRef IDOrdner As System.Guid) As Boolean
        Dim gen As New General
        Try

            Return True

        Catch ex As Exception
            Throw New Exception("contArchAbleg.checkRechtOrdnerFürDokumentAblegen: " + ex.ToString())
        End Try
    End Function

    Private Sub MenuItemDokumentLöschenS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDokumentLöschenS.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.ArchivOrdnerAblegen.DeleteSelectedDokumentBeforeInsert()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub PanelOrdnerAblegen_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelOrdnerAblegen.MouseUp
        Try
            Me.contextMenü1.Show(Me, e.Location())
        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub

    Private Sub PanelOrdnerAblegen_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelOrdnerAblegen.Resize
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ArchivOrdnerAblegen.Width = Me.PanelOrdnerAblegen.Width
            Me.ArchivOrdnerAblegen.Height = Me.PanelOrdnerAblegen.Height

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub AusZwischenablageEinfügenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AusZwischenablageEinfügenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            'Dim IDOrdner As New System.Guid
            'IDOrdner = Me.ArchivOrdnerAblegen.GetSelectedOrd()
            'If gen.IsNull(IDOrdner) Then
            '    MsgBox("Keinen Ordner ausgewählt!", MsgBoxStyle.Information, "Archivsystem")
            'End If
            'If Me.checkRechtOrdnerFürDokumentAblegen(IDOrdner) Then

            '    Dim genMain As New ITSCont.core.SystemDb.General
            '    genMain.GarbColl()

            '    If Not gen.IsNull(Me.contZwischenablage.DateiKopieren) Then
            '        Me.loadFile(Me.contZwischenablage.DateiKopieren)
            '    ElseIf Not gen.IsNull(Me.contZwischenablage.DateiAusschneiden) Then
            '        Me.loadFile(Me.contZwischenablage.DateiAusschneiden)
            '        If System.IO.File.Exists(Me.contZwischenablage.DateiAusschneiden) Then
            '            Me.arrFilesToDelete.Add(Me.contZwischenablage.DateiAusschneiden)
            '        End If
            '    Else
            '        MsgBox("Es wurde keine Datei in der Zwischenablage zum Einfügen ausgewählt!", MsgBoxStyle.Information, "Archivsystem")
            '    End If
            'End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub DateiEinfügenDragDrop()
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim IDOrdner As New System.Guid
            IDOrdner = Me.ArchivOrdnerAblegen.GetSelectedOrd()
            If gen.IsNull(IDOrdner) Then
                doUI.doMessageBox2("NoEntrySelected", "", "!")
                Exit Sub
            End If

            Dim genMain As New General
            genMain.GarbColl()

            If Me.checkRechtOrdnerFürDokumentAblegen(IDOrdner) Then
                If Not gen.IsNull(Me.ArchivOrdnerAblegen.fileDragDrop) Then
                    Me.loadFile(Me.ArchivOrdnerAblegen.fileDragDrop)
                    If doUI.doMessageBox3("ShouldTheFileDeletedFromTheClipboard", "", MsgBoxStyle.YesNo, "?") = MsgBoxResult.Yes Then
                        Me.arrFilesToDelete.Add(Me.ArchivOrdnerAblegen.fileDragDrop)
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("contArchAbleg.DateiEinfügenDragDrop: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UltraButtonSpeichern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click, UltraButtonSpeichern.Click
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.clearErrorProvider()
            If Me.checkInput() Then
                Me.DokumentSichern()
                Me.parentWindow.Close()
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UltraButtonAbbrechen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButtonAbbrechen.Click
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.parentWindow.Close()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub selectOrdner(ByVal IDOrdner As System.Guid)
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.ArchivOrdnerAblegen.SelectOrdner(IDOrdner)

        Catch ex As Exception
            Throw New Exception("contArchAbleg.selectOrdner: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UltraToolbarsManager1_ToolClick_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor


            Select Case e.Tool.Key

                Case "Schließen"
                    Me.parentWindow.Close()

            End Select

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UltraExpandableGroupBox1_ExpandedStateChanging(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles UltraExpandableGroupBox1.ExpandedStateChanging
        Try
            If UltraExpandableGroupBox1.Focused Then Me.mainWindow.showErweitertEinAus(Me.UltraExpandableGroupBox1.Expanded)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub ObjektdokumenteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObjektdokumenteToolStripMenuItem.Click
        Try
            Me.importDokumente("O")

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Public Sub importDokumente(ByVal typ As String)
        Dim gen As New General
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim frmUsrInput As New frmUserInput()
            frmUsrInput.setUI(frmUserInput.eTypeUI.SelectNameFromComboBox)
            frmUsrInput.ShowDialog(Me)
            If frmUsrInput.abort Then
                Exit Sub
            End If

            Dim IDOrdner As New System.Guid
            IDOrdner = Me.ArchivOrdnerAblegen.GetSelectedOrd()
            If gen.IsNull(IDOrdner) Then
                doUI.doMessageBox2("NoEntrySelected", "", "!")
                Exit Sub
            End If
            Dim doDoc1 As New doDoc()
            Dim protokoll As String = ""
            Dim dokusoAdd As System.Collections.Generic.List(Of clFileInfo)
            dokusoAdd = doDoc1.importDokuemte(IDOrdner, typ, protokoll, frmUsrInput.cboDocumentNames.Text.Trim(), frmUsrInput.chkAutoObjectName.Checked)
            For Each doku As clFileInfo In dokusoAdd
                Me.ArchivOrdnerAblegen.AddDokumenteToInsertxy(doku, "")
            Next

            If protokoll.Trim() <> "" Then
                Dim frmProt As New QS2.core.vb.frmProtocol()
                frmProt.initControl()
                frmProt.Show()
                frmProt.ContProtocol1.setText(protokoll.Trim())
                frmProt.Text = doUI.getRes("ImportDocuments")
            End If

        Catch ex As Exception
            Throw New Exception("contArchAbleg.importDokumente: " + ex.ToString())
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

    Private Sub NachVertragsNrToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NachVertragsNrToolStripMenuItem.Click
        Try
            Me.importDokumente("V")

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub PoliccenNrToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PoliccenNrToolStripMenuItem.Click
        Try
            Me.importDokumente("VP")

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

End Class
