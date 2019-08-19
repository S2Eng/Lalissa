Imports Infragistics.Win.UltraWinTree

Imports Infragistics.Win.UltraWinListView
Imports Infragistics.Win.UltraWinToolbars
Imports System.Windows.Forms



Public Class frmNachricht
    Inherits System.Windows.Forms.Form



    Private General As New GeneralArchiv
    Private info As New Info

    Public modalWindow As contPlanungMain
    Public modalWindowErinnerung As frmOffeneTermine

    Public _typ As New GeneralArchiv.eTypPlanung

    Private aufgabe As New sqlAufgaben
    Public _idaufgabe As System.Guid
    Private _idart As New System.Guid

    Private frmStatus As New GeneralArchiv.eStatusForm

    Private contTxtEditor As New QS2.Desktop.Txteditor.contTxtEditor()
    Public contListeAnhang As New contListeAnhang

    Private status As String = ""

    Public IDobject As String
    Public patient As String = ""

    Public dateTemp As DateTime = Nothing
    Public timeTemp As DateTime = Nothing

    Public selTeilnehmerauswahlLast As String = "G"
    Public doEditor As New QS2.Desktop.Txteditor.doEditor()

    Public _ErstelltVon As String = ""





#Region "initCodeAuto"

    Friend WithEvents CMenuStripAnhang As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SpeichernUnterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DateiÖffnenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents UTextMailCC As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Public WithEvents UTextMailAn As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Public WithEvents lblAn As System.Windows.Forms.Label
    Friend WithEvents UltraStatusBar1 As Infragistics.Win.UltraWinStatusBar.UltraStatusBar
    Friend WithEvents UComboPersonen As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Public WithEvents lblIntVerteiler As System.Windows.Forms.Label
    Friend WithEvents CMenuStripHistorie As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HistorieLöschenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelErinnerungen As System.Windows.Forms.Panel
    Friend WithEvents UToolbarsManagerTxt As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents layOben As Infragistics.Win.Misc.UltraGridBagLayoutManager
    Friend WithEvents PanelMitte As System.Windows.Forms.Panel
    Friend WithEvents PanelLeisteText As System.Windows.Forms.Panel
    Friend WithEvents _PanelLeisteText_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelLeisteText_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelLeisteText_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelLeisteText_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents PanelText As System.Windows.Forms.Panel
    Friend WithEvents UltraGroupBoxHeader As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBoxText As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents UltraGroupBoxButtonLieste As Infragistics.Win.Misc.UltraGroupBox
    Private WithEvents buttonBar1 As TXTextControl.ButtonBar
    Friend WithEvents PanelVonBis As System.Windows.Forms.Panel
    Friend WithEvents UButtonAbbrechen As Infragistics.Win.Misc.UltraButton
    Public WithEvents txtTitel As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Public WithEvents lblBetreff As System.Windows.Forms.Label
    Friend WithEvents PanelEinladen As System.Windows.Forms.Panel
    Public WithEvents txtTeilnehmer As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UButtonTeilnehmer As Infragistics.Win.Misc.UltraButton
    Friend WithEvents PanelDatum As System.Windows.Forms.Panel
    Friend WithEvents PanelBetreff As System.Windows.Forms.Panel
    Friend WithEvents PanelMailadressen2 As System.Windows.Forms.Panel
    Public WithEvents lblCC As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PanelUnten As System.Windows.Forms.Panel
    Friend WithEvents layText As Infragistics.Win.Misc.UltraGridBagLayoutManager



#End Region

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
    Friend WithEvents UltraToolbarsManager As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents AufgabeTerminNeu_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents _AufgabeTerminNeu_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _AufgabeTerminNeu_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _AufgabeTerminNeu_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _AufgabeTerminNeu_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents UltraComboTimeRemember As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents FlagRemember As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Public WithEvents lblEnde As System.Windows.Forms.Label
    Public WithEvents lblVon As System.Windows.Forms.Label
    Friend WithEvents UDtTimeEndet As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UDtTimeBeginnt As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UDtDateEndet As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UDtDateBeginnt As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents ImageListGeneral As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNachricht))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim GridBagConstraint1 As Infragistics.Win.Layout.GridBagConstraint = New Infragistics.Win.Layout.GridBagConstraint()
        Dim OptionSet1 As Infragistics.Win.UltraWinToolbars.OptionSet = New Infragistics.Win.UltraWinToolbars.OptionSet("lblOnOffHtmlText")
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1")
        Dim ButtonTool40 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Neu")
        Dim ButtonTool41 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Öffnen")
        Dim ButtonTool42 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Speichern")
        Dim ButtonTool15 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Exportieren")
        Dim StateButtonTool6 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtAnsicht", "")
        Dim ButtonTool43 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Drucken")
        Dim ButtonTool25 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Druckvorschau")
        Dim ButtonTool45 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Ausschneiden")
        Dim ButtonTool51 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Kopieren")
        Dim ButtonTool52 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Einfügen")
        Dim ButtonTool53 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_RückgängigMachen")
        Dim ButtonTool54 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Wiederherstellen")
        Dim ButtonTool55 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Suchen")
        Dim StateButtonTool3 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtHtml", "lblOnOffHtmlText")
        Dim StateButtonTool4 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtText", "lblOnOffHtmlText")
        Dim ButtonTool34 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Neu")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool35 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Öffnen")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool36 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Speichern")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool37 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Drucken")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool39 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Ausschneiden")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool46 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Kopieren")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool47 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Einfügen")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool48 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_RückgängigMachen")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool49 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Wiederherstellen")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool50 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Suchen")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool10 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Exportieren")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim StateButtonTool1 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtHtml", "lblOnOffHtmlText")
        Dim StateButtonTool2 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtText", "lblOnOffHtmlText")
        Dim LabelTool1 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("lblOnOffHtmlText")
        Dim StateButtonTool5 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("statButtAnsicht", "")
        Dim ButtonTool19 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("dok_Druckvorschau")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraStatusPanel1 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim UltraStatusPanel2 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim UltraStatusPanel3 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim UltraStatusPanel4 As Infragistics.Win.UltraWinStatusBar.UltraStatusPanel = New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel()
        Dim ButtonTool21 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Schließen")
        Dim RibbonTab1 As Infragistics.Win.UltraWinToolbars.RibbonTab = New Infragistics.Win.UltraWinToolbars.RibbonTab("ribbNachricht")
        Dim RibbonGroup1 As Infragistics.Win.UltraWinToolbars.RibbonGroup = New Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbGrpAktion")
        Dim ButtonTool11 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Schließen")
        Dim ButtonTool6 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonSenden")
        Dim ButtonTool16 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttSpeichern")
        Dim ButtonTool17 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Abschließen")
        Dim ButtonTool18 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Löschen")
        Dim RibbonGroup2 As Infragistics.Win.UltraWinToolbars.RibbonGroup = New Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbGrpTeilnehmer")
        Dim StateButtonTool9 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("Teilnehmer", "")
        Dim RibbonGroup3 As Infragistics.Win.UltraWinToolbars.RibbonGroup = New Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbGrpribbAnhang")
        Dim ButtonTool23 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("DateiHinzufügen")
        Dim PopupControlContainerTool2 As Infragistics.Win.UltraWinToolbars.PopupControlContainerTool = New Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("popUpContListeAnhang")
        Dim UltraToolbar2 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("Aufgabe, Termin neu ...")
        Dim ButtonTool1 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Schließen")
        Dim ButtonTool3 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonSenden")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttSpeichern")
        Dim ButtonTool5 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Abschließen")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Löschen")
        Dim StateButtonTool8 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("Teilnehmer", "")
        Dim ButtonTool24 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("DateiHinzufügen")
        Dim PopupControlContainerTool3 As Infragistics.Win.UltraWinToolbars.PopupControlContainerTool = New Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("popUpContListeAnhang")
        Dim ButtonTool7 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("buttSpeichern")
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool8 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Löschen")
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool9 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Schließen")
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool12 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("ButtonSenden")
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool13 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Abschließen")
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool14 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Um1StundeVerschieben")
        Dim ButtonTool22 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("DateiHinzufügen")
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim PopupControlContainerTool1 As Infragistics.Win.UltraWinToolbars.PopupControlContainerTool = New Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("popUpContListeAnhang")
        Dim StateButtonTool7 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("Teilnehmer", "")
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.CMenuStripHistorie = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HistorieLöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageListGeneral = New System.Windows.Forms.ImageList(Me.components)
        Me.UComboPersonen = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lblIntVerteiler = New System.Windows.Forms.Label()
        Me.AufgabeTerminNeu_Fill_Panel = New System.Windows.Forms.Panel()
        Me.UltraGroupBoxHeader = New Infragistics.Win.Misc.UltraGroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelMitte = New System.Windows.Forms.Panel()
        Me.UltraGroupBoxText = New Infragistics.Win.Misc.UltraGroupBox()
        Me.PanelText = New System.Windows.Forms.Panel()
        Me.PanelLeisteText = New System.Windows.Forms.Panel()
        Me.UltraGroupBoxButtonLieste = New Infragistics.Win.Misc.UltraGroupBox()
        Me.buttonBar1 = New TXTextControl.ButtonBar()
        Me._PanelLeisteText_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.UToolbarsManagerTxt = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._PanelLeisteText_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelLeisteText_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelLeisteText_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.PanelUnten = New System.Windows.Forms.Panel()
        Me.PanelDatum = New System.Windows.Forms.Panel()
        Me.PanelVonBis = New System.Windows.Forms.Panel()
        Me.UDtDateBeginnt = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblVon = New System.Windows.Forms.Label()
        Me.UDtDateEndet = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblEnde = New System.Windows.Forms.Label()
        Me.UDtTimeEndet = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.UDtTimeBeginnt = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.PanelErinnerungen = New System.Windows.Forms.Panel()
        Me.UltraComboTimeRemember = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.FlagRemember = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.PanelBetreff = New System.Windows.Forms.Panel()
        Me.txtTitel = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblBetreff = New System.Windows.Forms.Label()
        Me.PanelMailadressen2 = New System.Windows.Forms.Panel()
        Me.UTextMailAn = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblAn = New System.Windows.Forms.Label()
        Me.UTextMailCC = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.lblCC = New System.Windows.Forms.Label()
        Me.UButtonAbbrechen = New Infragistics.Win.Misc.UltraButton()
        Me.PanelEinladen = New System.Windows.Forms.Panel()
        Me.UButtonTeilnehmer = New Infragistics.Win.Misc.UltraButton()
        Me.txtTeilnehmer = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.UltraStatusBar1 = New Infragistics.Win.UltraWinStatusBar.UltraStatusBar()
        Me.CMenuStripAnhang = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DateiÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpeichernUnterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.UltraToolbarsManager = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.layText = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.layOben = New Infragistics.Win.Misc.UltraGridBagLayoutManager(Me.components)
        Me.CMenuStripHistorie.SuspendLayout()
        CType(Me.UComboPersonen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AufgabeTerminNeu_Fill_Panel.SuspendLayout()
        CType(Me.UltraGroupBoxHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBoxHeader.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PanelMitte.SuspendLayout()
        CType(Me.UltraGroupBoxText, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBoxText.SuspendLayout()
        Me.PanelLeisteText.SuspendLayout()
        CType(Me.UltraGroupBoxButtonLieste, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraGroupBoxButtonLieste.SuspendLayout()
        CType(Me.UToolbarsManagerTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDatum.SuspendLayout()
        Me.PanelVonBis.SuspendLayout()
        CType(Me.UDtDateBeginnt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDtDateEndet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDtTimeEndet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UDtTimeBeginnt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelErinnerungen.SuspendLayout()
        CType(Me.UltraComboTimeRemember, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FlagRemember, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBetreff.SuspendLayout()
        CType(Me.txtTitel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMailadressen2.SuspendLayout()
        CType(Me.UTextMailAn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UTextMailCC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEinladen.SuspendLayout()
        CType(Me.txtTeilnehmer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMenuStripAnhang.SuspendLayout()
        CType(Me.UltraToolbarsManager, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.layOben, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CMenuStripHistorie
        '
        Me.CMenuStripHistorie.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HistorieLöschenToolStripMenuItem})
        Me.CMenuStripHistorie.Name = "CMenuStripHistorie"
        Me.CMenuStripHistorie.Size = New System.Drawing.Size(172, 26)
        '
        'HistorieLöschenToolStripMenuItem
        '
        Me.HistorieLöschenToolStripMenuItem.Name = "HistorieLöschenToolStripMenuItem"
        Me.HistorieLöschenToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.HistorieLöschenToolStripMenuItem.Text = "Historie löschen ..."
        '
        'ImageListGeneral
        '
        Me.ImageListGeneral.ImageStream = CType(resources.GetObject("ImageListGeneral.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListGeneral.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListGeneral.Images.SetKeyName(0, "")
        Me.ImageListGeneral.Images.SetKeyName(1, "")
        Me.ImageListGeneral.Images.SetKeyName(2, "")
        Me.ImageListGeneral.Images.SetKeyName(3, "")
        Me.ImageListGeneral.Images.SetKeyName(4, "")
        Me.ImageListGeneral.Images.SetKeyName(5, "")
        Me.ImageListGeneral.Images.SetKeyName(6, "")
        Me.ImageListGeneral.Images.SetKeyName(7, "")
        Me.ImageListGeneral.Images.SetKeyName(8, "")
        Me.ImageListGeneral.Images.SetKeyName(9, "")
        Me.ImageListGeneral.Images.SetKeyName(10, "")
        Me.ImageListGeneral.Images.SetKeyName(11, "")
        Me.ImageListGeneral.Images.SetKeyName(12, "")
        Me.ImageListGeneral.Images.SetKeyName(13, "! - I39.ico")
        Me.ImageListGeneral.Images.SetKeyName(14, "NEW16.ICO")
        Me.ImageListGeneral.Images.SetKeyName(15, "Archiv.ico")
        Me.ImageListGeneral.Images.SetKeyName(16, "147.ico")
        Me.ImageListGeneral.Images.SetKeyName(17, "find_doc.ico")
        Me.ImageListGeneral.Images.SetKeyName(18, "addpr16.ico")
        Me.ImageListGeneral.Images.SetKeyName(19, "car3.ico")
        Me.ImageListGeneral.Images.SetKeyName(20, "copy.ico")
        Me.ImageListGeneral.Images.SetKeyName(21, "E - I259.ico")
        '
        'UComboPersonen
        '
        Appearance1.FontData.Name = "Microsoft Sans Serif"
        Me.UComboPersonen.Appearance = Appearance1
        Me.UComboPersonen.AutoSize = False
        Me.UComboPersonen.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched
        Me.UComboPersonen.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.UComboPersonen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance2.BackColor = System.Drawing.Color.White
        Appearance2.BackColorDisabled = System.Drawing.Color.White
        Appearance2.BorderColor = System.Drawing.Color.Black
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.ForeColorDisabled = System.Drawing.Color.Black
        Me.UComboPersonen.ItemAppearance = Appearance2
        Me.UComboPersonen.Location = New System.Drawing.Point(587, 11)
        Me.UComboPersonen.Name = "UComboPersonen"
        Me.UComboPersonen.Size = New System.Drawing.Size(147, 23)
        Me.UComboPersonen.TabIndex = 2
        '
        'lblIntVerteiler
        '
        Me.lblIntVerteiler.BackColor = System.Drawing.Color.Transparent
        Me.lblIntVerteiler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntVerteiler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblIntVerteiler.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblIntVerteiler.Location = New System.Drawing.Point(523, 11)
        Me.lblIntVerteiler.Name = "lblIntVerteiler"
        Me.lblIntVerteiler.Size = New System.Drawing.Size(74, 23)
        Me.lblIntVerteiler.TabIndex = 402
        Me.lblIntVerteiler.Text = "Int. Verteiler"
        Me.lblIntVerteiler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AufgabeTerminNeu_Fill_Panel
        '
        Me.AufgabeTerminNeu_Fill_Panel.BackColor = System.Drawing.Color.White
        Me.AufgabeTerminNeu_Fill_Panel.Controls.Add(Me.UltraGroupBoxHeader)
        Me.AufgabeTerminNeu_Fill_Panel.Controls.Add(Me.UltraStatusBar1)
        Me.AufgabeTerminNeu_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.AufgabeTerminNeu_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AufgabeTerminNeu_Fill_Panel.Location = New System.Drawing.Point(0, 70)
        Me.AufgabeTerminNeu_Fill_Panel.Name = "AufgabeTerminNeu_Fill_Panel"
        Me.AufgabeTerminNeu_Fill_Panel.Size = New System.Drawing.Size(833, 566)
        Me.AufgabeTerminNeu_Fill_Panel.TabIndex = 0
        '
        'UltraGroupBoxHeader
        '
        Appearance3.BackColor = System.Drawing.Color.Gainsboro
        Me.UltraGroupBoxHeader.Appearance = Appearance3
        Me.UltraGroupBoxHeader.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None
        Me.UltraGroupBoxHeader.Controls.Add(Me.Panel1)
        Me.UltraGroupBoxHeader.Controls.Add(Me.PanelUnten)
        Me.UltraGroupBoxHeader.Controls.Add(Me.PanelDatum)
        Me.UltraGroupBoxHeader.Controls.Add(Me.PanelBetreff)
        Me.UltraGroupBoxHeader.Controls.Add(Me.PanelMailadressen2)
        Me.UltraGroupBoxHeader.Controls.Add(Me.PanelEinladen)
        Me.UltraGroupBoxHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBoxHeader.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGroupBoxHeader.Location = New System.Drawing.Point(0, 0)
        Me.UltraGroupBoxHeader.Name = "UltraGroupBoxHeader"
        Me.UltraGroupBoxHeader.Size = New System.Drawing.Size(833, 542)
        Me.UltraGroupBoxHeader.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.PanelMitte)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 219)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(833, 284)
        Me.Panel1.TabIndex = 417
        '
        'PanelMitte
        '
        Me.PanelMitte.BackColor = System.Drawing.Color.Transparent
        Me.PanelMitte.Controls.Add(Me.UltraGroupBoxText)
        Me.PanelMitte.Controls.Add(Me.PanelLeisteText)
        Me.PanelMitte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMitte.Location = New System.Drawing.Point(0, 0)
        Me.PanelMitte.Name = "PanelMitte"
        Me.PanelMitte.Size = New System.Drawing.Size(833, 284)
        Me.PanelMitte.TabIndex = 416
        '
        'UltraGroupBoxText
        '
        Appearance4.BackColor = System.Drawing.Color.Gainsboro
        Me.UltraGroupBoxText.Appearance = Appearance4
        Me.UltraGroupBoxText.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None
        Me.UltraGroupBoxText.Controls.Add(Me.PanelText)
        Me.UltraGroupBoxText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGroupBoxText.Location = New System.Drawing.Point(0, 57)
        Me.UltraGroupBoxText.Name = "UltraGroupBoxText"
        Me.UltraGroupBoxText.Size = New System.Drawing.Size(833, 227)
        Me.UltraGroupBoxText.TabIndex = 3
        '
        'PanelText
        '
        Me.PanelText.BackColor = System.Drawing.Color.White
        Me.PanelText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        GridBagConstraint1.Fill = Infragistics.Win.Layout.FillType.Both
        GridBagConstraint1.Insets.Bottom = 5
        GridBagConstraint1.Insets.Left = 5
        GridBagConstraint1.Insets.Right = 5
        GridBagConstraint1.Insets.Top = 5
        Me.layText.SetGridBagConstraint(Me.PanelText, GridBagConstraint1)
        Me.PanelText.Location = New System.Drawing.Point(5, 5)
        Me.PanelText.Name = "PanelText"
        Me.layText.SetPreferredSize(Me.PanelText, New System.Drawing.Size(497, 226))
        Me.PanelText.Size = New System.Drawing.Size(823, 217)
        Me.PanelText.TabIndex = 0
        '
        'PanelLeisteText
        '
        Me.PanelLeisteText.BackColor = System.Drawing.Color.White
        Me.PanelLeisteText.Controls.Add(Me.UltraGroupBoxButtonLieste)
        Me.PanelLeisteText.Controls.Add(Me._PanelLeisteText_Toolbars_Dock_Area_Left)
        Me.PanelLeisteText.Controls.Add(Me._PanelLeisteText_Toolbars_Dock_Area_Right)
        Me.PanelLeisteText.Controls.Add(Me._PanelLeisteText_Toolbars_Dock_Area_Bottom)
        Me.PanelLeisteText.Controls.Add(Me._PanelLeisteText_Toolbars_Dock_Area_Top)
        Me.PanelLeisteText.Cursor = System.Windows.Forms.Cursors.Default
        Me.PanelLeisteText.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelLeisteText.Location = New System.Drawing.Point(0, 0)
        Me.PanelLeisteText.Name = "PanelLeisteText"
        Me.PanelLeisteText.Size = New System.Drawing.Size(833, 57)
        Me.PanelLeisteText.TabIndex = 381
        '
        'UltraGroupBoxButtonLieste
        '
        Me.UltraGroupBoxButtonLieste.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.None
        Me.UltraGroupBoxButtonLieste.Controls.Add(Me.buttonBar1)
        Me.UltraGroupBoxButtonLieste.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraGroupBoxButtonLieste.HeaderBorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGroupBoxButtonLieste.Location = New System.Drawing.Point(0, 27)
        Me.UltraGroupBoxButtonLieste.Name = "UltraGroupBoxButtonLieste"
        Me.UltraGroupBoxButtonLieste.Size = New System.Drawing.Size(833, 38)
        Me.UltraGroupBoxButtonLieste.TabIndex = 385
        Me.UltraGroupBoxButtonLieste.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.VisualStudio2005
        '
        'buttonBar1
        '
        Me.buttonBar1.BackColor = System.Drawing.Color.Gainsboro
        Me.buttonBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.buttonBar1.Location = New System.Drawing.Point(0, 0)
        Me.buttonBar1.Name = "buttonBar1"
        Me.buttonBar1.Size = New System.Drawing.Size(833, 28)
        Me.buttonBar1.TabIndex = 386
        Me.buttonBar1.TabStop = False
        Me.buttonBar1.Text = "buttonBar1"
        '
        '_PanelLeisteText_Toolbars_Dock_Area_Left
        '
        Me._PanelLeisteText_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelLeisteText_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.White
        Me._PanelLeisteText_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._PanelLeisteText_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelLeisteText_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 27)
        Me._PanelLeisteText_Toolbars_Dock_Area_Left.Name = "_PanelLeisteText_Toolbars_Dock_Area_Left"
        Me._PanelLeisteText_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 30)
        Me._PanelLeisteText_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UToolbarsManagerTxt
        '
        'UToolbarsManagerTxt
        '
        Me.UToolbarsManagerTxt.DesignerFlags = 1
        Me.UToolbarsManagerTxt.DockWithinContainer = Me.PanelLeisteText
        Me.UToolbarsManagerTxt.LockToolbars = True
        OptionSet1.AllowAllUp = False
        Me.UToolbarsManagerTxt.OptionSets.Add(OptionSet1)
        Me.UToolbarsManagerTxt.ShowFullMenusDelay = 500
        Me.UToolbarsManagerTxt.ShowQuickCustomizeButton = False
        Me.UToolbarsManagerTxt.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.OfficeXP
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        ButtonTool15.InstanceProps.IsFirstInGroup = True
        StateButtonTool6.InstanceProps.IsFirstInGroup = True
        ButtonTool43.InstanceProps.IsFirstInGroup = True
        ButtonTool45.InstanceProps.IsFirstInGroup = True
        ButtonTool53.InstanceProps.IsFirstInGroup = True
        ButtonTool55.InstanceProps.IsFirstInGroup = True
        StateButtonTool3.Checked = True
        StateButtonTool3.InstanceProps.IsFirstInGroup = True
        StateButtonTool3.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool4.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool40, ButtonTool41, ButtonTool42, ButtonTool15, StateButtonTool6, ButtonTool43, ButtonTool25, ButtonTool45, ButtonTool51, ButtonTool52, ButtonTool53, ButtonTool54, ButtonTool55, StateButtonTool3, StateButtonTool4})
        UltraToolbar1.Text = "UltraToolbar1"
        Me.UToolbarsManagerTxt.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        Appearance5.Image = CType(resources.GetObject("Appearance5.Image"), Object)
        ButtonTool34.SharedPropsInternal.AppearancesSmall.Appearance = Appearance5
        ButtonTool34.SharedPropsInternal.Caption = "Neu"
        Appearance6.Image = CType(resources.GetObject("Appearance6.Image"), Object)
        ButtonTool35.SharedPropsInternal.AppearancesSmall.Appearance = Appearance6
        ButtonTool35.SharedPropsInternal.Caption = "Öffnen"
        Appearance7.Image = CType(resources.GetObject("Appearance7.Image"), Object)
        ButtonTool36.SharedPropsInternal.AppearancesSmall.Appearance = Appearance7
        ButtonTool36.SharedPropsInternal.Caption = "Speichern"
        Appearance8.Image = CType(resources.GetObject("Appearance8.Image"), Object)
        ButtonTool37.SharedPropsInternal.AppearancesSmall.Appearance = Appearance8
        ButtonTool37.SharedPropsInternal.Caption = "Drucken"
        Appearance9.Image = CType(resources.GetObject("Appearance9.Image"), Object)
        ButtonTool39.SharedPropsInternal.AppearancesSmall.Appearance = Appearance9
        ButtonTool39.SharedPropsInternal.Caption = "Ausschneiden"
        Appearance10.Image = CType(resources.GetObject("Appearance10.Image"), Object)
        ButtonTool46.SharedPropsInternal.AppearancesSmall.Appearance = Appearance10
        ButtonTool46.SharedPropsInternal.Caption = "Kopieren"
        Appearance11.Image = CType(resources.GetObject("Appearance11.Image"), Object)
        ButtonTool47.SharedPropsInternal.AppearancesSmall.Appearance = Appearance11
        ButtonTool47.SharedPropsInternal.Caption = "Einfügen"
        Appearance12.Image = CType(resources.GetObject("Appearance12.Image"), Object)
        ButtonTool48.SharedPropsInternal.AppearancesSmall.Appearance = Appearance12
        ButtonTool48.SharedPropsInternal.Caption = "Rückgängig machen"
        ButtonTool48.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance13.Image = CType(resources.GetObject("Appearance13.Image"), Object)
        ButtonTool49.SharedPropsInternal.AppearancesSmall.Appearance = Appearance13
        ButtonTool49.SharedPropsInternal.Caption = "Wiederherstellen"
        ButtonTool49.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        Appearance14.Image = CType(resources.GetObject("Appearance14.Image"), Object)
        ButtonTool50.SharedPropsInternal.AppearancesSmall.Appearance = Appearance14
        ButtonTool50.SharedPropsInternal.Caption = "Suchen"
        Appearance15.Image = CType(resources.GetObject("Appearance15.Image"), Object)
        ButtonTool10.SharedPropsInternal.AppearancesLarge.Appearance = Appearance15
        Appearance16.Image = CType(resources.GetObject("Appearance16.Image"), Object)
        ButtonTool10.SharedPropsInternal.AppearancesSmall.Appearance = Appearance16
        ButtonTool10.SharedPropsInternal.Caption = "Export PDF"
        ButtonTool10.SharedPropsInternal.ToolTipText = "Als PDF exportieren"
        StateButtonTool1.Checked = True
        StateButtonTool1.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool1.OptionSetKey = "lblOnOffHtmlText"
        StateButtonTool1.SharedPropsInternal.Caption = "Html"
        StateButtonTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        StateButtonTool2.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        StateButtonTool2.OptionSetKey = "lblOnOffHtmlText"
        StateButtonTool2.SharedPropsInternal.Caption = "Text"
        StateButtonTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        LabelTool1.SharedPropsInternal.Caption = "lblOnOffHtmlText"
        StateButtonTool5.SharedPropsInternal.Caption = "Ansicht"
        StateButtonTool5.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        Appearance17.Image = CType(resources.GetObject("Appearance17.Image"), Object)
        ButtonTool19.SharedPropsInternal.AppearancesSmall.Appearance = Appearance17
        ButtonTool19.SharedPropsInternal.Caption = "Druckvorschau"
        Me.UToolbarsManagerTxt.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool34, ButtonTool35, ButtonTool36, ButtonTool37, ButtonTool39, ButtonTool46, ButtonTool47, ButtonTool48, ButtonTool49, ButtonTool50, ButtonTool10, StateButtonTool1, StateButtonTool2, LabelTool1, StateButtonTool5, ButtonTool19})
        '
        '_PanelLeisteText_Toolbars_Dock_Area_Right
        '
        Me._PanelLeisteText_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelLeisteText_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.White
        Me._PanelLeisteText_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._PanelLeisteText_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelLeisteText_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(833, 27)
        Me._PanelLeisteText_Toolbars_Dock_Area_Right.Name = "_PanelLeisteText_Toolbars_Dock_Area_Right"
        Me._PanelLeisteText_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 30)
        Me._PanelLeisteText_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UToolbarsManagerTxt
        '
        '_PanelLeisteText_Toolbars_Dock_Area_Bottom
        '
        Me._PanelLeisteText_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelLeisteText_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.White
        Me._PanelLeisteText_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._PanelLeisteText_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelLeisteText_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 57)
        Me._PanelLeisteText_Toolbars_Dock_Area_Bottom.Name = "_PanelLeisteText_Toolbars_Dock_Area_Bottom"
        Me._PanelLeisteText_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(833, 0)
        Me._PanelLeisteText_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UToolbarsManagerTxt
        '
        '_PanelLeisteText_Toolbars_Dock_Area_Top
        '
        Me._PanelLeisteText_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelLeisteText_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.White
        Me._PanelLeisteText_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._PanelLeisteText_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelLeisteText_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._PanelLeisteText_Toolbars_Dock_Area_Top.Name = "_PanelLeisteText_Toolbars_Dock_Area_Top"
        Me._PanelLeisteText_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(833, 27)
        Me._PanelLeisteText_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UToolbarsManagerTxt
        '
        'PanelUnten
        '
        Me.PanelUnten.BackColor = System.Drawing.Color.Transparent
        Me.PanelUnten.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelUnten.Location = New System.Drawing.Point(0, 503)
        Me.PanelUnten.Name = "PanelUnten"
        Me.PanelUnten.Size = New System.Drawing.Size(833, 39)
        Me.PanelUnten.TabIndex = 6
        Me.PanelUnten.Visible = False
        '
        'PanelDatum
        '
        Me.PanelDatum.BackColor = System.Drawing.Color.Transparent
        Me.PanelDatum.Controls.Add(Me.UComboPersonen)
        Me.PanelDatum.Controls.Add(Me.PanelVonBis)
        Me.PanelDatum.Controls.Add(Me.PanelErinnerungen)
        Me.PanelDatum.Controls.Add(Me.lblIntVerteiler)
        Me.PanelDatum.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelDatum.Location = New System.Drawing.Point(0, 157)
        Me.PanelDatum.Name = "PanelDatum"
        Me.PanelDatum.Size = New System.Drawing.Size(833, 62)
        Me.PanelDatum.TabIndex = 3
        '
        'PanelVonBis
        '
        Me.PanelVonBis.Controls.Add(Me.UDtDateBeginnt)
        Me.PanelVonBis.Controls.Add(Me.lblVon)
        Me.PanelVonBis.Controls.Add(Me.UDtDateEndet)
        Me.PanelVonBis.Controls.Add(Me.lblEnde)
        Me.PanelVonBis.Controls.Add(Me.UDtTimeEndet)
        Me.PanelVonBis.Controls.Add(Me.UDtTimeBeginnt)
        Me.PanelVonBis.Location = New System.Drawing.Point(19, 6)
        Me.PanelVonBis.Name = "PanelVonBis"
        Me.PanelVonBis.Size = New System.Drawing.Size(213, 50)
        Me.PanelVonBis.TabIndex = 0
        '
        'UDtDateBeginnt
        '
        Appearance18.BackColor = System.Drawing.Color.White
        Appearance18.BackColorDisabled = System.Drawing.Color.White
        Appearance18.BorderColor = System.Drawing.Color.Black
        Appearance18.FontData.BoldAsString = "False"
        Appearance18.FontData.ItalicAsString = "False"
        Appearance18.FontData.Name = "Microsoft Sans Serif"
        Appearance18.FontData.SizeInPoints = 8.25!
        Appearance18.FontData.StrikeoutAsString = "False"
        Appearance18.FontData.UnderlineAsString = "False"
        Appearance18.ForeColor = System.Drawing.Color.Black
        Appearance18.ForeColorDisabled = System.Drawing.Color.Black
        Me.UDtDateBeginnt.Appearance = Appearance18
        Me.UDtDateBeginnt.BackColor = System.Drawing.Color.White
        Me.UDtDateBeginnt.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.UDtDateBeginnt.Location = New System.Drawing.Point(64, 1)
        Me.UDtDateBeginnt.Name = "UDtDateBeginnt"
        Me.UDtDateBeginnt.Size = New System.Drawing.Size(96, 21)
        Me.UDtDateBeginnt.TabIndex = 0
        Me.UDtDateBeginnt.Value = Nothing
        '
        'lblVon
        '
        Me.lblVon.BackColor = System.Drawing.Color.Transparent
        Me.lblVon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVon.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVon.Location = New System.Drawing.Point(13, 1)
        Me.lblVon.Name = "lblVon"
        Me.lblVon.Size = New System.Drawing.Size(80, 23)
        Me.lblVon.TabIndex = 378
        Me.lblVon.Text = "Start"
        Me.lblVon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UDtDateEndet
        '
        Appearance19.BackColor = System.Drawing.Color.White
        Appearance19.BackColorDisabled = System.Drawing.Color.White
        Appearance19.BorderColor = System.Drawing.Color.Black
        Appearance19.FontData.BoldAsString = "False"
        Appearance19.FontData.ItalicAsString = "False"
        Appearance19.FontData.Name = "Microsoft Sans Serif"
        Appearance19.FontData.SizeInPoints = 8.25!
        Appearance19.FontData.StrikeoutAsString = "False"
        Appearance19.FontData.UnderlineAsString = "False"
        Appearance19.ForeColor = System.Drawing.Color.Black
        Appearance19.ForeColorDisabled = System.Drawing.Color.Black
        Me.UDtDateEndet.Appearance = Appearance19
        Me.UDtDateEndet.BackColor = System.Drawing.Color.White
        Me.UDtDateEndet.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.UDtDateEndet.Location = New System.Drawing.Point(64, 23)
        Me.UDtDateEndet.Name = "UDtDateEndet"
        Me.UDtDateEndet.Size = New System.Drawing.Size(96, 21)
        Me.UDtDateEndet.TabIndex = 2
        Me.UDtDateEndet.Value = Nothing
        '
        'lblEnde
        '
        Me.lblEnde.BackColor = System.Drawing.Color.Transparent
        Me.lblEnde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnde.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEnde.Location = New System.Drawing.Point(13, 23)
        Me.lblEnde.Name = "lblEnde"
        Me.lblEnde.Size = New System.Drawing.Size(80, 23)
        Me.lblEnde.TabIndex = 380
        Me.lblEnde.Text = "Ende"
        Me.lblEnde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UDtTimeEndet
        '
        Appearance20.BackColor = System.Drawing.Color.White
        Appearance20.BackColorDisabled = System.Drawing.Color.White
        Appearance20.BorderColor = System.Drawing.Color.Black
        Appearance20.FontData.BoldAsString = "False"
        Appearance20.FontData.ItalicAsString = "False"
        Appearance20.FontData.Name = "Microsoft Sans Serif"
        Appearance20.FontData.SizeInPoints = 8.25!
        Appearance20.FontData.StrikeoutAsString = "False"
        Appearance20.FontData.UnderlineAsString = "False"
        Appearance20.ForeColor = System.Drawing.Color.Black
        Appearance20.ForeColorDisabled = System.Drawing.Color.Black
        Me.UDtTimeEndet.Appearance = Appearance20
        Me.UDtTimeEndet.BackColor = System.Drawing.Color.White
        Me.UDtTimeEndet.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.UDtTimeEndet.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never
        Me.UDtTimeEndet.FormatString = ""
        Me.UDtTimeEndet.Location = New System.Drawing.Point(163, 24)
        Me.UDtTimeEndet.MaskInput = "hh:mm"
        Me.UDtTimeEndet.Name = "UDtTimeEndet"
        Me.UDtTimeEndet.Size = New System.Drawing.Size(45, 21)
        Me.UDtTimeEndet.TabIndex = 3
        Me.UDtTimeEndet.Value = Nothing
        '
        'UDtTimeBeginnt
        '
        Appearance21.BackColor = System.Drawing.Color.White
        Appearance21.BackColorDisabled = System.Drawing.Color.White
        Appearance21.BorderColor = System.Drawing.Color.Black
        Appearance21.FontData.BoldAsString = "False"
        Appearance21.FontData.ItalicAsString = "False"
        Appearance21.FontData.Name = "Microsoft Sans Serif"
        Appearance21.FontData.SizeInPoints = 8.25!
        Appearance21.FontData.StrikeoutAsString = "False"
        Appearance21.FontData.UnderlineAsString = "False"
        Appearance21.ForeColor = System.Drawing.Color.Black
        Appearance21.ForeColorDisabled = System.Drawing.Color.Black
        Me.UDtTimeBeginnt.Appearance = Appearance21
        Me.UDtTimeBeginnt.BackColor = System.Drawing.Color.White
        Me.UDtTimeBeginnt.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.UDtTimeBeginnt.DropDownButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Never
        Me.UDtTimeBeginnt.FormatString = ""
        Me.UDtTimeBeginnt.Location = New System.Drawing.Point(163, 1)
        Me.UDtTimeBeginnt.MaskInput = "hh:mm"
        Me.UDtTimeBeginnt.Name = "UDtTimeBeginnt"
        Me.UDtTimeBeginnt.Size = New System.Drawing.Size(45, 21)
        Me.UDtTimeBeginnt.TabIndex = 1
        Me.UDtTimeBeginnt.Value = Nothing
        '
        'PanelErinnerungen
        '
        Me.PanelErinnerungen.Controls.Add(Me.UltraComboTimeRemember)
        Me.PanelErinnerungen.Controls.Add(Me.FlagRemember)
        Me.PanelErinnerungen.Location = New System.Drawing.Point(258, 8)
        Me.PanelErinnerungen.Name = "PanelErinnerungen"
        Me.PanelErinnerungen.Size = New System.Drawing.Size(245, 30)
        Me.PanelErinnerungen.TabIndex = 1
        '
        'UltraComboTimeRemember
        '
        Appearance22.FontData.Name = "Microsoft Sans Serif"
        Me.UltraComboTimeRemember.Appearance = Appearance22
        Me.UltraComboTimeRemember.AutoSize = False
        Me.UltraComboTimeRemember.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList
        Me.UltraComboTimeRemember.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ValueListItem1.DataValue = "5 Minuten"
        ValueListItem1.DisplayText = "5 Minuten"
        ValueListItem2.DataValue = "10 Minuten"
        ValueListItem2.DisplayText = "10 Minuten"
        ValueListItem3.DataValue = "15 Minuten"
        ValueListItem3.DisplayText = "15 Minuten"
        ValueListItem4.DataValue = "30 Minuten"
        ValueListItem4.DisplayText = "30 Minuten"
        ValueListItem5.DataValue = "1 Stunde"
        ValueListItem5.DisplayText = "1 Stunde"
        ValueListItem6.DataValue = "2 Stunden"
        ValueListItem6.DisplayText = "2 Stunden"
        ValueListItem7.DataValue = "3 Stunden"
        ValueListItem7.DisplayText = "3 Stunden"
        Me.UltraComboTimeRemember.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem3, ValueListItem4, ValueListItem5, ValueListItem6, ValueListItem7})
        Me.UltraComboTimeRemember.Location = New System.Drawing.Point(82, 3)
        Me.UltraComboTimeRemember.Name = "UltraComboTimeRemember"
        Me.UltraComboTimeRemember.Size = New System.Drawing.Size(160, 23)
        Me.UltraComboTimeRemember.TabIndex = 1
        '
        'FlagRemember
        '
        Appearance23.FontData.BoldAsString = "False"
        Appearance23.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.FlagRemember.Appearance = Appearance23
        Me.FlagRemember.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FlagRemember.Location = New System.Drawing.Point(5, 3)
        Me.FlagRemember.Name = "FlagRemember"
        Me.FlagRemember.Size = New System.Drawing.Size(88, 24)
        Me.FlagRemember.TabIndex = 0
        Me.FlagRemember.Text = "Erinnerung"
        Me.FlagRemember.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.FlagRemember.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'PanelBetreff
        '
        Me.PanelBetreff.BackColor = System.Drawing.Color.Transparent
        Me.PanelBetreff.Controls.Add(Me.txtTitel)
        Me.PanelBetreff.Controls.Add(Me.lblBetreff)
        Me.PanelBetreff.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelBetreff.Location = New System.Drawing.Point(0, 123)
        Me.PanelBetreff.Name = "PanelBetreff"
        Me.PanelBetreff.Size = New System.Drawing.Size(833, 34)
        Me.PanelBetreff.TabIndex = 2
        '
        'txtTitel
        '
        Appearance24.BackColorDisabled = System.Drawing.Color.White
        Appearance24.FontData.BoldAsString = "False"
        Appearance24.FontData.ItalicAsString = "False"
        Appearance24.FontData.Name = "Microsoft Sans Serif"
        Appearance24.FontData.SizeInPoints = 8.25!
        Appearance24.FontData.StrikeoutAsString = "False"
        Appearance24.FontData.UnderlineAsString = "False"
        Me.txtTitel.Appearance = Appearance24
        Me.txtTitel.AutoSize = False
        Me.txtTitel.Location = New System.Drawing.Point(83, 5)
        Me.txtTitel.MaxLength = 180
        Me.txtTitel.Multiline = True
        Me.txtTitel.Name = "txtTitel"
        Me.txtTitel.Size = New System.Drawing.Size(651, 23)
        Me.txtTitel.TabIndex = 2
        Me.txtTitel.Tag = "Vorname"
        '
        'lblBetreff
        '
        Me.lblBetreff.BackColor = System.Drawing.Color.Transparent
        Me.lblBetreff.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBetreff.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBetreff.Location = New System.Drawing.Point(32, 5)
        Me.lblBetreff.Name = "lblBetreff"
        Me.lblBetreff.Size = New System.Drawing.Size(48, 23)
        Me.lblBetreff.TabIndex = 373
        Me.lblBetreff.Text = "Betreff"
        Me.lblBetreff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelMailadressen2
        '
        Me.PanelMailadressen2.BackColor = System.Drawing.Color.Transparent
        Me.PanelMailadressen2.Controls.Add(Me.UTextMailAn)
        Me.PanelMailadressen2.Controls.Add(Me.lblAn)
        Me.PanelMailadressen2.Controls.Add(Me.UTextMailCC)
        Me.PanelMailadressen2.Controls.Add(Me.lblCC)
        Me.PanelMailadressen2.Controls.Add(Me.UButtonAbbrechen)
        Me.PanelMailadressen2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelMailadressen2.Location = New System.Drawing.Point(0, 43)
        Me.PanelMailadressen2.Name = "PanelMailadressen2"
        Me.PanelMailadressen2.Size = New System.Drawing.Size(833, 80)
        Me.PanelMailadressen2.TabIndex = 1
        '
        'UTextMailAn
        '
        Appearance25.BackColorDisabled = System.Drawing.Color.WhiteSmoke
        Appearance25.FontData.BoldAsString = "False"
        Appearance25.FontData.ItalicAsString = "False"
        Appearance25.FontData.Name = "Microsoft Sans Serif"
        Appearance25.FontData.SizeInPoints = 8.25!
        Appearance25.FontData.StrikeoutAsString = "False"
        Appearance25.FontData.UnderlineAsString = "False"
        Me.UTextMailAn.Appearance = Appearance25
        Me.UTextMailAn.AutoSize = False
        Me.UTextMailAn.Location = New System.Drawing.Point(83, 5)
        Me.UTextMailAn.MaxLength = 70
        Me.UTextMailAn.Multiline = True
        Me.UTextMailAn.Name = "UTextMailAn"
        Me.UTextMailAn.Size = New System.Drawing.Size(651, 36)
        Me.UTextMailAn.TabIndex = 0
        Me.UTextMailAn.Tag = "Vorname"
        '
        'lblAn
        '
        Me.lblAn.BackColor = System.Drawing.Color.Transparent
        Me.lblAn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAn.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAn.Location = New System.Drawing.Point(32, 13)
        Me.lblAn.Name = "lblAn"
        Me.lblAn.Size = New System.Drawing.Size(26, 23)
        Me.lblAn.TabIndex = 404
        Me.lblAn.Text = "An"
        Me.lblAn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UTextMailCC
        '
        Appearance26.BackColorDisabled = System.Drawing.Color.WhiteSmoke
        Appearance26.FontData.BoldAsString = "False"
        Appearance26.FontData.ItalicAsString = "False"
        Appearance26.FontData.Name = "Microsoft Sans Serif"
        Appearance26.FontData.SizeInPoints = 8.25!
        Appearance26.FontData.StrikeoutAsString = "False"
        Appearance26.FontData.UnderlineAsString = "False"
        Me.UTextMailCC.Appearance = Appearance26
        Me.UTextMailCC.AutoSize = False
        Me.UTextMailCC.Location = New System.Drawing.Point(83, 43)
        Me.UTextMailCC.MaxLength = 70
        Me.UTextMailCC.Multiline = True
        Me.UTextMailCC.Name = "UTextMailCC"
        Me.UTextMailCC.Size = New System.Drawing.Size(651, 36)
        Me.UTextMailCC.TabIndex = 1
        Me.UTextMailCC.Tag = "Vorname"
        '
        'lblCC
        '
        Me.lblCC.BackColor = System.Drawing.Color.Transparent
        Me.lblCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCC.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCC.Location = New System.Drawing.Point(32, 49)
        Me.lblCC.Name = "lblCC"
        Me.lblCC.Size = New System.Drawing.Size(26, 23)
        Me.lblCC.TabIndex = 406
        Me.lblCC.Text = "CC"
        Me.lblCC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UButtonAbbrechen
        '
        Me.UButtonAbbrechen.Location = New System.Drawing.Point(622, 21)
        Me.UButtonAbbrechen.Name = "UButtonAbbrechen"
        Me.UButtonAbbrechen.Size = New System.Drawing.Size(70, 21)
        Me.UButtonAbbrechen.TabIndex = 405
        Me.UButtonAbbrechen.Text = "Abbrechen"
        '
        'PanelEinladen
        '
        Me.PanelEinladen.BackColor = System.Drawing.Color.Transparent
        Me.PanelEinladen.Controls.Add(Me.UButtonTeilnehmer)
        Me.PanelEinladen.Controls.Add(Me.txtTeilnehmer)
        Me.PanelEinladen.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelEinladen.Location = New System.Drawing.Point(0, 0)
        Me.PanelEinladen.Name = "PanelEinladen"
        Me.PanelEinladen.Size = New System.Drawing.Size(833, 43)
        Me.PanelEinladen.TabIndex = 0
        Me.PanelEinladen.Visible = False
        '
        'UButtonTeilnehmer
        '
        Appearance27.Image = CType(resources.GetObject("Appearance27.Image"), Object)
        Appearance27.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance27.ImageVAlign = Infragistics.Win.VAlign.Top
        Appearance27.TextHAlignAsString = "Center"
        Me.UButtonTeilnehmer.Appearance = Appearance27
        Me.UButtonTeilnehmer.Location = New System.Drawing.Point(10, 5)
        Me.UButtonTeilnehmer.Name = "UButtonTeilnehmer"
        Me.UButtonTeilnehmer.Size = New System.Drawing.Size(71, 35)
        Me.UButtonTeilnehmer.TabIndex = 0
        Me.UButtonTeilnehmer.Text = "Teilnehmer"
        '
        'txtTeilnehmer
        '
        Appearance28.BackColor = System.Drawing.Color.White
        Appearance28.FontData.BoldAsString = "False"
        Appearance28.FontData.ItalicAsString = "False"
        Appearance28.FontData.Name = "Microsoft Sans Serif"
        Appearance28.FontData.SizeInPoints = 8.25!
        Appearance28.FontData.StrikeoutAsString = "False"
        Appearance28.FontData.UnderlineAsString = "False"
        Me.txtTeilnehmer.Appearance = Appearance28
        Me.txtTeilnehmer.AutoSize = False
        Me.txtTeilnehmer.BackColor = System.Drawing.Color.White
        Me.txtTeilnehmer.Location = New System.Drawing.Point(83, 5)
        Me.txtTeilnehmer.MaxLength = 70
        Me.txtTeilnehmer.Multiline = True
        Me.txtTeilnehmer.Name = "txtTeilnehmer"
        Me.txtTeilnehmer.Size = New System.Drawing.Size(651, 36)
        Me.txtTeilnehmer.TabIndex = 1
        Me.txtTeilnehmer.Tag = "Vorname"
        '
        'UltraStatusBar1
        '
        Me.UltraStatusBar1.Location = New System.Drawing.Point(0, 542)
        Me.UltraStatusBar1.Name = "UltraStatusBar1"
        UltraStatusPanel1.Width = 150
        UltraStatusPanel2.Width = 160
        UltraStatusPanel3.Width = 180
        UltraStatusPanel4.MinWidth = 250
        UltraStatusPanel4.SizingMode = Infragistics.Win.UltraWinStatusBar.PanelSizingMode.Automatic
        UltraStatusPanel4.Width = 250
        Me.UltraStatusBar1.Panels.AddRange(New Infragistics.Win.UltraWinStatusBar.UltraStatusPanel() {UltraStatusPanel1, UltraStatusPanel2, UltraStatusPanel3, UltraStatusPanel4})
        Me.UltraStatusBar1.Size = New System.Drawing.Size(833, 24)
        Me.UltraStatusBar1.TabIndex = 409
        Me.UltraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.VisualStudio2005
        '
        'CMenuStripAnhang
        '
        Me.CMenuStripAnhang.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiÖffnenToolStripMenuItem, Me.SpeichernUnterToolStripMenuItem})
        Me.CMenuStripAnhang.Name = "CMenuStripAnhang"
        Me.CMenuStripAnhang.Size = New System.Drawing.Size(170, 48)
        '
        'DateiÖffnenToolStripMenuItem
        '
        Me.DateiÖffnenToolStripMenuItem.Name = "DateiÖffnenToolStripMenuItem"
        Me.DateiÖffnenToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.DateiÖffnenToolStripMenuItem.Text = "Datei öffnen"
        '
        'SpeichernUnterToolStripMenuItem
        '
        Me.SpeichernUnterToolStripMenuItem.Name = "SpeichernUnterToolStripMenuItem"
        Me.SpeichernUnterToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.SpeichernUnterToolStripMenuItem.Text = "Speichern unter ..."
        '
        '_AufgabeTerminNeu_Toolbars_Dock_Area_Left
        '
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.White
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 70)
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Left.Name = "_AufgabeTerminNeu_Toolbars_Dock_Area_Left"
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 566)
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Left.ToolbarsManager = Me.UltraToolbarsManager
        '
        'UltraToolbarsManager
        '
        Me.UltraToolbarsManager.DesignerFlags = 1
        Me.UltraToolbarsManager.DockWithinContainer = Me
        Me.UltraToolbarsManager.DockWithinContainerBaseType = GetType(System.Windows.Forms.Form)
        Me.UltraToolbarsManager.LockToolbars = True
        Me.UltraToolbarsManager.Office2007UICompatibility = False
        Me.UltraToolbarsManager.Ribbon.ApplicationMenu.ToolAreaLeft.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool21})
        Me.UltraToolbarsManager.Ribbon.ApplicationMenuButtonImage = CType(resources.GetObject("UltraToolbarsManager.Ribbon.ApplicationMenuButtonImage"), System.Drawing.Image)
        RibbonTab1.Caption = "Nachricht"
        RibbonGroup1.Caption = "Aktion"
        ButtonTool11.InstanceProps.IsFirstInGroup = True
        ButtonTool11.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool6.InstanceProps.IsFirstInGroup = True
        ButtonTool6.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool16.InstanceProps.IsFirstInGroup = True
        ButtonTool16.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool17.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        ButtonTool18.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        RibbonGroup1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool11, ButtonTool6, ButtonTool16, ButtonTool17, ButtonTool18})
        RibbonGroup2.Caption = "Teilnehmer"
        StateButtonTool9.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        StateButtonTool9.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        RibbonGroup2.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {StateButtonTool9})
        RibbonGroup3.Caption = "Anhang"
        ButtonTool23.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        PopupControlContainerTool2.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        RibbonGroup3.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool23, PopupControlContainerTool2})
        RibbonTab1.Groups.AddRange(New Infragistics.Win.UltraWinToolbars.RibbonGroup() {RibbonGroup1, RibbonGroup2, RibbonGroup3})
        Me.UltraToolbarsManager.Ribbon.NonInheritedRibbonTabs.AddRange(New Infragistics.Win.UltraWinToolbars.RibbonTab() {RibbonTab1})
        Me.UltraToolbarsManager.ShowFullMenusDelay = 500
        Me.UltraToolbarsManager.ShowQuickCustomizeButton = False
        Me.UltraToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.OfficeXP
        UltraToolbar2.DockedColumn = 0
        UltraToolbar2.DockedRow = 0
        ButtonTool3.InstanceProps.IsFirstInGroup = True
        ButtonTool5.InstanceProps.IsFirstInGroup = True
        ButtonTool4.InstanceProps.IsFirstInGroup = True
        StateButtonTool8.InstanceProps.IsFirstInGroup = True
        StateButtonTool8.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        ButtonTool24.InstanceProps.IsFirstInGroup = True
        UltraToolbar2.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool1, ButtonTool3, ButtonTool2, ButtonTool5, ButtonTool4, StateButtonTool8, ButtonTool24, PopupControlContainerTool3})
        UltraToolbar2.Text = "Aufgabe, Termin neu ..."
        Me.UltraToolbarsManager.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar2})
        Appearance29.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool7.SharedPropsInternal.AppearancesSmall.HotTrackAppearance = Appearance29
        ButtonTool7.SharedPropsInternal.Caption = "Speichern"
        ButtonTool7.SharedPropsInternal.CustomizerCaption = "Speichern"
        ButtonTool7.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance30.Image = CType(resources.GetObject("Appearance30.Image"), Object)
        ButtonTool8.SharedPropsInternal.AppearancesLarge.Appearance = Appearance30
        Appearance31.Image = CType(resources.GetObject("Appearance31.Image"), Object)
        ButtonTool8.SharedPropsInternal.AppearancesSmall.Appearance = Appearance31
        Appearance32.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool8.SharedPropsInternal.AppearancesSmall.HotTrackAppearance = Appearance32
        ButtonTool8.SharedPropsInternal.Caption = "Löschen"
        ButtonTool8.SharedPropsInternal.CustomizerCaption = "Löschen"
        ButtonTool8.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance33.Image = CType(resources.GetObject("Appearance33.Image"), Object)
        ButtonTool9.SharedPropsInternal.AppearancesLarge.Appearance = Appearance33
        Appearance34.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool9.SharedPropsInternal.AppearancesSmall.HotTrackAppearance = Appearance34
        ButtonTool9.SharedPropsInternal.Caption = "Schließen"
        ButtonTool9.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways
        Appearance35.Cursor = System.Windows.Forms.Cursors.Hand
        ButtonTool12.SharedPropsInternal.AppearancesSmall.HotTrackAppearance = Appearance35
        ButtonTool12.SharedPropsInternal.Caption = "Senden"
        ButtonTool12.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance36.Image = CType(resources.GetObject("Appearance36.Image"), Object)
        ButtonTool13.SharedPropsInternal.AppearancesLarge.Appearance = Appearance36
        Appearance37.Image = CType(resources.GetObject("Appearance37.Image"), Object)
        ButtonTool13.SharedPropsInternal.AppearancesSmall.Appearance = Appearance37
        ButtonTool13.SharedPropsInternal.Caption = "Abschließen"
        ButtonTool13.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        ButtonTool14.SharedPropsInternal.Caption = "Um 1 Stunde verschieben"
        ButtonTool14.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Appearance38.Image = CType(resources.GetObject("Appearance38.Image"), Object)
        ButtonTool22.SharedPropsInternal.AppearancesLarge.Appearance = Appearance38
        Appearance39.Image = CType(resources.GetObject("Appearance39.Image"), Object)
        ButtonTool22.SharedPropsInternal.AppearancesSmall.Appearance = Appearance39
        ButtonTool22.SharedPropsInternal.Caption = "Datei hinzufügen"
        ButtonTool22.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        PopupControlContainerTool1.SharedPropsInternal.Caption = "Liste Anhang"
        PopupControlContainerTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        StateButtonTool7.MenuDisplayStyle = Infragistics.Win.UltraWinToolbars.StateButtonMenuDisplayStyle.DisplayCheckmark
        Appearance40.Image = CType(resources.GetObject("Appearance40.Image"), Object)
        StateButtonTool7.SharedPropsInternal.AppearancesLarge.Appearance = Appearance40
        Appearance41.Image = CType(resources.GetObject("Appearance41.Image"), Object)
        StateButtonTool7.SharedPropsInternal.AppearancesSmall.Appearance = Appearance41
        StateButtonTool7.SharedPropsInternal.Caption = "Teilnehmer einladen"
        StateButtonTool7.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        Me.UltraToolbarsManager.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool7, ButtonTool8, ButtonTool9, ButtonTool12, ButtonTool13, ButtonTool14, ButtonTool22, PopupControlContainerTool1, StateButtonTool7})
        '
        '_AufgabeTerminNeu_Toolbars_Dock_Area_Right
        '
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.White
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(833, 70)
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Right.Name = "_AufgabeTerminNeu_Toolbars_Dock_Area_Right"
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 566)
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Right.ToolbarsManager = Me.UltraToolbarsManager
        '
        '_AufgabeTerminNeu_Toolbars_Dock_Area_Top
        '
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.White
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Top.Name = "_AufgabeTerminNeu_Toolbars_Dock_Area_Top"
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(833, 70)
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Top.ToolbarsManager = Me.UltraToolbarsManager
        '
        '_AufgabeTerminNeu_Toolbars_Dock_Area_Bottom
        '
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.White
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 636)
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Bottom.Name = "_AufgabeTerminNeu_Toolbars_Dock_Area_Bottom"
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(833, 0)
        Me._AufgabeTerminNeu_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.UltraToolbarsManager
        '
        'layText
        '
        Me.layText.ContainerControl = Me.UltraGroupBoxText
        Me.layText.ExpandToFitHeight = True
        Me.layText.ExpandToFitWidth = True
        '
        'layOben
        '
        Me.layOben.ExpandToFitHeight = True
        Me.layOben.ExpandToFitWidth = True
        '
        'frmNachricht
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(833, 636)
        Me.Controls.Add(Me.AufgabeTerminNeu_Fill_Panel)
        Me.Controls.Add(Me._AufgabeTerminNeu_Toolbars_Dock_Area_Left)
        Me.Controls.Add(Me._AufgabeTerminNeu_Toolbars_Dock_Area_Right)
        Me.Controls.Add(Me._AufgabeTerminNeu_Toolbars_Dock_Area_Bottom)
        Me.Controls.Add(Me._AufgabeTerminNeu_Toolbars_Dock_Area_Top)
        Me.Name = "frmNachricht"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nachricht"
        Me.CMenuStripHistorie.ResumeLayout(False)
        CType(Me.UComboPersonen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AufgabeTerminNeu_Fill_Panel.ResumeLayout(False)
        CType(Me.UltraGroupBoxHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBoxHeader.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.PanelMitte.ResumeLayout(False)
        CType(Me.UltraGroupBoxText, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBoxText.ResumeLayout(False)
        Me.PanelLeisteText.ResumeLayout(False)
        CType(Me.UltraGroupBoxButtonLieste, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraGroupBoxButtonLieste.ResumeLayout(False)
        CType(Me.UToolbarsManagerTxt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDatum.ResumeLayout(False)
        Me.PanelVonBis.ResumeLayout(False)
        Me.PanelVonBis.PerformLayout()
        CType(Me.UDtDateBeginnt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDtDateEndet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDtTimeEndet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UDtTimeBeginnt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelErinnerungen.ResumeLayout(False)
        CType(Me.UltraComboTimeRemember, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FlagRemember, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBetreff.ResumeLayout(False)
        CType(Me.txtTitel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMailadressen2.ResumeLayout(False)
        CType(Me.UTextMailAn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UTextMailCC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEinladen.ResumeLayout(False)
        CType(Me.txtTeilnehmer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraStatusBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMenuStripAnhang.ResumeLayout(False)
        CType(Me.UltraToolbarsManager, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.layOben, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private Sub UltraToolbarsManager_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UltraToolbarsManager.ToolClick
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case e.Tool.Key

                Case "Schließen"
                    Me.Close()

                Case "ButtonSenden"
                    If General.IsNull(Me.UTextMailAn.Text) And General.IsNull(Me.UTextMailCC.Text) Then
                        MsgBox("Es wurde keine E-Mail Adresse angegeben!", MsgBoxStyle.Exclamation, "Mail senden")
                        Me.UTextMailAn.Focus()
                        Exit Sub
                    End If
                    If Me.saveNachricht() Then
                        'Me.ShowData(Me.idaufgabe)
                        If Me._idart.ToString = General.IDMail.ToString Then
                            If General.IsNull(Me.UTextMailAn.Text) Then
                                MsgBox("Nachricht wurde gespeichert!" + vbNewLine + _
                                        "Hinweis: Das Mail konnte nicht versendet werden, da keine E-Mail Adresse angegeben wurde!", MsgBoxStyle.Information, "ITSCont")
                                Me.Close()
                            End If
                            Dim cl As New cMailTermine
                            Dim attach As New ArrayList
                            For Each item As UltraListViewItem In Me.contListeAnhang.listDateiAnhang.Items
                                Dim clAnh As New GeneralArchiv.clAnhang
                                clAnh = item.Tag
                                attach.Add(clAnh)
                            Next
                            Dim typTxt As New TXTextControl.StreamType
                            If Me.isHtml Then
                                typTxt = TXTextControl.StreamType.HTMLFormat
                            Else
                                typTxt = TXTextControl.StreamType.PlainText
                            End If

                            If cl.sendEMail(Me.UTextMailAn.Text, Me.UTextMailCC.Text, False, True, Me.txtTitel.Text, _
                                            doEditor.getText(typTxt, Me.contTxtEditor.textControl1), attach, Me.isHtml, _
                                            True, Me._idaufgabe) Then

                                If Not General.IsNull(Me.modalWindow) Then Me.modalWindow.refreshMailsTermine()
                                If Not General.IsNull(Me.modalWindowErinnerung) Then Me.modalWindowErinnerung.loadListe(False)
                                info.showInfo(True, 1400, Me, "Nachrichten wurden gesendet!")
                                Me.Close()
                            Else
                                MsgBox("Fehler beim Versenden des E-Mails!" + vbNewLine + _
                                            "Hinweis: Die Nachricht wurde gespeichert!", MsgBoxStyle.Exclamation, "E-Mail versenden")
                                Me.Close()
                            End If
                        End If
                    End If

                Case "Abschließen"
                    Dim compSql1 As New compSql()
                    If compSql1.aufgabeAbschließen(Me._idaufgabe) Then
                        info.showInfo(True, 1400, Me, "Abgeschlossen")
                        If Not General.IsNull(Me.modalWindow) Then Me.modalWindow.refreshMailsTermine()
                        If Not General.IsNull(Me.modalWindowErinnerung) Then Me.modalWindowErinnerung.loadListe(False)
                        info.showInfo(True, 1400, Me, "Gelöscht")
                        Me.Close()
                    End If

                Case "buttSpeichern"
                    If Me.saveNachricht() Then
                        If Not General.IsNull(Me.modalWindow) Then Me.modalWindow.refreshMailsTermine()
                        If Not General.IsNull(Me.modalWindowErinnerung) Then Me.modalWindowErinnerung.loadListe(False)
                        info.showInfo(True, 1400, Me, "")
                        Me.Close()
                    End If

                Case "Löschen"
                    If MsgBox("Wollen Sie die Aufgabe wirklich löschen?", MsgBoxStyle.YesNo, _
                                          "PMDS") = DialogResult.Yes Then

                        Dim aufgabe As New sqlAufgaben
                        aufgabe.DeleteRow(Me._idaufgabe)
                        clearFields()
                        If Not General.IsNull(Me.modalWindow) Then Me.modalWindow.refreshMailsTermine()
                        If Not General.IsNull(Me.modalWindowErinnerung) Then Me.modalWindowErinnerung.loadListe(False)
                        info.showInfo(True, 1400, Me, "Gelöscht")
                        Me.Close()
                    End If

                    'Case "Um1StundeVerschieben"
                    '    Me.Aufgabe1StundeVerschieben()

                Case "DateiHinzufügen"
                    Me.contListeAnhang.addAnhang()

                Case "popUpContListeAnhang"

                Case "Teilnehmer"
                    Dim buttTool As StateButtonTool = Me.UltraToolbarsManager.Toolbars(0).Tools("Teilnehmer")
                    If buttTool.Checked Then
                        Me.PanelEinladen.Visible = True
                    Else
                        Me.PanelEinladen.Visible = False
                    End If

            End Select


        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Function isHtml() As Boolean
        Try
            Dim butt As StateButtonTool = Me.UToolbarsManagerTxt.Tools("statButtHtml")
            Return butt.Checked

        Catch ex As Exception
            Throw New Exception("isHtml: " + ex.ToString())
        End Try
    End Function
    Public Sub setHtml(ByVal isHTML As Boolean)
        Try
            Dim butt As StateButtonTool
            If isHTML Then
                butt = Me.UToolbarsManagerTxt.Tools("statButtHtml")
                butt.Checked = True
            Else
                butt = Me.UToolbarsManagerTxt.Tools("statButtText")
                butt.Checked = True
            End If

        Catch ex As Exception
            Throw New Exception("setHtml: " + ex.ToString())
        End Try
    End Sub
    Private Sub UToolbarsManagerTxt_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles UToolbarsManagerTxt.ToolClick
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case e.Tool.Key
                Case "dok_Neu"
                    Me.contTxtEditor.FileNew(True, False)
                Case "dok_Öffnen"
                    Me.contTxtEditor.FileNew(False, False)
                    Me.contTxtEditor.FileOpen()
                    If Not General.IsNull(Me.contTxtEditor.callEditorKeyPress) Then Me.contTxtEditor.callEditorKeyPress.Invoke(True)
                    Me.resizeForm()
                Case "dok_Speichern"
                    Me.contTxtEditor.speichernAls()
                Case "dok_Exportieren"
                    Me.contTxtEditor.ExportPDF("", True, True)
                Case "dok_Drucken"
                    Me.contTxtEditor.Print()
                Case "dok_Druckvorschau"
                    Me.contTxtEditor.PrintPreview()
                    '      PrintPreview()
                Case "statButtAnsicht"
                    If Me.contTxtEditor.textControl1.ViewMode = TXTextControl.ViewMode.Normal Then
                        Me.contTxtEditor.textControl1.ViewMode = TXTextControl.ViewMode.PageView
                    Else
                        Me.contTxtEditor.textControl1.ViewMode = TXTextControl.ViewMode.Normal
                    End If
                Case "dok_Ausschneiden"
                    Me.contTxtEditor.Cut()
                Case "dok_Kopieren"
                    Me.contTxtEditor.Copy()
                Case "dok_Einfügen"
                    Me.contTxtEditor.Paste()
                Case ""
                    Me.contTxtEditor.textControl1.Clear()
                Case "dok_RückgängigMachen"
                    Me.contTxtEditor.Redo()
                Case "dok_Wiederherstellen"
                    Me.contTxtEditor.Undo()
                Case "dok_Suchen"
                    Me.contTxtEditor.Find()
            End Select

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub frmNachricht_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            'Me.contTxtEditor.EnableToolbarButtons()

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub AufgabeTerminNeu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein2.ico_Message, 32, 32)

            Me.Hide()

            Me.UltraToolbarsManager.Tools("buttSpeichern").SharedProps.AppearancesSmall.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32)

            Me.contListeAnhang.modalWindow = Me
            Dim popContAnhang As PopupControlContainerTool '= New PopupControlContainerTool("popup_control")
            popContAnhang = Me.UltraToolbarsManager.Toolbars(0).Tools("popUpContListeAnhang")
            popContAnhang.Control = Me.contListeAnhang
            popContAnhang.DropDownArrowStyle = DropDownArrowStyle.Standard

            Me.PanelErinnerungen.Visible = False

            Me.UltraToolbarsManager.Toolbars(0).Tools("ButtonSenden").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
            If Me.General.userIsAdminxy Then
                Me.UltraToolbarsManager.Toolbars(0).Tools("Löschen").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.True
            Else
                Me.UltraToolbarsManager.Toolbars(0).Tools("Löschen").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
            End If

            General.getAllUserCbo(Me.UComboPersonen)

            Me.loadEditoren()

            Me.CancelButton = Me.UButtonAbbrechen
            Me.resizeForm()

            Me.txtTitel.Focus()

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.txtTitel.Focus()
        End Try
    End Sub
    Private Sub AufgabeTerminNeu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub
    Private Sub AufgabeTerminNeu_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.resizeForm()

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub loadEditoren()
        Try
            Me.PanelText.Controls.Add(Me.contTxtEditor)
            Me.contTxtEditor.textControl1.ButtonBar = buttonBar1
            Me.contTxtEditor.loadForm(False, Nothing, False, False)
            Me.contTxtEditor.setControlTyp()
            Me.contTxtEditor.callEditorKeyPress = New QS2.Desktop.Txteditor.contTxtEditor.delEditorKeyPress(AddressOf Me.EditorKeyIsPressed)

            Me.resizeForm()

            Me.contTxtEditor.EnableToolbarButtons()

        Catch ex As Exception
            Throw New Exception("loadEditoren: " + ex.ToString())
        Finally
        End Try
    End Sub

#Region "Funktion"

    Public Function Init(ByVal Exch As Exchange) As Boolean
        Try
            Dim guid As System.Guid
            Me.Cursor = Cursors.WaitCursor

            If Exch.app = General.InitApplicationAufgabenTermine.nachrichtAnzeigen Then
                Me._ErstelltVon = ""
                Dim ID As New System.Guid
                ID = General.StrToGuid(Exch.str)
                Me.frmStatus = General.eStatusForm.edit
                Me.ShowData(ID)
                Me.ShowUIForm()

            ElseIf Exch.app = General.InitApplicationAufgabenTermine.terminNeu Then
                Me._ErstelltVon = ""
                Neu_Termin()
                Me.ShowUIForm()
                Me.setTempDateTime()

            ElseIf Exch.app = General.InitApplicationAufgabenTermine.mailNeu Then
                Me._ErstelltVon = ""
                Me.Neu_Mail()
                Me.ShowUIForm()
                If Not General.IsNull(Exch.str) Then
                    Me.UTextMailAn.Text = Exch.str
                End If
                If Exch.typMail = General.eTypMail.an Then
                    Me.UTextMailAn.Text = Exch.str
                ElseIf Exch.typMail = General.eTypMail.cc Then
                    Me.UTextMailCC.Text = Exch.str
                    'ElseIf Exch.typMail = General.eTypMail.bcc Then
                    '    Me.UTextMailCC.Text = Exch.str
                    '    Me.RButtonBCC.Checked = True
                End If
                Me.setTempDateTime()

            End If

        Catch ex As Exception
            Throw New Exception("Init: " + ex.ToString())
        Finally
            Me.resizeForm()
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Public Sub Neu_Termin()
        Try
            Me.formNeu()

            Me._idart = General.IDTermin

            Me.contTxtEditor.clearForm()

            Me.UltraToolbarsManager.Toolbars(0).Tools("Abschließen").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.True
            Me.UltraToolbarsManager.Toolbars(0).Tools("ButtonSenden").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
            Me.setObjectPanel(Me.patient, Me.IDobject)
            Me.txtTitel.Focus()

        Catch ex As Exception
            Throw New Exception("Neu_Termin: " + ex.ToString())
        End Try
    End Sub
    Public Sub Neu_Mail()
        Try
            Me.formNeu()

            Me.PanelVonBis.Visible = False
            Me._idart = General.IDMail

            Me.contTxtEditor.clearForm()

            Me.UltraToolbarsManager.Toolbars(0).Tools("Abschließen").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False

            Me.UltraToolbarsManager.Toolbars(0).Tools("ButtonSenden").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.True
            Me.setObjectPanel(Me.patient, Me.IDobject)
            Me.txtTitel.Focus()

        Catch ex As Exception
            Throw New Exception("Neu_Mail: " + ex.ToString())
        End Try
    End Sub
    Public Function formNeu() As Boolean
        Try
            Me.clearFields()

            Me._idaufgabe = System.Guid.NewGuid

            Me.FlagRemember.Checked = False
            UltraComboTimeRemember.Enabled = False
            UltraComboTimeRemember.Value = ""

            'Me.UDtDateBeginnt.Value = Date.Now.Date
            'Dim NewDateTime As Date = New Date(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 9, 0, 0)
            'Me.UDtTimeBeginnt.Value = NewDateTime

            Me.status = "Offen"

            Me.UltraStatusBar1.Panels(0).Text = ""
            Me.UltraStatusBar1.Panels(1).Text = ""
            Me.UltraStatusBar1.Panels(2).Text = ""
            Me.UltraStatusBar1.Panels(3).Text = ""

            Me.setErstelltVon(General.actUser, Now)
            If Me._typ = General.eTypPlanung.termin Then
                Me.setStatus("")
            ElseIf Me._typ = General.eTypPlanung.mail Then
                Me.setStatus("Status: Neu")
            End If

            UComboPersonen.Value = General.actUser

            frmStatus = General.eStatusForm.neu

            Me.contTxtEditor.clearForm()

            Me.UTextMailAn.Text = ""
            Me.UTextMailCC.Text = ""

        Catch ex As Exception
            Throw New Exception("formNeu: " + ex.ToString())
        End Try
    End Function

    Public Sub setTempDateTime()
        Try
            Me.UDtDateBeginnt.Value = General.CheckDateNull(Me.dateTemp)
            Me.UDtTimeBeginnt.Value = General.CheckDateNull(Me.timeTemp)

        Catch ex As Exception
            Throw New Exception("setTempDateTime: " + ex.ToString())
        End Try
    End Sub
    Public Sub ShowUIForm()
        Try
            If Me.frmStatus = General.eStatusForm.neu Then
                If Me._typ = General.eTypPlanung.mail Then
                    Me.Text = "Neue E-Mail"
                    Me.UltraToolbarsManager.Toolbars(0).Tools("Abschließen").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
                    Me.UltraToolbarsManager.Toolbars(0).Tools("buttSpeichern").SharedProps.Caption = "Als Entwurf speichern"
                    Me.UltraToolbarsManager.Toolbars(0).Tools("Teilnehmer").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
                    Me.PanelVonBis.Visible = False
                ElseIf Me._typ = General.eTypPlanung.termin Then
                    Me.Text = "Neuer Termin"
                    Me.Icon = General.ImageToIcon(QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Message, 32, 32))
                    Me.PanelMailadressen2.Visible = False
                End If
            Else
                If Me._typ = General.eTypPlanung.mail Then
                    Me.Text = "E-Mail"
                    Me.UltraToolbarsManager.Toolbars(0).Tools("Abschließen").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
                    Me.UltraToolbarsManager.Toolbars(0).Tools("buttSpeichern").SharedProps.Caption = "Als Entwurf speichern"
                    Me.UltraToolbarsManager.Toolbars(0).Tools("Teilnehmer").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
                    Me.PanelVonBis.Visible = False
                ElseIf Me._typ = General.eTypPlanung.termin Then
                    Me.Text = "Termin"
                    Me.Icon = General.ImageToIcon(QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Message, 32, 32))
                    Me.PanelMailadressen2.Visible = False
                End If
                If Not General.IsNull(Trim(txtTitel.Text)) Then Me.Text += " " + Trim(txtTitel.Text)
            End If

            Me.Width += 1

        Catch ex As Exception
            Throw New Exception("ShowUIForm: " + ex.ToString())
        End Try
    End Sub

    Private Function clearFields()
        Try
            Me.txtTitel.Text = ""
            Me.UDtDateBeginnt.Value = Nothing
            Me.UDtTimeBeginnt.Value = Nothing
            Me.UDtDateEndet.Value = Nothing
            Me.UDtTimeEndet.Value = Nothing

            Me.txtTeilnehmer.Text = ""

            Me.UComboPersonen.SelectedItem = Nothing
            Me.UltraComboTimeRemember.SelectedItem = Nothing

            FlagRemember.Checked = False

            Me.contTxtEditor.clearForm()

        Catch ex As Exception
            Throw New Exception("clearFields: " + ex.ToString())
        End Try
    End Function

    Public Function checkInput() As Boolean
        Try
            ' Überprüfung Felder
            If General.IsNull(Me.txtTitel.Text) Then
                MsgBox("Betreff: Eingabe erforderlich!", MsgBoxStyle.Exclamation, "PMDS")
                txtTitel.Focus()
                Return False
            End If

            If Me._typ = General.eTypPlanung.termin Then
                If General.IsNull(Me.UDtDateBeginnt.Value) Then
                    MsgBox("Start: Eingabe erforderlich!", MsgBoxStyle.Exclamation, "PMDS")
                    UDtDateBeginnt.Focus()
                    Return False
                End If
                If General.IsNull(Me.UDtTimeBeginnt.Value) Then
                    MsgBox("Start: Eingabe erforderlich!", MsgBoxStyle.Exclamation, "PMDS")
                    UDtTimeBeginnt.Focus()
                    Return False
                End If
                If Not General.IsNull(UDtDateEndet.Value) And Me.UDtDateEndet.Value < Me.UDtDateBeginnt.Value Then
                    MsgBox("Betreff: Eingabe erforderlich!", MsgBoxStyle.Exclamation, "PMDS")
                    UDtDateEndet.Focus()
                    Return False
                End If
                If Not General.IsNull(Me.UDtTimeEndet.Value) And Not General.IsNull(UDtDateEndet.Value) _
                            And Me.UDtDateEndet.Value = Me.UDtDateBeginnt.Value _
                            And Me.UDtTimeEndet.Value < Me.UDtTimeBeginnt.Value Then
                    MsgBox("'Endet um' darf nicht kleiner sein als 'Beginnt um'!", MsgBoxStyle.Exclamation, "PMDS")
                    UDtTimeEndet.Focus()
                    Return False
                End If

                Me.autoSetDatumZeitEnde()
            End If

            If General.IsNull(Me.UComboPersonen.Value) Then
                MsgBox("Sachbearbeiter: Auswahl erforderlich!", MsgBoxStyle.Exclamation, "PMDS")
                UComboPersonen.Focus()
                Return False
            End If

            If Me.txtTeilnehmer.Text <> "" Then
                Dim compSql1 As New compSql()
                If Not compSql1.checkTeilnemherliste(Me.txtTeilnehmer.Text) Then
                    If MsgBox("Hinweis: Sie haben Teilnehmer in die Teilnehmerliste eingetragen, die nicht existieren!" + vbNewLine +
                              "Soll die Nachricht trotzdem gespeichert werden?", MsgBoxStyle.YesNo, "Teilnehmer einladen") = MsgBoxResult.No Then
                        Me.txtTeilnehmer.Focus()
                        Return False
                    End If
                End If
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("checkInput: " + ex.ToString())
        End Try
    End Function


    Public Function saveNachricht() As Boolean
        Try
            If Not Me.checkInput() Then Exit Function

            aufgabe.tAufgaben.Clear()
            aufgabe.ClearClassMembers()

            aufgabe.ID = Me._idaufgabe
            aufgabe.IDArt = Me._idart

            If General.IsNull(Me.UComboPersonen.Value) Then
                aufgabe.FürIDPerson = ""
            Else
                aufgabe.FürIDPerson = Me.UComboPersonen.SelectedItem.DataValue
            End If

            aufgabe.FürIDBMB = Nothing
            aufgabe.IDPerson = General.actUser
            aufgabe.ErinnerungMail = False

            If Not General.IsNull(txtTitel.Text) Then : aufgabe.Betreff = txtTitel.Text : Else : aufgabe.Betreff = Nothing : End If
            If Not General.IsNull(Me.UTextMailAn.Text) Then : aufgabe.MailAn = Me.UTextMailAn.Text : Else : aufgabe.MailAn = "" : End If
            If Not General.IsNull(Me.UTextMailCC.Text) Then : aufgabe.MailCC = Me.UTextMailCC.Text : Else : aufgabe.MailCC = "" : End If
            If Not General.IsNull(txtTeilnehmer.Text) Then : aufgabe.Teilnehmer = txtTeilnehmer.Text : Else : aufgabe.Teilnehmer = "" : End If

            aufgabe.Priorität = "Mittel"
            aufgabe.StatusA = Me.status

            If Not General.IsNull(FlagRemember.Checked) Then : aufgabe.RememberYesNo = FlagRemember.Checked : Else : aufgabe.RememberYesNo = Nothing : End If
            If Not General.IsNull(UltraComboTimeRemember.Value) Then : aufgabe.Remember = UltraComboTimeRemember.Value : Else : aufgabe.Remember = Nothing : End If
            aufgabe.RemeberAllWeek = False
            aufgabe.RemeberAllDay = False

            If Me._typ = General.eTypPlanung.termin Then
                If Not General.IsNull(UDtTimeBeginnt.Value) Then
                    Dim datTimeBeginnt As Date = UDtTimeBeginnt.Value
                    Dim datDateBeginnt As Date = UDtDateBeginnt.Value
                    aufgabe.StartTime = New Date(datDateBeginnt.Year, datDateBeginnt.Month, datDateBeginnt.Day, datTimeBeginnt.Hour, datTimeBeginnt.Minute, datTimeBeginnt.Second)
                Else
                    aufgabe.StartTime = Nothing
                End If
                If Not General.IsNull(UDtTimeEndet.Value) Then
                    Dim datTimeEnde As Date = UDtTimeEndet.Value
                    Dim datDateEnd As Date = UDtDateEndet.Value
                    aufgabe.EndTime = New Date(datDateEnd.Year, datDateEnd.Month, datDateEnd.Day, datTimeEnde.Hour, datTimeEnde.Minute, datTimeEnde.Second)
                Else
                    aufgabe.EndTime = Nothing
                End If
                If Not General.IsNull(UDtDateBeginnt.Value) Then : aufgabe.StartDate = UDtDateBeginnt.Value : Else : aufgabe.StartDate = Nothing : End If
                If Not General.IsNull(UDtDateEndet.Value) Then : aufgabe.EndDate = UDtDateEndet.Value : Else : aufgabe.EndDate = Nothing : End If
            Else
                aufgabe.StartTime = Nothing
                aufgabe.EndTime = Nothing
                aufgabe.StartDate = Nothing
                aufgabe.EndDate = Nothing
            End If

            aufgabe.StatusA = Me.status
            If aufgabe.StatusA = "Erledigt" Then
                aufgabe.Abgeschlossen = True
            Else
                aufgabe.Abgeschlossen = False
            End If

            aufgabe.Zusatz = Me.patient
            aufgabe.DB = ""

            'If Not General.IsNull(UCheckAbgeschlossen.Checked) Then : DCAufgaben.tblAdminAufgaben.Abgeschlossen = UCheckAbgeschlossen.Checked : Else : DCAufgaben.tblAdminAufgaben.Abgeschlossen = False : End If

            ' Text schreiben
            Dim text As String = ""
            Dim typTxt As New TXTextControl.StreamType
            If Me.isHtml Then
                typTxt = TXTextControl.StreamType.HTMLFormat
            Else
                typTxt = TXTextControl.StreamType.PlainText
            End If
            text = Me.doEditor.getText(typTxt, Me.contTxtEditor.textControl1)
            If Not General.IsNull(text) Then
                aufgabe.Text = text
                aufgabe.AlsHTML = Me.isHtml
            Else
                aufgabe.Text = ""
                aufgabe.AlsHTML = False
            End If

            'If Not General.IsNull(UCheckAbgeschlossen.Checked) Then : DCAufgaben.tblAdminAufgaben.Abgeschlossen = UCheckAbgeschlossen.Checked : Else : DCAufgaben.tblAdminAufgaben.Abgeschlossen = False : End If

            If frmStatus = General.eStatusForm.neu Then
                Me.aufgabe.InsertRow()
            ElseIf frmStatus = General.eStatusForm.edit Then
                Me.aufgabe.UpdateRow(Me._idaufgabe)
            End If

            If frmStatus = General.eStatusForm.neu Then
                If Me.IDobject <> "" Then
                    Dim gIDObj As New System.Guid(General.StrToGuid(Me.IDobject).ToString)
                    If Not General.IsNull(gIDObj) Then
                        Dim tblAdminAufgabeZuordnung As New sqlAufgabeZuordnung
                        tblAdminAufgabeZuordnung.ID = System.Guid.NewGuid
                        tblAdminAufgabeZuordnung.IDAufgabe = Me._idaufgabe
                        tblAdminAufgabeZuordnung.IDZuordnung = gIDObj
                        tblAdminAufgabeZuordnung.Application = Me._typ
                        tblAdminAufgabeZuordnung.InsertRow()
                    End If
                End If
            End If

            'Dim tblAdminAufgabeSel As New tblAufgabeZuordnung
            'tblAdminAufgabeSel.SelectAllRows_IDAufgabe(Me.idaufgabe)
            'For Each DataRowSel As DataRow In tblAdminAufgabeSel.DataTable.Rows
            '    tblAdminAufgabeSel.DeleteRow(DataRowSel("ID"))
            'Next

            Me.contListeAnhang.anhangSichern()
            General.GarbColl()

            Return True

        Catch ex As Exception
            Throw New Exception("saveNachricht: " + ex.ToString())
        End Try
    End Function



    Public Function ShowData(ByVal IDAufgabe As System.Guid) As Boolean
        Try
            Me.clearFields()
            aufgabe.tAufgaben.Rows.Clear()

            aufgabe.getAufgaben(IDAufgabe)
            If aufgabe.tAufgaben.Rows.Count <> 1 Then
                Throw New Exception("ShowData: IDAufgabe in der Datenbank nicht gefunden!")
            End If

            Dim r As DataRow = aufgabe.tAufgaben.Rows(0)
            Me._idaufgabe = (r("ID"))
            If Not General.IsNull(r("Betreff")) Then Me.txtTitel.Text = r("Betreff")
            If Not General.IsNull(r("Teilnehmer")) Then Me.txtTeilnehmer.Text = r("Teilnehmer")

            If Me.txtTeilnehmer.Text <> "" Then
                Dim buttTool As StateButtonTool = Me.UltraToolbarsManager.Toolbars(0).Tools("Teilnehmer")
                buttTool.Checked = True
                Me.PanelEinladen.Visible = True
            End If

            Me._idart = r("IDArt")
            Me.status = r("Status")

            If Not General.IsNull(r("StartDate")) Then Me.UDtDateBeginnt.Value = r("StartDate")
            If Not General.IsNull(r("StartTime")) Then Me.UDtTimeBeginnt.Value = Format(r("StartTime"), "HH:mm")
            If Not General.IsNull(r("EndDate")) Then Me.UDtDateEndet.Value = r("EndDate")
            If Not General.IsNull(r("EndTime")) Then Me.UDtTimeEndet.Value = Format(r("EndTime"), "HH:mm")

            Me.setErstelltVon(r("ErstelltVon"), r("ErstelltAm"))
            Me._ErstelltVon = r("ErstelltVon")

            If Not General.IsNull(r("RememberYesNo")) Then Me.FlagRemember.Checked = r("RememberYesNo")
            If r("RememberYesNo") Then
                UltraComboTimeRemember.Enabled = True
                If Not General.IsNull(r("Remember")) Then Me.UltraComboTimeRemember.Value = r("Remember")
            ElseIf Not Me.FlagRemember.Checked Then
                UltraComboTimeRemember.Enabled = False
                UltraComboTimeRemember.Value = Nothing
                UltraComboTimeRemember.SelectedItem = Nothing
            End If

            Me.UComboPersonen.Value = r("FürIDPerson")

            If General.IDMail.ToString = Me._idart.ToString Then
                Me.UltraToolbarsManager.Toolbars(0).Tools("ButtonSenden").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.True
                If Not General.IsNull(r("WEBGesendet")) Then
                    If r("WEBGesendet") Then
                        Me.setStatus("Gesendet: " + Format(r("gesendetAm"), "dd.MM.yyyy hh:MM").ToString)
                    Else
                        Me.setStatus("Noch nicht gesendet!")
                    End If
                Else
                    Me.setStatus("Noch nicht gesendet!")
                End If
            Else
                Me.UltraToolbarsManager.Toolbars(0).Tools("ButtonSenden").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
                If Me.status = "Offen" Then
                    Me.showAbschließen()
                ElseIf Me.status = "Erledigt" Then
                    Me.UltraToolbarsManager.Toolbars(0).Tools("Abschließen").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
                End If
                Me.setStatus("Status: " + Me.status)
            End If

            If Not General.IsNull(r("MailAn")) Then
                Me.UTextMailAn.Text = r("MailAn")
            Else
                Me.UTextMailAn.Text = ""
            End If
            If Not General.IsNull(r("MailCC")) Then
                Me.UTextMailCC.Text = r("MailCC")
            Else
                Me.UTextMailCC.Text = ""
            End If

            Me.readObject(Me._idaufgabe)

            Me.textAnzeigen(r("Text"), r("AlsHTML"))
            Me.contListeAnhang.anhangLesen(Nothing)

            Me.resizeForm()

            General.GarbColl()

            Me.txtTitel.Focus()

        Catch ex As Exception
            Throw New Exception("ShowData: " + ex.ToString())
        End Try
    End Function

    Public Sub showAbschließen()
        Try
            If Me._ErstelltVon.Trim() = "" Then
                Me.UltraToolbarsManager.Toolbars(0).Tools("Abschließen").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
                Me.UltraToolbarsManager.Toolbars(0).Tools("Löschen").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
            Else
                If General.actUser.Trim().ToLower().Equals(Me._ErstelltVon.Trim().ToLower()) Then
                    Me.UltraToolbarsManager.Toolbars(0).Tools("Abschließen").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.True
                    Me.UltraToolbarsManager.Toolbars(0).Tools("Löschen").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.True
                Else
                    Me.UltraToolbarsManager.Toolbars(0).Tools("Abschließen").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
                    Me.UltraToolbarsManager.Toolbars(0).Tools("Löschen").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
                End If
            End If

        Catch ex As Exception
            Throw New Exception("showAbschließen: " + ex.ToString())
        End Try
    End Sub

    Public Sub textAnzeigen(ByVal text As String, ByVal html As Boolean)
        Try
            If html Then
                Me.contTxtEditor.showText(text, TXTextControl.StreamType.HTMLFormat, True, TXTextControl.ViewMode.Normal)
            Else
                Me.contTxtEditor.showText(text, TXTextControl.StreamType.PlainText, True, TXTextControl.ViewMode.Normal)
            End If

            If html Then
                Me.setHtml(True)
            Else
                Me.setHtml(False)
            End If

        Catch ex As Exception
            Throw New Exception("textAnzeigen: " + ex.ToString())
        End Try
    End Sub
    Public Sub readObject(ByVal IDAufgabe As System.Guid)
        Try
            Dim cl As New cMailTermine
            Dim ret As New clObject
            Me.patient = ""
            ret = cl.getObjectNachricht(IDAufgabe)
            If ret.id <> "" Then
                Me.IDobject = ret.id
                Me.patient = ret.bezeichnung
            End If

            Me.setObjectPanel(Me.patient, Me.IDobject)

        Catch ex As Exception
            Throw New Exception("readObject: " + ex.ToString())
        End Try
    End Sub

    Public Function setAbgeschlossenxy() As Boolean
        Try

            'Dim dDateBeginntxy As Date = UDtDateBeginnt.Value
            'Dim dTimeBeginntxy As Date = UDtTimeBeginnt.Value
            'DCAufgaben.tblAdminAufgaben.Abgeschlossen = Me.bAbgeschlossen
            'If dDateBeginnt.Date >= Date.Now.Date Then
            '    If dTimeBeginnt.Hour > Date.Now.Hour Then
            '        DCAufgaben.tblAdminAufgaben.Abgeschlossen = False
            '    ElseIf dTimeBeginnt.Hour = Date.Now.Hour And dTimeBeginnt.Minute > Date.Now.Minute Then
            '        DCAufgaben.tblAdminAufgaben.Abgeschlossen = False
            '    Else
            '        If DCAufgaben.tblAdminAufgaben.StatusA = "Erledigt" Then
            '            DCAufgaben.tblAdminAufgaben.Abgeschlossen = True
            '        Else
            '            DCAufgaben.tblAdminAufgaben.Abgeschlossen = False
            '        End If
            '    End If
            'Else
            '    If DCAufgaben.tblAdminAufgaben.StatusA = "Erledigt" Then
            '        DCAufgaben.tblAdminAufgaben.Abgeschlossen = True
            '    Else
            '        DCAufgaben.tblAdminAufgaben.Abgeschlossen = False
            '    End If
            'End If

        Catch ex As Exception
            Throw New Exception("setAbgeschlossen: " + ex.ToString())
        End Try
    End Function

    Public Sub autoSetDatumZeitEnde()
        Try
            If Me._typ = General.eTypPlanung.termin Then
                If Not General.IsNull(Me.UDtDateBeginnt.Value) And Not General.IsNull(Me.UDtTimeBeginnt.Value) Then
                    If General.IsNull(Me.UDtDateEndet.Value) Then UDtDateEndet.Value = UDtDateBeginnt.Value
                    If Me.UDtDateEndet.Value < Me.UDtDateBeginnt.Value Then UDtDateEndet.Value = UDtDateBeginnt.Value
                    If (Me.UDtDateEndet.Value = Me.UDtDateBeginnt.Value And Me.UDtTimeEndet.Value < Me.UDtTimeBeginnt.Value) Or
                                General.IsNull(Me.UDtTimeEndet.Value) Then
                        Dim Dat As Date = UDtTimeBeginnt.Value
                        Dat = Dat.AddMinutes(30)
                        Dim DateTimePlus30 As Date = New Date(Dat.Year, Dat.Month, Dat.Day, Dat.Hour, Dat.Minute, 0)
                        UDtTimeEndet.Value = DateTimePlus30
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("autoSetDatumZeitEnde: " + ex.ToString())
        End Try
    End Sub


#End Region

    Private Sub FlagRemember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlagRemember.Click
        Try
            If Not Me.FlagRemember.Checked Then
                UltraComboTimeRemember.Enabled = True
                UltraComboTimeRemember.Value = "15 Minuten"
            ElseIf Me.FlagRemember.Checked Then
                UltraComboTimeRemember.Enabled = False
                UltraComboTimeRemember.Value = Nothing
                UltraComboTimeRemember.SelectedItem = Nothing
            End If
        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub




    Private Sub Aufgabe1StundeVerschiebenxy()
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.saveNachricht() Then
                info.showInfo(True, 1400, Me, "Verschoben")
                Me.modalWindow.refreshMailsTermine()
                Me.Close()
            End If

        Catch ex As Exception
            Throw New Exception("Aufgabe1StundeVerschieben: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Public Sub EditorKeyIsPressed(ByVal OnOff As Boolean)
        Try


        Catch ex As Exception
            Throw New Exception("EditorKeyIsPressed: " + ex.ToString())
        End Try
    End Sub

    Public Sub resizeForm()
        Try
            Me.contTxtEditor.resizeControl(Me.PanelText.Width, Me.PanelText.Height)

        Catch ex As Exception
            Throw New Exception("resizeForm: " + ex.ToString())
        End Try
    End Sub


    Public Sub setErstelltVon(ByVal ErstelltVon As String, ByVal ErstelltAm As Date)
        Try
            Me.UltraStatusBar1.Panels(0).Text = "Erstellt: " + Format(ErstelltAm, "dd.MM.yyyy HH:mm").ToString
            Me.UltraStatusBar1.Panels(1).Text = "Von: " + ErstelltVon

        Catch ex As Exception
            Throw New Exception("setErstelltVon: " + ex.ToString())
        End Try
    End Sub
    Public Sub setStatus(ByVal txt As String)
        Try
            If txt = "" Then
                Me.UltraStatusBar1.Panels(2).Text = Me.status
            Else
                Me.UltraStatusBar1.Panels(2).Text = txt
            End If

        Catch ex As Exception
            Throw New Exception("setStatus: " + ex.ToString())
        End Try
    End Sub
    Public Sub setObjectPanel(ByVal patient As String, ByVal idobject As String)
        Try
            If idobject = "" Then
                Me.UltraStatusBar1.Panels(3).Text = "Keinen Patienten zugeordnet!"
            Else
                Me.UltraStatusBar1.Panels(3).Text = "Patient: " + patient
                Me.UltraStatusBar1.Panels(3).Tag = idobject
            End If

        Catch ex As Exception
            Throw New Exception("setObjectPanel: " + ex.ToString())
        End Try
    End Sub


    Private Sub UButtonAbbrechen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonAbbrechen.Click
        Try
            Me.Close()

        Catch ex As Exception
            Me.General.GetEcxeptionGeneral(ex)
        End Try
    End Sub


    Private Sub UDtDateBeginnt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UDtDateBeginnt.Leave
        Try
            Me.autoSetDatumZeitEnde()

        Catch ex As Exception
            Me.General.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub UDtDateBeginnt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UDtDateBeginnt.ValueChanged

    End Sub
    Private Sub UDtTimeBeginnt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UDtTimeBeginnt.Leave
        Try
            Me.autoSetDatumZeitEnde()

        Catch ex As Exception
            Me.General.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub UDtTimeBeginnt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UDtTimeBeginnt.ValueChanged

    End Sub
    Private Sub UDtDateEndet_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UDtDateEndet.Leave
        Try
            autoSetDatumZeitEnde()

        Catch ex As Exception
            Me.General.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub UDtTimeEndet_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UDtTimeEndet.Leave
        Try
            autoSetDatumZeitEnde()

        Catch ex As Exception
            Me.General.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub UDtDateBeginnt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles UDtDateBeginnt.Enter
        Try
            UDtDateBeginnt.SelectionStart = 0
            UDtDateBeginnt.SelectionLength = 100

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub
    Private Sub UDtTimeBeginnt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles UDtTimeBeginnt.Enter
        Try
            UDtTimeBeginnt.SelectionStart = 0
            UDtTimeBeginnt.SelectionLength = 100

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub
    Private Sub UDtDateEndet_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles UDtDateEndet.Enter
        Try
            UDtDateEndet.SelectionStart = 0
            UDtDateEndet.SelectionLength = 100

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub
    Private Sub UDtTimeEndet_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles UDtTimeEndet.Enter
        Try
            UDtTimeEndet.SelectionStart = 0
            UDtTimeEndet.SelectionLength = 100

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub

    Private Sub UButtonTeilnehmer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonTeilnehmer.Click
        Try
            If Me.txtTeilnehmer.Text <> "" Then
                If Microsoft.VisualBasic.Right(Me.txtTeilnehmer.Text, 1) <> ";" Then Me.txtTeilnehmer.Text += ";"
            End If
            Dim frm As New frmTeilnehmer
            frm.UOptionSetArt.Value = Me.selTeilnehmerauswahlLast
            frm.selList = Me.txtTeilnehmer.Text
            frm.ShowDialog(Me)
            Me.selTeilnehmerauswahlLast = frm.UOptionSetArt.Value
            If frm.apport Then Exit Sub
            Me.txtTeilnehmer.Text = frm.selList

        Catch ex As Exception
            Me.General.GetEcxeptionGeneral(ex)
        End Try
    End Sub

End Class
