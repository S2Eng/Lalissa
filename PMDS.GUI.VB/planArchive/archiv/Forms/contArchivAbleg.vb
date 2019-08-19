Imports System.IO
Imports System.Windows.Forms



Public Class contArchivAbleg
    Inherits System.Windows.Forms.UserControl


    Private gen As New GeneralArchiv
    Private ui As New UIElements()

    Public mainWindow As frmArchivAbleg


    Private ArchivOrdnerAblegen As New contOrdner

    Public Enum eTyp
        Benutzer = 0
    End Enum

    Private dataSchr�nke As New dsPlanArchive
    Private dataF�cher As New dsPlanArchive
    Private dataOrdner As New dsPlanArchive

    Private dataSchlagwortkatalog As New dsPlanArchive
    Public objects As New ArrayList

    ' Public contZwischenablage As contZwischenablage

    Public acP As New System.Drawing.Point

    'Friend WithEvents ArchivOrdner1 As S2Archivsystem.ArchivOrdner
    Friend WithEvents ContextMenuDokumentAngebenS As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuItemDokumentAusw�hlenS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MItemAusPostboxHinzuf�genS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuItemDokumentL�schenS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CMenuStripBezeichungenL�schen As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents BeziehungenL�schenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelOrdnerAblegen As System.Windows.Forms.Panel
    Friend WithEvents AusZwischenablageEinf�genToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Public parentWindow As frmArchivAbleg

    Public dokumentAbgelegt As Boolean = False
    Friend WithEvents UTreeBeziehungen As Infragistics.Win.UltraWinTree.UltraTree
    Friend WithEvents UDateG�ltigBis As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UDateG�ltigVon As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UComboWichtigkeit As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UTextNotiz As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents GBoxDateiInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblInfoGe�ndertAm As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblInfoErstelltAm As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblInfoGr��e As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblInfoDatei As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Public WithEvents UltraButtonSpeichern As Infragistics.Win.Misc.UltraButton
    Public WithEvents UltraButtonAbbrechen As Infragistics.Win.Misc.UltraButton
    Friend WithEvents LabelTitelGefunden As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ArchivDokumentAblegen_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents UGridSchlagwortkatalog As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraExpandableGroupBox1 As Infragistics.Win.Misc.UltraExpandableGroupBox
    Friend WithEvents UltraExpandableGroupBoxPanel1 As Infragistics.Win.Misc.UltraExpandableGroupBoxPanel
    Friend WithEvents PanelAll As System.Windows.Forms.Panel
    Friend WithEvents PanelUnten As System.Windows.Forms.Panel
    Friend WithEvents PanelUntenButton As System.Windows.Forms.Panel
    Friend WithEvents layButtonUnten As Infragistics.Win.Misc.UltraGridBagLayoutManager

    Public arrFilesToDelete As New ArrayList



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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(contArchivAbleg))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem9 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Me.PanelOrdnerAblegen = New System.Windows.Forms.Panel()
        Me.ContextMenuDokumentAngebenS = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuItemDokumentAusw�hlenS = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MItemAusPostboxHinzuf�genS = New System.Windows.Forms.ToolStripMenuItem()
        Me.AusZwischenablageEinf�genToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuItemDokumentL�schenS = New System.Windows.Forms.ToolStripMenuItem()
        Me.CMenuStripBezeichungenL�schen = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BeziehungenL�schenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UTreeBeziehungen = New Infragistics.Win.UltraWinTree.UltraTree()
        Me.UDateG�ltigBis = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel()
        Me.UDateG�ltigVon = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UComboWichtigkeit = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel()
        Me.UTextNotiz = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.GBoxDateiInfo = New System.Windows.Forms.GroupBox()
        Me.lblInfoGe�ndertAm = New Infragistics.Win.Misc.UltraLabel()
        Me.lblInfoErstelltAm = New Infragistics.Win.Misc.UltraLabel()
        Me.lblInfoGr��e = New Infragistics.Win.Misc.UltraLabel()
        Me.lblInfoDatei = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraButtonSpeichern = New Infragistics.Win.Misc.UltraButton()
        Me.UltraButtonAbbrechen = New Infragistics.Win.Misc.UltraButton()
        Me.LabelTitelGefunden = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ArchivDokumentAblegen_Fill_Panel = New System.Windows.Forms.Panel()
        Me.PanelAll = New System.Windows.Forms.Panel()
        Me.UltraExpandableGroupBox1 = New Infragistics.Win.Misc.UltraExpandableGroupBox()
        Me.UltraExpandableGroupBoxPanel1 = New Infragistics.Win.Misc.UltraExpandableGroupBoxPanel()
        Me.UGridSchlagwortkatalog = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.PanelUnten = New System.Windows.Forms.Panel()
        Me.PanelUntenButton = New System.Windows.Forms.Panel()
        Me.layButtonUnten = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.ContextMenuDokumentAngebenS.SuspendLayout()
        Me.CMenuStripBezeichungenL�schen.SuspendLayout()
        CType(Me.UTreeBeziehungen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDateG�ltigBis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDateG�ltigVon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UComboWichtigkeit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UTextNotiz, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxDateiInfo.SuspendLayout()
        Me.ArchivDokumentAblegen_Fill_Panel.SuspendLayout()
        Me.PanelAll.SuspendLayout()
        CType(Me.UltraExpandableGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraExpandableGroupBox1.SuspendLayout()
        Me.UltraExpandableGroupBoxPanel1.SuspendLayout()
        CType(Me.UGridSchlagwortkatalog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelUnten.SuspendLayout()
        Me.PanelUntenButton.SuspendLayout()
        CType(Me.layButtonUnten, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelOrdnerAblegen
        '
        Me.PanelOrdnerAblegen.BackColor = System.Drawing.Color.White
        Me.PanelOrdnerAblegen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelOrdnerAblegen.ContextMenuStrip = Me.ContextMenuDokumentAngebenS
        Me.PanelOrdnerAblegen.Location = New System.Drawing.Point(11, 25)
        Me.PanelOrdnerAblegen.Name = "PanelOrdnerAblegen"
        Me.PanelOrdnerAblegen.Size = New System.Drawing.Size(337, 450)
        Me.PanelOrdnerAblegen.TabIndex = 0
        '
        'ContextMenuDokumentAngebenS
        '
        Me.ContextMenuDokumentAngebenS.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItemDokumentAusw�hlenS, Me.ToolStripMenuItem2, Me.MItemAusPostboxHinzuf�genS, Me.AusZwischenablageEinf�genToolStripMenuItem, Me.ToolStripMenuItem1, Me.MenuItemDokumentL�schenS})
        Me.ContextMenuDokumentAngebenS.Name = "ContextMenuDokumentAngebenS"
        Me.ContextMenuDokumentAngebenS.Size = New System.Drawing.Size(245, 104)
        '
        'MenuItemDokumentAusw�hlenS
        '
        Me.MenuItemDokumentAusw�hlenS.Image = CType(resources.GetObject("MenuItemDokumentAusw�hlenS.Image"), System.Drawing.Image)
        Me.MenuItemDokumentAusw�hlenS.Name = "MenuItemDokumentAusw�hlenS"
        Me.MenuItemDokumentAusw�hlenS.Size = New System.Drawing.Size(244, 22)
        Me.MenuItemDokumentAusw�hlenS.Text = "Dokument ausw�hlen ..."
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(241, 6)
        '
        'MItemAusPostboxHinzuf�genS
        '
        Me.MItemAusPostboxHinzuf�genS.Image = CType(resources.GetObject("MItemAusPostboxHinzuf�genS.Image"), System.Drawing.Image)
        Me.MItemAusPostboxHinzuf�genS.Name = "MItemAusPostboxHinzuf�genS"
        Me.MItemAusPostboxHinzuf�genS.Size = New System.Drawing.Size(244, 22)
        Me.MItemAusPostboxHinzuf�genS.Text = "Aus Postbox hinzuf�gen ..."
        '
        'AusZwischenablageEinf�genToolStripMenuItem
        '
        Me.AusZwischenablageEinf�genToolStripMenuItem.Name = "AusZwischenablageEinf�genToolStripMenuItem"
        Me.AusZwischenablageEinf�genToolStripMenuItem.Size = New System.Drawing.Size(244, 22)
        Me.AusZwischenablageEinf�genToolStripMenuItem.Text = "Aus Zwischenablage einf�gen ..."
        Me.AusZwischenablageEinf�genToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(241, 6)
        '
        'MenuItemDokumentL�schenS
        '
        Me.MenuItemDokumentL�schenS.Image = CType(resources.GetObject("MenuItemDokumentL�schenS.Image"), System.Drawing.Image)
        Me.MenuItemDokumentL�schenS.Name = "MenuItemDokumentL�schenS"
        Me.MenuItemDokumentL�schenS.Size = New System.Drawing.Size(244, 22)
        Me.MenuItemDokumentL�schenS.Text = "L�schen ..."
        '
        'CMenuStripBezeichungenL�schen
        '
        Me.CMenuStripBezeichungenL�schen.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BeziehungenL�schenToolStripMenuItem})
        Me.CMenuStripBezeichungenL�schen.Name = "CMenuStripBezeichungenL�schen"
        Me.CMenuStripBezeichungenL�schen.Size = New System.Drawing.Size(119, 26)
        '
        'BeziehungenL�schenToolStripMenuItem
        '
        Me.BeziehungenL�schenToolStripMenuItem.Image = CType(resources.GetObject("BeziehungenL�schenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.BeziehungenL�schenToolStripMenuItem.Name = "BeziehungenL�schenToolStripMenuItem"
        Me.BeziehungenL�schenToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.BeziehungenL�schenToolStripMenuItem.Text = "L�schen"
        '
        'UTreeBeziehungen
        '
        Me.UTreeBeziehungen.ContextMenuStrip = Me.CMenuStripBezeichungenL�schen
        Me.UTreeBeziehungen.Location = New System.Drawing.Point(766, 252)
        Me.UTreeBeziehungen.Name = "UTreeBeziehungen"
        Me.UTreeBeziehungen.Size = New System.Drawing.Size(38, 22)
        Me.UTreeBeziehungen.TabIndex = 465
        Me.UTreeBeziehungen.Visible = False
        '
        'UDateG�ltigBis
        '
        Appearance1.BackColor = System.Drawing.Color.White
        Me.UDateG�ltigBis.Appearance = Appearance1
        Me.UDateG�ltigBis.BackColor = System.Drawing.Color.White
        Me.UDateG�ltigBis.Location = New System.Drawing.Point(82, 52)
        Me.UDateG�ltigBis.Name = "UDateG�ltigBis"
        Me.UDateG�ltigBis.Size = New System.Drawing.Size(104, 21)
        Me.UDateG�ltigBis.TabIndex = 1
        '
        'UltraLabel6
        '
        Appearance2.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel6.Appearance = Appearance2
        Me.UltraLabel6.Location = New System.Drawing.Point(60, 54)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(24, 16)
        Me.UltraLabel6.TabIndex = 464
        Me.UltraLabel6.Text = "bis"
        '
        'UltraLabel2
        '
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel2.Appearance = Appearance3
        Me.UltraLabel2.Location = New System.Drawing.Point(8, 33)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(88, 16)
        Me.UltraLabel2.TabIndex = 462
        Me.UltraLabel2.Text = "G�ltigkeit von"
        '
        'UDateG�ltigVon
        '
        Appearance4.BackColor = System.Drawing.Color.White
        Me.UDateG�ltigVon.Appearance = Appearance4
        Me.UDateG�ltigVon.BackColor = System.Drawing.Color.White
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        Me.UDateG�ltigVon.DropDownAppearance = Appearance5
        Me.UDateG�ltigVon.Location = New System.Drawing.Point(82, 31)
        Me.UDateG�ltigVon.Name = "UDateG�ltigVon"
        Me.UDateG�ltigVon.Size = New System.Drawing.Size(104, 21)
        Me.UDateG�ltigVon.TabIndex = 0
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
        Me.UComboWichtigkeit.Location = New System.Drawing.Point(253, 32)
        Me.UComboWichtigkeit.Name = "UComboWichtigkeit"
        Me.UComboWichtigkeit.Size = New System.Drawing.Size(104, 19)
        Me.UComboWichtigkeit.TabIndex = 2
        '
        'UltraLabel3
        '
        Appearance7.BackColor = System.Drawing.Color.Transparent
        Appearance7.ForeColor = System.Drawing.Color.Black
        Me.UltraLabel3.Appearance = Appearance7
        Me.UltraLabel3.Location = New System.Drawing.Point(192, 33)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(64, 16)
        Me.UltraLabel3.TabIndex = 459
        Me.UltraLabel3.Text = "Wichtigkeit"
        '
        'UTextNotiz
        '
        Appearance8.BackColor = System.Drawing.Color.White
        Appearance8.FontData.SizeInPoints = 10.0!
        Me.UTextNotiz.Appearance = Appearance8
        Me.UTextNotiz.BackColor = System.Drawing.Color.White
        Me.UTextNotiz.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UTextNotiz.Location = New System.Drawing.Point(8, 83)
        Me.UTextNotiz.Multiline = True
        Me.UTextNotiz.Name = "UTextNotiz"
        Me.UTextNotiz.Scrollbars = System.Windows.Forms.ScrollBars.Both
        Me.UTextNotiz.Size = New System.Drawing.Size(349, 164)
        Me.UTextNotiz.TabIndex = 3
        Me.UTextNotiz.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'GBoxDateiInfo
        '
        Me.GBoxDateiInfo.Controls.Add(Me.lblInfoGe�ndertAm)
        Me.GBoxDateiInfo.Controls.Add(Me.lblInfoErstelltAm)
        Me.GBoxDateiInfo.Controls.Add(Me.lblInfoGr��e)
        Me.GBoxDateiInfo.Controls.Add(Me.lblInfoDatei)
        Me.GBoxDateiInfo.Location = New System.Drawing.Point(766, 280)
        Me.GBoxDateiInfo.Name = "GBoxDateiInfo"
        Me.GBoxDateiInfo.Size = New System.Drawing.Size(29, 38)
        Me.GBoxDateiInfo.TabIndex = 457
        Me.GBoxDateiInfo.TabStop = False
        Me.GBoxDateiInfo.Text = "Dateinfo ..."
        Me.GBoxDateiInfo.Visible = False
        '
        'lblInfoGe�ndertAm
        '
        Appearance9.ForeColor = System.Drawing.Color.Gray
        Appearance9.TextHAlignAsString = "Left"
        Me.lblInfoGe�ndertAm.Appearance = Appearance9
        Me.lblInfoGe�ndertAm.Location = New System.Drawing.Point(200, 32)
        Me.lblInfoGe�ndertAm.Name = "lblInfoGe�ndertAm"
        Me.lblInfoGe�ndertAm.Size = New System.Drawing.Size(200, 16)
        Me.lblInfoGe�ndertAm.TabIndex = 242
        Me.lblInfoGe�ndertAm.Text = "G�ndert am: 04.08.2006 13:56:03"
        '
        'lblInfoErstelltAm
        '
        Appearance10.ForeColor = System.Drawing.Color.Gray
        Appearance10.TextHAlignAsString = "Left"
        Me.lblInfoErstelltAm.Appearance = Appearance10
        Me.lblInfoErstelltAm.Location = New System.Drawing.Point(8, 32)
        Me.lblInfoErstelltAm.Name = "lblInfoErstelltAm"
        Me.lblInfoErstelltAm.Size = New System.Drawing.Size(200, 16)
        Me.lblInfoErstelltAm.TabIndex = 241
        Me.lblInfoErstelltAm.Text = "Erstellt am: 12.4.2004 12:3"
        '
        'lblInfoGr��e
        '
        Appearance11.ForeColor = System.Drawing.Color.Gray
        Appearance11.TextHAlignAsString = "Left"
        Me.lblInfoGr��e.Appearance = Appearance11
        Me.lblInfoGr��e.Location = New System.Drawing.Point(8, 48)
        Me.lblInfoGr��e.Name = "lblInfoGr��e"
        Me.lblInfoGr��e.Size = New System.Drawing.Size(200, 16)
        Me.lblInfoGr��e.TabIndex = 240
        Me.lblInfoGr��e.Text = "Gr��e: 45,2 kByte"
        '
        'lblInfoDatei
        '
        Appearance12.ForeColor = System.Drawing.Color.Gray
        Me.lblInfoDatei.Appearance = Appearance12
        Me.lblInfoDatei.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoDatei.Location = New System.Drawing.Point(8, 16)
        Me.lblInfoDatei.Name = "lblInfoDatei"
        Me.lblInfoDatei.Size = New System.Drawing.Size(392, 16)
        Me.lblInfoDatei.TabIndex = 239
        Me.lblInfoDatei.Text = "Datei: Vorlage.doc"
        '
        'UltraLabel1
        '
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Me.UltraLabel1.Appearance = Appearance13
        Me.UltraLabel1.Location = New System.Drawing.Point(7, 66)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(38, 16)
        Me.UltraLabel1.TabIndex = 466
        Me.UltraLabel1.Text = "Notiz:"
        '
        'UltraButtonSpeichern
        '
        Appearance14.Image = CType(resources.GetObject("Appearance14.Image"), Object)
        Me.UltraButtonSpeichern.Appearance = Appearance14
        Me.UltraButtonSpeichern.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UltraButtonSpeichern.Location = New System.Drawing.Point(19, 3)
        Me.UltraButtonSpeichern.Name = "UltraButtonSpeichern"
        Me.UltraButtonSpeichern.Size = New System.Drawing.Size(102, 27)
        Me.UltraButtonSpeichern.TabIndex = 0
        Me.UltraButtonSpeichern.Text = "Speichern"
        '
        'UltraButtonAbbrechen
        '
        Me.UltraButtonAbbrechen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.UltraButtonAbbrechen.Location = New System.Drawing.Point(121, 3)
        Me.UltraButtonAbbrechen.Name = "UltraButtonAbbrechen"
        Me.UltraButtonAbbrechen.Size = New System.Drawing.Size(81, 27)
        Me.UltraButtonAbbrechen.TabIndex = 1
        Me.UltraButtonAbbrechen.Text = "Abbrechen"
        '
        'LabelTitelGefunden
        '
        Me.LabelTitelGefunden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelTitelGefunden.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.LabelTitelGefunden.ForeColor = System.Drawing.Color.Black
        Me.LabelTitelGefunden.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.LabelTitelGefunden.ImageIndex = 2
        Me.LabelTitelGefunden.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelTitelGefunden.Location = New System.Drawing.Point(11, 5)
        Me.LabelTitelGefunden.Name = "LabelTitelGefunden"
        Me.LabelTitelGefunden.Size = New System.Drawing.Size(293, 21)
        Me.LabelTitelGefunden.TabIndex = 469
        Me.LabelTitelGefunden.Text = "Ordner anklicken und Dokument ausw�hlen"
        Me.LabelTitelGefunden.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.ImageIndex = 4
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(204, 21)
        Me.Label1.TabIndex = 470
        Me.Label1.Text = "Allgemeine Angaben zum Dokument"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ArchivDokumentAblegen_Fill_Panel
        '
        Me.ArchivDokumentAblegen_Fill_Panel.BackColor = System.Drawing.Color.White
        Me.ArchivDokumentAblegen_Fill_Panel.Controls.Add(Me.PanelAll)
        Me.ArchivDokumentAblegen_Fill_Panel.Controls.Add(Me.PanelUnten)
        Me.ArchivDokumentAblegen_Fill_Panel.Controls.Add(Me.UTreeBeziehungen)
        Me.ArchivDokumentAblegen_Fill_Panel.Controls.Add(Me.GBoxDateiInfo)
        Me.ArchivDokumentAblegen_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.ArchivDokumentAblegen_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ArchivDokumentAblegen_Fill_Panel.Location = New System.Drawing.Point(0, 0)
        Me.ArchivDokumentAblegen_Fill_Panel.Name = "ArchivDokumentAblegen_Fill_Panel"
        Me.ArchivDokumentAblegen_Fill_Panel.Size = New System.Drawing.Size(752, 515)
        Me.ArchivDokumentAblegen_Fill_Panel.TabIndex = 2
        '
        'PanelAll
        '
        Me.PanelAll.Controls.Add(Me.PanelOrdnerAblegen)
        Me.PanelAll.Controls.Add(Me.LabelTitelGefunden)
        Me.PanelAll.Controls.Add(Me.UltraExpandableGroupBox1)
        Me.PanelAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAll.Location = New System.Drawing.Point(0, 0)
        Me.PanelAll.Name = "PanelAll"
        Me.PanelAll.Size = New System.Drawing.Size(752, 482)
        Me.PanelAll.TabIndex = 0
        '
        'UltraExpandableGroupBox1
        '
        Appearance15.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance15.BorderColor = System.Drawing.Color.Black
        Appearance15.BorderColor2 = System.Drawing.Color.Black
        Me.UltraExpandableGroupBox1.Appearance = Appearance15
        Me.UltraExpandableGroupBox1.Controls.Add(Me.UltraExpandableGroupBoxPanel1)
        Me.UltraExpandableGroupBox1.Expanded = False
        Me.UltraExpandableGroupBox1.ExpandedSize = New System.Drawing.Size(390, 450)
        Appearance29.FontData.SizeInPoints = 10.0!
        Me.UltraExpandableGroupBox1.HeaderAppearance = Appearance29
        Me.UltraExpandableGroupBox1.HeaderClickAction = Infragistics.Win.Misc.GroupBoxHeaderClickAction.ToggleExpansion
        Me.UltraExpandableGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.LeftInsideBorder
        Me.UltraExpandableGroupBox1.Location = New System.Drawing.Point(352, 25)
        Me.UltraExpandableGroupBox1.Name = "UltraExpandableGroupBox1"
        Me.UltraExpandableGroupBox1.Size = New System.Drawing.Size(29, 450)
        Me.UltraExpandableGroupBox1.TabIndex = 1
        Me.UltraExpandableGroupBox1.Text = "Erweiterte Angaben"
        Me.UltraExpandableGroupBox1.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP
        '
        'UltraExpandableGroupBoxPanel1
        '
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UComboWichtigkeit)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel3)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UDateG�ltigVon)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UGridSchlagwortkatalog)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.Label1)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UTextNotiz)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel2)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UDateG�ltigBis)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel6)
        Me.UltraExpandableGroupBoxPanel1.Controls.Add(Me.UltraLabel1)
        Me.UltraExpandableGroupBoxPanel1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraExpandableGroupBoxPanel1.Name = "UltraExpandableGroupBoxPanel1"
        Me.UltraExpandableGroupBoxPanel1.Size = New System.Drawing.Size(364, 446)
        Me.UltraExpandableGroupBoxPanel1.TabIndex = 0
        Me.UltraExpandableGroupBoxPanel1.Visible = False
        '
        'UGridSchlagwortkatalog
        '
        Appearance16.BackColor = System.Drawing.Color.White
        Appearance16.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.UGridSchlagwortkatalog.DisplayLayout.Appearance = Appearance16
        Me.UGridSchlagwortkatalog.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Appearance17.BackColor = System.Drawing.Color.FloralWhite
        Me.UGridSchlagwortkatalog.DisplayLayout.CaptionAppearance = Appearance17
        Me.UGridSchlagwortkatalog.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[True]
        Appearance18.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance18.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridSchlagwortkatalog.DisplayLayout.GroupByBox.Appearance = Appearance18
        Appearance19.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridSchlagwortkatalog.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance19
        Me.UGridSchlagwortkatalog.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.UGridSchlagwortkatalog.DisplayLayout.GroupByBox.Prompt = "Ziehen Sie eine Spalte herein  nach der Sie gruppieren m�chten:"
        Appearance20.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance20.BackColor2 = System.Drawing.SystemColors.Control
        Appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance20.ForeColor = System.Drawing.SystemColors.GrayText
        Me.UGridSchlagwortkatalog.DisplayLayout.GroupByBox.PromptAppearance = Appearance20
        Me.UGridSchlagwortkatalog.DisplayLayout.MaxColScrollRegions = 1
        Me.UGridSchlagwortkatalog.DisplayLayout.MaxRowScrollRegions = 1
        Appearance21.BackColor = System.Drawing.SystemColors.Window
        Appearance21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.ActiveCellAppearance = Appearance21
        Appearance22.BackColor = System.Drawing.Color.DodgerBlue
        Appearance22.ForeColor = System.Drawing.Color.White
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.ActiveRowAppearance = Appearance22
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance23.BackColor = System.Drawing.SystemColors.Window
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.CardAreaAppearance = Appearance23
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.CardSpacing = 0
        Appearance24.BorderColor = System.Drawing.Color.Silver
        Appearance24.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.CellAppearance = Appearance24
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.CellPadding = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.CellSpacing = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.DefaultRowHeight = 1
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.FilterRowSpacingAfter = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.FilterRowSpacingBefore = 0
        Appearance25.BackColor = System.Drawing.SystemColors.Control
        Appearance25.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance25.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance25.BorderColor = System.Drawing.SystemColors.Window
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.GroupByRowAppearance = Appearance25
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.GroupByRowPadding = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.GroupByRowSpacingAfter = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.GroupByRowSpacingBefore = 0
        Appearance26.TextHAlignAsString = "Left"
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.HeaderAppearance = Appearance26
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.XPThemed
        Appearance27.BackColor = System.Drawing.SystemColors.Window
        Appearance27.BorderColor = System.Drawing.Color.Silver
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.RowAppearance = Appearance27
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
        Appearance28.BackColor = System.Drawing.SystemColors.ControlLight
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.TemplateAddRowAppearance = Appearance28
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.TemplateAddRowSpacingAfter = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.Override.TemplateAddRowSpacingBefore = 0
        Me.UGridSchlagwortkatalog.DisplayLayout.RowConnectorColor = System.Drawing.Color.FloralWhite
        Me.UGridSchlagwortkatalog.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.None
        Me.UGridSchlagwortkatalog.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.UGridSchlagwortkatalog.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.UGridSchlagwortkatalog.Location = New System.Drawing.Point(8, 252)
        Me.UGridSchlagwortkatalog.Name = "UGridSchlagwortkatalog"
        Me.UGridSchlagwortkatalog.Size = New System.Drawing.Size(349, 189)
        Me.UGridSchlagwortkatalog.TabIndex = 4
        Me.UGridSchlagwortkatalog.Text = "Schlagwortkatalog ..."
        Me.UGridSchlagwortkatalog.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        '
        'PanelUnten
        '
        Me.PanelUnten.Controls.Add(Me.PanelUntenButton)
        Me.PanelUnten.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelUnten.Location = New System.Drawing.Point(0, 482)
        Me.PanelUnten.Name = "PanelUnten"
        Me.PanelUnten.Size = New System.Drawing.Size(752, 33)
        Me.PanelUnten.TabIndex = 2
        '
        'PanelUntenButton
        '
        Me.PanelUntenButton.Controls.Add(Me.UltraButtonSpeichern)
        Me.PanelUntenButton.Controls.Add(Me.UltraButtonAbbrechen)
        Me.PanelUntenButton.Location = New System.Drawing.Point(261, -1)
        Me.PanelUntenButton.Name = "PanelUntenButton"
        Me.PanelUntenButton.Size = New System.Drawing.Size(230, 35)
        Me.PanelUntenButton.TabIndex = 0
        '
        'layButtonUnten
        '
        Me.layButtonUnten.ContainerControl = Me.PanelUnten
        Me.layButtonUnten.ExpandToFitHeight = True
        Me.layButtonUnten.ExpandToFitWidth = True
        '
        'contArchivAbleg
        '
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ArchivDokumentAblegen_Fill_Panel)
        Me.Name = "contArchivAbleg"
        Me.Size = New System.Drawing.Size(752, 515)
        Me.ContextMenuDokumentAngebenS.ResumeLayout(False)
        Me.CMenuStripBezeichungenL�schen.ResumeLayout(False)
        CType(Me.UTreeBeziehungen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDateG�ltigBis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDateG�ltigVon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UComboWichtigkeit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UTextNotiz, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxDateiInfo.ResumeLayout(False)
        Me.ArchivDokumentAblegen_Fill_Panel.ResumeLayout(False)
        Me.PanelAll.ResumeLayout(False)
        CType(Me.UltraExpandableGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraExpandableGroupBox1.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.ResumeLayout(False)
        Me.UltraExpandableGroupBoxPanel1.PerformLayout()
        CType(Me.UGridSchlagwortkatalog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelUnten.ResumeLayout(False)
        Me.PanelUntenButton.ResumeLayout(False)
        CType(Me.layButtonUnten, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub Dokument_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            'Dim uiMen� As New clUIElements
            'Me.contZwischenablage = New contZwischenablage
            'uiMen�.Menu_loadContainer(Me.UltraToolbarsManager1, 0, Me.contZwischenablage, "Zwischenablage")

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        End Try
    End Sub

    Public Sub initForm(ByVal IDOrdner As System.Guid)
        Try
            'ImportVerzeichnisseToolStripMenuItem.Visible = True

            Me.LoadOrdnerIntoPanels()
            Me.resetForm(IDOrdner)

            Dim cl As New compSql()
            cl.ObjekteAblegen(Me.objects, Me.UTreeBeziehungen)
            Me.UTreeBeziehungen.ExpandAll(Infragistics.Win.UltraWinTree.ExpandAllType.Always)

            Dim d_evHandClick As New dArchiv.Funct(AddressOf Me.ArchivOrdner_Clickxy)
            Me.ArchivOrdnerAblegen.delClick.RegisterDelegate(d_evHandClick)

            Dim d_evHandDragDrop As New dArchiv.Funct(AddressOf Me.DateiEinf�genDragDrop)
            Me.ArchivOrdnerAblegen.delDragDrop.RegisterDelegate(d_evHandDragDrop)
            Me.ArchivOrdnerAblegen.initTree_icons(False)

            If objects.Count = 1 Then
                Dim aktObj As New clObject
                aktObj = objects.Item(0)
                Me.mainWindow.Text = "Dokumente ablegen f�r " + aktObj.bezeichnung
            End If

            Me.ArchivOrdnerAblegen.ResizeControl(Me.PanelOrdnerAblegen.Height, Me.PanelOrdnerAblegen.Width)

        Catch ex As Exception
            Throw New Exception("initForm: " + ex.ToString())
        End Try
    End Sub

    Public Sub LoadOrdnerIntoPanels()
        Try

            Me.ArchivOrdnerAblegen = New contOrdner
            Me.PanelOrdnerAblegen.Controls.Add(Me.ArchivOrdnerAblegen)
            Me.ArchivOrdnerAblegen.modalusrCont = Me
            Me.ArchivOrdnerAblegen.ResizeControl(Me.PanelOrdnerAblegen.Width - 2, Me.PanelOrdnerAblegen.Height)
            Me.ArchivOrdnerAblegen.fill_DockStyle()

        Catch ex As Exception
            Throw New Exception("LoadOrdnerIntoPanels: " + ex.ToString())
        End Try
    End Sub

    Public Sub resetForm(ByVal IDOrdner As System.Guid)
        Try
            Me.LoadOrdner(IDOrdner)
            Me.UDateG�ltigVon.Value = Nothing
            Me.UDateG�ltigBis.Value = Nothing
            Me.UComboWichtigkeit.SelectedIndex = 1
            Me.UTextNotiz.Text = ""
            Me.ClearInfoFieldsDatei()
            Me.LoadSchlagwortkatalog()
            Me.arrFilesToDelete.Clear()
            Me.arrFilesToDelete = New ArrayList

        Catch ex As Exception
            Throw New Exception("resetForm: " + ex.ToString())
        End Try
    End Sub

    Public Sub LoadOrdner(ByVal IDOrdner As System.Guid)
        Try

            Me.ArchivOrdnerAblegen.LoadOrdnerbaum(contOrdner.etyp.Ablegen, IDOrdner)

        Catch ex As Exception
            Throw New Exception("LoadOrdner: " + ex.ToString())
        End Try
    End Sub
    Private Sub UTabPageSchrankFachOrdner_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Public Sub LoadSchlagwortkatalog()
        Try

            Dim db_ThemenSchlagw As New compSql
            Me.dataSchlagwortkatalog = db_ThemenSchlagw.LesenAllerThemenUndSchlagw�rter()

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

            dataThemen.tblSchlagw�rter.Columns.Add(New DataColumn("G�ltig", GetType(System.Boolean)))

            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).Columns("G�ltig").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).Columns("G�ltig").DefaultCellValue = False

            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(0).Columns("Thema").Width = 110
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).Columns("Schlagwort").Width = 50

            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(0).Columns("Thema").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).Columns("Schlagwort").CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit

            For Each r As dsPlanArchive.tblSchlagw�rterRow In dataThemen.tblSchlagw�rter.Rows
                r("G�ltig") = False
            Next
            'For Each itm As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.UGridSchlagwortkatalog.Rows
            '    itm.Cells("G�ltig").Value = False
            'Next

            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(0).HeaderVisible = False
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(0).ColHeadersVisible = False
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).HeaderVisible = False
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).ColHeadersVisible = False
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(0).Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None
            Me.UGridSchlagwortkatalog.DisplayLayout.Bands(1).Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None

            UGridSchlagwortkatalog.DisplayLayout.Bands(0).Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.None
            UGridSchlagwortkatalog.DisplayLayout.Bands(0).Override.RowAppearance.BorderColor = System.Drawing.Color.White

        Catch ex As Exception
            Throw New Exception("initSchlagwortkatalog: " + ex.ToString())
        End Try
    End Sub

    Private Sub UltraComboWichtigkeit_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)

    End Sub
    Private Sub UltraComboWichtigkeit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub UltraComboSchrank_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)

    End Sub

    Private Sub UltraComboFach_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)

    End Sub

    Private Sub UButtonDokumentSpeichern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub UButtonDokumentL�schen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub UltraTabControl1_SelectedTabChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs)
        Try

            If e.Tab.Index = 4 Then
                Application.DoEvents()
                Me.UTextNotiz.Focus()
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        End Try
    End Sub

    Private Sub UltraLabel3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub UComboWichtigkeit_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub tollClick_alt()

        Try
            Me.Cursor = Cursors.WaitCursor

            'If e.Item.Key = "DokuAusw�hlen" Then
            '    Me.ShowTab(0)
            'ElseIf e.Item.Key = "Schlagwortkatalog" Then
            '    Me.ShowTab(1)
            'ElseIf e.Item.Key = "Notiz" Then
            '    Me.ShowTab(2)
            'ElseIf e.Item.Key = "AllgAngaben" Then
            '    Me.ShowTab(3)
            'ElseIf e.Item.Key = "AusPostboxHinzuf�gen" Then
            '    Me.AusPostboxHinzuf�gen()
            'ElseIf e.Item.Key = "DokuSichern" Then
            '    Me.DokumentSichern()
            'ElseIf e.Item.Key = "AblageNeu" Then
            '    Me.GesamtesFensterR�cksetzen()
            'End If

        Catch ex As Exception
            Throw New Exception("tollClick_alt: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub GesamtesFensterR�cksetzen()
        Try
            Me.resetForm(Nothing)

        Catch ex As Exception
            Throw New Exception("GesamtesFensterR�cksetzen: " + ex.ToString())
        End Try
    End Sub
    Public Sub AusPostboxHinzuf�gen(ByVal typ As eTyp)
        Try

            If Not gen.IsNull(Me.ArchivOrdnerAblegen.GetSelectedOrdner()) Then
                Dim frmPost As New FrmPostbox(FrmPostbox.eTyp.Benutzer)
                frmPost = New FrmPostbox(FrmPostbox.eTyp.Benutzer)

                frmPost.IDOrdner = Me.ArchivOrdnerAblegen.GetSelectedOrdner()
                frmPost.ShowDialog(Me)
                If Not frmPost.apport Then

                    For Each file As String In frmPost.arr�bernehmen
                        Me.loadFile(file)
                    Next
                    Dim bDeleteFiles As Boolean = False
                    If frmPost.UCheckEditorDateienL�schen.Checked Then
                        bDeleteFiles = True
                        For Each file As String In frmPost.arr�bernehmen
                            Me.arrFilesToDelete.Add(file)
                        Next
                    End If
                End If
            Else
                MsgBox("Es wurde kein Ordner ausgew�hlt!", MsgBoxStyle.Information, "Archivsystem")
            End If

        Catch ex As Exception
            Throw New Exception("AusPostboxHinzuf�gen: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Function DokumentSichern() As Boolean
        Try

            Dim clLiz As New cArchive

            'If gen.IsNull(Me.ArchivOrdnerAblegen.GetSelectedOrdner()) Then
            '    MsgBox(ui.GetResString("ERRDokuSpeichernOrdner"), MsgBoxStyle.Information, "Archivsystem")
            '    Return False
            'End If
            'If gen.IsNull(Me.FileInfo.file_name) Or gen.IsNull(Me.FileInfo.file_origVerzeichnis) Or gen.IsNull(Me.FileInfo.fileB) Then
            '    MsgBox(ui.GetResString("ERRDokuSpeichernDokument"), MsgBoxStyle.Information, "Archivsystem")
            '    Return False
            'End If

            Dim compPfad As New compSql
            If gen.IsNull(compPfad.pfadLesen()) Then
                MsgBox("Es wurde kein Dokumentenpfad angegeben!", MsgBoxStyle.Information, "Archivsystem")
                Return False
            End If
            If Not System.IO.Directory.Exists(compPfad.pfadLesen()) Then
                MsgBox("Es wurde kein Dokumentenpfad angegeben!", MsgBoxStyle.Information, "Archivsystem")
                Return False
            End If

            Dim genMain As New GeneralArchiv
            genMain.GarbColl()

            Dim arrInfo As New ArrayList
            arrInfo = Me.ArchivOrdnerAblegen.GetFileInfoDateiAblegen_rek(Nothing, True)
            Dim obj As New ArrayList
            obj = Me.getObjects()

            Dim clSave As New cArchive
            Dim ret As New cArchive.clRet
            ret = clSave.DokumentInsArchivAblegen(arrInfo, Me.UTextNotiz.Text, UDateG�ltigVon.Value, UDateG�ltigBis.Value, UComboWichtigkeit.Value,
                                                        Me.arrFilesToDelete, obj, Me.dataSchlagwortkatalog, False)
            If ret.OK Then
                'MsgBox("Das Dokument wurde ins Archiv abgelegt!" + vbNewLine + _
                '            "Anzahl" + " " + arrInfo.Count.ToString, MsgBoxStyle.Information, "Archivsystem")

                Dim info As New Info
                info.showInfo(True, 1400, Me.mainWindow, "")

                arrInfo = Nothing
                Me.resetForm(Nothing)
                Me.arrFilesToDelete = New ArrayList
                ' Me.contZwischenablage.loadClipboard()
                Me.dokumentAbgelegt = True

                Return True
            Else
                Throw New Exception("DokumentSichern: Fehler beim Sichern eines Dokumentes!")
            End If

        Catch ex As Exception
            Throw New Exception("DokumentSichern: " + ex.ToString())
        End Try
    End Function
    Public Function Dateien_originalL�schenxy() As Boolean
        Try

            For Each file As String In Me.arrFilesToDelete
                If System.IO.File.Exists(file) Then
                    Try
                        System.IO.File.Delete(file)
                    Catch ex As Exception
                    End Try
                End If
            Next

        Catch ex As Exception
            Throw New Exception("Dateien_originalL�schen: " + ex.ToString())
        End Try
    End Function

    Public Function SchlagwortkatalogSpeichernxy(ByVal IDDokumenteintrag As System.Guid) As Boolean
        Try

            ' Schlagwortkatalog speichern
            Dim comp As New compSql
            comp.deleteDokumenteneintragSchlagw�rter(IDDokumenteintrag)      ' alle Schlagw�rter l�schen
            For Each r As dsPlanArchive.tblSchlagw�rterRow In Me.dataSchlagwortkatalog.tblSchlagw�rter
                If r("G�ltig") = True Then
                    Dim r_dokSchlagw As dsPlanArchive.tblDokumenteneintragSchlagw�rterRow
                    Dim dataDokumenteneintragSchlagw�rter As New dsPlanArchive
                    r_dokSchlagw = dataDokumenteneintragSchlagw�rter.tblDokumenteneintragSchlagw�rter.NewRow
                    gen.initRow(r_dokSchlagw)
                    r_dokSchlagw.ID = System.Guid.NewGuid
                    r_dokSchlagw.IDDokumenteneintrag = IDDokumenteintrag
                    r_dokSchlagw.IDSchlagwort = r.ID
                    comp.writeDokumenteneintragSchlagw�rter(r_dokSchlagw)
                End If
            Next
            Return True

        Catch ex As Exception
            Throw New Exception("SchlagwortkatalogSpeichern: " + ex.ToString())
        End Try
    End Function
    Public Function ObjectSpeichernxy(ByVal IDDokumenteintrag As System.Guid) As Boolean
        Try

            Dim comp As New compSql
            Dim firstItem As Infragistics.Win.UltraWinTree.UltraTreeNode
            firstItem = Me.UTreeBeziehungen.Nodes(0)
            For Each item As Infragistics.Win.UltraWinTree.UltraTreeNode In firstItem.Nodes
                Dim ob As New Object
                ob = item.Tag
                Dim r_object As dsPlanArchive.tblObjektRow
                Dim data As New dsPlanArchive
                r_object = data.tblObjekt.NewRow
                gen.initRow(r_object)

                r_object.ID = System.Guid.NewGuid
                r_object.IDDokumenteintrag = IDDokumenteintrag
                r_object.Datenbankidentit�t = True
                Dim typ As New compSql.eTypObj

                If ob.GetType.ToString = "System.Int32" Then
                    r_object.ID_int = ob
                    typ = compSql.eTypObj.int
                ElseIf ob.GetType.ToString = "System.String" Then
                    Try
                        Dim id As New System.Guid(ob.ToString)
                        r_object.ID_guid = id
                        typ = compSql.eTypObj.guid
                    Catch ex As Exception
                        r_object.ID_str = ob
                        typ = compSql.eTypObj.str
                    End Try
                End If

                comp.insertObject(r_object)

            Next

            'For Each obxy As Object In Me.objects
            '    Dim r_object As S2ArchivWork.dsObjects.tblObjektRow
            '    Dim data As New S2ArchivWork.dsObjects
            '    r_object = data.tblObjekt.NewRow
            '    gen.initRow(r_object)

            '    r_object.ID = System.Guid.NewGuid
            '    r_object.IDDokumenteintrag = IDDokumenteintrag
            '    r_object.Datenbankidentit�t = True
            '    Dim typ As New S2ArchivWork.compObjekt.eTyp
            '    If ob.GetType.ToString = "System.Guid" Then
            '        r_object.ID_guid = ob
            '        typ = S2ArchivWork.compObjekt.eTyp.guid
            '    ElseIf ob.GetType.ToString = "System.Int32" Then
            '        r_object.ID_int = ob
            '        typ = S2ArchivWork.compObjekt.eTyp.int
            '    ElseIf ob.GetType.ToString = "System.String" Then
            '        r_object.ID_str = ob
            '        typ = S2ArchivWork.compObjekt.eTyp.str
            '    End If

            '    comp.insertObject(r_object, Me.typAblage)
            'Next

            Return True

        Catch ex As Exception
            Throw New Exception("ObjectSpeichern: " + ex.ToString())
        End Try
    End Function
    Public Function getObjects() As ArrayList
        Try

            Dim ret As New ArrayList
            Dim comp As New compSql
            Dim firstItem As Infragistics.Win.UltraWinTree.UltraTreeNode
            firstItem = Me.UTreeBeziehungen.Nodes(0)
            For Each item As Infragistics.Win.UltraWinTree.UltraTreeNode In firstItem.Nodes
                Dim ob As New clObject
                ob.id = item.Tag
                ob.bezeichnung = item.Text
                ret.Add(ob)
            Next
            Return ret

        Catch ex As Exception
            Throw New Exception("getObjects: " + ex.ToString())
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
            Throw New Exception("DateiPhysischSpeichern: " + ex.ToString())
        End Try
    End Function
    Private Sub UltraTabPageControl6_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub UltraTabPageControl5_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub UltraTabPageControl1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Public Function SelectFile() As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim selectedFile As String = ""
            selectedFile = ui.SelectFileDialog("All Files (*.*)|*.*|" + _
                        "Microsoft Word Files (*.doc)|*.doc|" + _
                        "Microsoft Excel Files (*.xls)|*.xls|" + _
                        "Text Files (*.txt)|*.txt|" + _
                        "pdf Files (*.pdf)|*.pdf|" + _
                        "rtf Files (*.Rtf)|*.rtf", "")

            If Not gen.IsNull(selectedFile) Then
                Me.loadFile(selectedFile)
            End If

        Catch ex As Exception
            Throw New Exception("SelectFile: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Public Function loadFile(ByVal file As String) As Boolean
        Try

            Me.ClearInfoFieldsDatei()

            Dim FileToAdd As New clFileInfo
            If System.IO.File.Exists(file) Then
                If System.IO.Directory.Exists(ui.GetDir(file)) Then
                    If gen.IsNull(ui.GetFiletyp(file)) Then
                        MsgBox("Keinen Dateityp gefunden!", MsgBoxStyle.Information, "Archivsystem")
                        Return False
                    End If
                    If gen.IsNull(ui.GetFileName(file)) Then
                        MsgBox("Feler beim Lesen des Dateinamens!", MsgBoxStyle.Information, "Archivsystem")
                        Return False
                    End If
                    FileToAdd.file_typ = ui.GetFiletyp(file)
                    FileToAdd.file_origVerzeichnis = ui.GetDir(file)
                    FileToAdd.file_name = ui.GetFileName(file)

                    ' Read File into byte Array
                    Dim fs As New System.IO.FileStream(file, FileMode.Open, FileAccess.Read)
                    Dim r As New BinaryReader(fs)
                    Dim fileByte(fs.Length) As Byte
                    fileByte = r.ReadBytes(fs.Length)
                    FileToAdd.fileB = fileByte

                    ' fileInfos einlesen
                    Dim FileInfo As New System.IO.FileInfo(file)
                    FileToAdd.file_erstelltAm = FileInfo.CreationTime
                    FileToAdd.file_ge�ndertAm = FileInfo.LastWriteTime
                    FileToAdd.file_gr��e = CStr(FileInfo.Length)

                    If Me.ArchivOrdnerAblegen.AddDokumenteToInsert(FileToAdd) Then
                        Me.WriteInfoFieldsDatei(FileToAdd.file_name, FileToAdd.file_gr��e, FileToAdd.file_erstelltAm, FileToAdd.file_ge�ndertAm)
                    End If

                Else
                    MsgBox("Fehler beim Lesen der Datei: " + file + vbNewLine + _
                                           "Das Verzeichnis existiert nicht: " + ui.GetDir(file), MsgBoxStyle.Information, "Archivsystem")
                End If
            Else

                MsgBox("Fehler beim Lesen der Datei: " + file + vbNewLine + _
                                       "Das Verzeichnis existiert nicht: ", MsgBoxStyle.Information, "Archivsystem")
            End If

        Catch ex As Exception
            Throw New Exception("loadFile: " + ex.ToString())
        End Try
    End Function
    Private Sub WriteInfoFieldsDatei(ByVal Datei As String, ByVal Gr��e As Double, ByVal ErstelltAm As Date, ByVal Ge�ndertAm As Date)
        Try

            Me.lblInfoDatei.Text = "Datei" + "  " + Datei
            Me.lblInfoGr��e.Text = "Gr��e" + "  " + Format(Gr��e, "###,###,##0.##").ToString + " Byte"
            If Not gen.IsNull(ErstelltAm) Then
                Me.lblInfoErstelltAm.Text = "Erstellt am" + "  " + ErstelltAm.ToString
            Else
                Me.lblInfoErstelltAm.Text = "Erstellt am"
            End If
            If Not gen.IsNull(Ge�ndertAm) Then
                Me.lblInfoGe�ndertAm.Text = "Ge�ndert am" + "  " + Ge�ndertAm.ToString
            Else
                Me.lblInfoGe�ndertAm.Text = "Ge�ndert am"
            End If

        Catch ex As Exception
            Throw New Exception("WriteInfoFieldsDatei: " + ex.ToString())
        End Try
    End Sub
    Private Sub ClearInfoFieldsDatei()
        Try

            Me.lblInfoDatei.Text = "Datei"
            Me.lblInfoGr��e.Text = "Gr��e" + "0"
            Me.lblInfoErstelltAm.Text = "Erstellt am"
            Me.lblInfoGe�ndertAm.Text = "Ge�ndert am"

        Catch ex As Exception
            Throw New Exception("ClearInfoFieldsDatei: " + ex.ToString())
        End Try
    End Sub

    Private Sub ArchivOrdner_Clickxy()
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearInfoFieldsDatei()
            Dim fInfo As New clFileInfo
            Dim cTag As New clTagSchrankFachOrdner
            cTag = Me.ArchivOrdnerAblegen.GetSelTagInfo()
            Dim IDOrdner As New System.Guid
            IDOrdner = Me.ArchivOrdnerAblegen.GetSelectedOrd()
            If Not gen.IsNull(IDOrdner) Then
                Me.ContextMenuDokumentAngebenS.Show(Me, acP)
            End If

            If gen.IsNull(cTag) Then Exit Sub
            If cTag.typ = clTagSchrankFachOrdner.eTyp.typDateiAblegen Then
                fInfo = cTag.fileInfo
                If Not gen.IsNull(fInfo) Then
                    Me.WriteInfoFieldsDatei(fInfo.file_name, fInfo.file_gr��e, fInfo.file_erstelltAm, fInfo.file_ge�ndertAm)
                End If

            End If

        Catch ex As Exception
            Throw New Exception("ArchivOrdner_Click: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ArchivDokumentAblegen_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize

    End Sub
    Public Sub ResizeControl(ByVal h As Double, ByVal w As Double)
        Dim gen As New GeneralArchiv
        Try
            Me.Width = w
            Me.Height = h

            Me.ArchivOrdnerAblegen.ResizeControl(Me.PanelOrdnerAblegen.Height, Me.PanelOrdnerAblegen.Width)

        Catch ex As Exception
            Throw New Exception("ResizeControl: " + ex.ToString())
        End Try
    End Sub

    Private Sub ContextMenuDokumentAngeben_Popup(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MenuItemDokumentAusw�hlenS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDokumentAusw�hlenS.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim IDOrdner As New System.Guid
            IDOrdner = Me.ArchivOrdnerAblegen.GetSelectedOrd()
            If gen.IsNull(IDOrdner) Then
                MsgBox("Keinen Ordner ausgew�hlt!", MsgBoxStyle.Information, "Archivsystem")
                Exit Sub
            End If
            If Me.checkRechtOrdnerF�rDokumentAblegen(IDOrdner) Then
                Me.SelectFile()
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Function checkRechtOrdnerF�rDokumentAblegen(ByRef IDOrdner As System.Guid) As Boolean
        Dim gen As New GeneralArchiv
        Try
            Return True

        Catch ex As Exception
            Throw New Exception("checkRechtOrdnerF�rDokumentAblegen: " + ex.ToString())
        End Try
    End Function
    Private Sub MItemAusPostboxHinzuf�genS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MItemAusPostboxHinzuf�genS.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.AusPostboxHinzuf�gen(eTyp.Benutzer)

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MenuItemDokumentL�schenS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItemDokumentL�schenS.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.ArchivOrdnerAblegen.DeleteSelectedDokumentBeforeInsert()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BeziehungenL�schenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BeziehungenL�schenToolStripMenuItem.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.UTreeBeziehungen.SelectedNodes.Count > 0 Then
                Dim Item As Infragistics.Win.UltraWinTree.UltraTreeNode
                Item = Me.UTreeBeziehungen.SelectedNodes(0)
                If gen.IsNull(Item.Tag) Then Exit Sub
                If MsgBox("Wollen Sie die Beziehung wirklich l�schen?", MsgBoxStyle.YesNo, "Archivsystem") = MsgBoxResult.Yes Then
                    Me.UTreeBeziehungen.SelectedNodes(0).Remove()
                End If
            End If


        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub PanelOrdnerAblegen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelOrdnerAblegen.Click


    End Sub
    Private Sub PanelOrdnerAblegen_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PanelOrdnerAblegen.MouseUp
        Try
            Me.ContextMenuDokumentAngebenS.Show(Me, e.Location())
        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub

    Private Sub PanelOrdnerAblegen_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles PanelOrdnerAblegen.Resize
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ArchivOrdnerAblegen.Width = Me.PanelOrdnerAblegen.Width
            Me.ArchivOrdnerAblegen.Height = Me.PanelOrdnerAblegen.Height

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub AusZwischenablageEinf�genToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AusZwischenablageEinf�genToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            'Dim IDOrdner As New System.Guid
            'IDOrdner = Me.ArchivOrdnerAblegen.GetSelectedOrd()
            'If gen.IsNull(IDOrdner) Then
            '    MsgBox("Keinen Ordner ausgew�hlt!", MsgBoxStyle.Information, "Archivsystem")
            'End If
            'If Me.checkRechtOrdnerF�rDokumentAblegen(IDOrdner) Then

            '    Dim genMain As New General
            '    genMain.GarbColl()

            '    If Not gen.IsNull(Me.contZwischenablage.DateiKopieren) Then
            '        Me.loadFile(Me.contZwischenablage.DateiKopieren)
            '    ElseIf Not gen.IsNull(Me.contZwischenablage.DateiAusschneiden) Then
            '        Me.loadFile(Me.contZwischenablage.DateiAusschneiden)
            '        If System.IO.File.Exists(Me.contZwischenablage.DateiAusschneiden) Then
            '            Me.arrFilesToDelete.Add(Me.contZwischenablage.DateiAusschneiden)
            '        End If
            '    Else
            '        MsgBox("Es wurde keine Datei in der Zwischenablage zum Einf�gen ausgew�hlt!", MsgBoxStyle.Information, "Archivsystem")
            '    End If
            'End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub DateiEinf�genDragDrop()
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim IDOrdner As New System.Guid
            IDOrdner = Me.ArchivOrdnerAblegen.GetSelectedOrd()
            If gen.IsNull(IDOrdner) Then
                MsgBox("Keinen Ordner ausgew�hlt!", MsgBoxStyle.Information, "Archivsystem")
                Exit Sub
            End If

            Dim genMain As New GeneralArchiv
            genMain.GarbColl()

            If Me.checkRechtOrdnerF�rDokumentAblegen(IDOrdner) Then

                If Not gen.IsNull(Me.ArchivOrdnerAblegen.fileDragDrop) Then
                    Me.loadFile(Me.ArchivOrdnerAblegen.fileDragDrop)
                    If MsgBox("Soll die Datei aus der Zwischenablage nach dem Speichern gel�scht werden?", MsgBoxStyle.YesNo, "Archivsystem") = MsgBoxResult.Yes Then
                        Me.arrFilesToDelete.Add(Me.ArchivOrdnerAblegen.fileDragDrop)
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("DateiEinf�genDragDrop: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub ImportVerzeichnisseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim IDOrdner As New System.Guid
            IDOrdner = Me.ArchivOrdnerAblegen.GetSelectedOrd()
            If gen.IsNull(IDOrdner) Then
                MsgBox("Keinen Ordner ausgew�hlt!", MsgBoxStyle.Information, "Archivsystem")
                Exit Sub
            End If
            If Me.checkRechtOrdnerF�rDokumentAblegen(IDOrdner) Then
                Dim cl As New cArchive()
                cl.importVerzeichnisse(IDOrdner)
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UltraButtonSpeichern_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButtonSpeichern.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.DokumentSichern()
            Me.parentWindow.Close()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UltraButtonAbbrechen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraButtonAbbrechen.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.parentWindow.Close()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub PanelOrdnerAblegen_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelOrdnerAblegen.Paint

    End Sub


    Private Sub ULabelZwischenablage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub ArchivDokumentAblegen_Fill_Panel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ArchivDokumentAblegen_Fill_Panel.Paint

    End Sub

    Public Sub selectOrdner(ByVal IDOrdner As System.Guid)
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.ArchivOrdnerAblegen.SelectOrdner(IDOrdner)

        Catch ex As Exception
            Throw New Exception("selectOrdner: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub UltraToolbarsManager1_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs)

    End Sub

    Private Sub UltraToolbarsManager1_ToolClick_1(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case e.Tool.Key

                Case "Schlie�en"
                    Me.parentWindow.Close()

            End Select

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UltraExpandableGroupBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraExpandableGroupBox1.Click
        'If UltraExpandableGroupBox1.Expanded Then
        '    UltraExpandableGroupBox1.Expanded = False
        'Else
        '    UltraExpandableGroupBox1.Expanded = True
        'End If
    End Sub

    Private Sub UltraExpandableGroupBox1_ExpandedStateChanging(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles UltraExpandableGroupBox1.ExpandedStateChanging
        Try
            If UltraExpandableGroupBox1.Focused Then Me.mainWindow.showErweitertEinAus(Me.UltraExpandableGroupBox1.Expanded)

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        End Try
    End Sub

    Private Sub PanelOrdnerAblegen_VisibleChanged(sender As Object, e As EventArgs) Handles PanelOrdnerAblegen.VisibleChanged
        Try
            If Me.Visible Then
                Me.ArchivOrdnerAblegen.ResizeControl(Me.PanelOrdnerAblegen.Height, Me.PanelOrdnerAblegen.Width)
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class
