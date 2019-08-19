Imports Infragistics.Win.UltraWinTree
Imports Infragistics.Win.UltraWinListView
Imports Infragistics.Win.UltraWinToolbars
Imports System.Windows.Forms
Imports System.Drawing
Imports Infragistics.Win.UltraWinGrid
Imports Microsoft.Exchange.WebServices.Data
Imports Infragistics.Win.UltraWinToolTip

Public Class frmNachricht2
    Inherits System.Windows.Forms.Form

    Public IDArt As Integer = -999

    Private General As New General
    Public modalWindow As contPlanung2

    Public compPlan1 As New compPlan()
    Public dsPlan1 As New dsPlan()

    Public rPlan As dsPlan.planRow

    Private frmStatus As New General.eStatusForm
    Private neuanlagexy As Boolean = False

    Public tPlanObjectsAllCopy As New dsPlan.planObjectDataTable()

    Public contListeAnhang As New contListeAnhang2
    Public contListTextTemplates1 As New contListTextTemplates()
    Public contSelectPatienten As New contSelectPatientenBenutzer()
    Public contSelectBenutzer As New contSelectPatientenBenutzer()

    Public lockToolbarTxt = False

    Public standardViewExtEditor As TXTextControl.ViewMode

    Public doEditor As New QS2.Desktop.Txteditor.doEditor()
    Public genMain As New General()

    Public isLoaded As Boolean = False
    Public abort As Boolean = True
    Public lockToolbar As Boolean = False

    Public generatePlanForEachObj As Boolean = False
    Public compUserAccounts1 As New compUserAccounts()
    Public isEditable As Boolean = True

    Public IDActivityForNewPlan As System.Guid = Nothing
    Public clPlan1 As New clPlan()

    Public heigthAllOnTop As Integer = 260
    Public heigthMinimalOnTop As Integer = 150
    Public heigthPanelMail As Integer = 108
    Public loadAllActivities As Boolean = False

    Public doUI1 As New doUI()

    Public Enum eTypAction
        sendEMailClicked = 0
        sendPlanClicked = 1
        saveButtClicked = 2
    End Enum

    Public typAntworten As eAntworten
    Public Enum eAntworten
        antworten = 0
        alleAntworten = 1
        weiterleiten = 2
        None = -100
    End Enum
    Public Enum eTypUIPlan
        user = 0
        addObjekt = 1
        Mailadresses = 3
    End Enum

    Public InSharedMemory As Boolean = False

    Public LastTextBody As String = ""

    Public ElementHost As New System.Windows.Forms.Integration.ElementHost()
    Public IExplorer1 As New IExplorer()

    Public Messages As HandleMessage.Messages = Nothing
    Public isOpend As Boolean = False

    Public doEditor1 As New QS2.Desktop.Txteditor.doEditor()

    Public md_doForModalDialog As Boolean = False
    Public md_eMail As Boolean = False
    Public md_Mailadresse As String = ""
    Public md_body As String = ""
    Public md_bodyIsHtml As Boolean = False
    Public md_IDArt As Integer = -1
    Public md_betreff As String = ""

    Public contSelectSelListCategories As New contSelectSelList()







#Region "initCodeAuto"

    Public WithEvents txtMailCC As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Public WithEvents txtMailAn As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents PanelMitte As System.Windows.Forms.Panel
    Friend WithEvents PanelText As System.Windows.Forms.Panel
    Public WithEvents txtBetreff As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Public WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents cboPriorität As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents PanelDatum As System.Windows.Forms.Panel
    Friend WithEvents PanelBetreff As System.Windows.Forms.Panel
    Friend WithEvents PanelMail As System.Windows.Forms.Panel
    Public WithEvents txtMailBCC As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents grpTop As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents btnBcc As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSearchCc As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSearchAn As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblAutoEMailAn As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chkTextIsHtml As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents UltraTabControlText As Infragistics.Win.UltraWinTabControl.UltraTabControl
    Friend WithEvents UltraTabSharedControlsPage1 As Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage
    Friend WithEvents UltraTabPageControl1 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents UltraTabPageControl2 As Infragistics.Win.UltraWinTabControl.UltraTabPageControl
    Friend WithEvents PanelText_Fill_Panel As System.Windows.Forms.Panel
    Friend WithEvents _PanelText_Toolbars_Dock_Area_Left As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents toolbarsManagerText As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents _PanelText_Toolbars_Dock_Area_Right As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelText_Toolbars_Dock_Area_Top As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents _PanelText_Toolbars_Dock_Area_Bottom As Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea
    Friend WithEvents btnSendEMails As Infragistics.Win.Misc.UltraButton
    Friend WithEvents PanelMailEmpfangenAmGesendetAm As System.Windows.Forms.Panel
    Friend WithEvents PanelMailAdr As System.Windows.Forms.Panel
    Friend WithEvents lblMailVon As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblEmpfangenAmGesendetAm As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents labelEmpfangenGesendet As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lbkPriorität As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblStartAt As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents labelVon As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblAutoEMailBcc As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblAutoEMailCc As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents btnSendPlan As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblBetreff As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ContextMenuStripStatBar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelWebBrowser As System.Windows.Forms.Panel
    Friend WithEvents PanelBrowser As System.Windows.Forms.Panel
    Friend WithEvents PanelTxtEditor As System.Windows.Forms.Panel
    Friend WithEvents chkSendWithPostOfficeBoxForAll As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Private WithEvents winFormHtmlEditor1 As SpiceLogic.WinHTMLEditor.WinForm.WinFormHtmlEditor
    Friend WithEvents PlanungseintragAusGesendeterListeLöschenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditorTmp1 As TXTextControl.TextControl
    Friend WithEvents dropDownCategories As Infragistics.Win.Misc.UltraDropDownButton
    Private WithEvents uPopupContCategories As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents dropDownPatienten As Infragistics.Win.Misc.UltraDropDownButton
    Friend WithEvents dropDownUsers As Infragistics.Win.Misc.UltraDropDownButton
    Private WithEvents uPopUpContBenutzer As Infragistics.Win.Misc.UltraPopupControlContainer
    Private WithEvents uPopUpContPatienten As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents PanelBody As Panel
    Friend WithEvents PanelBottom As Panel
    Friend WithEvents btnAbort As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents PanelTop As Panel
    Friend WithEvents PanelToolbar As Panel
    Friend WithEvents PanelToolbar_Fill_Panel As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents _PanelToolbar_Toolbars_Dock_Area_Left As UltraToolbarsDockArea
    Friend WithEvents _PanelToolbar_Toolbars_Dock_Area_Right As UltraToolbarsDockArea
    Friend WithEvents _PanelToolbar_Toolbars_Dock_Area_Bottom As UltraToolbarsDockArea
    Friend WithEvents _PanelToolbar_Toolbars_Dock_Area_Top As UltraToolbarsDockArea
    Friend WithEvents PanelAll2 As Panel
    Friend WithEvents lblErstelltVon As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblErstelltAm As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents picInfo As Infragistics.Win.UltraWinEditors.UltraPictureBox
    Friend WithEvents grpStatus As Infragistics.Win.Misc.UltraGroupBox
    Public WithEvents optStatus As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Public WithEvents dteEndetAm As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblEndAt As Infragistics.Win.Misc.UltraLabel
    Public WithEvents iNTenMonat As QS2.Desktop.ControlManagment.BaseMaskEdit
    Private WithEvents lblTagWochenMonatnTen As QS2.Desktop.ControlManagment.BaseLabel
    Public WithEvents iWiedWertJeden As QS2.Desktop.ControlManagment.BaseMaskEdit
    Public WithEvents chkGanzerTag As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents grpSerientermin As Infragistics.Win.Misc.UltraGroupBox
    Friend WithEvents grpWochentage As Infragistics.Win.Misc.UltraGroupBox
    Public WithEvents cboDauer As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Public WithEvents chkIsSerientermin As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Public WithEvents optSerienterminType As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Public WithEvents opTagWochenMonat As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Public WithEvents cbSo As QS2.Desktop.ControlManagment.BaseCheckBox
    Public WithEvents cbSa As QS2.Desktop.ControlManagment.BaseCheckBox
    Public WithEvents cbFr As QS2.Desktop.ControlManagment.BaseCheckBox
    Public WithEvents cbDo As QS2.Desktop.ControlManagment.BaseCheckBox
    Public WithEvents cbMi As QS2.Desktop.ControlManagment.BaseCheckBox
    Public WithEvents cbDi As QS2.Desktop.ControlManagment.BaseCheckBox
    Public WithEvents cbMo As QS2.Desktop.ControlManagment.BaseCheckBox
    Public WithEvents dteSerienterminEndetAm As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents lblSerienterminEnde As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents PlanungsenträgeDieZuDiesemEintragGehörenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem



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
    Friend WithEvents toolbarsManagerMain As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Public WithEvents dteBeginntAm As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DictionaryFileInfo1 As SpiceLogic.HtmlEditorControl.Domain.DesignTime.DictionaryFileInfo = New SpiceLogic.HtmlEditorControl.Domain.DesignTime.DictionaryFileInfo()
        Dim UltraTab2 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim UltraTab1 As Infragistics.Win.UltraWinTabControl.UltraTab = New Infragistics.Win.UltraWinTabControl.UltraTab()
        Dim OptionSet1 As Infragistics.Win.UltraWinToolbars.OptionSet = New Infragistics.Win.UltraWinToolbars.OptionSet("lblOnOffEditor")
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1")
        Dim StateButtonTool3 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("btnIntEditor", "lblOnOffEditor")
        Dim StateButtonTool4 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("btnWebbrowser", "lblOnOffEditor")
        Dim StateButtonTool1 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("btnIntEditor", "lblOnOffEditor")
        Dim StateButtonTool2 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("btnWebbrowser", "lblOnOffEditor")
        Dim LabelTool1 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("lblOnOffEditor")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], "Html", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo2 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], "Html", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNachricht2))
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo3 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], "Html", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo4 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Planungseintrag senden", Infragistics.Win.ToolTipImage.[Default], "Senden", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo5 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Suche Objekte", Infragistics.Win.ToolTipImage.[Default], "", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo6 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], "Html", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo7 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("E-Mails aller Objekte automatisch auflisten", Infragistics.Win.ToolTipImage.[Default], "E-Mails auflisten", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo8 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("E-Mails aller Objekte automatisch auflisten", Infragistics.Win.ToolTipImage.[Default], "E-Mails auflisten", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo9 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("E-Mail versenden", Infragistics.Win.ToolTipImage.[Default], "Senden", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo10 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("E-Mails aller Objekte automatisch auflisten", Infragistics.Win.ToolTipImage.[Default], "E-Mails auflisten", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo11 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Suche Objekte", Infragistics.Win.ToolTipImage.[Default], "", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo12 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Suche Objekte", Infragistics.Win.ToolTipImage.[Default], "", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo13 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Objekt zur E-Mail-Adresse öffnen", Infragistics.Win.ToolTipImage.[Default], "Objekt öffnen", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim RibbonTab1 As Infragistics.Win.UltraWinToolbars.RibbonTab = New Infragistics.Win.UltraWinToolbars.RibbonTab("ribbNachricht")
        Dim RibbonGroup1 As Infragistics.Win.UltraWinToolbars.RibbonGroup = New Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbGrpAktion")
        Dim ButtonTool18 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Löschen")
        Dim RibbonGroup2 As Infragistics.Win.UltraWinToolbars.RibbonGroup = New Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbGrpTeilnehmer")
        Dim RibbonGroup3 As Infragistics.Win.UltraWinToolbars.RibbonGroup = New Infragistics.Win.UltraWinToolbars.RibbonGroup("ribbGrpribbAnhang")
        Dim ButtonTool23 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("DateiHinzufügen")
        Dim PopupControlContainerTool2 As Infragistics.Win.UltraWinToolbars.PopupControlContainerTool = New Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("popUpContListeAnhang")
        Dim UltraToolbar2 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("Aufgabe, Termin neu ...")
        Dim ButtonTool4 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Löschen")
        Dim ButtonTool16 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnAntworten")
        Dim ButtonTool19 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnAllenAntworten")
        Dim ButtonTool25 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnWeiterleiten")
        Dim ButtonTool24 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("DateiHinzufügen")
        Dim PopupControlContainerTool3 As Infragistics.Win.UltraWinToolbars.PopupControlContainerTool = New Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("popUpContListeAnhang")
        Dim PopupControlContainerTool7 As Infragistics.Win.UltraWinToolbars.PopupControlContainerTool = New Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("popUpContUpTextTemplates")
        Dim ButtonTool8 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("Löschen")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ButtonTool22 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("DateiHinzufügen")
        Dim PopupControlContainerTool1 As Infragistics.Win.UltraWinToolbars.PopupControlContainerTool = New Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("popUpContListeAnhang")
        Dim ButtonTool2 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnWeiterleiten")
        Dim ButtonTool7 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnAntworten")
        Dim ButtonTool14 As Infragistics.Win.UltraWinToolbars.ButtonTool = New Infragistics.Win.UltraWinToolbars.ButtonTool("btnAllenAntworten")
        Dim PopupControlContainerTool6 As Infragistics.Win.UltraWinToolbars.PopupControlContainerTool = New Infragistics.Win.UltraWinToolbars.PopupControlContainerTool("popUpContUpTextTemplates")
        Me.UltraTabPageControl2 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.PanelBrowser = New System.Windows.Forms.Panel()
        Me.PanelWebBrowser = New System.Windows.Forms.Panel()
        Me.UltraTabPageControl1 = New Infragistics.Win.UltraWinTabControl.UltraTabPageControl()
        Me.PanelTxtEditor = New System.Windows.Forms.Panel()
        Me.winFormHtmlEditor1 = New SpiceLogic.WinHTMLEditor.WinForm.WinFormHtmlEditor()
        Me.PanelMitte = New System.Windows.Forms.Panel()
        Me.PanelBody = New System.Windows.Forms.Panel()
        Me.PanelText = New System.Windows.Forms.Panel()
        Me.PanelText_Fill_Panel = New System.Windows.Forms.Panel()
        Me.UltraTabControlText = New Infragistics.Win.UltraWinTabControl.UltraTabControl()
        Me.UltraTabSharedControlsPage1 = New Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage()
        Me._PanelText_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.toolbarsManagerText = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me._PanelText_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelText_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelText_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.grpTop = New Infragistics.Win.Misc.UltraGroupBox()
        Me.PanelDatum = New System.Windows.Forms.Panel()
        Me.chkIsSerientermin = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.cboDauer = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.grpSerientermin = New Infragistics.Win.Misc.UltraGroupBox()
        Me.dteSerienterminEndetAm = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblSerienterminEnde = New Infragistics.Win.Misc.UltraLabel()
        Me.grpWochentage = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cbSo = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.cbSa = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.cbFr = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.cbDo = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.cbMi = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.cbDi = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.cbMo = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.opTagWochenMonat = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.iWiedWertJeden = New QS2.Desktop.ControlManagment.BaseMaskEdit()
        Me.lblTagWochenMonatnTen = New QS2.Desktop.ControlManagment.BaseLabel()
        Me.iNTenMonat = New QS2.Desktop.ControlManagment.BaseMaskEdit()
        Me.optSerienterminType = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.chkGanzerTag = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.dteEndetAm = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblEndAt = New Infragistics.Win.Misc.UltraLabel()
        Me.picInfo = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.lblErstelltVon = New Infragistics.Win.Misc.UltraLabel()
        Me.lblErstelltAm = New Infragistics.Win.Misc.UltraLabel()
        Me.grpStatus = New Infragistics.Win.Misc.UltraGroupBox()
        Me.optStatus = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.dteBeginntAm = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblStartAt = New Infragistics.Win.Misc.UltraLabel()
        Me.cboPriorität = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lbkPriorität = New Infragistics.Win.Misc.UltraLabel()
        Me.chkTextIsHtml = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.PanelBetreff = New System.Windows.Forms.Panel()
        Me.txtBetreff = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.btnSendPlan = New Infragistics.Win.Misc.UltraButton()
        Me.lblBetreff = New Infragistics.Win.Misc.UltraLabel()
        Me.PanelMail = New System.Windows.Forms.Panel()
        Me.PanelMailAdr = New System.Windows.Forms.Panel()
        Me.EditorTmp1 = New TXTextControl.TextControl()
        Me.btnSearchAn = New Infragistics.Win.Misc.UltraButton()
        Me.txtMailCC = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.chkSendWithPostOfficeBoxForAll = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.lblAutoEMailBcc = New Infragistics.Win.Misc.UltraLabel()
        Me.lblAutoEMailCc = New Infragistics.Win.Misc.UltraLabel()
        Me.btnSendEMails = New Infragistics.Win.Misc.UltraButton()
        Me.lblAutoEMailAn = New Infragistics.Win.Misc.UltraLabel()
        Me.btnBcc = New Infragistics.Win.Misc.UltraButton()
        Me.btnSearchCc = New Infragistics.Win.Misc.UltraButton()
        Me.txtMailBCC = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.txtMailAn = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.PanelMailEmpfangenAmGesendetAm = New System.Windows.Forms.Panel()
        Me.labelVon = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMailVon = New Infragistics.Win.Misc.UltraLabel()
        Me.lblEmpfangenAmGesendetAm = New Infragistics.Win.Misc.UltraLabel()
        Me.labelEmpfangenGesendet = New Infragistics.Win.Misc.UltraLabel()
        Me.dropDownCategories = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.ContextMenuStripStatBar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanungsenträgeDieZuDiesemEintragGehörenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanungseintragAusGesendeterListeLöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.uPopupContCategories = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.dropDownPatienten = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.dropDownUsers = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.uPopUpContBenutzer = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.uPopUpContPatienten = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.btnAbort = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.toolbarsManagerMain = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me.PanelToolbar = New System.Windows.Forms.Panel()
        Me.PanelToolbar_Fill_Panel = New Infragistics.Win.Misc.UltraPanel()
        Me._PanelToolbar_Toolbars_Dock_Area_Left = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelToolbar_Toolbars_Dock_Area_Right = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelToolbar_Toolbars_Dock_Area_Bottom = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me._PanelToolbar_Toolbars_Dock_Area_Top = New Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea()
        Me.PanelTop = New System.Windows.Forms.Panel()
        Me.PanelAll2 = New System.Windows.Forms.Panel()
        Me.UltraTabPageControl2.SuspendLayout()
        Me.UltraTabPageControl1.SuspendLayout()
        Me.PanelTxtEditor.SuspendLayout()
        Me.winFormHtmlEditor1.SuspendLayout()
        Me.PanelMitte.SuspendLayout()
        Me.PanelBody.SuspendLayout()
        Me.PanelText.SuspendLayout()
        Me.PanelText_Fill_Panel.SuspendLayout()
        CType(Me.UltraTabControlText, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UltraTabControlText.SuspendLayout()
        CType(Me.toolbarsManagerText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpTop.SuspendLayout()
        Me.PanelDatum.SuspendLayout()
        CType(Me.chkIsSerientermin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDauer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpSerientermin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSerientermin.SuspendLayout()
        CType(Me.dteSerienterminEndetAm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpWochentage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpWochentage.SuspendLayout()
        CType(Me.cbSo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbFr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbMi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbDi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbMo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.opTagWochenMonat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.optSerienterminType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkGanzerTag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteEndetAm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpStatus.SuspendLayout()
        CType(Me.optStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteBeginntAm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPriorität, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTextIsHtml, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBetreff.SuspendLayout()
        CType(Me.txtBetreff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMail.SuspendLayout()
        Me.PanelMailAdr.SuspendLayout()
        CType(Me.txtMailCC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSendWithPostOfficeBoxForAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMailBCC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMailAn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMailEmpfangenAmGesendetAm.SuspendLayout()
        Me.ContextMenuStripStatBar.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBottom.SuspendLayout()
        CType(Me.toolbarsManagerMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelToolbar.SuspendLayout()
        Me.PanelToolbar_Fill_Panel.SuspendLayout()
        Me.PanelTop.SuspendLayout()
        Me.PanelAll2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraTabPageControl2
        '
        Me.UltraTabPageControl2.Controls.Add(Me.PanelBrowser)
        Me.UltraTabPageControl2.Controls.Add(Me.PanelWebBrowser)
        Me.UltraTabPageControl2.Location = New System.Drawing.Point(1, 23)
        Me.UltraTabPageControl2.Name = "UltraTabPageControl2"
        Me.UltraTabPageControl2.Size = New System.Drawing.Size(1118, 346)
        '
        'PanelBrowser
        '
        Me.PanelBrowser.BackColor = System.Drawing.Color.Transparent
        Me.PanelBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBrowser.Location = New System.Drawing.Point(0, 0)
        Me.PanelBrowser.Name = "PanelBrowser"
        Me.PanelBrowser.Size = New System.Drawing.Size(1118, 346)
        Me.PanelBrowser.TabIndex = 3
        '
        'PanelWebBrowser
        '
        Me.PanelWebBrowser.BackColor = System.Drawing.Color.Transparent
        Me.PanelWebBrowser.Location = New System.Drawing.Point(992, 259)
        Me.PanelWebBrowser.Name = "PanelWebBrowser"
        Me.PanelWebBrowser.Size = New System.Drawing.Size(87, 71)
        Me.PanelWebBrowser.TabIndex = 2
        '
        'UltraTabPageControl1
        '
        Me.UltraTabPageControl1.Controls.Add(Me.PanelTxtEditor)
        Me.UltraTabPageControl1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabPageControl1.Name = "UltraTabPageControl1"
        Me.UltraTabPageControl1.Size = New System.Drawing.Size(1118, 346)
        '
        'PanelTxtEditor
        '
        Me.PanelTxtEditor.BackColor = System.Drawing.Color.Transparent
        Me.PanelTxtEditor.Controls.Add(Me.winFormHtmlEditor1)
        Me.PanelTxtEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelTxtEditor.Location = New System.Drawing.Point(0, 0)
        Me.PanelTxtEditor.Name = "PanelTxtEditor"
        Me.PanelTxtEditor.Size = New System.Drawing.Size(1118, 346)
        Me.PanelTxtEditor.TabIndex = 0
        '
        'winFormHtmlEditor1
        '
        Me.winFormHtmlEditor1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.winFormHtmlEditor1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.winFormHtmlEditor1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.winFormHtmlEditor1.Charset = "utf-8"
        Me.winFormHtmlEditor1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.winFormHtmlEditor1.DocumentHtml = "<!DOCTYPE html>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<html><head>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<meta content=""text/html; charset=unicode"" http-eq" &
    "uiv=""Content-Type"" />" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</head>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<body></body></html>"
        Me.winFormHtmlEditor1.EditorContextMenuStrip = Nothing
        Me.winFormHtmlEditor1.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.ReadOnly_Preview
        Me.winFormHtmlEditor1.HeaderStyleContentElementID = "page_style"
        Me.winFormHtmlEditor1.HorizontalScroll = Nothing
        Me.winFormHtmlEditor1.Location = New System.Drawing.Point(0, 0)
        Me.winFormHtmlEditor1.Name = "winFormHtmlEditor1"
        Me.winFormHtmlEditor1.Options.ConvertFileUrlsToLocalPaths = True
        Me.winFormHtmlEditor1.Options.CustomDOCTYPE = Nothing
        Me.winFormHtmlEditor1.Options.DefaultHtmlType = SpiceLogic.HtmlEditorControl.Domain.BOs.HtmlContentTypes.DocumentHtml
        Me.winFormHtmlEditor1.Options.FooterTagNavigatorFont = Nothing
        Me.winFormHtmlEditor1.Options.FooterTagNavigatorTextColor = System.Drawing.Color.Teal
        Me.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.ConnectionMode = SpiceLogic.HtmlEditorControl.Domain.BOs.UserOptions.FTPSettings.ConnectionModes.Active
        Me.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.Host = Nothing
        Me.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.Password = Nothing
        Me.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.Port = Nothing
        Me.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.RemoteFolderPath = Nothing
        Me.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.Timeout = 4000
        Me.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.UrlOfTheRemoteFolderPath = Nothing
        Me.winFormHtmlEditor1.Options.FTPSettingsForRemoteResources.UserName = Nothing
        Me.winFormHtmlEditor1.Size = New System.Drawing.Size(1118, 346)
        Me.winFormHtmlEditor1.SpellCheckOptions.CurlyUnderlineImageFilePath = Nothing
        DictionaryFileInfo1.AffixFilePath = Nothing
        DictionaryFileInfo1.DictionaryFilePath = Nothing
        DictionaryFileInfo1.EnableUserDictionary = True
        DictionaryFileInfo1.UserDictionaryFilePath = Nothing
        Me.winFormHtmlEditor1.SpellCheckOptions.DictionaryFile = DictionaryFileInfo1
        Me.winFormHtmlEditor1.SpellCheckOptions.WaitAlertMessage = "Searching next messpelled word..... (please wait)"
        Me.winFormHtmlEditor1.TabIndex = 5
        '
        'winFormHtmlEditor1.WinFormHtmlEditor_Toolbar1
        '
        Me.winFormHtmlEditor1.Toolbar1.Location = New System.Drawing.Point(0, 0)
        Me.winFormHtmlEditor1.Toolbar1.Name = "WinFormHtmlEditor_Toolbar1"
        Me.winFormHtmlEditor1.Toolbar1.Size = New System.Drawing.Size(1118, 29)
        Me.winFormHtmlEditor1.Toolbar1.TabIndex = 0
        '
        'winFormHtmlEditor1.WinFormHtmlEditor_Toolbar2
        '
        Me.winFormHtmlEditor1.Toolbar2.Location = New System.Drawing.Point(0, 29)
        Me.winFormHtmlEditor1.Toolbar2.Name = "WinFormHtmlEditor_Toolbar2"
        Me.winFormHtmlEditor1.Toolbar2.Size = New System.Drawing.Size(1118, 29)
        Me.winFormHtmlEditor1.Toolbar2.TabIndex = 0
        Me.winFormHtmlEditor1.ToolbarContextMenuStrip = Nothing
        '
        'winFormHtmlEditor1.WinFormHtmlEditor_ToolbarFooter
        '
        Me.winFormHtmlEditor1.ToolbarFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.winFormHtmlEditor1.ToolbarFooter.Location = New System.Drawing.Point(0, 321)
        Me.winFormHtmlEditor1.ToolbarFooter.Name = "WinFormHtmlEditor_ToolbarFooter"
        Me.winFormHtmlEditor1.ToolbarFooter.Size = New System.Drawing.Size(1118, 25)
        Me.winFormHtmlEditor1.ToolbarFooter.TabIndex = 7
        Me.winFormHtmlEditor1.VerticalScroll = Nothing
        Me.winFormHtmlEditor1.z__ignore = False
        '
        'PanelMitte
        '
        Me.PanelMitte.BackColor = System.Drawing.Color.Transparent
        Me.PanelMitte.Controls.Add(Me.PanelBody)
        Me.PanelMitte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMitte.Location = New System.Drawing.Point(0, 267)
        Me.PanelMitte.Name = "PanelMitte"
        Me.PanelMitte.Size = New System.Drawing.Size(1122, 395)
        Me.PanelMitte.TabIndex = 416
        '
        'PanelBody
        '
        Me.PanelBody.BackColor = System.Drawing.Color.Transparent
        Me.PanelBody.Controls.Add(Me.PanelText)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 0)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(1122, 395)
        Me.PanelBody.TabIndex = 2
        '
        'PanelText
        '
        Me.PanelText.BackColor = System.Drawing.Color.White
        Me.PanelText.Controls.Add(Me.PanelText_Fill_Panel)
        Me.PanelText.Controls.Add(Me._PanelText_Toolbars_Dock_Area_Left)
        Me.PanelText.Controls.Add(Me._PanelText_Toolbars_Dock_Area_Right)
        Me.PanelText.Controls.Add(Me._PanelText_Toolbars_Dock_Area_Bottom)
        Me.PanelText.Controls.Add(Me._PanelText_Toolbars_Dock_Area_Top)
        Me.PanelText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelText.Location = New System.Drawing.Point(0, 0)
        Me.PanelText.Name = "PanelText"
        Me.PanelText.Size = New System.Drawing.Size(1122, 395)
        Me.PanelText.TabIndex = 0
        '
        'PanelText_Fill_Panel
        '
        Me.PanelText_Fill_Panel.Controls.Add(Me.UltraTabControlText)
        Me.PanelText_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.PanelText_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelText_Fill_Panel.Location = New System.Drawing.Point(0, 23)
        Me.PanelText_Fill_Panel.Name = "PanelText_Fill_Panel"
        Me.PanelText_Fill_Panel.Size = New System.Drawing.Size(1122, 372)
        Me.PanelText_Fill_Panel.TabIndex = 0
        '
        'UltraTabControlText
        '
        Me.UltraTabControlText.Controls.Add(Me.UltraTabSharedControlsPage1)
        Me.UltraTabControlText.Controls.Add(Me.UltraTabPageControl1)
        Me.UltraTabControlText.Controls.Add(Me.UltraTabPageControl2)
        Me.UltraTabControlText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraTabControlText.Location = New System.Drawing.Point(0, 0)
        Me.UltraTabControlText.Name = "UltraTabControlText"
        Me.UltraTabControlText.SharedControlsPage = Me.UltraTabSharedControlsPage1
        Me.UltraTabControlText.Size = New System.Drawing.Size(1122, 372)
        Me.UltraTabControlText.TabIndex = 1
        UltraTab2.Key = "Browser"
        UltraTab2.TabPage = Me.UltraTabPageControl2
        UltraTab2.Text = "Browser"
        UltraTab1.Key = "Texteditor"
        UltraTab1.TabPage = Me.UltraTabPageControl1
        UltraTab1.Text = "Texteditor"
        Me.UltraTabControlText.Tabs.AddRange(New Infragistics.Win.UltraWinTabControl.UltraTab() {UltraTab2, UltraTab1})
        '
        'UltraTabSharedControlsPage1
        '
        Me.UltraTabSharedControlsPage1.Location = New System.Drawing.Point(-10000, -10000)
        Me.UltraTabSharedControlsPage1.Name = "UltraTabSharedControlsPage1"
        Me.UltraTabSharedControlsPage1.Size = New System.Drawing.Size(1118, 346)
        '
        '_PanelText_Toolbars_Dock_Area_Left
        '
        Me._PanelText_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelText_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.White
        Me._PanelText_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._PanelText_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelText_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 23)
        Me._PanelText_Toolbars_Dock_Area_Left.Name = "_PanelText_Toolbars_Dock_Area_Left"
        Me._PanelText_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 372)
        Me._PanelText_Toolbars_Dock_Area_Left.ToolbarsManager = Me.toolbarsManagerText
        '
        'toolbarsManagerText
        '
        Me.toolbarsManagerText.DesignerFlags = 1
        Me.toolbarsManagerText.DockWithinContainer = Me.PanelText
        Me.toolbarsManagerText.LockToolbars = True
        Me.toolbarsManagerText.OptionSets.Add(OptionSet1)
        Me.toolbarsManagerText.ShowFullMenusDelay = 500
        Me.toolbarsManagerText.ShowQuickCustomizeButton = False
        UltraToolbar1.DockedColumn = 0
        UltraToolbar1.DockedRow = 0
        StateButtonTool4.Checked = True
        UltraToolbar1.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {StateButtonTool3, StateButtonTool4})
        UltraToolbar1.Text = "UltraToolbar1"
        Me.toolbarsManagerText.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar1})
        StateButtonTool1.OptionSetKey = "lblOnOffEditor"
        StateButtonTool1.SharedPropsInternal.Caption = "Texteditor"
        StateButtonTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        StateButtonTool1.Tag = "ResID.Texteditor"
        StateButtonTool2.Checked = True
        StateButtonTool2.OptionSetKey = "lblOnOffEditor"
        StateButtonTool2.SharedPropsInternal.Caption = "Browser"
        StateButtonTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        StateButtonTool2.Tag = "ResID.Browser"
        LabelTool1.SharedPropsInternal.Caption = "lblOnOffEditor"
        Me.toolbarsManagerText.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {StateButtonTool1, StateButtonTool2, LabelTool1})
        '
        '_PanelText_Toolbars_Dock_Area_Right
        '
        Me._PanelText_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelText_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.White
        Me._PanelText_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._PanelText_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelText_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(1122, 23)
        Me._PanelText_Toolbars_Dock_Area_Right.Name = "_PanelText_Toolbars_Dock_Area_Right"
        Me._PanelText_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 372)
        Me._PanelText_Toolbars_Dock_Area_Right.ToolbarsManager = Me.toolbarsManagerText
        '
        '_PanelText_Toolbars_Dock_Area_Bottom
        '
        Me._PanelText_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelText_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.White
        Me._PanelText_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._PanelText_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelText_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 395)
        Me._PanelText_Toolbars_Dock_Area_Bottom.Name = "_PanelText_Toolbars_Dock_Area_Bottom"
        Me._PanelText_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(1122, 0)
        Me._PanelText_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.toolbarsManagerText
        '
        '_PanelText_Toolbars_Dock_Area_Top
        '
        Me._PanelText_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelText_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.White
        Me._PanelText_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._PanelText_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelText_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._PanelText_Toolbars_Dock_Area_Top.Name = "_PanelText_Toolbars_Dock_Area_Top"
        Me._PanelText_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(1122, 23)
        Me._PanelText_Toolbars_Dock_Area_Top.ToolbarsManager = Me.toolbarsManagerText
        '
        'grpTop
        '
        Me.grpTop.Controls.Add(Me.PanelDatum)
        Me.grpTop.Controls.Add(Me.PanelBetreff)
        Me.grpTop.Controls.Add(Me.PanelMail)
        Me.grpTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpTop.Location = New System.Drawing.Point(0, 0)
        Me.grpTop.Name = "grpTop"
        Me.grpTop.Size = New System.Drawing.Size(1122, 267)
        Me.grpTop.TabIndex = 6
        '
        'PanelDatum
        '
        Me.PanelDatum.BackColor = System.Drawing.Color.Transparent
        Me.PanelDatum.Controls.Add(Me.chkIsSerientermin)
        Me.PanelDatum.Controls.Add(Me.cboDauer)
        Me.PanelDatum.Controls.Add(Me.grpSerientermin)
        Me.PanelDatum.Controls.Add(Me.chkGanzerTag)
        Me.PanelDatum.Controls.Add(Me.dteEndetAm)
        Me.PanelDatum.Controls.Add(Me.lblEndAt)
        Me.PanelDatum.Controls.Add(Me.picInfo)
        Me.PanelDatum.Controls.Add(Me.lblErstelltVon)
        Me.PanelDatum.Controls.Add(Me.lblErstelltAm)
        Me.PanelDatum.Controls.Add(Me.grpStatus)
        Me.PanelDatum.Controls.Add(Me.dteBeginntAm)
        Me.PanelDatum.Controls.Add(Me.lblStartAt)
        Me.PanelDatum.Controls.Add(Me.cboPriorität)
        Me.PanelDatum.Controls.Add(Me.lbkPriorität)
        Me.PanelDatum.Controls.Add(Me.chkTextIsHtml)
        Me.PanelDatum.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelDatum.Location = New System.Drawing.Point(3, 143)
        Me.PanelDatum.Name = "PanelDatum"
        Me.PanelDatum.Size = New System.Drawing.Size(1116, 113)
        Me.PanelDatum.TabIndex = 4
        '
        'chkIsSerientermin
        '
        Appearance1.BackColor = System.Drawing.Color.Transparent
        Appearance1.BackColorDisabled = System.Drawing.Color.Transparent
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Appearance1.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.chkIsSerientermin.Appearance = Appearance1
        Me.chkIsSerientermin.BackColor = System.Drawing.Color.Transparent
        Me.chkIsSerientermin.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkIsSerientermin.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkIsSerientermin.Location = New System.Drawing.Point(323, 2)
        Me.chkIsSerientermin.Name = "chkIsSerientermin"
        Me.chkIsSerientermin.Size = New System.Drawing.Size(86, 18)
        Me.chkIsSerientermin.TabIndex = 4
        Me.chkIsSerientermin.Tag = "ResID.Serientermin"
        Me.chkIsSerientermin.Text = "Serientermin"
        UltraToolTipInfo1.ToolTipTextFormatted = "Text unterhalb in Html oder als normalen Text darstellen"
        UltraToolTipInfo1.ToolTipTitle = "Html"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.chkIsSerientermin, UltraToolTipInfo1)
        Me.chkIsSerientermin.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.chkIsSerientermin.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'cboDauer
        '
        Me.cboDauer.Location = New System.Drawing.Point(197, 37)
        Me.cboDauer.Name = "cboDauer"
        Me.cboDauer.Size = New System.Drawing.Size(103, 21)
        Me.cboDauer.TabIndex = 3
        '
        'grpSerientermin
        '
        Me.grpSerientermin.Controls.Add(Me.dteSerienterminEndetAm)
        Me.grpSerientermin.Controls.Add(Me.lblSerienterminEnde)
        Me.grpSerientermin.Controls.Add(Me.grpWochentage)
        Me.grpSerientermin.Controls.Add(Me.opTagWochenMonat)
        Me.grpSerientermin.Controls.Add(Me.iWiedWertJeden)
        Me.grpSerientermin.Controls.Add(Me.lblTagWochenMonatnTen)
        Me.grpSerientermin.Controls.Add(Me.iNTenMonat)
        Me.grpSerientermin.Controls.Add(Me.optSerienterminType)
        Me.grpSerientermin.Location = New System.Drawing.Point(311, 9)
        Me.grpSerientermin.Name = "grpSerientermin"
        Me.grpSerientermin.Size = New System.Drawing.Size(475, 101)
        Me.grpSerientermin.TabIndex = 5
        Me.grpSerientermin.Tag = ""
        Me.grpSerientermin.Visible = False
        '
        'dteSerienterminEndetAm
        '
        Appearance7.BackColor = System.Drawing.Color.White
        Appearance7.BackColor2 = System.Drawing.Color.White
        Appearance7.BackColorDisabled = System.Drawing.Color.White
        Appearance7.BackColorDisabled2 = System.Drawing.Color.White
        Appearance7.FontData.BoldAsString = "False"
        Appearance7.FontData.ItalicAsString = "False"
        Appearance7.FontData.Name = "Microsoft Sans Serif"
        Appearance7.FontData.SizeInPoints = 8.25!
        Appearance7.FontData.StrikeoutAsString = "False"
        Appearance7.FontData.UnderlineAsString = "False"
        Appearance7.ForeColor = System.Drawing.Color.Black
        Appearance7.ForeColorDisabled = System.Drawing.Color.Black
        Me.dteSerienterminEndetAm.Appearance = Appearance7
        Me.dteSerienterminEndetAm.BackColor = System.Drawing.Color.White
        Me.dteSerienterminEndetAm.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dteSerienterminEndetAm.Location = New System.Drawing.Point(66, 11)
        Me.dteSerienterminEndetAm.MaskInput = "{date}"
        Me.dteSerienterminEndetAm.Name = "dteSerienterminEndetAm"
        Me.dteSerienterminEndetAm.Size = New System.Drawing.Size(93, 21)
        Me.dteSerienterminEndetAm.TabIndex = 0
        Me.dteSerienterminEndetAm.Value = Nothing
        '
        'lblSerienterminEnde
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.ForeColor = System.Drawing.Color.Black
        Appearance8.ForeColorDisabled = System.Drawing.Color.Black
        Appearance8.TextVAlignAsString = "Middle"
        Me.lblSerienterminEnde.Appearance = Appearance8
        Me.lblSerienterminEnde.Location = New System.Drawing.Point(7, 13)
        Me.lblSerienterminEnde.Name = "lblSerienterminEnde"
        Me.lblSerienterminEnde.Size = New System.Drawing.Size(90, 17)
        Me.lblSerienterminEnde.TabIndex = 505
        Me.lblSerienterminEnde.Tag = "ResID.plan.EndetAm"
        Me.lblSerienterminEnde.Text = "Endet am"
        '
        'grpWochentage
        '
        Appearance9.BackColorDisabled = System.Drawing.Color.White
        Me.grpWochentage.Appearance = Appearance9
        Me.grpWochentage.Controls.Add(Me.cbSo)
        Me.grpWochentage.Controls.Add(Me.cbSa)
        Me.grpWochentage.Controls.Add(Me.cbFr)
        Me.grpWochentage.Controls.Add(Me.cbDo)
        Me.grpWochentage.Controls.Add(Me.cbMi)
        Me.grpWochentage.Controls.Add(Me.cbDi)
        Me.grpWochentage.Controls.Add(Me.cbMo)
        Me.grpWochentage.Location = New System.Drawing.Point(314, 37)
        Me.grpWochentage.Name = "grpWochentage"
        Me.grpWochentage.Size = New System.Drawing.Size(153, 57)
        Me.grpWochentage.TabIndex = 5
        Me.grpWochentage.Tag = "ResID.Wochentage"
        Me.grpWochentage.Text = "Wochentage"
        Me.grpWochentage.UseAppStyling = False
        '
        'cbSo
        '
        Appearance10.TextHAlignAsString = "Center"
        Appearance10.TextVAlignAsString = "Middle"
        Me.cbSo.Appearance = Appearance10
        Me.cbSo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbSo.Location = New System.Drawing.Point(126, 16)
        Me.cbSo.Name = "cbSo"
        Me.cbSo.Size = New System.Drawing.Size(24, 34)
        Me.cbSo.TabIndex = 13
        Me.cbSo.Text = "So"
        '
        'cbSa
        '
        Appearance11.TextHAlignAsString = "Center"
        Appearance11.TextVAlignAsString = "Middle"
        Me.cbSa.Appearance = Appearance11
        Me.cbSa.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbSa.Location = New System.Drawing.Point(106, 16)
        Me.cbSa.Name = "cbSa"
        Me.cbSa.Size = New System.Drawing.Size(24, 34)
        Me.cbSa.TabIndex = 12
        Me.cbSa.Text = "Sa"
        '
        'cbFr
        '
        Appearance12.TextHAlignAsString = "Center"
        Appearance12.TextVAlignAsString = "Middle"
        Me.cbFr.Appearance = Appearance12
        Me.cbFr.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbFr.Location = New System.Drawing.Point(86, 16)
        Me.cbFr.Name = "cbFr"
        Me.cbFr.Size = New System.Drawing.Size(24, 34)
        Me.cbFr.TabIndex = 11
        Me.cbFr.Text = "Fr"
        '
        'cbDo
        '
        Appearance13.TextHAlignAsString = "Center"
        Appearance13.TextVAlignAsString = "Middle"
        Me.cbDo.Appearance = Appearance13
        Me.cbDo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbDo.Location = New System.Drawing.Point(66, 16)
        Me.cbDo.Name = "cbDo"
        Me.cbDo.Size = New System.Drawing.Size(24, 34)
        Me.cbDo.TabIndex = 10
        Me.cbDo.Text = "Do"
        '
        'cbMi
        '
        Appearance14.TextHAlignAsString = "Center"
        Appearance14.TextVAlignAsString = "Middle"
        Me.cbMi.Appearance = Appearance14
        Me.cbMi.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbMi.Location = New System.Drawing.Point(46, 16)
        Me.cbMi.Name = "cbMi"
        Me.cbMi.Size = New System.Drawing.Size(24, 34)
        Me.cbMi.TabIndex = 9
        Me.cbMi.Text = "Mi"
        '
        'cbDi
        '
        Appearance15.TextHAlignAsString = "Center"
        Appearance15.TextVAlignAsString = "Middle"
        Me.cbDi.Appearance = Appearance15
        Me.cbDi.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbDi.Location = New System.Drawing.Point(26, 16)
        Me.cbDi.Name = "cbDi"
        Me.cbDi.Size = New System.Drawing.Size(24, 34)
        Me.cbDi.TabIndex = 8
        Me.cbDi.Text = "Di"
        '
        'cbMo
        '
        Appearance16.TextHAlignAsString = "Center"
        Appearance16.TextVAlignAsString = "Middle"
        Me.cbMo.Appearance = Appearance16
        Me.cbMo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbMo.Location = New System.Drawing.Point(6, 16)
        Me.cbMo.Name = "cbMo"
        Me.cbMo.Size = New System.Drawing.Size(24, 34)
        Me.cbMo.TabIndex = 7
        Me.cbMo.Text = "Mo"
        '
        'opTagWochenMonat
        '
        Appearance17.BackColorDisabled = System.Drawing.Color.White
        Me.opTagWochenMonat.Appearance = Appearance17
        Me.opTagWochenMonat.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.opTagWochenMonat.CheckedIndex = 0
        ValueListItem6.CheckState = System.Windows.Forms.CheckState.Checked
        ValueListItem6.DataValue = 0
        ValueListItem6.DisplayText = "Tage"
        ValueListItem6.Tag = "ResID.Tage"
        ValueListItem7.DataValue = 1
        ValueListItem7.DisplayText = "Wochen"
        ValueListItem7.Tag = "ResID.Wochen"
        ValueListItem8.DataValue = 2
        ValueListItem8.DisplayText = "Monate"
        ValueListItem8.Tag = "ResID.Monate"
        Me.opTagWochenMonat.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem6, ValueListItem7, ValueListItem8})
        Me.opTagWochenMonat.Location = New System.Drawing.Point(149, 54)
        Me.opTagWochenMonat.Name = "opTagWochenMonat"
        Me.opTagWochenMonat.Size = New System.Drawing.Size(166, 15)
        Me.opTagWochenMonat.TabIndex = 3
        Me.opTagWochenMonat.Text = "Tage"
        '
        'iWiedWertJeden
        '
        Appearance18.BackColorDisabled = System.Drawing.SystemColors.Control
        Appearance18.ForeColorDisabled = System.Drawing.Color.Black
        Me.iWiedWertJeden.Appearance = Appearance18
        Me.iWiedWertJeden.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.[Integer]
        Me.iWiedWertJeden.InputMask = "nnn"
        Me.iWiedWertJeden.Location = New System.Drawing.Point(66, 51)
        Me.iWiedWertJeden.MaxValue = 1000
        Me.iWiedWertJeden.MinValue = 1
        Me.iWiedWertJeden.Name = "iWiedWertJeden"
        Me.iWiedWertJeden.NonAutoSizeHeight = 20
        Me.iWiedWertJeden.Size = New System.Drawing.Size(77, 20)
        Me.iWiedWertJeden.TabIndex = 2
        Me.iWiedWertJeden.Text = "                 "
        '
        'lblTagWochenMonatnTen
        '
        Appearance19.FontData.SizeInPoints = 8.0!
        Me.lblTagWochenMonatnTen.Appearance = Appearance19
        Me.lblTagWochenMonatnTen.AutoSize = True
        Me.lblTagWochenMonatnTen.Location = New System.Drawing.Point(146, 75)
        Me.lblTagWochenMonatnTen.Name = "lblTagWochenMonatnTen"
        Me.lblTagWochenMonatnTen.Size = New System.Drawing.Size(82, 14)
        Me.lblTagWochenMonatnTen.TabIndex = 500
        Me.lblTagWochenMonatnTen.Tag = "ResID.TenDesMonats"
        Me.lblTagWochenMonatnTen.Text = ".ten des Monats"
        '
        'iNTenMonat
        '
        Appearance20.BackColorDisabled = System.Drawing.SystemColors.Control
        Appearance20.ForeColorDisabled = System.Drawing.Color.Black
        Me.iNTenMonat.Appearance = Appearance20
        Me.iNTenMonat.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.[Integer]
        Me.iNTenMonat.InputMask = "nnn"
        Me.iNTenMonat.Location = New System.Drawing.Point(66, 72)
        Me.iNTenMonat.MaxValue = CType(31, Short)
        Me.iNTenMonat.MinValue = CType(1, Short)
        Me.iNTenMonat.Name = "iNTenMonat"
        Me.iNTenMonat.NonAutoSizeHeight = 20
        Me.iNTenMonat.Size = New System.Drawing.Size(77, 20)
        Me.iNTenMonat.TabIndex = 4
        Me.iNTenMonat.Text = "                   "
        '
        'optSerienterminType
        '
        Me.optSerienterminType.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.optSerienterminType.CheckedIndex = 0
        ValueListItem3.CheckState = System.Windows.Forms.CheckState.Checked
        ValueListItem3.DataValue = 1
        ValueListItem3.DisplayText = "täglich"
        ValueListItem3.Tag = "ResID.täglich"
        ValueListItem4.DataValue = 2
        ValueListItem4.DisplayText = "alle"
        ValueListItem4.Tag = "ResID.alle6"
        ValueListItem5.DataValue = 3
        ValueListItem5.DisplayText = "jeden"
        ValueListItem5.Tag = "ResID.jeden"
        Me.optSerienterminType.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem3, ValueListItem4, ValueListItem5})
        Me.optSerienterminType.ItemSpacingVertical = 4
        Me.optSerienterminType.Location = New System.Drawing.Point(8, 36)
        Me.optSerienterminType.Name = "optSerienterminType"
        Me.optSerienterminType.Size = New System.Drawing.Size(55, 55)
        Me.optSerienterminType.TabIndex = 1
        Me.optSerienterminType.Text = "täglich"
        '
        'chkGanzerTag
        '
        Appearance21.BackColor = System.Drawing.Color.Transparent
        Appearance21.BackColorDisabled = System.Drawing.Color.Transparent
        Appearance21.ForeColor = System.Drawing.Color.Black
        Appearance21.ForeColorDisabled = System.Drawing.Color.Black
        Appearance21.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.chkGanzerTag.Appearance = Appearance21
        Me.chkGanzerTag.BackColor = System.Drawing.Color.Transparent
        Me.chkGanzerTag.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkGanzerTag.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkGanzerTag.Location = New System.Drawing.Point(199, 15)
        Me.chkGanzerTag.Name = "chkGanzerTag"
        Me.chkGanzerTag.Size = New System.Drawing.Size(88, 18)
        Me.chkGanzerTag.TabIndex = 2
        Me.chkGanzerTag.Tag = "ResID.GanzerTag"
        Me.chkGanzerTag.Text = "Ganzer Tag"
        UltraToolTipInfo2.ToolTipTextFormatted = "Text unterhalb in Html oder als normalen Text darstellen"
        UltraToolTipInfo2.ToolTipTitle = "Html"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.chkGanzerTag, UltraToolTipInfo2)
        Me.chkGanzerTag.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.chkGanzerTag.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'dteEndetAm
        '
        Appearance22.BackColor = System.Drawing.Color.White
        Appearance22.BackColor2 = System.Drawing.Color.White
        Appearance22.BackColorDisabled = System.Drawing.Color.White
        Appearance22.BackColorDisabled2 = System.Drawing.Color.White
        Appearance22.FontData.BoldAsString = "False"
        Appearance22.FontData.ItalicAsString = "False"
        Appearance22.FontData.Name = "Microsoft Sans Serif"
        Appearance22.FontData.SizeInPoints = 8.25!
        Appearance22.FontData.StrikeoutAsString = "False"
        Appearance22.FontData.UnderlineAsString = "False"
        Appearance22.ForeColor = System.Drawing.Color.Black
        Appearance22.ForeColorDisabled = System.Drawing.Color.Black
        Me.dteEndetAm.Appearance = Appearance22
        Me.dteEndetAm.BackColor = System.Drawing.Color.White
        Me.dteEndetAm.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dteEndetAm.Location = New System.Drawing.Point(72, 37)
        Me.dteEndetAm.MaskInput = "{date} {time}"
        Me.dteEndetAm.Name = "dteEndetAm"
        Me.dteEndetAm.Size = New System.Drawing.Size(121, 21)
        Me.dteEndetAm.TabIndex = 1
        Me.dteEndetAm.Value = Nothing
        '
        'lblEndAt
        '
        Appearance23.BackColor = System.Drawing.Color.Transparent
        Appearance23.ForeColor = System.Drawing.Color.Black
        Appearance23.ForeColorDisabled = System.Drawing.Color.Black
        Appearance23.TextVAlignAsString = "Middle"
        Me.lblEndAt.Appearance = Appearance23
        Me.lblEndAt.Location = New System.Drawing.Point(8, 39)
        Me.lblEndAt.Name = "lblEndAt"
        Me.lblEndAt.Size = New System.Drawing.Size(90, 17)
        Me.lblEndAt.TabIndex = 503
        Me.lblEndAt.Tag = "ResID.plan.EndetAm"
        Me.lblEndAt.Text = "Endet am"
        '
        'picInfo
        '
        Me.picInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picInfo.BorderShadowColor = System.Drawing.Color.Empty
        Me.picInfo.Image = CType(resources.GetObject("picInfo.Image"), Object)
        Me.picInfo.Location = New System.Drawing.Point(1088, 75)
        Me.picInfo.Name = "picInfo"
        Me.picInfo.Size = New System.Drawing.Size(20, 21)
        Me.picInfo.TabIndex = 495
        '
        'lblErstelltVon
        '
        Me.lblErstelltVon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance24.BackColor = System.Drawing.Color.Transparent
        Appearance24.FontData.SizeInPoints = 7.5!
        Appearance24.ForeColor = System.Drawing.Color.Black
        Appearance24.ForeColorDisabled = System.Drawing.Color.Black
        Appearance24.TextVAlignAsString = "Middle"
        Me.lblErstelltVon.Appearance = Appearance24
        Me.lblErstelltVon.AutoSize = True
        Me.lblErstelltVon.Location = New System.Drawing.Point(954, 80)
        Me.lblErstelltVon.Name = "lblErstelltVon"
        Me.lblErstelltVon.Size = New System.Drawing.Size(90, 13)
        Me.lblErstelltVon.TabIndex = 421
        Me.lblErstelltVon.Tag = ""
        Me.lblErstelltVon.Text = "Erstellt von: Admin"
        '
        'lblErstelltAm
        '
        Me.lblErstelltAm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance25.BackColor = System.Drawing.Color.Transparent
        Appearance25.FontData.SizeInPoints = 7.5!
        Appearance25.ForeColor = System.Drawing.Color.Black
        Appearance25.ForeColorDisabled = System.Drawing.Color.Black
        Appearance25.TextVAlignAsString = "Middle"
        Me.lblErstelltAm.Appearance = Appearance25
        Me.lblErstelltAm.AutoSize = True
        Me.lblErstelltAm.Location = New System.Drawing.Point(954, 95)
        Me.lblErstelltAm.Name = "lblErstelltAm"
        Me.lblErstelltAm.Size = New System.Drawing.Size(154, 13)
        Me.lblErstelltAm.TabIndex = 493
        Me.lblErstelltAm.Tag = ""
        Me.lblErstelltAm.Text = "Erstellt am: 2017-08-23 12:23:21"
        '
        'grpStatus
        '
        Me.grpStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpStatus.Controls.Add(Me.optStatus)
        Me.grpStatus.Location = New System.Drawing.Point(838, 6)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Size = New System.Drawing.Size(124, 38)
        Me.grpStatus.TabIndex = 10
        Me.grpStatus.Tag = "ResID.Status"
        Me.grpStatus.Text = "Status"
        '
        'optStatus
        '
        Me.optStatus.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.optStatus.CheckedIndex = 0
        ValueListItem1.CheckState = System.Windows.Forms.CheckState.Checked
        ValueListItem1.DataValue = 0
        ValueListItem1.DisplayText = "Offen"
        ValueListItem1.Tag = "ResID.Openly"
        ValueListItem2.DataValue = "Completed"
        ValueListItem2.DisplayText = "Erledigt"
        ValueListItem2.Tag = "ResID.Completed"
        Me.optStatus.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2})
        Me.optStatus.Location = New System.Drawing.Point(9, 17)
        Me.optStatus.Name = "optStatus"
        Me.optStatus.Size = New System.Drawing.Size(108, 17)
        Me.optStatus.TabIndex = 493
        Me.optStatus.Text = "Offen"
        '
        'dteBeginntAm
        '
        Appearance26.BackColor = System.Drawing.Color.White
        Appearance26.BackColor2 = System.Drawing.Color.White
        Appearance26.BackColorDisabled = System.Drawing.Color.White
        Appearance26.BackColorDisabled2 = System.Drawing.Color.White
        Appearance26.FontData.BoldAsString = "False"
        Appearance26.FontData.ItalicAsString = "False"
        Appearance26.FontData.Name = "Microsoft Sans Serif"
        Appearance26.FontData.SizeInPoints = 8.25!
        Appearance26.FontData.StrikeoutAsString = "False"
        Appearance26.FontData.UnderlineAsString = "False"
        Appearance26.ForeColor = System.Drawing.Color.Black
        Appearance26.ForeColorDisabled = System.Drawing.Color.Black
        Me.dteBeginntAm.Appearance = Appearance26
        Me.dteBeginntAm.BackColor = System.Drawing.Color.White
        Me.dteBeginntAm.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dteBeginntAm.Location = New System.Drawing.Point(72, 14)
        Me.dteBeginntAm.MaskInput = "{date} {time}"
        Me.dteBeginntAm.Name = "dteBeginntAm"
        Me.dteBeginntAm.Size = New System.Drawing.Size(121, 21)
        Me.dteBeginntAm.TabIndex = 0
        Me.dteBeginntAm.Value = Nothing
        '
        'lblStartAt
        '
        Appearance27.BackColor = System.Drawing.Color.Transparent
        Appearance27.ForeColor = System.Drawing.Color.Black
        Appearance27.ForeColorDisabled = System.Drawing.Color.Black
        Appearance27.TextVAlignAsString = "Middle"
        Me.lblStartAt.Appearance = Appearance27
        Me.lblStartAt.Location = New System.Drawing.Point(8, 16)
        Me.lblStartAt.Name = "lblStartAt"
        Me.lblStartAt.Size = New System.Drawing.Size(90, 17)
        Me.lblStartAt.TabIndex = 382
        Me.lblStartAt.Tag = "ResID.plan.BeginntAm"
        Me.lblStartAt.Text = "Beginnt am"
        '
        'cboPriorität
        '
        Me.cboPriorität.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance28.BackColor = System.Drawing.Color.White
        Appearance28.BackColor2 = System.Drawing.Color.White
        Appearance28.BackColorDisabled = System.Drawing.Color.White
        Appearance28.BackColorDisabled2 = System.Drawing.Color.White
        Appearance28.FontData.Name = "Microsoft Sans Serif"
        Appearance28.ForeColor = System.Drawing.Color.Black
        Appearance28.ForeColorDisabled = System.Drawing.Color.Black
        Me.cboPriorität.Appearance = Appearance28
        Me.cboPriorität.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboPriorität.AutoSize = False
        Me.cboPriorität.BackColor = System.Drawing.Color.White
        Me.cboPriorität.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched
        Me.cboPriorität.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance29.BackColor = System.Drawing.Color.White
        Appearance29.BackColorDisabled = System.Drawing.Color.White
        Appearance29.BorderColor = System.Drawing.Color.Black
        Appearance29.ForeColor = System.Drawing.Color.Black
        Appearance29.ForeColorDisabled = System.Drawing.Color.Black
        Me.cboPriorität.ItemAppearance = Appearance29
        Me.cboPriorität.Location = New System.Drawing.Point(1017, 19)
        Me.cboPriorität.Name = "cboPriorität"
        Me.cboPriorität.Size = New System.Drawing.Size(81, 20)
        Me.cboPriorität.TabIndex = 11
        '
        'lbkPriorität
        '
        Me.lbkPriorität.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance30.BackColor = System.Drawing.Color.Transparent
        Appearance30.ForeColor = System.Drawing.Color.Black
        Appearance30.ForeColorDisabled = System.Drawing.Color.Black
        Appearance30.TextHAlignAsString = "Right"
        Appearance30.TextVAlignAsString = "Middle"
        Me.lbkPriorität.Appearance = Appearance30
        Me.lbkPriorität.Location = New System.Drawing.Point(955, 20)
        Me.lbkPriorität.Name = "lbkPriorität"
        Me.lbkPriorität.Size = New System.Drawing.Size(58, 17)
        Me.lbkPriorität.TabIndex = 420
        Me.lbkPriorität.Tag = "ResID.Priority"
        Me.lbkPriorität.Text = "Priorität"
        '
        'chkTextIsHtml
        '
        Me.chkTextIsHtml.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance31.BackColor = System.Drawing.Color.Transparent
        Appearance31.BackColorDisabled = System.Drawing.Color.Transparent
        Appearance31.ForeColor = System.Drawing.Color.Black
        Appearance31.ForeColorDisabled = System.Drawing.Color.Black
        Appearance31.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.chkTextIsHtml.Appearance = Appearance31
        Me.chkTextIsHtml.BackColor = System.Drawing.Color.Transparent
        Me.chkTextIsHtml.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkTextIsHtml.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkTextIsHtml.Location = New System.Drawing.Point(9, 96)
        Me.chkTextIsHtml.Name = "chkTextIsHtml"
        Me.chkTextIsHtml.Size = New System.Drawing.Size(57, 15)
        Me.chkTextIsHtml.TabIndex = 6
        Me.chkTextIsHtml.TabStop = False
        Me.chkTextIsHtml.Tag = "ResID.Html"
        Me.chkTextIsHtml.Text = "Html"
        UltraToolTipInfo3.ToolTipTextFormatted = "Text unterhalb in Html oder als normalen Text darstellen"
        UltraToolTipInfo3.ToolTipTitle = "Html"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.chkTextIsHtml, UltraToolTipInfo3)
        Me.chkTextIsHtml.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.chkTextIsHtml.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'PanelBetreff
        '
        Me.PanelBetreff.BackColor = System.Drawing.Color.Transparent
        Me.PanelBetreff.Controls.Add(Me.txtBetreff)
        Me.PanelBetreff.Controls.Add(Me.btnSendPlan)
        Me.PanelBetreff.Controls.Add(Me.lblBetreff)
        Me.PanelBetreff.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelBetreff.Location = New System.Drawing.Point(3, 111)
        Me.PanelBetreff.Name = "PanelBetreff"
        Me.PanelBetreff.Size = New System.Drawing.Size(1116, 32)
        Me.PanelBetreff.TabIndex = 3
        '
        'txtBetreff
        '
        Me.txtBetreff.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance32.BackColor = System.Drawing.Color.White
        Appearance32.BackColor2 = System.Drawing.Color.White
        Appearance32.BackColorDisabled = System.Drawing.Color.White
        Appearance32.BackColorDisabled2 = System.Drawing.Color.White
        Appearance32.FontData.BoldAsString = "False"
        Appearance32.FontData.ItalicAsString = "False"
        Appearance32.FontData.Name = "Microsoft Sans Serif"
        Appearance32.FontData.SizeInPoints = 8.25!
        Appearance32.FontData.StrikeoutAsString = "False"
        Appearance32.FontData.UnderlineAsString = "False"
        Appearance32.ForeColor = System.Drawing.Color.Black
        Appearance32.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtBetreff.Appearance = Appearance32
        Me.txtBetreff.AutoSize = False
        Me.txtBetreff.BackColor = System.Drawing.Color.White
        Me.txtBetreff.Location = New System.Drawing.Point(73, 7)
        Me.txtBetreff.MaxLength = 0
        Me.txtBetreff.Name = "txtBetreff"
        Me.txtBetreff.Size = New System.Drawing.Size(1035, 23)
        Me.txtBetreff.TabIndex = 0
        Me.txtBetreff.Tag = "Vorname"
        '
        'btnSendPlan
        '
        Appearance33.ForeColor = System.Drawing.Color.Black
        Appearance33.ForeColorDisabled = System.Drawing.Color.Black
        Me.btnSendPlan.Appearance = Appearance33
        Me.btnSendPlan.Location = New System.Drawing.Point(1099, 0)
        Me.btnSendPlan.Name = "btnSendPlan"
        Me.btnSendPlan.Size = New System.Drawing.Size(73, 25)
        Me.btnSendPlan.TabIndex = 385
        Me.btnSendPlan.Tag = "ResID.Send"
        Me.btnSendPlan.Text = "Senden"
        UltraToolTipInfo4.ToolTipText = "Planungseintrag senden"
        UltraToolTipInfo4.ToolTipTitle = "Senden"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnSendPlan, UltraToolTipInfo4)
        Me.btnSendPlan.Visible = False
        '
        'lblBetreff
        '
        Appearance34.BackColor = System.Drawing.Color.Transparent
        Appearance34.ForeColor = System.Drawing.Color.Black
        Appearance34.ForeColorDisabled = System.Drawing.Color.Black
        Appearance34.TextVAlignAsString = "Middle"
        Me.lblBetreff.Appearance = Appearance34
        Me.lblBetreff.Location = New System.Drawing.Point(9, 10)
        Me.lblBetreff.Name = "lblBetreff"
        Me.lblBetreff.Size = New System.Drawing.Size(131, 17)
        Me.lblBetreff.TabIndex = 421
        Me.lblBetreff.Tag = "ResID.Subject"
        Me.lblBetreff.Text = "Betreff"
        '
        'PanelMail
        '
        Me.PanelMail.BackColor = System.Drawing.Color.Transparent
        Me.PanelMail.Controls.Add(Me.PanelMailAdr)
        Me.PanelMail.Controls.Add(Me.PanelMailEmpfangenAmGesendetAm)
        Me.PanelMail.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelMail.Location = New System.Drawing.Point(3, 3)
        Me.PanelMail.Name = "PanelMail"
        Me.PanelMail.Size = New System.Drawing.Size(1116, 108)
        Me.PanelMail.TabIndex = 0
        '
        'PanelMailAdr
        '
        Me.PanelMailAdr.BackColor = System.Drawing.Color.Transparent
        Me.PanelMailAdr.Controls.Add(Me.EditorTmp1)
        Me.PanelMailAdr.Controls.Add(Me.btnSearchAn)
        Me.PanelMailAdr.Controls.Add(Me.txtMailCC)
        Me.PanelMailAdr.Controls.Add(Me.chkSendWithPostOfficeBoxForAll)
        Me.PanelMailAdr.Controls.Add(Me.lblAutoEMailBcc)
        Me.PanelMailAdr.Controls.Add(Me.lblAutoEMailCc)
        Me.PanelMailAdr.Controls.Add(Me.btnSendEMails)
        Me.PanelMailAdr.Controls.Add(Me.lblAutoEMailAn)
        Me.PanelMailAdr.Controls.Add(Me.btnBcc)
        Me.PanelMailAdr.Controls.Add(Me.btnSearchCc)
        Me.PanelMailAdr.Controls.Add(Me.txtMailBCC)
        Me.PanelMailAdr.Controls.Add(Me.txtMailAn)
        Me.PanelMailAdr.Location = New System.Drawing.Point(0, 21)
        Me.PanelMailAdr.Name = "PanelMailAdr"
        Me.PanelMailAdr.Size = New System.Drawing.Size(1077, 87)
        Me.PanelMailAdr.TabIndex = 2
        '
        'EditorTmp1
        '
        Me.EditorTmp1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.EditorTmp1.Location = New System.Drawing.Point(1099, 27)
        Me.EditorTmp1.Name = "EditorTmp1"
        Me.EditorTmp1.PageMargins.Bottom = 79.03R
        Me.EditorTmp1.PageMargins.Left = 79.03R
        Me.EditorTmp1.PageMargins.Right = 79.03R
        Me.EditorTmp1.PageMargins.Top = 79.03R
        Me.EditorTmp1.Size = New System.Drawing.Size(54, 41)
        Me.EditorTmp1.TabIndex = 426
        Me.EditorTmp1.TabStop = False
        Me.EditorTmp1.Text = "This Text Control is hidden at run time"
        '
        'btnSearchAn
        '
        Appearance35.ForeColor = System.Drawing.Color.Black
        Appearance35.ForeColorDisabled = System.Drawing.Color.Black
        Appearance35.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance35.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnSearchAn.Appearance = Appearance35
        Me.btnSearchAn.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchAn.Location = New System.Drawing.Point(65, 5)
        Me.btnSearchAn.Name = "btnSearchAn"
        Me.btnSearchAn.Size = New System.Drawing.Size(34, 19)
        Me.btnSearchAn.TabIndex = 1
        Me.btnSearchAn.Tag = "ResID.To3"
        Me.btnSearchAn.Text = "An"
        UltraToolTipInfo5.ToolTipText = "Suche Objekte"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnSearchAn, UltraToolTipInfo5)
        '
        'txtMailCC
        '
        Me.txtMailCC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance36.BackColor = System.Drawing.Color.White
        Appearance36.BackColor2 = System.Drawing.Color.White
        Appearance36.BackColorDisabled = System.Drawing.Color.White
        Appearance36.BackColorDisabled2 = System.Drawing.Color.White
        Appearance36.FontData.BoldAsString = "False"
        Appearance36.FontData.ItalicAsString = "False"
        Appearance36.FontData.Name = "Microsoft Sans Serif"
        Appearance36.FontData.SizeInPoints = 8.25!
        Appearance36.FontData.StrikeoutAsString = "False"
        Appearance36.FontData.UnderlineAsString = "False"
        Appearance36.ForeColor = System.Drawing.Color.Black
        Appearance36.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtMailCC.Appearance = Appearance36
        Me.txtMailCC.AutoSize = False
        Me.txtMailCC.BackColor = System.Drawing.Color.White
        Me.txtMailCC.Location = New System.Drawing.Point(105, 38)
        Me.txtMailCC.MaxLength = 0
        Me.txtMailCC.Multiline = True
        Me.txtMailCC.Name = "txtMailCC"
        Me.txtMailCC.Size = New System.Drawing.Size(575, 30)
        Me.txtMailCC.TabIndex = 4
        Me.txtMailCC.Tag = "Vorname"
        '
        'chkSendWithPostOfficeBoxForAll
        '
        Me.chkSendWithPostOfficeBoxForAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance37.BackColor = System.Drawing.Color.Transparent
        Appearance37.BackColorDisabled = System.Drawing.Color.Transparent
        Appearance37.ForeColor = System.Drawing.Color.Black
        Appearance37.ForeColorDisabled = System.Drawing.Color.Black
        Appearance37.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.chkSendWithPostOfficeBoxForAll.Appearance = Appearance37
        Me.chkSendWithPostOfficeBoxForAll.BackColor = System.Drawing.Color.Transparent
        Me.chkSendWithPostOfficeBoxForAll.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkSendWithPostOfficeBoxForAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkSendWithPostOfficeBoxForAll.Location = New System.Drawing.Point(8, 70)
        Me.chkSendWithPostOfficeBoxForAll.Name = "chkSendWithPostOfficeBoxForAll"
        Me.chkSendWithPostOfficeBoxForAll.Size = New System.Drawing.Size(274, 13)
        Me.chkSendWithPostOfficeBoxForAll.TabIndex = 425
        Me.chkSendWithPostOfficeBoxForAll.Tag = "ResID.SendWithPostOfficeBoxForAll"
        Me.chkSendWithPostOfficeBoxForAll.Text = "Allg. E-Mail-Adresse zum versenden verwenden"
        UltraToolTipInfo6.ToolTipTextFormatted = "Text unterhalb in Html oder als normalen Text darstellen"
        UltraToolTipInfo6.ToolTipTitle = "Html"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.chkSendWithPostOfficeBoxForAll, UltraToolTipInfo6)
        Me.chkSendWithPostOfficeBoxForAll.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.chkSendWithPostOfficeBoxForAll.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'lblAutoEMailBcc
        '
        Me.lblAutoEMailBcc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance38.BackColor = System.Drawing.Color.Transparent
        Appearance38.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance38.FontData.SizeInPoints = 7.0!
        Appearance38.ForeColor = System.Drawing.Color.RoyalBlue
        Appearance38.ForeColorDisabled = System.Drawing.Color.RoyalBlue
        Me.lblAutoEMailBcc.Appearance = Appearance38
        Me.lblAutoEMailBcc.AutoSize = True
        Appearance39.FontData.UnderlineAsString = "True"
        Me.lblAutoEMailBcc.HotTrackAppearance = Appearance39
        Me.lblAutoEMailBcc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAutoEMailBcc.Location = New System.Drawing.Point(694, 58)
        Me.lblAutoEMailBcc.Name = "lblAutoEMailBcc"
        Me.lblAutoEMailBcc.Size = New System.Drawing.Size(23, 12)
        Me.lblAutoEMailBcc.TabIndex = 9
        Me.lblAutoEMailBcc.Tag = "ResID.Auto"
        Me.lblAutoEMailBcc.Text = "Auto"
        UltraToolTipInfo7.ToolTipText = "E-Mails aller Objekte automatisch auflisten"
        UltraToolTipInfo7.ToolTipTitle = "E-Mails auflisten"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.lblAutoEMailBcc, UltraToolTipInfo7)
        Me.lblAutoEMailBcc.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'lblAutoEMailCc
        '
        Appearance40.BackColor = System.Drawing.Color.Transparent
        Appearance40.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance40.FontData.SizeInPoints = 7.0!
        Appearance40.ForeColor = System.Drawing.Color.RoyalBlue
        Appearance40.ForeColorDisabled = System.Drawing.Color.RoyalBlue
        Me.lblAutoEMailCc.Appearance = Appearance40
        Me.lblAutoEMailCc.AutoSize = True
        Appearance41.FontData.UnderlineAsString = "True"
        Me.lblAutoEMailCc.HotTrackAppearance = Appearance41
        Me.lblAutoEMailCc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAutoEMailCc.Location = New System.Drawing.Point(72, 56)
        Me.lblAutoEMailCc.Name = "lblAutoEMailCc"
        Me.lblAutoEMailCc.Size = New System.Drawing.Size(23, 12)
        Me.lblAutoEMailCc.TabIndex = 8
        Me.lblAutoEMailCc.Tag = "ResID.Auto"
        Me.lblAutoEMailCc.Text = "Auto"
        UltraToolTipInfo8.ToolTipText = "E-Mails aller Objekte automatisch auflisten"
        UltraToolTipInfo8.ToolTipTitle = "E-Mails auflisten"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.lblAutoEMailCc, UltraToolTipInfo8)
        Me.lblAutoEMailCc.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'btnSendEMails
        '
        Appearance42.ForeColor = System.Drawing.Color.Black
        Appearance42.ForeColorDisabled = System.Drawing.Color.Black
        Appearance42.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance42.ImageVAlign = Infragistics.Win.VAlign.Top
        Appearance42.TextHAlignAsString = "Center"
        Me.btnSendEMails.Appearance = Appearance42
        Me.btnSendEMails.Location = New System.Drawing.Point(8, 5)
        Me.btnSendEMails.Name = "btnSendEMails"
        Me.btnSendEMails.Size = New System.Drawing.Size(55, 56)
        Me.btnSendEMails.TabIndex = 0
        Me.btnSendEMails.Tag = "ResID.Send"
        Me.btnSendEMails.Text = "Senden"
        UltraToolTipInfo9.ToolTipText = "E-Mail versenden"
        UltraToolTipInfo9.ToolTipTitle = "Senden"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnSendEMails, UltraToolTipInfo9)
        '
        'lblAutoEMailAn
        '
        Appearance43.BackColor = System.Drawing.Color.Transparent
        Appearance43.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance43.FontData.SizeInPoints = 7.0!
        Appearance43.ForeColor = System.Drawing.Color.RoyalBlue
        Appearance43.ForeColorDisabled = System.Drawing.Color.RoyalBlue
        Me.lblAutoEMailAn.Appearance = Appearance43
        Me.lblAutoEMailAn.AutoSize = True
        Appearance44.FontData.UnderlineAsString = "True"
        Me.lblAutoEMailAn.HotTrackAppearance = Appearance44
        Me.lblAutoEMailAn.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAutoEMailAn.Location = New System.Drawing.Point(69, 22)
        Me.lblAutoEMailAn.Name = "lblAutoEMailAn"
        Me.lblAutoEMailAn.Size = New System.Drawing.Size(23, 12)
        Me.lblAutoEMailAn.TabIndex = 7
        Me.lblAutoEMailAn.Tag = "ResID.Auto"
        Me.lblAutoEMailAn.Text = "Auto"
        UltraToolTipInfo10.ToolTipText = "E-Mails aller Objekte automatisch auflisten"
        UltraToolTipInfo10.ToolTipTitle = "E-Mails auflisten"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.lblAutoEMailAn, UltraToolTipInfo10)
        Me.lblAutoEMailAn.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'btnBcc
        '
        Me.btnBcc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance45.ForeColor = System.Drawing.Color.Black
        Appearance45.ForeColorDisabled = System.Drawing.Color.Black
        Appearance45.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance45.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnBcc.Appearance = Appearance45
        Me.btnBcc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBcc.Location = New System.Drawing.Point(687, 39)
        Me.btnBcc.Name = "btnBcc"
        Me.btnBcc.Size = New System.Drawing.Size(34, 19)
        Me.btnBcc.TabIndex = 5
        Me.btnBcc.Tag = "ResID.Bcc"
        Me.btnBcc.Text = "Bcc"
        UltraToolTipInfo11.ToolTipText = "Suche Objekte"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnBcc, UltraToolTipInfo11)
        '
        'btnSearchCc
        '
        Appearance46.ForeColor = System.Drawing.Color.Black
        Appearance46.ForeColorDisabled = System.Drawing.Color.Black
        Appearance46.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance46.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnSearchCc.Appearance = Appearance46
        Me.btnSearchCc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchCc.Location = New System.Drawing.Point(65, 38)
        Me.btnSearchCc.Name = "btnSearchCc"
        Me.btnSearchCc.Size = New System.Drawing.Size(34, 19)
        Me.btnSearchCc.TabIndex = 3
        Me.btnSearchCc.Tag = "ResID.Cc"
        Me.btnSearchCc.Text = "Cc"
        UltraToolTipInfo12.ToolTipText = "Suche Objekte"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnSearchCc, UltraToolTipInfo12)
        '
        'txtMailBCC
        '
        Me.txtMailBCC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance47.BackColor = System.Drawing.Color.White
        Appearance47.BackColorDisabled = System.Drawing.Color.White
        Appearance47.FontData.BoldAsString = "False"
        Appearance47.FontData.ItalicAsString = "False"
        Appearance47.FontData.Name = "Microsoft Sans Serif"
        Appearance47.FontData.SizeInPoints = 8.25!
        Appearance47.FontData.StrikeoutAsString = "False"
        Appearance47.FontData.UnderlineAsString = "False"
        Appearance47.ForeColor = System.Drawing.Color.Black
        Appearance47.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtMailBCC.Appearance = Appearance47
        Me.txtMailBCC.AutoSize = False
        Me.txtMailBCC.BackColor = System.Drawing.Color.White
        Me.txtMailBCC.Location = New System.Drawing.Point(723, 38)
        Me.txtMailBCC.MaxLength = 0
        Me.txtMailBCC.Multiline = True
        Me.txtMailBCC.Name = "txtMailBCC"
        Me.txtMailBCC.Size = New System.Drawing.Size(281, 30)
        Me.txtMailBCC.TabIndex = 6
        Me.txtMailBCC.Tag = "Vorname"
        '
        'txtMailAn
        '
        Me.txtMailAn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance48.BackColor = System.Drawing.Color.White
        Appearance48.BackColorDisabled = System.Drawing.Color.White
        Appearance48.FontData.BoldAsString = "False"
        Appearance48.FontData.ItalicAsString = "False"
        Appearance48.FontData.Name = "Microsoft Sans Serif"
        Appearance48.FontData.SizeInPoints = 8.25!
        Appearance48.FontData.StrikeoutAsString = "False"
        Appearance48.FontData.UnderlineAsString = "False"
        Appearance48.ForeColor = System.Drawing.Color.Black
        Appearance48.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtMailAn.Appearance = Appearance48
        Me.txtMailAn.AutoSize = False
        Me.txtMailAn.BackColor = System.Drawing.Color.White
        Me.txtMailAn.Location = New System.Drawing.Point(105, 3)
        Me.txtMailAn.MaxLength = 0
        Me.txtMailAn.Multiline = True
        Me.txtMailAn.Name = "txtMailAn"
        Me.txtMailAn.Size = New System.Drawing.Size(899, 33)
        Me.txtMailAn.TabIndex = 2
        Me.txtMailAn.Tag = "Vorname"
        '
        'PanelMailEmpfangenAmGesendetAm
        '
        Me.PanelMailEmpfangenAmGesendetAm.BackColor = System.Drawing.Color.Transparent
        Me.PanelMailEmpfangenAmGesendetAm.Controls.Add(Me.labelVon)
        Me.PanelMailEmpfangenAmGesendetAm.Controls.Add(Me.lblMailVon)
        Me.PanelMailEmpfangenAmGesendetAm.Controls.Add(Me.lblEmpfangenAmGesendetAm)
        Me.PanelMailEmpfangenAmGesendetAm.Controls.Add(Me.labelEmpfangenGesendet)
        Me.PanelMailEmpfangenAmGesendetAm.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelMailEmpfangenAmGesendetAm.Location = New System.Drawing.Point(0, 0)
        Me.PanelMailEmpfangenAmGesendetAm.Name = "PanelMailEmpfangenAmGesendetAm"
        Me.PanelMailEmpfangenAmGesendetAm.Size = New System.Drawing.Size(1116, 21)
        Me.PanelMailEmpfangenAmGesendetAm.TabIndex = 1
        '
        'labelVon
        '
        Appearance49.BackColor = System.Drawing.Color.Transparent
        Appearance49.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance49.FontData.SizeInPoints = 8.0!
        Appearance49.ForeColor = System.Drawing.Color.RoyalBlue
        Appearance49.ForeColorDisabled = System.Drawing.Color.RoyalBlue
        Me.labelVon.Appearance = Appearance49
        Me.labelVon.AutoSize = True
        Appearance50.FontData.UnderlineAsString = "True"
        Me.labelVon.HotTrackAppearance = Appearance50
        Me.labelVon.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.labelVon.Location = New System.Drawing.Point(72, 4)
        Me.labelVon.Name = "labelVon"
        Me.labelVon.Size = New System.Drawing.Size(27, 14)
        Me.labelVon.TabIndex = 385
        Me.labelVon.Tag = "ResID.From"
        Me.labelVon.Text = "Von:"
        UltraToolTipInfo13.ToolTipText = "Objekt zur E-Mail-Adresse öffnen"
        UltraToolTipInfo13.ToolTipTitle = "Objekt öffnen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.labelVon, UltraToolTipInfo13)
        Me.labelVon.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'lblMailVon
        '
        Me.lblMailVon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance51.BackColor = System.Drawing.Color.Transparent
        Appearance51.ForeColor = System.Drawing.Color.Black
        Appearance51.ForeColorDisabled = System.Drawing.Color.Black
        Appearance51.TextVAlignAsString = "Middle"
        Me.lblMailVon.Appearance = Appearance51
        Me.lblMailVon.Location = New System.Drawing.Point(105, 2)
        Me.lblMailVon.Name = "lblMailVon"
        Me.lblMailVon.Size = New System.Drawing.Size(732, 17)
        Me.lblMailVon.TabIndex = 382
        Me.lblMailVon.Text = "hannes.le@s2-engineering.com"
        '
        'lblEmpfangenAmGesendetAm
        '
        Me.lblEmpfangenAmGesendetAm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance52.BackColor = System.Drawing.Color.Transparent
        Appearance52.ForeColorDisabled = System.Drawing.Color.Black
        Appearance52.TextVAlignAsString = "Middle"
        Me.lblEmpfangenAmGesendetAm.Appearance = Appearance52
        Me.lblEmpfangenAmGesendetAm.Location = New System.Drawing.Point(937, 3)
        Me.lblEmpfangenAmGesendetAm.Name = "lblEmpfangenAmGesendetAm"
        Me.lblEmpfangenAmGesendetAm.Size = New System.Drawing.Size(171, 17)
        Me.lblEmpfangenAmGesendetAm.TabIndex = 384
        Me.lblEmpfangenAmGesendetAm.Text = "2011-03-02 12:34:04"
        '
        'labelEmpfangenGesendet
        '
        Me.labelEmpfangenGesendet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance53.BackColor = System.Drawing.Color.Transparent
        Appearance53.ForeColor = System.Drawing.Color.Black
        Appearance53.ForeColorDisabled = System.Drawing.Color.Black
        Appearance53.TextHAlignAsString = "Right"
        Appearance53.TextVAlignAsString = "Middle"
        Me.labelEmpfangenGesendet.Appearance = Appearance53
        Me.labelEmpfangenGesendet.Location = New System.Drawing.Point(845, 3)
        Me.labelEmpfangenGesendet.Name = "labelEmpfangenGesendet"
        Me.labelEmpfangenGesendet.Size = New System.Drawing.Size(91, 17)
        Me.labelEmpfangenGesendet.TabIndex = 383
        Me.labelEmpfangenGesendet.Text = "Empfangen am:"
        '
        'dropDownCategories
        '
        Me.dropDownCategories.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.dropDownCategories.Location = New System.Drawing.Point(234, 5)
        Me.dropDownCategories.Name = "dropDownCategories"
        Me.dropDownCategories.Size = New System.Drawing.Size(107, 25)
        Me.dropDownCategories.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.dropDownCategories.TabIndex = 484
        Me.dropDownCategories.Tag = "ResID.Categories"
        Me.dropDownCategories.Text = "Kategorien"
        '
        'ContextMenuStripStatBar
        '
        Me.ContextMenuStripStatBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditierenToolStripMenuItem, Me.PlanungsenträgeDieZuDiesemEintragGehörenToolStripMenuItem, Me.PlanungseintragAusGesendeterListeLöschenToolStripMenuItem})
        Me.ContextMenuStripStatBar.Name = "ContextMenuStripStatBar"
        Me.ContextMenuStripStatBar.Size = New System.Drawing.Size(329, 70)
        '
        'EditierenToolStripMenuItem
        '
        Me.EditierenToolStripMenuItem.CheckOnClick = True
        Me.EditierenToolStripMenuItem.Name = "EditierenToolStripMenuItem"
        Me.EditierenToolStripMenuItem.Size = New System.Drawing.Size(328, 22)
        Me.EditierenToolStripMenuItem.Tag = "ResID.Edit"
        Me.EditierenToolStripMenuItem.Text = "Editieren"
        '
        'PlanungsenträgeDieZuDiesemEintragGehörenToolStripMenuItem
        '
        Me.PlanungsenträgeDieZuDiesemEintragGehörenToolStripMenuItem.Name = "PlanungsenträgeDieZuDiesemEintragGehörenToolStripMenuItem"
        Me.PlanungsenträgeDieZuDiesemEintragGehörenToolStripMenuItem.Size = New System.Drawing.Size(328, 22)
        Me.PlanungsenträgeDieZuDiesemEintragGehörenToolStripMenuItem.Tag = "ResID.PlansBelongsToThisPlan"
        Me.PlanungsenträgeDieZuDiesemEintragGehörenToolStripMenuItem.Text = "Planungsenträge, die zu diesem Eintrag gehören"
        '
        'PlanungseintragAusGesendeterListeLöschenToolStripMenuItem
        '
        Me.PlanungseintragAusGesendeterListeLöschenToolStripMenuItem.Name = "PlanungseintragAusGesendeterListeLöschenToolStripMenuItem"
        Me.PlanungseintragAusGesendeterListeLöschenToolStripMenuItem.Size = New System.Drawing.Size(328, 22)
        Me.PlanungseintragAusGesendeterListeLöschenToolStripMenuItem.Tag = "ResID.ClearItemFromSentList"
        Me.PlanungseintragAusGesendeterListeLöschenToolStripMenuItem.Text = "Planungseintrag aus gesendeter Liste löschen"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'UltraToolTipManager1
        '
        Me.UltraToolTipManager1.AutoPopDelay = 0
        Me.UltraToolTipManager1.ContainingControl = Me
        Me.UltraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.BalloonTip
        Me.UltraToolTipManager1.InitialDelay = 0
        '
        'dropDownPatienten
        '
        Appearance2.BorderColor = System.Drawing.Color.Black
        Me.dropDownPatienten.Appearance = Appearance2
        Me.dropDownPatienten.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.dropDownPatienten.Location = New System.Drawing.Point(14, 5)
        Me.dropDownPatienten.Name = "dropDownPatienten"
        Me.dropDownPatienten.Size = New System.Drawing.Size(107, 25)
        Me.dropDownPatienten.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.dropDownPatienten.TabIndex = 499
        Me.dropDownPatienten.Tag = "ResID.Patienten"
        Me.dropDownPatienten.Text = "Patienten"
        '
        'dropDownUsers
        '
        Appearance3.BorderColor = System.Drawing.Color.Black
        Me.dropDownUsers.Appearance = Appearance3
        Me.dropDownUsers.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.dropDownUsers.Location = New System.Drawing.Point(124, 5)
        Me.dropDownUsers.Name = "dropDownUsers"
        Me.dropDownUsers.Size = New System.Drawing.Size(107, 25)
        Me.dropDownUsers.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.dropDownUsers.TabIndex = 498
        Me.dropDownUsers.Tag = "ResID.Benutzer"
        Me.dropDownUsers.Text = "Benutzer"
        '
        'PanelBottom
        '
        Me.PanelBottom.BackColor = System.Drawing.Color.Transparent
        Me.PanelBottom.Controls.Add(Me.btnAbort)
        Me.PanelBottom.Controls.Add(Me.btnSave)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 695)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(1122, 38)
        Me.PanelBottom.TabIndex = 100
        '
        'btnAbort
        '
        Appearance5.ForeColor = System.Drawing.Color.Black
        Appearance5.ForeColorDisabled = System.Drawing.Color.Black
        Me.btnAbort.Appearance = Appearance5
        Me.btnAbort.Location = New System.Drawing.Point(556, 3)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(84, 31)
        Me.btnAbort.TabIndex = 101
        Me.btnAbort.Tag = "ResID.Abort"
        Me.btnAbort.Text = "Abbrechen"
        '
        'btnSave
        '
        Appearance6.ForeColor = System.Drawing.Color.Black
        Appearance6.ForeColorDisabled = System.Drawing.Color.Black
        Me.btnSave.Appearance = Appearance6
        Me.btnSave.Location = New System.Drawing.Point(469, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 31)
        Me.btnSave.TabIndex = 100
        Me.btnSave.Tag = "ResID.Save"
        Me.btnSave.Text = "Speichern"
        '
        'toolbarsManagerMain
        '
        Me.toolbarsManagerMain.DesignerFlags = 1
        Me.toolbarsManagerMain.DockWithinContainer = Me.PanelToolbar
        Me.toolbarsManagerMain.LockToolbars = True
        Me.toolbarsManagerMain.Office2007UICompatibility = False
        RibbonTab1.Caption = "Nachricht"
        RibbonGroup1.Caption = "Aktion"
        ButtonTool18.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        RibbonGroup1.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool18})
        RibbonGroup2.Caption = "Teilnehmer"
        RibbonGroup3.Caption = "Anhang"
        ButtonTool23.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        PopupControlContainerTool2.InstanceProps.PreferredSizeOnRibbon = Infragistics.Win.UltraWinToolbars.RibbonToolSize.Large
        RibbonGroup3.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool23, PopupControlContainerTool2})
        RibbonTab1.Groups.AddRange(New Infragistics.Win.UltraWinToolbars.RibbonGroup() {RibbonGroup1, RibbonGroup2, RibbonGroup3})
        Me.toolbarsManagerMain.Ribbon.NonInheritedRibbonTabs.AddRange(New Infragistics.Win.UltraWinToolbars.RibbonTab() {RibbonTab1})
        Me.toolbarsManagerMain.ShowFullMenusDelay = 500
        Me.toolbarsManagerMain.ShowQuickCustomizeButton = False
        Me.toolbarsManagerMain.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.OfficeXP
        UltraToolbar2.DockedColumn = 0
        UltraToolbar2.DockedRow = 0
        ButtonTool4.InstanceProps.IsFirstInGroup = True
        ButtonTool16.InstanceProps.IsFirstInGroup = True
        ButtonTool24.InstanceProps.IsFirstInGroup = True
        UltraToolbar2.NonInheritedTools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool4, ButtonTool16, ButtonTool19, ButtonTool25, ButtonTool24, PopupControlContainerTool3, PopupControlContainerTool7})
        UltraToolbar2.Text = "Aufgabe, Termin neu ..."
        Me.toolbarsManagerMain.Toolbars.AddRange(New Infragistics.Win.UltraWinToolbars.UltraToolbar() {UltraToolbar2})
        Appearance4.Cursor = System.Windows.Forms.Cursors.Default
        ButtonTool8.SharedPropsInternal.AppearancesSmall.HotTrackAppearance = Appearance4
        ButtonTool8.SharedPropsInternal.Caption = "Löschen"
        ButtonTool8.SharedPropsInternal.CustomizerCaption = "Löschen"
        ButtonTool8.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageOnlyOnToolbars
        ButtonTool8.Tag = "ResID.Delete"
        ButtonTool22.SharedPropsInternal.Caption = "Datei hinzufügen"
        ButtonTool22.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        ButtonTool22.SharedPropsInternal.ToolTipText = "Datei als Anhang hinzufügen"
        ButtonTool22.Tag = "ResID.AddFile"
        PopupControlContainerTool1.SharedPropsInternal.Caption = "Anhang"
        PopupControlContainerTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        PopupControlContainerTool1.Tag = "ResID.Appendix"
        ButtonTool2.SharedPropsInternal.Caption = "Weiterleiten"
        ButtonTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        ButtonTool2.Tag = "ResID.PassOn"
        ButtonTool7.SharedPropsInternal.Caption = "Antworten"
        ButtonTool7.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        ButtonTool7.Tag = "ResID.Reply"
        ButtonTool14.SharedPropsInternal.Caption = "Allen Antworten"
        ButtonTool14.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageOnlyOnToolbars
        ButtonTool14.Tag = "ResID.ReplyAll"
        PopupControlContainerTool6.SharedPropsInternal.Caption = "Textvorlagen"
        PopupControlContainerTool6.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText
        PopupControlContainerTool6.Tag = "ResID.TextTemplates"
        Me.toolbarsManagerMain.Tools.AddRange(New Infragistics.Win.UltraWinToolbars.ToolBase() {ButtonTool8, ButtonTool22, PopupControlContainerTool1, ButtonTool2, ButtonTool7, ButtonTool14, PopupControlContainerTool6})
        '
        'PanelToolbar
        '
        Me.PanelToolbar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelToolbar.BackColor = System.Drawing.Color.Transparent
        Me.PanelToolbar.Controls.Add(Me.PanelToolbar_Fill_Panel)
        Me.PanelToolbar.Controls.Add(Me._PanelToolbar_Toolbars_Dock_Area_Left)
        Me.PanelToolbar.Controls.Add(Me._PanelToolbar_Toolbars_Dock_Area_Right)
        Me.PanelToolbar.Controls.Add(Me._PanelToolbar_Toolbars_Dock_Area_Bottom)
        Me.PanelToolbar.Controls.Add(Me._PanelToolbar_Toolbars_Dock_Area_Top)
        Me.PanelToolbar.Location = New System.Drawing.Point(556, 4)
        Me.PanelToolbar.Name = "PanelToolbar"
        Me.PanelToolbar.Size = New System.Drawing.Size(562, 30)
        Me.PanelToolbar.TabIndex = 0
        '
        'PanelToolbar_Fill_Panel
        '
        Me.PanelToolbar_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default
        Me.PanelToolbar_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelToolbar_Fill_Panel.Location = New System.Drawing.Point(0, 27)
        Me.PanelToolbar_Fill_Panel.Name = "PanelToolbar_Fill_Panel"
        Me.PanelToolbar_Fill_Panel.Size = New System.Drawing.Size(562, 3)
        Me.PanelToolbar_Fill_Panel.TabIndex = 0
        '
        '_PanelToolbar_Toolbars_Dock_Area_Left
        '
        Me._PanelToolbar_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelToolbar_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.Transparent
        Me._PanelToolbar_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left
        Me._PanelToolbar_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelToolbar_Toolbars_Dock_Area_Left.Location = New System.Drawing.Point(0, 27)
        Me._PanelToolbar_Toolbars_Dock_Area_Left.Name = "_PanelToolbar_Toolbars_Dock_Area_Left"
        Me._PanelToolbar_Toolbars_Dock_Area_Left.Size = New System.Drawing.Size(0, 3)
        Me._PanelToolbar_Toolbars_Dock_Area_Left.ToolbarsManager = Me.toolbarsManagerMain
        '
        '_PanelToolbar_Toolbars_Dock_Area_Right
        '
        Me._PanelToolbar_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelToolbar_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.Transparent
        Me._PanelToolbar_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right
        Me._PanelToolbar_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelToolbar_Toolbars_Dock_Area_Right.Location = New System.Drawing.Point(562, 27)
        Me._PanelToolbar_Toolbars_Dock_Area_Right.Name = "_PanelToolbar_Toolbars_Dock_Area_Right"
        Me._PanelToolbar_Toolbars_Dock_Area_Right.Size = New System.Drawing.Size(0, 3)
        Me._PanelToolbar_Toolbars_Dock_Area_Right.ToolbarsManager = Me.toolbarsManagerMain
        '
        '_PanelToolbar_Toolbars_Dock_Area_Bottom
        '
        Me._PanelToolbar_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelToolbar_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.Transparent
        Me._PanelToolbar_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom
        Me._PanelToolbar_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelToolbar_Toolbars_Dock_Area_Bottom.Location = New System.Drawing.Point(0, 30)
        Me._PanelToolbar_Toolbars_Dock_Area_Bottom.Name = "_PanelToolbar_Toolbars_Dock_Area_Bottom"
        Me._PanelToolbar_Toolbars_Dock_Area_Bottom.Size = New System.Drawing.Size(562, 0)
        Me._PanelToolbar_Toolbars_Dock_Area_Bottom.ToolbarsManager = Me.toolbarsManagerMain
        '
        '_PanelToolbar_Toolbars_Dock_Area_Top
        '
        Me._PanelToolbar_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping
        Me._PanelToolbar_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.Transparent
        Me._PanelToolbar_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top
        Me._PanelToolbar_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText
        Me._PanelToolbar_Toolbars_Dock_Area_Top.Location = New System.Drawing.Point(0, 0)
        Me._PanelToolbar_Toolbars_Dock_Area_Top.Name = "_PanelToolbar_Toolbars_Dock_Area_Top"
        Me._PanelToolbar_Toolbars_Dock_Area_Top.Size = New System.Drawing.Size(562, 27)
        Me._PanelToolbar_Toolbars_Dock_Area_Top.ToolbarsManager = Me.toolbarsManagerMain
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.Transparent
        Me.PanelTop.Controls.Add(Me.dropDownPatienten)
        Me.PanelTop.Controls.Add(Me.dropDownUsers)
        Me.PanelTop.Controls.Add(Me.PanelToolbar)
        Me.PanelTop.Controls.Add(Me.dropDownCategories)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1122, 33)
        Me.PanelTop.TabIndex = 5
        '
        'PanelAll2
        '
        Me.PanelAll2.BackColor = System.Drawing.Color.Transparent
        Me.PanelAll2.Controls.Add(Me.PanelMitte)
        Me.PanelAll2.Controls.Add(Me.grpTop)
        Me.PanelAll2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelAll2.Location = New System.Drawing.Point(0, 33)
        Me.PanelAll2.Name = "PanelAll2"
        Me.PanelAll2.Size = New System.Drawing.Size(1122, 662)
        Me.PanelAll2.TabIndex = 6
        '
        'frmNachricht2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1122, 733)
        Me.Controls.Add(Me.PanelAll2)
        Me.Controls.Add(Me.PanelTop)
        Me.Controls.Add(Me.PanelBottom)
        Me.DoubleBuffered = True
        Me.MinimumSize = New System.Drawing.Size(1022, 600)
        Me.Name = "frmNachricht2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planungseintrag"
        Me.UltraTabPageControl2.ResumeLayout(False)
        Me.UltraTabPageControl1.ResumeLayout(False)
        Me.PanelTxtEditor.ResumeLayout(False)
        Me.winFormHtmlEditor1.ResumeLayout(False)
        Me.winFormHtmlEditor1.PerformLayout()
        Me.PanelMitte.ResumeLayout(False)
        Me.PanelBody.ResumeLayout(False)
        Me.PanelText.ResumeLayout(False)
        Me.PanelText_Fill_Panel.ResumeLayout(False)
        CType(Me.UltraTabControlText, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UltraTabControlText.ResumeLayout(False)
        CType(Me.toolbarsManagerText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpTop.ResumeLayout(False)
        Me.PanelDatum.ResumeLayout(False)
        Me.PanelDatum.PerformLayout()
        CType(Me.chkIsSerientermin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDauer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpSerientermin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSerientermin.ResumeLayout(False)
        Me.grpSerientermin.PerformLayout()
        CType(Me.dteSerienterminEndetAm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpWochentage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpWochentage.ResumeLayout(False)
        CType(Me.cbSo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbFr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbMi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbDi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbMo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.opTagWochenMonat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.optSerienterminType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkGanzerTag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteEndetAm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpStatus.ResumeLayout(False)
        CType(Me.optStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteBeginntAm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPriorität, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTextIsHtml, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBetreff.ResumeLayout(False)
        CType(Me.txtBetreff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMail.ResumeLayout(False)
        Me.PanelMailAdr.ResumeLayout(False)
        Me.PanelMailAdr.PerformLayout()
        CType(Me.txtMailCC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSendWithPostOfficeBoxForAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMailBCC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMailAn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMailEmpfangenAmGesendetAm.ResumeLayout(False)
        Me.PanelMailEmpfangenAmGesendetAm.PerformLayout()
        Me.ContextMenuStripStatBar.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBottom.ResumeLayout(False)
        CType(Me.toolbarsManagerMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelToolbar.ResumeLayout(False)
        Me.PanelToolbar_Fill_Panel.ResumeLayout(False)
        Me.PanelTop.ResumeLayout(False)
        Me.PanelAll2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Sub loadForm()
        Try
            If Me.isLoaded Then Exit Sub

            Me.standardViewExtEditor = TXTextControl.ViewMode.PageView

            Me.UltraTabControlText.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard

            Me.loadRes()
            Me.contListeAnhang.initControl()
            Me.typAntworten = eAntworten.None

            'Me.btnTeilnehmer.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_persons, 32, 32)
            'Me.btnSendAnswer.Appearance.Image = ITSCont.core.SystemDb.getRes.getImage(core.SystemDb.getRes.ePicture.ico_send, core.SystemDb.getRes.ePicTyp.ico)

            Dim MaxIDSelListEntryReturn As Integer = -1
            Dim tSelListEntriesReturn As System.Collections.Generic.List(Of PMDS.db.Entities.tblSelListEntries) = Nothing
            MaxIDSelListEntryReturn = -1
            tSelListEntriesReturn = Nothing

            Me.contSelectPatienten.initControl(contSelectPatientenBenutzer.eTypeUI.Patients, False, False)
            Me.contSelectBenutzer.initControl(contSelectPatientenBenutzer.eTypeUI.Users, False, False)

            Me.contListeAnhang.modalWindow = Me
            Dim popContAnhang As PopupControlContainerTool
            popContAnhang = Me.toolbarsManagerMain.Toolbars(0).Tools("popUpContListeAnhang")
            popContAnhang.Control = Me.contListeAnhang
            popContAnhang.DropDownArrowStyle = DropDownArrowStyle.Standard

            Me.contListTextTemplates1.mainWindow = Me
            Me.contListTextTemplates1.initControl()
            Dim popUpContUpTextTemplates As PopupControlContainerTool
            popContAnhang = Me.toolbarsManagerMain.Toolbars(0).Tools("popUpContUpTextTemplates")
            popContAnhang.Control = Me.contListTextTemplates1
            popContAnhang.DropDownArrowStyle = DropDownArrowStyle.Standard

            'Me.clObjects.loadAuswahlliste(Nothing, Me.cboArt, "PT", dsAuswahListSelLists, "", "", core.SystemDb.Enums.eKeyCol.IDNr)
            MaxIDSelListEntryReturn = -1
            tSelListEntriesReturn = Nothing
            Me.genMain.loadSelList(Nothing, Me.cboPriorität, "PRT", tSelListEntriesReturn, General.eKeyCol.Description, MaxIDSelListEntryReturn)

            MaxIDSelListEntryReturn = -1
            tSelListEntriesReturn = Nothing

            Me.contSelectBenutzer.MainNachricht = Me
            Me.uPopUpContBenutzer.PopupControl = Me.contSelectBenutzer
            Me.dropDownUsers.PopupItem = Me.uPopUpContBenutzer
            Me.contSelectBenutzer.popupContMainSearch = Me.uPopUpContBenutzer

            Me.contSelectPatienten.MainNachricht = Me
            Me.uPopUpContPatienten.PopupControl = Me.contSelectPatienten
            Me.dropDownPatienten.PopupItem = Me.uPopUpContPatienten
            Me.contSelectPatienten.popupContMainSearch = Me.uPopUpContPatienten

            Me.contSelectSelListCategories.MainMessage = Me
            Me.contSelectSelListCategories.initControl("PlanCategory", False)
            Me.uPopupContCategories.PopupControl = Me.contSelectSelListCategories
            Me.dropDownCategories.PopupItem = Me.uPopupContCategories
            Me.contSelectSelListCategories.popupContMainSearch = Me.uPopupContCategories

            Me.loadCboDauer()

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.AcceptButton = Me.btnSave
            Me.CancelButton = Me.btnAbort

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("frmNachricht2.loadForm: " + ex.ToString())
        Finally
            Me.txtBetreff.Focus()
        End Try
    End Sub

    Public Sub loadRes()
        Try
            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein2.ico_Message, 32, 32)
            Me.toolbarsManagerMain.Ribbon.ApplicationMenuButtonImage = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein2.ico_Message, 32, 32)

            Me.btnSendEMails.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_send, 32, 32)
            Me.btnSendPlan.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_send, 32, 32)

            Me.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32)
            Me.toolbarsManagerMain.Tools("Löschen").SharedProps.AppearancesSmall.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)
            Me.toolbarsManagerMain.Tools("DateiHinzufügen").SharedProps.AppearancesSmall.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Plus, 32, 32)
            Me.toolbarsManagerMain.Tools("btnAntworten").SharedProps.AppearancesSmall.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_antworten, 32, 32)
            Me.toolbarsManagerMain.Tools("btnAllenAntworten").SharedProps.AppearancesSmall.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_antworten, 32, 32)
            Me.toolbarsManagerMain.Tools("btnWeiterleiten").SharedProps.AppearancesSmall.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_antworten, 32, 32)

            Dim IsAdmin As Boolean = False
            If IsAdmin Then
                Me.toolbarsManagerMain.Toolbars(0).Tools("Löschen").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.True
            Else
                Me.toolbarsManagerMain.Toolbars(0).Tools("Löschen").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.True
            End If

            'If Not ITSCont.core.SystemDb.actUsr.rUsr.IsAdmin And Not ENV.adminSecure Then
            '    Me.EditierenToolStripMenuItem.Visible = True
            'End If

            Me.txtBetreff.Focus()

        Catch ex As Exception
            Throw New Exception("frmNachricht.loadRes: " + ex.ToString())
        Finally
            Me.txtBetreff.Focus()
        End Try
    End Sub

    Public Sub loadCboDauer()
        Try
            Me.cboDauer.Clear()

            Me.cboDauer.Items.Add(15, doUI.getRes("15Minutes"))
            Me.cboDauer.Items.Add(30, doUI.getRes("30Minutes"))
            Me.cboDauer.Items.Add(45, doUI.getRes("45Minutes"))
            Me.cboDauer.Items.Add(60, doUI.getRes("1Hour"))
            Me.cboDauer.Items.Add(90, doUI.getRes("11/2Hour"))
            Me.cboDauer.Items.Add(120, doUI.getRes("2Hour"))
            Me.cboDauer.Items.Add(150, doUI.getRes("21/2Hour"))
            Me.cboDauer.Items.Add(180, doUI.getRes("3Hour"))
            Me.cboDauer.Items.Add(240, doUI.getRes("4Hour"))
            Me.cboDauer.Items.Add(300, doUI.getRes("5Hour"))
            Me.cboDauer.Items.Add(360, doUI.getRes("6Hour"))
            Me.cboDauer.Items.Add(420, doUI.getRes("7Hour"))
            Me.cboDauer.Items.Add(480, doUI.getRes("8Hour"))
            Me.cboDauer.Items.Add(540, doUI.getRes("9Hour"))
            Me.cboDauer.Items.Add(600, doUI.getRes("10Hour"))
            Me.cboDauer.Items.Add(660, doUI.getRes("11Hour"))
            Me.cboDauer.Items.Add(720, doUI.getRes("12Hour"))

        Catch ex As Exception
            Throw New Exception("frmNachricht.loadCboDauer: " + ex.ToString())
        End Try
    End Sub


    Public Sub setWebBrowser(ByRef text As String)
        Try
            'Dim cArchiv1 As New cArchiv()
            'Dim file As String = cArchiv1.getFilename(ITSCont.core.base.funct.path_temp, "mail", ".html", 0, False)
            'System.IO.File.WriteAllText(file, text)

            Me.PanelBrowser.Controls.Clear()

            Me.ElementHost.Child = IExplorer1
            Me.ElementHost.Dock = DockStyle.Fill
            Me.PanelBrowser.Controls.Add(Me.ElementHost)

            Me.IExplorer1.NavigateToStr(text)

        Catch ex As Exception
            Throw New Exception("frmNachricht.setWebBrowser: " + ex.ToString())
        End Try
    End Sub

    Private Sub AufgabeTerminNeu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor
            'If Not Me.InSharedMemory Then
            '    Me.doLoad()
            'End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UltraToolbarsManager_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles toolbarsManagerMain.ToolClick
        Try
            If Me.lockToolbar Then Exit Sub
            Me.Cursor = Cursors.WaitCursor

            Select Case e.Tool.Key
                Case "Löschen"
                    If doUI.doMessageBox3("DoYouRealyWantToDeleteTheEntry", "", MsgBoxStyle.YesNo, "?") = MsgBoxResult.Yes Then
                        Dim cOutlookWebAPI1 As New cOutlookWebAPI()
                        cOutlookWebAPI1.deleteOutlookItem(Me.rPlan.ID, Me.rPlan.SendWithPostOfficeBoxForAll)
                        Me.compPlan1.deletePlan(rPlan.ID, rPlan.MessageId, rPlan.Für, Me.rPlan.IDArt, Me.rPlan.Betreff)
                        Me.abort = False
                        Me.Close()
                    End If

                Case "DateiHinzufügen"
                    Me.contListeAnhang.anhangHinzufügen(rPlan.ID)

                Case "btnAntworten"
                    Me.antworten(eAntworten.antworten)

                Case "btnAllenAntworten"
                    Me.antworten(eAntworten.alleAntworten)

                Case "btnWeiterleiten"
                    Me.antworten(eAntworten.weiterleiten)

            End Select

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub AufgabeTerminNeu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me.PanelBrowser.Controls.Clear()
            If Me.InSharedMemory Then
                If General.InitHTMLEditorEveryClick Then
                    contPlanungData.reloadHTMLControl(Me.PanelTxtEditor, Me.winFormHtmlEditor1)
                Else
                    contPlanungData.ClearHTMLBrowser(Me.winFormHtmlEditor1)
                End If
                Me.Visible = False
                Me.isOpend = False
                e.Cancel = True
            Else

            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub AufgabeTerminNeu_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        End Try
    End Sub

#Region "Funktion"

    Public Function clear() As Boolean
        Try
            Me.lblMailVon.Text = ""
            Me.lblEmpfangenAmGesendetAm.Text = ""

            Me.setToolBarBody(False)

            Me.txtBetreff.Text = ""
            Me.dteBeginntAm.Value = Nothing
            Me.chkGanzerTag.Checked = False
            Me.dteEndetAm.Value = Nothing
            Me.cboDauer.Value = Nothing
            Me.setUIEndetAm(False)
            Me.setUISerientermine("", "")

            Dim UserLoggedIn As String = Me.genMain.getLoggedInUser()
            Me.setErstelltVon(UserLoggedIn.Trim(), Now)
            Me.frmStatus = General.eStatusForm.neu
            'Me.clearWebBrowser()

            Me.optStatus.CheckedIndex = 0

            Me.txtMailAn.Text = ""
            Me.txtMailCC.Text = ""
            Me.chkTextIsHtml.Checked = True
            Me.chkSendWithPostOfficeBoxForAll.Checked = False
            Me.contSelectSelListCategories.setSelectionOnOff(False)
            Me.LastTextBody = ""

            Me.lblErstelltVon.Text = ""
            Me.lblErstelltAm.Text = ""
            Me.setInfoGeneral(Nothing, True)

            Me.EditierenToolStripMenuItem.Checked = False

            Me.clearSerientermineUI()

        Catch ex As Exception
            Throw New Exception("frmNachricht.clear: " + ex.ToString())
        End Try
    End Function
    Public Sub clearSerientermineUI()
        Try
            Me.chkIsSerientermin.Checked = False
            Me.dteSerienterminEndetAm.Value = Nothing
            Me.grpSerientermin.Visible = False

            Me.optSerienterminType.CheckedIndex = 0
            Me.iWiedWertJeden.Value = Nothing
            Me.opTagWochenMonat.CheckedIndex = 0
            Me.iNTenMonat.Value = Nothing

            Me.cbMo.Checked = False
            Me.cbDi.Checked = False
            Me.cbMi.Checked = False
            Me.cbDo.Checked = False
            Me.cbFr.Checked = False
            Me.cbSa.Checked = False
            Me.cbSo.Checked = False

        Catch ex As Exception
            Throw New Exception("frmNachricht.clearSerientermineUI: " + ex.ToString())
        End Try
    End Sub
    Public Sub setUISerientermine(SerienterminType As String, TagWochenMonat As String)
        Try
            If SerienterminType.Trim() <> "" Then
                Dim iSerienterminType As Integer = System.Convert.ToInt32(SerienterminType.Trim())
                If iSerienterminType = 1 Then
                    Me.iWiedWertJeden.Enabled = False
                    Me.opTagWochenMonat.Enabled = False
                    Me.iNTenMonat.Enabled = False
                    Me.grpWochentage.Enabled = True

                ElseIf iSerienterminType = 2 Then
                    Me.iWiedWertJeden.Enabled = True
                    Me.opTagWochenMonat.Enabled = True
                    Me.iNTenMonat.Enabled = False
                    Me.grpWochentage.Enabled = False

                    If TagWochenMonat.Trim() <> "" Then
                        Dim iTagWochenMonat As Integer = System.Convert.ToInt32(TagWochenMonat.Trim())
                        If iTagWochenMonat = 1 Then
                            Me.grpWochentage.Enabled = True
                        Else
                            Me.grpWochentage.Enabled = False
                        End If
                    Else
                        Me.grpWochentage.Enabled = False
                    End If

                ElseIf iSerienterminType = 3 Then
                    Me.iWiedWertJeden.Enabled = False
                    Me.opTagWochenMonat.Enabled = False
                    Me.iNTenMonat.Enabled = True
                    Me.grpWochentage.Enabled = False

                End If
            Else
                Me.iWiedWertJeden.Enabled = False
                Me.opTagWochenMonat.Enabled = False
                Me.iNTenMonat.Enabled = False
                Me.grpWochentage.Enabled = False
            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht2.setUISerientermine: " + ex.ToString())
        End Try
    End Sub

    Public Function Init(ByVal Exch As General.exchPlan, IDArtNewPlan As Integer) As Boolean
        Try
            If Me.tPlanObjectsAllCopy Is Nothing Then
                Throw New Exception("frmNachricht.Init: tPlanObjects is null!")
            End If

            Dim guid As System.Guid
            Me.Cursor = Cursors.WaitCursor
            Me.clear()
            Me.typAntworten = eAntworten.None
            If Exch.app = General.InitApplicationAufgabenTermine.nachrichtAnzeigen Then
                Me.frmStatus = General.eStatusForm.edit

                Me.dsPlan1 = New dsPlan()
                Me.compPlan1 = New compPlan()
                Me.compPlan1.getPlan(General.StrToGuid(Exch.str), compPlan.eTypSelPlan.id, Me.dsPlan1)
                Me.rPlan = Me.dsPlan1.plan.Rows(0)
                Me.loadData()

                Me.setUIAfterLoading()
                Me.setTitleWindow()
                Me.textAnzeigenxy(Me.rPlan.Text, Me.rPlan.html, Me.rPlan.IDArt)
                'Me.lblArt.Visible = False
                'Me.cboArt2.Visible = False
            Else
                Me.frmStatus = General.eStatusForm.neu
                Me.IDArt = IDArtNewPlan
                Me.setToolBarBody(False)
                'Me.lblArt.Visible = True
                'Me.cboArt2.Visible = True

                If Not General.IsNull(Exch.str) Then
                    Me.txtMailAn.Text = Exch.str
                End If
                If Exch.typMail = General.eTypMail.an Then
                    Me.txtMailAn.Text = Exch.str
                ElseIf Exch.typMail = General.eTypMail.cc Then
                    Me.txtMailCC.Text = Exch.str
                    'ElseIf Exch.typMail = ITSCont.core.SystemDb.General.eTypMail.bcc Then
                    '    Me.UTextMailCC.Text = Exch.str
                    '    Me.RButtonBCC.Checked = True
                End If

                If Not Me.IDActivityForNewPlan = Nothing Then
                End If

                Me.setDBForNewPlan()
                Me.contListeAnhang.loadData(rPlan.ID)
                Me.contSelectPatienten.loadData2(Me.rPlan.ID, Nothing, True)
                Me.contSelectBenutzer.loadData2(Me.rPlan.ID, Nothing, True)

                Me.setUIAfterLoading()
                'Me.genMain.loadSignature(Me.ContTxtEditor1)
                Me.setTitleWindow()
                Me.winFormHtmlEditor1.DocumentHtml = Me.genMain.loadSignatureAsHTMLxy()
                Me.LastTextBody = Me.winFormHtmlEditor1.DocumentHtml
            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht.Init: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function

    Public Sub setTitleWindow()
        Try
            If Me.IDArt = clPlan.typPlan_AufgabeTermin Then
                Me.Text = doUI.getRes("Aufgabe/Termin")

            ElseIf Me.IDArt = clPlan.typPlan_Notiz Then
                Me.Text = doUI.getRes("Notice")

            ElseIf Me.IDArt = clPlan.typPlan_EMailGesendet Or Me.IDArt = clPlan.typPlan_EMailEmpfangen Then
                Me.Text = doUI.getRes("eMail")

            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht.setTitleWindow: " + ex.ToString())
        End Try
    End Sub

    Public Function loadData() As Boolean
        Try
            'Dim rPlanAct As dsPlan.planRow = Me.dsPlan1.plan.Rows(0)
            'If Me.loadAllActivities Then
            '    Me.ContComboActivities1.loadAllActivities("", -1, -1, -1, -1)
            'Else
            '    Me.ContComboActivities1.loadAllActivities("", -1, -1, -1, -1)
            '    'Me.ContComboActivities1.loadAllActivities("", 0, 0, 0, -1)
            'End If

            Me.txtBetreff.Text = Me.rPlan.Betreff
            Me.IDArt = Me.rPlan.IDArt

            If Not Me.rPlan.IsempfangenAmNull() Then
                'Me.lblEmpfangenAmGesendetAm.Text = rPlan.empfangenAm.ToString("dd.MM.yyyy HH:mm:ss")
                Me.setLabelsEmpfangenAmGesendetAm(False, Me.rPlan.empfangenAm, Me.rPlan.MailFrom)
            Else
                Me.setLabelsEmpfangenAmGesendetAm(False, Nothing, Me.rPlan.MailFrom)
            End If
            Me.lblMailVon.Text = Me.rPlan.MailFrom

            If Me.rPlan.Status.Trim() <> "" Then
                If Me.rPlan.Status.Trim().ToLower().Equals(("Offen").Trim().ToLower()) Then
                    Me.optStatus.CheckedIndex = 0
                ElseIf Me.rPlan.Status.Trim().ToLower().Equals(("Erledigt").Trim().ToLower()) Then
                    Me.optStatus.CheckedIndex = 1
                Else
                    Throw New Exception("frmNachricht.loadData: Me.rPlan.Status='" + Me.rPlan.Status.Trim() + "' not allowed!")
                End If
            Else
                Me.optStatus.Value = Nothing
            End If

            If Not Me.rPlan.IsBeginntAmNull() Then
                Me.dteBeginntAm.Value = Me.rPlan.BeginntAm
            Else
                Me.dteBeginntAm.Value = Nothing
            End If
            Me.cboPriorität.Text = Me.rPlan.Priorität

            Me.contSelectSelListCategories.loadDataColl(Me.rPlan.Category.Trim())

            'Me.textAnzeigenxy(Me.rPlan.Text, Me.rPlan.html, Me.rPlan.IDArt)
            'Me.cboFür.Text = rPlan.Für
            'rPlan.Zusatz = ""
            'rPlan.objectName = Me.patient
            Me.txtMailAn.Text = Me.rPlan.MailAn
            Me.txtMailCC.Text = Me.rPlan.MailCC
            Me.txtMailBCC.Text = Me.rPlan.MailBcc

            If Not Me.rPlan.IsIDActivityNull() Then
            Else
            End If


            If Me.rPlan.IsEndetAmNull() Then
                Me.dteEndetAm.Value = Nothing
            Else
                Me.dteEndetAm.DateTime = Me.rPlan.EndetAm
            End If
            If Me.rPlan.Dauer = -1 Then
                Me.cboDauer.Value = Nothing
            Else
                Me.cboDauer.Value = rPlan.Dauer
            End If
            Me.chkGanzerTag.Checked = Me.rPlan.GanzerTag
            Me.setUIEndetAm(Me.rPlan.GanzerTag)

            Me.chkIsSerientermin.Checked = Me.rPlan.IsSerientermin
            Me.grpSerientermin.Visible = Me.rPlan.IsSerientermin
            If Me.rPlan.IsSerienterminEndetAmNull() Then
                Me.dteSerienterminEndetAm.Value = Nothing
            Else
                Me.dteSerienterminEndetAm.Value = Me.rPlan.SerienterminEndetAm.Date
            End If

            If Me.rPlan.SerienterminType.Trim() <> "" Then
                If Me.rPlan.SerienterminType.Trim() = "1" Then
                    Me.optSerienterminType.CheckedIndex = 0
                ElseIf Me.rPlan.SerienterminType.Trim() = "2" Then
                    Me.optSerienterminType.CheckedIndex = 1
                ElseIf Me.rPlan.SerienterminType.Trim() = "3" Then
                    Me.optSerienterminType.CheckedIndex = 2
                End If
            Else
                Me.optSerienterminType.CheckedIndex = 0
            End If
            If Me.rPlan.IsWiedWertJedenNull() Then
                Me.iWiedWertJeden.Value = Nothing
            Else
                Me.iWiedWertJeden.Value = Me.rPlan.WiedWertJeden
            End If
            If Me.rPlan.TagWochenMonat.Trim() <> "" Then
                If Me.rPlan.TagWochenMonat.Trim() = "0" Then
                    Me.opTagWochenMonat.CheckedIndex = 0
                ElseIf Me.rPlan.TagWochenMonat.Trim() = "1" Then
                    Me.opTagWochenMonat.CheckedIndex = 1
                ElseIf Me.rPlan.TagWochenMonat.Trim() = "2" Then
                    Me.opTagWochenMonat.CheckedIndex = 2
                End If
            Else
                Me.opTagWochenMonat.CheckedIndex = 0
            End If
            If Me.rPlan.IsnTenMonatNull() Then
                Me.iNTenMonat.Value = Nothing
            Else
                Me.iNTenMonat.Value = Me.rPlan.nTenMonat
            End If

            Me.setWochentage(Me.rPlan.Wochentage.Trim())


            Me.chkSendWithPostOfficeBoxForAll.Checked = Me.rPlan.SendWithPostOfficeBoxForAll
            Me.setErstelltVon(Me.rPlan.ErstelltVon, Me.rPlan.ErstelltAm)

            If Not Me.rPlan.IsIDUserAccountNull() Then
                Me.setInfoGeneral(Me.rPlan.IDUserAccount, False)
            Else
                Me.setInfoGeneral(Nothing, False)
            End If

            Me.contSelectBenutzer.loadData2(Me.rPlan.ID, Nothing, False)
            Me.contSelectPatienten.loadData2(Me.rPlan.ID, Nothing, False)
            'Me.copyPlanObjects()

            Me.contListeAnhang.loadData(Me.rPlan.ID)

            If Me.IDArt = clPlan.typPlan_EMailEmpfangen Then
                If Not PMDS.Global.ENV.adminSecure Then
                    Me.compPlan1.UpdatePlanReaded(Me.rPlan.ID, True)
                End If
            End If

            General.GarbColl()

        Catch ex As Exception
            Throw New Exception("frmNachricht.loadData: " + ex.ToString())
        End Try
    End Function

    Public Sub textAnzeigenxy(ByVal text As String, ByVal html As Boolean, ByVal IDArtAct As Integer)
        Try
            Dim typUI As New General.etyp()
            If Me.isEditable Then
                typUI = General.etyp.all
            Else
                typUI = General.etyp.onlyShow
            End If

            If html Then
                Me.setToolBarBody(False)
                System.Windows.Forms.Application.DoEvents()
                'Me.doEditor1.showText(text, TXTextControl.StreamType.HTMLFormat, Me.isEditable, TXTextControl.ViewMode.PageView, Me.ContTxtEditor22._textControl)
                Me.LoadTxtControl(TXTextControl.StringStreamType.HTMLFormat, text)

                'Me.setWebBrowser(text)
                'If IDArtAct = clPlan.typPlan_EMailEmpfangen Then
                '    Me.setToolBarBody(True)
                '    Application.DoEvents()
                '    Me.ContTxtEditor1.showText(text, TXTextControl.StreamType.HTMLFormat, Me.isEditable, Me.standardViewExtEditor)
                '            Me.setWebBrowser(text)
                'Else
                '    Me.setToolBarBody(True)
                '    Application.DoEvents()
                '    Me.ContTxtEditor1.showText(text, TXTextControl.StreamType.HTMLFormat, Me.isEditable, Me.standardViewExtEditor)
                '    Me.setWebBrowser(text)
                'End If
                Me.LastTextBody = text
            Else
                Me.setToolBarBody(False)
                System.Windows.Forms.Application.DoEvents()
                'Me.doEditor1.showText(text, TXTextControl.StreamType.PlainText, Me.isEditable, TXTextControl.ViewMode.PageView, Me.ContTxtEditor22._textControl)
                Me.LoadTxtControl(TXTextControl.StringStreamType.PlainText, text)
                'Me.setWebBrowser(text)
                Me.LastTextBody = text
            End If

            If html Then
                Me.setHtml(True, False)
            Else
                If clPlan.checkIfTextIsHtmlText(text.Trim()) Then
                    Me.setHtml(True, False)
                Else
                    Me.setHtml(False, False)
                End If
            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht.textAnzeigen: " + ex.ToString())
        End Try
    End Sub
    Public Sub LoadTxtControl(DefaultLoadTypes As TXTextControl.StringStreamType, txt As String)
        Try
            If General.InitHTMLEditorEveryClick Then
                contPlanungData.reloadHTMLControl(Me.PanelTxtEditor, Me.winFormHtmlEditor1)
            Else
                contPlanungData.ClearHTMLBrowser(Me.winFormHtmlEditor1)
            End If

            If DefaultLoadTypes = TXTextControl.StringStreamType.HTMLFormat Then
                'Me.winFormHtmlEditor1.DocumentHtml = txt
                'Me.winFormHtmlEditor1.Content.SetDocumentHtml(txt)
                Me.winFormHtmlEditor1.DocumentHtml = txt
            Else
                If clPlan.checkIfTextIsHtmlText(txt.Trim()) Then
                    Me.chkTextIsHtml.Checked = True
                    Me.winFormHtmlEditor1.DocumentHtml = txt
                Else
                    Me.winFormHtmlEditor1.Content.SetBodyText(txt)
                End If
            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht.LoadTxtControl: " + ex.ToString())
        End Try
    End Sub
    Public Sub showTabText(ByVal tabnr As Integer)
        Try
            Me.UltraTabControlText.SelectedTab = Me.UltraTabControlText.Tabs(tabnr)
            Application.DoEvents()

            If tabnr = 0 Then
                If Me.frmStatus = General.eStatusForm.edit Then
                    Me.setWebBrowser(Me.rPlan.Text)
                Else
                    Dim typTxt As New TXTextControl.StreamType
                    If Me.isHtml Then
                        typTxt = TXTextControl.StreamType.HTMLFormat
                    Else
                        typTxt = TXTextControl.StreamType.PlainText
                    End If
                    Me.setWebBrowser(Me.winFormHtmlEditor1.DocumentHtml)
                End If
            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht.showTabText: " + ex.ToString())
        End Try
    End Sub

    Public Sub antworten(ByVal typ As eAntworten)
        Try
            Dim IDActivity As System.Guid = Nothing     'Me.getSelActivity(False)

            Dim tNewObjects As New dsPlan.planObjectDataTable()
            Me.tPlanObjectsAllCopy.CopyToDataTable(tNewObjects, LoadOption.OverwriteChanges)
            Dim frmNewPlan As frmNachricht2 = Me.genMain.newMessage(Now, Now, tNewObjects, Nothing, IDActivity, False, False, "", "", Nothing, False, True)

            frmNewPlan.loadForm()
            Dim exch As New General.exchPlan
            exch.app = General.InitApplicationAufgabenTermine.terminNeu
            frmNewPlan.Init(exch, clPlan.typPlan_EMailGesendet)
            frmNewPlan.IDArt = clPlan.typPlan_EMailGesendet

            If typ = eAntworten.antworten Then
                frmNewPlan.txtMailAn.Text = IIf(Me.lblMailVon.Text.Trim() = "", "", Me.lblMailVon.Text.Trim())
                frmNewPlan.txtBetreff.Text = "AW: " + Me.txtBetreff.Text

            ElseIf typ = eAntworten.alleAntworten Then
                frmNewPlan.txtMailAn.Text = IIf(Me.lblMailVon.Text.Trim() <> "", Me.lblMailVon.Text.Trim() + ";", "")
                frmNewPlan.txtMailAn.Text += IIf(Me.txtMailAn.Text.Trim() <> "", Me.txtMailAn.Text.Trim() + ";", "")

                frmNewPlan.txtBetreff.Text = "AW: " + Me.txtBetreff.Text

            ElseIf typ = eAntworten.weiterleiten Then
                frmNewPlan.txtBetreff.Text = "WG: " + Me.txtBetreff.Text

            End If

            'For Each rPlanObj As dsPlan.planObjectRow In Me.tPlanObjectsAllCopy
            '    Dim rNewPlanObject As dsPlan.planObjectRow = Me.compPlan1.getNewRowPlanObject(frmNewPlan.tPlanObjectsAllCopy)
            '    rNewPlanObject.ID = System.Guid.NewGuid()
            '    rNewPlanObject.IDObject = rPlanObj.IDObject
            '    rNewPlanObject.IDPlan = frmNewPlan.rPlan.ID
            'Next

            Dim typTxt As New TXTextControl.StreamType
            If Me.isHtml Then
                typTxt = TXTextControl.StreamType.HTMLFormat
            Else
                typTxt = TXTextControl.StreamType.PlainText
            End If

            Me.contListeAnhang.copyAnhänge(frmNewPlan.contListeAnhang.DsPlan2.planAnhang, frmNewPlan.rPlan.ID)
            frmNewPlan.contListeAnhang.doCount()
            'frmNewPlan.Visible = False
            'frmNewPlan.Show()
            'frmNewPlan.winFormHtmlEditor1.DocumentHtml.(0, txtInfoAddTop)
            frmNewPlan.setUIAfterLoading()
            If frmNewPlan.IDArt <> clPlan.typPlan_EMailGesendet And
               frmNewPlan.IDArt <> clPlan.typPlan_EMailEmpfangen Then

                frmNewPlan.setUIEMailAdressesOnOff()
            End If

            'frmNewPlan.winFormHtmlEditor1.Content.InsertText(txtInfoAddTop)
            If General.InitHTMLEditorEveryClick Then
                contPlanungData.reloadHTMLControl(frmNewPlan.PanelTxtEditor, frmNewPlan.winFormHtmlEditor1)
            Else
                contPlanungData.ClearHTMLBrowser(frmNewPlan.winFormHtmlEditor1)
            End If

            frmNewPlan.textAnzeigenxy("", Me.isHtml, frmNewPlan.IDArt)
            frmNewPlan.winFormHtmlEditor1.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.WYSIWYG_Design

            If Me.isHtml Then
                'Dim txtTmp As String = Me.winFormHtmlEditor1.Content.GetBodyText()
                'If txtTmp.Trim() <> "" Then
                '    Dim sHtml As String = Me.winFormHtmlEditor1.DocumentHtml
                '    Dim iPosFirstTxt As String = sHtml.IndexOf("<p>")
                '    If iPosFirstTxt <> -1 Then
                '        sHtml = sHtml.Insert(iPosFirstTxt + 3, txtInfoAddTop)
                '        frmNewPlan.winFormHtmlEditor1.Content.SetDocumentHtml(sHtml)
                '    Else
                '        frmNewPlan.winFormHtmlEditor1.Content.SetDocumentHtml(Me.winFormHtmlEditor1.DocumentHtml)
                '    End If
                'Else
                '    frmNewPlan.winFormHtmlEditor1.Content.SetDocumentHtml(Me.winFormHtmlEditor1.DocumentHtml)
                'End If

                frmNewPlan.winFormHtmlEditor1.Content.SetDocumentHtml(Me.winFormHtmlEditor1.DocumentHtml)
                'For Each el As System.Windows.Forms.HtmlElement In Me.winFormHtmlEditor1.Content.GetHtmlElements(True)

                '    Dim strxy As String = ""

                'Next
                Dim NewLineHtml As String = "<br />"
                Dim txtInfoAddTop As String = NewLineHtml + NewLineHtml + NewLineHtml +
                    "<p><span style='font-family: ""Calibri"",""sans-serif""'><FONT SIZE=3>" + "" + NewLineHtml +
                        "------------------------------------------------------------------------------------------------------------------------------" + NewLineHtml +
                        doUI.getRes("From2") + ": " + Me.lblMailVon.Text + NewLineHtml +
                        doUI.getRes("SentOn") + ": " + Me.lblEmpfangenAmGesendetAm.Text + NewLineHtml +
                        doUI.getRes("An") + ": " + Me.txtMailAn.Text + NewLineHtml +
                        doUI.getRes("Cc") + ": " + Me.txtMailCC.Text + NewLineHtml +
                        doUI.getRes("Subject") + ": " + Me.txtBetreff.Text + NewLineHtml +
                        "------------------------------------------------------------------------------------------------------------------------------" + NewLineHtml + NewLineHtml

                frmNewPlan.winFormHtmlEditor1.Content.InsertHtmlBetweenHead(txtInfoAddTop)
                'Dim str As String = Me.winFormHtmlEditor1.Content.GetHtmlElements(True)(0).InnerText
                frmNewPlan.LastTextBody = Me.winFormHtmlEditor1.DocumentHtml

            Else
                Dim txtInfoAddTop As String = vbNewLine + vbNewLine + vbNewLine +
                        "------------------------------------------------------------------------------------------------------------------------------" + vbNewLine +
                        doUI.getRes("From2") + ": " + Me.lblMailVon.Text + vbNewLine +
                        doUI.getRes("SentOn") + ": " + Me.lblEmpfangenAmGesendetAm.Text + vbNewLine +
                        doUI.getRes("An") + ": " + Me.txtMailAn.Text + vbNewLine +
                        doUI.getRes("Cc") + ": " + Me.txtMailCC.Text + vbNewLine +
                        doUI.getRes("Subject") + ": " + Me.txtBetreff.Text + vbNewLine +
                        "------------------------------------------------------------------------------------------------------------------------------" + vbNewLine + vbNewLine

                Dim txtToAdd As String = txtInfoAddTop + Me.winFormHtmlEditor1.Content.GetBodyText()
                frmNewPlan.winFormHtmlEditor1.Content.SetBodyText(txtToAdd)
                frmNewPlan.LastTextBody = Me.winFormHtmlEditor1.Content.GetBodyText()

            End If

            frmNewPlan.typAntworten = typ
            frmNewPlan.chkTextIsHtml.Checked = Me.isHtml
            frmNewPlan.winFormHtmlEditor1.DefaultFontSizeInPt = "14"
            'frmNewPlan.winFormHtmlEditor1.Selection.SelectText(0, 0)
            frmNewPlan.dteBeginntAm.DateTime = Now
            'frmNewPlan.Visible = True
            frmNewPlan.Show()

        Catch ex As Exception
            Throw New Exception("frmNachricht.antworten: " + ex.ToString())
        End Try
    End Sub

    Public Sub SetTextTemplate(ByVal IDTextTemplate As Guid, ByRef WithSignature As Boolean)
        Try
            Dim dsAutoDocuRead As New dsAutoDocu()
            Dim compAutoDocuRead As New compAutoDocu()
            compAutoDocuRead.getTextTamplates(IDTextTemplate, dsAutoDocuRead, compAutoDocu.eSelTextTemplates.ID)
            Dim rTextTemplates As dsAutoDocu.tblTextTemplatesRow = dsAutoDocuRead.tblTextTemplates.Rows(0)

            compAutoDocuRead.getTextTamplatesFiles(rTextTemplates.ID, dsAutoDocuRead, compAutoDocu.eSelTextTemplates.IDTextTemplate)

            Dim SignatureRtf As String = ""
            If WithSignature Then
                Me.genMain.loadSignatureAsRtf(SignatureRtf)
            End If

            Me.EditorTmp1.Text = ""
            'Dim editorTmp As New TXTextControl.ServerTextControl
            'editorTmp.Create()
            'Dim LoadSettings As TXTextControl.LoadSettings = New TXTextControl.LoadSettings
            'editorTmp.Load(rTextTemplates.Txt, TXTextControl.StreamType.RichTextFormat)
            doEditor1.showText(rTextTemplates.Txt, TXTextControl.StreamType.RichTextFormat, False, TXTextControl.ViewMode.PageView, Me.EditorTmp1)

            Dim sBodyOrig As String = ""
            If Me.chkTextIsHtml.Checked Then
                sBodyOrig = Me.winFormHtmlEditor1.DocumentHtml
            Else
                sBodyOrig = Me.winFormHtmlEditor1.Content.GetBodyText()
            End If

            Dim SaveSettings As New TXTextControl.SaveSettings()
            Dim BodyTmp As String = ""
            If WithSignature And SignatureRtf.Trim() <> "" Then
                Me.doEditor1.appendText(SignatureRtf, Me.EditorTmp1)
            End If
            If Me.typAntworten = eAntworten.weiterleiten Or Me.typAntworten = eAntworten.antworten Or Me.typAntworten = eAntworten.alleAntworten Then
                If Me.chkTextIsHtml.Checked Then
                    Me.doEditor1.appendText2(sBodyOrig, Me.EditorTmp1, TXTextControl.StringStreamType.HTMLFormat)
                Else
                    'Dim sb As New System.Text.StringBuilder()
                    'sb.AppendLine()
                    'sb.AppendLine()
                    'Me.doEditor1.appendPlainTxt(sb.ToString(), Me.EditorTmp1)
                    Me.doEditor1.appendText2(sBodyOrig, Me.EditorTmp1, TXTextControl.StringStreamType.PlainText)
                End If
            End If

            If General.InitHTMLEditorEveryClick Then
                contPlanungData.reloadHTMLControl(Me.PanelTxtEditor, Me.winFormHtmlEditor1)
            Else
                contPlanungData.ClearHTMLBrowser(Me.winFormHtmlEditor1)
            End If

            If rTextTemplates.Betreff.Trim() <> "" Then
                Me.txtBetreff.Text = rTextTemplates.Betreff.Trim()
            End If
            If rTextTemplates.An.Trim() <> "" Then
                Me.txtMailAn.Text = rTextTemplates.An.Trim()
            End If
            If rTextTemplates.CC.Trim() <> "" Then
                Me.txtMailCC.Text = rTextTemplates.CC.Trim()
            End If
            If rTextTemplates.BCC.Trim() <> "" Then
                Me.txtMailBCC.Text = rTextTemplates.BCC.Trim()
            End If

            Me.contSelectBenutzer.loadDataColl(rTextTemplates.lstIDBenutzer.Trim())
            Me.contSelectPatienten.loadDataColl(rTextTemplates.lstIDPatienten.Trim())

            Me.winFormHtmlEditor1.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.WYSIWYG_Design
            If Me.chkTextIsHtml.Checked Then
                BodyTmp = doEditor1.getText(TXTextControl.StringStreamType.HTMLFormat, Me.EditorTmp1)
                'Me.EditorTmp1.Save(BodyTmp, TXTextControl.StreamType.HTMLFormat, SaveSettings)
                Me.winFormHtmlEditor1.DocumentHtml = BodyTmp
            Else
                BodyTmp = doEditor1.getText(TXTextControl.StringStreamType.PlainText, Me.EditorTmp1)
                Me.winFormHtmlEditor1.Content.SetBodyText(BodyTmp)
            End If

            For Each rTextTemplateFile As dsAutoDocu.tblTextTemplatesFilesRow In dsAutoDocuRead.tblTextTemplatesFiles
                Me.contListeAnhang.addFile(rTextTemplateFile.Docu, rTextTemplateFile.Bezeichnung, rTextTemplateFile.FileType, Me.rPlan.ID)
            Next
            Me.contListeAnhang.doCount()

        Catch ex As Exception
            Throw New Exception("frmNachricht.SetTextTemplate: " + ex.ToString())
        End Try
    End Sub
    Public Sub clearErrorProvider()
        Try
            Me.ErrorProvider1.SetError(Me.txtBetreff, "")
            Me.ErrorProvider1.SetError(Me.dteBeginntAm, "")
            Me.ErrorProvider1.SetError(Me.dteEndetAm, "")
            Me.ErrorProvider1.SetError(Me.cboDauer, "")
            Me.ErrorProvider1.SetError(Me.txtMailAn, "")
            Me.ErrorProvider1.SetError(Me.txtMailCC, "")
            Me.ErrorProvider1.SetError(Me.btnSendEMails, "")
            Me.ErrorProvider1.SetError(Me.btnSendPlan, "")

            Me.ErrorProvider1.SetError(Me.chkIsSerientermin, "")
            Me.ErrorProvider1.SetError(Me.dteSerienterminEndetAm, "")
            Me.ErrorProvider1.SetError(Me.grpSerientermin, "")
            Me.ErrorProvider1.SetError(Me.optSerienterminType, "")
            Me.ErrorProvider1.SetError(Me.iWiedWertJeden, "")
            Me.ErrorProvider1.SetError(Me.opTagWochenMonat, "")
            Me.ErrorProvider1.SetError(Me.iNTenMonat, "")
            Me.ErrorProvider1.SetError(Me.grpWochentage, "")

            Me.ErrorProvider1.SetError(Me.cbMo, "")
            Me.ErrorProvider1.SetError(Me.cbDi, "")
            Me.ErrorProvider1.SetError(Me.cbMi, "")
            Me.ErrorProvider1.SetError(Me.cbDo, "")
            Me.ErrorProvider1.SetError(Me.cbFr, "")
            Me.ErrorProvider1.SetError(Me.cbSa, "")
            Me.ErrorProvider1.SetError(Me.cbSo, "")

        Catch ex As Exception
            Throw New Exception("frmNachricht.clearErrorProvider: " + ex.ToString())
        End Try
    End Sub
    Public Function checkInput(ByVal typAction As eTypAction) As Boolean
        Try
            Me.clearErrorProvider()

            If General.IsNull(Me.txtBetreff.Text) Then
                Dim txt As String = doUI.getRes("SubjectInputRequired")
                Me.ErrorProvider1.SetError(Me.txtBetreff, txt)
                doUI.doMessageBox2("SubjectInputRequired", "", "!")
                txtBetreff.Focus()
                Return False
            End If

            Dim ui1 As New UI()
            If Me.IDArt = -999 Then
                Throw New Exception("frmNachricht.checkInput: Me.IDArt=-999 not allowed!")
            End If

            If Not Me.genMain.checkComboBox(Me.cboPriorität, False) Then Return False

            If General.IsNull(Me.dteBeginntAm.Value) Then
                Dim txt As String = doUI.getRes("BeginsAtInputRequired")
                Me.ErrorProvider1.SetError(Me.dteBeginntAm, txt)
                doUI.doMessageBox2("BeginsAtInputRequired", "", "!")
                dteBeginntAm.Focus()
                Return False
            End If

            If Not Me.chkGanzerTag.Checked Then
                If General.IsNull(Me.dteEndetAm.Value) Then
                    Dim txt As String = doUI.getRes("EndsAtInputRequired")
                    Me.ErrorProvider1.SetError(Me.dteEndetAm, txt)
                    doUI.doMessageBox2("EndsAtInputRequired", "", "!")
                    Me.dteEndetAm.Focus()
                    Return False
                Else
                    If Me.dteEndetAm.DateTime <= Me.dteBeginntAm.DateTime Then
                        Dim txt As String = doUI.getRes("EndetAmMussGrösserAlsBeginntAmSein")
                        Me.ErrorProvider1.SetError(Me.dteEndetAm, txt)
                        doUI.doMessageBox2("EndetAmMussGrösserAlsBeginntAmSein", "", "!")
                        Me.dteEndetAm.Focus()
                        Return False
                    End If
                End If
            End If

            If Me.chkIsSerientermin.Checked Then
                If General.IsNull(Me.dteSerienterminEndetAm.Value) Then
                    Dim txt As String = doUI.getRes("SerienterminEndetAmInputRequired")
                    Me.ErrorProvider1.SetError(Me.dteSerienterminEndetAm, txt)
                    doUI.doMessageBox2("SerienterminEndetAmInputRequired", "", "!")
                    dteSerienterminEndetAm.Focus()
                    Return False
                Else
                    If Me.dteSerienterminEndetAm.DateTime.Date <= Me.dteBeginntAm.DateTime.Date Then
                        Dim txt As String = doUI.getRes("SerienterminMussGrösserAlsBeginntAmSein")
                        Me.ErrorProvider1.SetError(Me.dteSerienterminEndetAm, txt)
                        doUI.doMessageBox2("SerienterminMussGrösserAlsBeginntAmSein", "", "!")
                        Me.dteSerienterminEndetAm.Focus()
                        Return False
                    End If
                End If

                Dim iSerientermintype As Integer = System.Convert.ToInt32(Me.optSerienterminType.Value.ToString().Trim())
                If iSerientermintype = 1 Then
                    Dim sWochentage As String = Me.getWochentage()
                    If sWochentage.Trim() = "" Then
                        Dim txt As String = doUI.getRes("WochentageSelectionRequired")
                        Me.ErrorProvider1.SetError(Me.grpWochentage, txt)
                        doUI.doMessageBox2("WochentageSelectionRequired", "", "!")
                        Me.grpWochentage.Focus()
                        Return False
                    End If

                ElseIf iSerientermintype = 2 Then
                    If Me.iWiedWertJeden.Value Is System.DBNull.Value Then
                        Dim txt As String = doUI.getRes("WiedWertJedenInputRequired")
                        Me.ErrorProvider1.SetError(Me.iWiedWertJeden, txt)
                        doUI.doMessageBox2("WiedWertJedenInputRequired", "", "!")
                        Me.iWiedWertJeden.Focus()
                        Return False
                    End If

                    Dim iTagWochenMonat As Integer = System.Convert.ToInt32(Me.opTagWochenMonat.Value.ToString().Trim())
                    If iTagWochenMonat = 1 Then
                        Dim sWochentage As String = Me.getWochentage()
                        If sWochentage.Trim() = "" Then
                            Dim txt As String = doUI.getRes("WochentageSelectionRequired")
                            Me.ErrorProvider1.SetError(Me.grpWochentage, txt)
                            doUI.doMessageBox2("WochentageSelectionRequired", "", "!")
                            Me.grpWochentage.Focus()
                            Return False
                        End If
                    End If

                ElseIf iSerientermintype = 3 Then
                    If Me.iNTenMonat.Value Is System.DBNull.Value Then
                        Dim txt As String = doUI.getRes("NTenMonatInputRequired")
                        Me.ErrorProvider1.SetError(Me.iNTenMonat, txt)
                        doUI.doMessageBox2("NTenMonatInputRequired", "", "!")
                        Me.iNTenMonat.Focus()
                        Return False
                    End If
                End If

            End If

            Return True

        Catch ex As Exception
            Throw New Exception("frmNachricht.checkInput: " + ex.ToString())
        End Try
    End Function
    Public Function validateEMailSendingSettings(ByRef rPlanToSend As dsPlan.planRow,
                                  ByRef bSendOnServer As Boolean, ByRef rUsrAccount As dsUserAccounts.tblUserAccountsRow,
                                  ByRef withMsgBox As Boolean) As Boolean
        Try
            bSendOnServer = True
            If Not bSendOnServer Then
                Dim UserLoggedIn As String = Me.genMain.getLoggedInUser()
                rUsrAccount = compUserAccounts1.getUserAccountsRow(Nothing, UserLoggedIn.Trim(), compUserAccounts.eTypSelUserAccounts.usr, compUserAccounts.eTypEMailAccount.SMTP, False, False)
                If rUsrAccount Is Nothing Then
                    If withMsgBox Then
                        doUI.doMessageBox2("NoAccountForUserDefined", "", "!")
                    End If
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht.validateEMailSendingSettings: " + ex.ToString())
        End Try
    End Function

    Public Function checkInputSend(ByVal typAction As eTypAction, ByVal checkEMail As Boolean) As Boolean
        Try
            Me.clearErrorProvider()

            If checkEMail Then
                'If Me.txtMailAn.Text.Trim() = "" Or Me.txtMailCC.Text.Trim() = "" Then
                '    Dim txt As String = "Versenden nicht möglich da keine E-Mail-Adressen eingegeben!"
                '    Me.txtMailAn.Focus()
                '    Me.ErrorProvider1.SetError(Me.txtMailAn, txt)
                '    MsgBox(txt, MsgBoxStyle.Exclamation, "Planung")
                '    Return False
                'End If
            Else
                Dim bTeilnehmerLoaded As Boolean = False
                If Not bTeilnehmerLoaded Then
                    Dim txt As String = doUI.getRes("SendingSotPossibleBecauseNoClerksInvited")
                    Me.ErrorProvider1.SetError(Me.btnSendEMails, txt)
                    doUI.doMessageBox2("SendingSotPossibleBecauseNoClerksInvited", "", "!")
                    Return False
                End If
            End If

            Return True

            'Me.clearErrorProvider()

            'Dim bTeilnehmerLoaded As Boolean = False
            'If Me.txtTeilnehmer.Text.Trim() <> "" Then
            '    Dim lstUsers As System.Collections.Generic.List(Of String) = ITSCont.core.cs.generic.readStrVariables(Me.txtTeilnehmer.Text.Trim())
            '    If lstUsers.Count > 0 Then
            '        bTeilnehmerLoaded = True
            '    End If
            'End If

            'Dim bOk As Boolean = False
            'If onlyObjetkOrSachbearbeiter Then
            '    If bTeilnehmerLoaded Or Me.tPlanObjectsAllCopy.Rows.Count > 0 Then
            '        bOk = True
            '    End If
            'Else
            '    If bTeilnehmerLoaded Then
            '        bOk = True
            '    End If
            'End If
            'If Not bOk Then
            '    Dim txt As String = "Versenden von E-Mails nicht möglich da keine Teilnehmer eingeladen bzw. keine Objekte vorhanden!"
            '    Me.ErrorProvider1.SetError(Me.btnSendEMails, txt)
            '    MsgBox(txt, MsgBoxStyle.Exclamation, "Planung")
            '    Return False
            'End If

            Return True

        Catch ex As Exception
            Throw New Exception("frmNachricht.checkInputSend: " + ex.ToString())
        End Try
    End Function


    Public Function savePlan2(ByVal typAction As eTypAction, ByRef rSelUserAccountReturn As dsUserAccounts.tblUserAccountsRow) As Boolean
        Dim protokollOk As String = ""
        Dim protokollErr As String = ""
        Try
            If Not Me.checkInput(typAction) Then
                Return False
            End If

            Dim bSendOnServer As Boolean = False
            Dim dsInteropPar1 As New dsInteropPar()
            Dim rUsrAccount As dsUserAccounts.tblUserAccountsRow
            Dim anzPläne As Integer = 0
            Dim anzEMails As Integer = 0
            Dim anzErr As Integer = 0

            If Me.IDArt = clPlan.typPlan_EMailGesendet Then
                If Not Me.validateEMailSendingSettings(Me.rPlan, bSendOnServer, rUsrAccount, True) Then
                    Return False
                End If
            End If

            Dim rSelUserAccount As dsUserAccounts.tblUserAccountsRow = Nothing
            Dim UsrExchangeKto As String = ""
            If Me.IDArt = clPlan.typPlan_AufgabeTermin Or Me.IDArt = clPlan.typPlan_Notiz Then
            End If

            If typAction = eTypAction.sendPlanClicked Then
                If Me.IDArt = clPlan.typPlan_AufgabeTermin Or Me.IDArt = clPlan.typPlan_Notiz Then
                    If Not Me.checkInputSend(typAction, False) Then
                        Return False
                    End If
                Else
                    Throw New Exception("rSelSelListArt.IDNr not allowed!")
                End If
            End If

            If typAction = eTypAction.sendEMailClicked Then
                If Not Me.checkInputSend(typAction, True) Then
                    Return False
                End If
            End If

            ' Save for Producer
            Dim Producer As String = ""
            If Me.frmStatus = General.eStatusForm.neu Then
                Dim UserLoggedIn As String = Me.genMain.getLoggedInUser()
                Producer = UserLoggedIn.Trim()
            End If

            Dim IDSerientermin As Nullable(Of Guid) = Nothing
            Dim lstSerientermineResult As New System.Collections.Generic.List(Of General.cSerientermine)
            If Me.chkIsSerientermin.Checked Then
                Dim sWochentage As String = Me.getWochentage()

                Dim iWiedWertJedenTmp As Nullable(Of Integer) = Nothing
                If (Not Me.iWiedWertJeden.Value Is Nothing) AndAlso (Not Me.iWiedWertJeden.Value Is System.DBNull.Value) Then
                    iWiedWertJedenTmp = Me.iWiedWertJeden.Value
                End If
                Dim iNTenMonatTmp As Nullable(Of Integer) = Nothing
                If (Not Me.iNTenMonat.Value Is Nothing) AndAlso (Not Me.iNTenMonat.Value Is System.DBNull.Value) Then
                    iNTenMonatTmp = Me.iNTenMonat.Value
                End If

                IDSerientermin = System.Guid.NewGuid()
                Me.genMain.calcDateStartEnd(Me.dteBeginntAm.Value, Me.dteEndetAm.Value, Me.chkGanzerTag.Checked, Me.chkIsSerientermin.Checked,
                                            Me.optSerienterminType.Value.ToString().Trim(), iWiedWertJedenTmp, Me.opTagWochenMonat.Value, iNTenMonatTmp, sWochentage,
                                            lstSerientermineResult, Me.dteSerienterminEndetAm.Value, IDSerientermin)

                If lstSerientermineResult.Count = 0 Then
                    doUI.doMessageBox2("KeineSerientermineGeneriert", "", "!")
                    Return False
                    'Throw New Exception("frmNachricht2.savePlan2: lstSerientermineResult.Count = 0 not allowed!")
                End If
            Else
                Me.clearSerientermineUI()
            End If

            Dim ownerSucessfullySaved As Boolean = False
            Dim rPlanOwner As dsPlan.planRow = Me.dsPlan1.plan.Rows(0)
            If Me.setPlanRowTemp(rPlanOwner, Producer, Nothing, typAction, IDSerientermin) Then
                If UsrExchangeKto.Trim() <> "" Then
                    rPlanOwner.Für = UsrExchangeKto.Trim()
                    rSelUserAccountReturn = rSelUserAccount
                End If
                rPlanOwner.IsOwner = True
                If Not Me.chkIsSerientermin.Checked Then
                    If Me.saveNachrichtToDb2() Then
                        ownerSucessfullySaved = True
                        If typAction = eTypAction.saveButtClicked Then
                            protokollOk = doUI.getRes("EntrySave") + vbNewLine + protokollOk
                            Return True
                        End If
                    End If
                Else
                    ownerSucessfullySaved = True
                End If
            Else
                Throw New Exception("savePlan: Error saving E-Mail!")
            End If

            If ownerSucessfullySaved Then
                Me.contListeAnhang.anhangTempSichern()
                'Me.setPlanRowTemp(rPlanTemp, saveClicked, "", Nothing)

                If Me.rPlan.IDArt = clPlan.typPlan_AufgabeTermin Or Me.rPlan.IDArt = clPlan.typPlan_Notiz Then
                    ' Save Users
                    'Dim lstUsers As System.Collections.Generic.List(Of String) = PMDS.Global.generic.readStrVariables(Me.rPlan.Teilnehmer.Trim())
                    'If lstUsers.Count > 0 Then
                    If lstSerientermineResult.Count > 0 Then
                        For Each SerientermineAct As General.cSerientermine In lstSerientermineResult
                            Dim b As New PMDS.db.PMDSBusiness()
                            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                                'Dim rUsr As PMDS.db.Entities.Benutzer = b.getUserByUserName(usr.Trim(), db)

                                Dim dsPlanNew As New dsPlan()
                                Dim compPlanNew As New compPlan()
                                compPlanNew.getPlan(System.Guid.NewGuid(), compPlan.eTypSelPlan.id, dsPlanNew)
                                compPlanNew.getPlanAnhang(System.Guid.NewGuid(), compPlan.eTypSelPlanAnhang.idPlan, dsPlanNew)
                                compPlanNew.getPlanObject(System.Guid.NewGuid, compPlan.eTypSelPlanObject.id, dsPlanNew)

                                Dim rPlanNew As dsPlan.planRow = Me.compPlan1.getNewRowPlan(dsPlanNew)
                                rPlanNew.ItemArray = rPlanOwner.ItemArray
                                rPlanNew.ID = System.Guid.NewGuid()
                                'rPlanNew.Für = usr
                                rPlanNew.IDPlanMain = rPlanOwner.ID
                                rPlanNew.BeginntAm = SerientermineAct.dFrom
                                rPlanNew.EndetAm = SerientermineAct.dTo

                                For Each rPlanObj As dsPlan.planObjectRow In Me.tPlanObjectsAllCopy
                                    Dim rNewPlanObject As dsPlan.planObjectRow = Me.compPlan1.getNewRowPlanObject(dsPlanNew.planObject)
                                    rNewPlanObject.ID = System.Guid.NewGuid()
                                    rNewPlanObject.IDObject = rPlanObj.IDObject
                                    rNewPlanObject.IDPlan = rPlanNew.ID
                                Next

                                Me.contListeAnhang.loadAnhangTemp(rPlanNew.ID, dsPlanNew)

                                compPlanNew.daPlan.Update(dsPlanNew.plan)
                                compPlanNew.daPlanAnhang.Update(dsPlanNew.planAnhang)
                                compPlanNew.daPlanObject.Update(dsPlanNew.planObject)

                                If typAction = eTypAction.sendPlanClicked Then
                                    Me.updateSendPlan(rPlanNew.ID, True, False, Now)
                                    anzPläne += 1

                                ElseIf typAction = eTypAction.saveButtClicked Then
                                    anzPläne += 1

                                End If

                            End Using
                        Next

                        If typAction = eTypAction.sendPlanClicked Then
                            If rPlanOwner.IDArt = clPlan.typPlan_AufgabeTermin Or rPlanOwner.IDArt = clPlan.typPlan_Notiz Then
                                Me.updateSendPlan(rPlanOwner.ID, False, False, Nothing)

                                Dim protokollOkSinge As String = doUI.getRes("PlansSended")
                                protokollOkSinge += " (" + anzPläne.ToString() + ")"
                                protokollOk = protokollOkSinge + "!" + vbNewLine + protokollOk
                            Else
                                Throw New Exception("rPlanOwner.IDArt '" + rPlanOwner.IDArt.ToString() + "' not allowed!")
                            End If

                        ElseIf typAction = eTypAction.saveButtClicked Then
                            Dim txt As String = doUI.getRes("PlansSaved")
                            txt += " (" + anzPläne.ToString() + ")"
                            protokollOk = txt + vbNewLine + protokollOk
                        End If

                    End If
                End If

                dsInteropPar1 = New dsInteropPar()
                If Me.rPlan.IDArt = clPlan.typPlan_EMailGesendet Then
                    If typAction = eTypAction.sendEMailClicked Or typAction = eTypAction.sendPlanClicked Then
                        Dim rPlanNew As dsPlan.planRow = Nothing

                        If Me.rPlan.IDArt = clPlan.typPlan_EMailGesendet Then
                            rPlanNew = rPlanOwner
                        Else
                            Throw New Exception("Me.rPlan.IDArt '" + Me.rPlan.IDArt.ToString() + "' not allowed!")
                        End If

                        Dim sendTo As String = Me.doEMailsForObjectsForControl(Nothing, protokollErr, True, False)
                        If rPlanNew.MailAn.Trim() <> "" Or sendTo.Trim() <> "" Or sendTo.Trim() <> "" Then
                            rPlanNew.MailAn += sendTo

                            Me.sendEMail(rPlanNew, rPlanOwner.ID, bSendOnServer, dsInteropPar1, False, rUsrAccount, protokollErr, anzEMails, anzErr)
                        End If

                        If bSendOnServer Then
                            If dsInteropPar1.InteropPar.Rows.Count > 0 Then
                                Me.genMain.addInteropSendEMail(dsInteropPar1)
                                protokollOk = dsInteropPar1.InteropPar.Rows.Count.ToString() + " E-Mail/s werden vom Server an Objekte versendet!" + vbNewLine + protokollOk
                            End If
                        Else
                            Dim txt As String = doUI.getRes("PlansSended")
                            txt = String.Format(txt, anzEMails.ToString()) + "!"
                            protokollOk = txt + vbNewLine + protokollOk
                        End If

                        Return True
                    Else
                        Return True
                    End If
                Else
                    Return True
                End If
            End If

            Throw New Exception("savePlan: Error saving Plan!")
            Return False

        Catch ex As Exception
            Throw New Exception("frmNachricht.savePlan2: " + ex.ToString())
        Finally
            If Not protokollOk.Trim() = "" Then
                MsgBox(protokollOk, MsgBoxStyle.Information, doUI.getRes("Save"))
            End If
            Me.doProtokoll(protokollErr, doUI.getRes("SavePlan"))
        End Try
    End Function

    Public Function setPlanRowTemp(ByRef rPlanToSet As dsPlan.planRow,
                             ByRef Usr As String, ByRef IDPlanMain As System.Guid,
                             ByVal typAction As eTypAction, ByRef IDSerientermin As Nullable(Of Guid)) As Boolean
        Try
            rPlanToSet.Betreff = Me.txtBetreff.Text
            rPlanToSet.IDArt = Me.IDArt
            If General.IsNull(Me.dteBeginntAm.Value) Then
                rPlanToSet.SetBeginntAmNull()
            Else
                rPlanToSet.BeginntAm = Me.dteBeginntAm.Value
            End If

            rPlanToSet.Priorität = Me.cboPriorität.Text
            If (Not Me.optStatus.Value Is Nothing) Then
                If Me.optStatus.CheckedIndex = 0 Then
                    Me.rPlan.Status = "Offen"
                ElseIf Me.optStatus.CheckedIndex = 1 Then
                    Me.rPlan.Status = "Erledigt"
                Else
                    Throw New Exception("setPlanRowTemp: Me.optStatus.CheckedIndex '" + Me.optStatus.CheckedIndex.ToString() + "' not allowed!")
                End If
            Else
                Me.rPlan.Status = "Offen"
            End If

            If Not Me.General.IsNull(IDPlanMain) Then
                rPlanToSet.IDPlanMain = IDPlanMain
            Else
                rPlanToSet.SetIDPlanMainNull()
            End If

            rPlanToSet.SetIDActivityNull()
            Dim lstSelectedCategories As New System.Collections.Generic.List(Of Guid)()
            Me.rPlan.Category = Me.contSelectSelListCategories.getSelectedData(lstSelectedCategories)

            Dim text As String = ""
            Dim typTxt As New TXTextControl.StreamType
            If Me.isHtml Then
                typTxt = TXTextControl.StreamType.HTMLFormat
            Else
                typTxt = TXTextControl.StreamType.PlainText
            End If

            If Me.isHtml Then
                text = Me.winFormHtmlEditor1.DocumentHtml
            Else
                text = Me.winFormHtmlEditor1.Content.GetBodyText()
            End If

            If Not General.IsNull(text) Then
                rPlanToSet.Text = text
                rPlanToSet.html = Me.isHtml
            Else
                rPlanToSet.Text = ""
                rPlanToSet.html = False
            End If

            If Usr.Trim() <> "" Then
                rPlanToSet.Für = Usr
            End If

            rPlanToSet.Zusatz = ""
            rPlanToSet.MailAn = Me.txtMailAn.Text.Trim()
            rPlanToSet.MailCC = Me.txtMailCC.Text.Trim()
            rPlanToSet.MailBcc = Me.txtMailBCC.Text.Trim()
            rPlanToSet.IsgesendetAmNull()


            If Me.dteEndetAm.Value Is Nothing Then
                Me.rPlan.SetEndetAmNull()
            Else
                Me.rPlan.EndetAm = Me.dteEndetAm.DateTime
            End If
            If Me.cboDauer.Value Is Nothing OrElse Me.cboDauer.Value Is System.DBNull.Value OrElse Me.cboDauer.Value = -1 Then
                rPlan.Dauer = -1
            Else
                rPlan.Dauer = Me.cboDauer.Value
            End If
            Me.rPlan.GanzerTag = Me.chkGanzerTag.Checked

            If Me.rPlan.GanzerTag Then
                Dim EndetAmEndeTmp As Date = New Date(Me.rPlan.BeginntAm.Date.Year, Me.rPlan.BeginntAm.Date.Month, Me.rPlan.BeginntAm.Date.Day, 23, 59, 59)
                Me.rPlan.EndetAm = EndetAmEndeTmp
            End If

            Me.rPlan.IsSerientermin = Me.chkIsSerientermin.Checked
            If IDSerientermin Is Nothing Then
                Me.rPlan.SetIDSerienterminNull()
            Else
                Me.rPlan.IDSerientermin = IDSerientermin.Value
            End If

            If Me.dteSerienterminEndetAm.Value Is Nothing Then
                Me.rPlan.SetSerienterminEndetAmNull()
            Else
                Me.rPlan.SerienterminEndetAm = Me.dteSerienterminEndetAm.DateTime.Date
            End If

            If (Not Me.optSerienterminType.Value Is Nothing) Then
                If Me.optSerienterminType.CheckedIndex = 0 Then
                    Me.rPlan.SerienterminType = "1"
                ElseIf Me.optSerienterminType.CheckedIndex = 1 Then
                    Me.rPlan.SerienterminType = "2"
                ElseIf Me.optSerienterminType.CheckedIndex = 2 Then
                    Me.rPlan.SerienterminType = "3"
                Else
                    Throw New Exception("frmNachricht.setPlanRowTemp: Me.optSerienterminType.CheckedIndex '" + Me.optSerienterminType.CheckedIndex.ToString() + "' not allowed!")
                End If
            Else
                Me.rPlan.SerienterminType = ""
            End If

            If Me.iWiedWertJeden.Value Is System.DBNull.Value Then
                Me.rPlan.SetWiedWertJedenNull()
            Else
                Me.rPlan.WiedWertJeden = Me.iWiedWertJeden.Value
            End If

            If (Not Me.opTagWochenMonat.Value Is Nothing) Then
                If Me.opTagWochenMonat.CheckedIndex = 0 Then
                    Me.rPlan.TagWochenMonat = "0"
                ElseIf Me.opTagWochenMonat.CheckedIndex = 1 Then
                    Me.rPlan.TagWochenMonat = "1"
                ElseIf Me.opTagWochenMonat.CheckedIndex = 2 Then
                    Me.rPlan.TagWochenMonat = "2"
                Else
                    Throw New Exception("frmNachricht.setPlanRowTemp: Me.opTagWochenMonat.CheckedIndex '" + Me.opTagWochenMonat.CheckedIndex.ToString() + "' not allowed!")
                End If
            Else
                Me.rPlan.TagWochenMonat = ""
            End If

            If Me.iNTenMonat.Value Is System.DBNull.Value Then
                Me.rPlan.SetnTenMonatNull()
            Else
                Me.rPlan.nTenMonat = Me.iNTenMonat.Value
            End If

            Me.rPlan.Wochentage = Me.getWochentage()


            If rPlanToSet.IDArt = 2 Then
                If Me.frmStatus = General.eStatusForm.neu Then
                    rPlanToSet.design = True
                End If
            Else
                rPlanToSet.design = False
            End If

            rPlanToSet.SendWithPostOfficeBoxForAll = Me.chkSendWithPostOfficeBoxForAll.Checked

            If Me.frmStatus = General.eStatusForm.neu Then
                Dim UserLoggedIn As String = Me.genMain.getLoggedInUser()
                rPlanToSet.ErstelltVon = UserLoggedIn.Trim()
                rPlanToSet.ErstelltAm = Now
            End If

            rPlanToSet.LastChangeITSCont = Now
            rPlanToSet.LastSyncToExchange = Now

            Return True

        Catch ex As Exception
            Throw New Exception("frmNachricht.setPlanRowTemp: " + ex.ToString())
        End Try
    End Function
    Public Function saveNachrichtToDb2() As Boolean
        Try
            Me.compPlan1.daPlan.Update(Me.dsPlan1.plan)
            Me.contSelectBenutzer.saveData()
            Me.contSelectPatienten.saveData()
            Me.contListeAnhang.save(rPlan.ID)

            General.GarbColl()
            Return True

        Catch ex As Exception
            Throw New Exception("frmNachricht.saveNachrichtToDb2: " + ex.ToString())
        End Try
    End Function

    Public Function getWochentage() As String
        Try
            Dim sWochentage As String = ""

            If Me.cbMo.Checked Then
                sWochentage += "Mo;"
            End If
            If Me.cbDi.Checked Then
                sWochentage += "Di;"
            End If
            If Me.cbMi.Checked Then
                sWochentage += "Mi;"
            End If
            If Me.cbDo.Checked Then
                sWochentage += "Do;"
            End If
            If Me.cbFr.Checked Then
                sWochentage += "Fr;"
            End If
            If Me.cbSa.Checked Then
                sWochentage += "Sa;"
            End If
            If Me.cbSo.Checked Then
                sWochentage += "So;"
            End If

            Return sWochentage.Trim()

        Catch ex As Exception
            Throw New Exception("frmNachricht.getWochentage: " + ex.ToString())
        End Try
    End Function
    Public Sub setWochentage(ByRef sWochentage As String)
        Try
            If sWochentage.Trim().Contains(("Mo;")) Then
                Me.cbMo.Checked = True
            Else
                Me.cbMo.Checked = False
            End If
            If sWochentage.Trim().Contains(("Di;")) Then
                Me.cbDi.Checked = True
            Else
                Me.cbDi.Checked = False
            End If
            If sWochentage.Trim().Contains(("Mi;")) Then
                Me.cbMi.Checked = True
            Else
                Me.cbMi.Checked = False
            End If
            If sWochentage.Trim().Contains(("Do;")) Then
                Me.cbDo.Checked = True
            Else
                Me.cbDo.Checked = False
            End If
            If sWochentage.Trim().Contains(("Fr;")) Then
                Me.cbFr.Checked = True
            Else
                Me.cbFr.Checked = False
            End If
            If sWochentage.Trim().Contains(("Sa;")) Then
                Me.cbSa.Checked = True
            Else
                Me.cbSa.Checked = False
            End If
            If sWochentage.Trim().Contains(("So;")) Then
                Me.cbSo.Checked = True
            Else
                Me.cbSo.Checked = False
            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht.setWochentage: " + ex.ToString())
        End Try
    End Sub

    Public Sub setUIEndetAm(IsGanzerTag As Boolean)
        Try
            If IsGanzerTag  Then
                Me.dteEndetAm.Value = Nothing
                Me.cboDauer.Value = Nothing
                Me.dteEndetAm.Visible = False
                Me.lblEndAt.Visible = False
                Me.cboDauer.Visible = False
            Else
                Me.dteEndetAm.Visible = True
                Me.lblEndAt.Visible = True
                Me.cboDauer.Visible = True
            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht2.setUIEndetAm: " + ex.ToString())
        End Try
    End Sub

    Public Sub SerienterminTypeOrTagWochenMonat_ValueChanged()
        Try
            Dim sSerienterminType As String = ""
            If (Not Me.optSerienterminType.Value Is Nothing) Then
                sSerienterminType = Me.optSerienterminType.Value.ToString().Trim()
            End If
            Dim sTagWochenMonat As String = ""
            If (Not Me.opTagWochenMonat.Value Is Nothing) Then
                sTagWochenMonat = Me.opTagWochenMonat.Value.ToString().Trim()
            End If

            Me.setUISerientermine(sSerienterminType, sTagWochenMonat)

        Catch ex As Exception
            Throw New Exception("frmnachricht2.SerienterminTypeOrTagWochenMonat_ValueChanged: " + ex.ToString())
        End Try
    End Sub

    Public Function sendEMail(ByRef rPlanToSend As dsPlan.planRow, ByVal IDParent As System.Guid,
                              ByRef bSendOnServer As Boolean, ByRef dsInteropPar1 As dsInteropPar, ByRef doSendServer As Boolean,
                              ByRef rUsrAccount As dsUserAccounts.tblUserAccountsRow,
                              ByRef protokollTxt As String, ByRef anz As Integer, ByRef anzErr As Integer) As Boolean
        Try
            Dim dsPlanToSend As New dsPlan()
            Me.compPlan1.getPlanAnhang(rPlanToSend.ID, compPlan.eTypSelPlanAnhang.idPlan, dsPlanToSend)
            If rPlanToSend.MailAn.Trim() <> "" Or rPlanToSend.MailCC.Trim() <> "" Then
                Dim bSendOK As Boolean = False
                If bSendOnServer Then
                    bSendOK = Me.genMain.addInteropPar(rPlanToSend.ID, IDParent, dsInteropPar1)
                    If doSendServer Then
                        bSendOK = Me.genMain.addInteropSendEMail(dsInteropPar1)
                    End If
                Else
                    bSendOK = Me.clPlan1.sendEMailxy(rPlanToSend.MailAn.Trim(), rPlanToSend.MailCC.Trim(), rPlanToSend.MailBcc.Trim(), False,
                                      rPlanToSend.Betreff, rPlanToSend.Text, dsPlanToSend.planAnhang, rPlanToSend.html, True,
                                      rPlanToSend.ID, IDParent, False, True, protokollTxt, False, rUsrAccount, False, False)
                End If
                If bSendOK Then
                    anz += 1
                    Return True
                Else
                    protokollTxt = "Error: E-Mail '" + rPlanToSend.Betreff + "' could not send to '" + rPlanToSend.MailAn.Trim() + "'!" + vbNewLine + protokollTxt
                    anzErr += 1
                    Return False
                End If
            Else
                protokollTxt = doUI.getRes("ItWasNotSpecifiedEMailAddress") + vbNewLine + protokollTxt
                anzErr += 1
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht.sendEMail: " + ex.ToString())
        End Try
    End Function
    Public Function updateSendPlan(ByVal IDPlan As System.Guid, ByVal isOwner As Boolean, ByRef design As Boolean, ByVal empfangenAm As Date)
        Try
            Me.compPlan1.updateGesendetAm(IDPlan, Now)
            Me.compPlan1.UpdatePlanIsOwner(IDPlan, isOwner)
            Me.compPlan1.UpdatePlanDesign(IDPlan, design)
            If Not empfangenAm = Nothing Then
                Me.compPlan1.updateEmpfangenAm(IDPlan, empfangenAm)
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("frmNachricht.updateSendPlan: " + ex.ToString())
        End Try
    End Function

    Public Function setDBForNewPlan() As Boolean
        Try
            Me.dsPlan1 = New dsPlan()
            Me.compPlan1 = New compPlan()
            Me.compPlan1.getPlan(System.Guid.NewGuid(), compPlan.eTypSelPlan.id, Me.dsPlan1)
            Me.rPlan = Me.compPlan1.getNewRowPlan(Me.dsPlan1)

        Catch ex As Exception
            Throw New Exception("frmNachricht.setDBForNewPlan: " + ex.ToString())
        End Try
    End Function

    Public Sub setUIAfterLoading()
        Try
            If Me.IDArt = clPlan.typPlan_EMailGesendet Then
                Me.setUIEMailPostausgang()

            ElseIf Me.IDArt = clPlan.typPlan_EMailEmpfangen Then
                Me.setUIEMailPosteingang(True)

            ElseIf Me.IDArt = clPlan.typPlan_AufgabeTermin Then
                Me.setUIAufgabeTermin()

            ElseIf Me.IDArt = clPlan.typPlan_Notiz Then
                Me.setUINotiz()
                'ElseIf Me.chckIfIsWorkshop Then
                '    Me.setUIWorkshop()
                'ElseIf Me.chckIfIsSeminar() Or Me.chckIfIsWebinar() Or Me.chckIfIsTelTermin Or Me.chckIfIsTerminVorOrt() Or
                '    Me.chckIfIsAnfahrt() Or Me.chckIfIsAbfahrt() Then

                '    Me.setUIGeneralPlans()

                'ElseIf Me.chckIfIsWebauftrag() Then
                '    Me.setUIWebauftrag()

            Else
                Throw New Exception("setUIAfterLoading: plan.IDArt '" + Me.IDArt.ToString() + "' not defined!")
            End If

            Me.chkTextIsHtml.Enabled = True

        Catch ex As Exception
            Throw New Exception("frmNachricht.setUIAfterLoading: " + ex.ToString())
        End Try
    End Sub

    Public Sub setUIEMailPostausgang()
        Try
            If Me.frmStatus = General.eStatusForm.neu Or Me.rPlan.IsgesendetAmNull() Then

                Me.PanelMail.Height = Me.heigthPanelMail
                Me.PanelMailEmpfangenAmGesendetAm.Height = 24
                Me.grpTop.Height = Me.heigthAllOnTop

                Me.btnSendPlan.Visible = False

                Me.toolbarsManagerMain.Toolbars(0).Tools("btnAntworten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
                Me.toolbarsManagerMain.Toolbars(0).Tools("btnAllenAntworten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
                Me.toolbarsManagerMain.Toolbars(0).Tools("btnWeiterleiten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
                Me.btnSendEMails.Visible = True

                Me.setEditAfterLoading()

            ElseIf Me.frmStatus = General.eStatusForm.edit Then
                Me.setUIEMailPosteingang(False)

            End If

            If rPlan.IsgesendetAmNull() Then
                Me.setLabelsEmpfangenAmGesendetAm(True, Nothing, "")
                If Me.frmStatus = General.eStatusForm.edit Then
                    Me.lblEmpfangenAmGesendetAm.Text = doUI.getRes("NotYetBeenSent")
                End If
            Else
                Me.setLabelsEmpfangenAmGesendetAm(True, rPlan.gesendetAm, "")
            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht.setUIEMailPostausgang: " + ex.ToString())
        End Try
    End Sub
    Public Sub setUIEMailPosteingang(ByVal showMIMEButt As Boolean)
        Try
            Me.PanelMail.Height = Me.heigthPanelMail
            Me.PanelMailEmpfangenAmGesendetAm.Height = 24
            Me.grpTop.Height = Me.heigthAllOnTop

            Me.btnSendPlan.Visible = False

            Me.toolbarsManagerMain.Toolbars(0).Tools("btnAntworten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.True
            Me.toolbarsManagerMain.Toolbars(0).Tools("btnAllenAntworten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.True
            Me.toolbarsManagerMain.Toolbars(0).Tools("btnWeiterleiten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.True
            Me.btnSendEMails.Visible = False

            Me.setEditAfterLoading()

            'Me.toolbarsManagerMain.Toolbars(0).Tools("DateiHinzufügen").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.True

            Me.toolbarsManagerMain.Tools("DateiHinzufügen").SharedProps.Visible = True

        Catch ex As Exception
            Throw New Exception("frmNachricht.setUIEMailPosteingang: " + ex.ToString())
        End Try
    End Sub

    Public Sub setUIAufgabeTermin()
        Try
            If Me.rPlan.IsgesendetAmNull() Then
                Me.btnSendPlan.Visible = False
            Else
                Me.btnSendPlan.Visible = False
            End If

            'Me.Icon = General.ImageToIcon(Global.ITSCont.plan.ui.My.Resources.Resources.ICO_Planungsystem)
            Me.PanelMail.Height = 0
            Me.grpTop.Height = Me.heigthMinimalOnTop

            Me.toolbarsManagerMain.Toolbars(0).Tools("btnAntworten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
            Me.toolbarsManagerMain.Toolbars(0).Tools("btnAllenAntworten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
            Me.toolbarsManagerMain.Toolbars(0).Tools("btnWeiterleiten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
            Me.btnSendEMails.Visible = False
            Me.setEditAfterLoading()

        Catch ex As Exception
            Throw New Exception("frmNachricht.setUIAufgabeTermin: " + ex.ToString())
        End Try
    End Sub

    Public Sub setUINotiz()
        Try
            'Me.Icon = General.ImageToIcon(Global.ITSCont.plan.ui.My.Resources.Resources.ICO_Planungsystem)
            Me.PanelMail.Height = 0
            Me.grpTop.Height = Me.heigthMinimalOnTop

            If Me.rPlan.IsgesendetAmNull() Then
                Me.btnSendPlan.Visible = False
            Else
                Me.btnSendPlan.Visible = False
            End If

            Me.toolbarsManagerMain.Toolbars(0).Tools("btnAntworten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
            Me.toolbarsManagerMain.Toolbars(0).Tools("btnAllenAntworten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
            Me.toolbarsManagerMain.Toolbars(0).Tools("btnWeiterleiten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
            Me.btnSendEMails.Visible = False
            Me.setEditAfterLoading()

        Catch ex As Exception
            Throw New Exception("frmNachricht.setUINotiz: " + ex.ToString())
        End Try
    End Sub

    Public Sub setEditAfterLoading()
        Try
            Me.winFormHtmlEditor1.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.WYSIWYG_Design

            If frmStatus = General.eStatusForm.edit Then
                Me.chkSendWithPostOfficeBoxForAll.Visible = False

                If Me.IDArt = clPlan.typPlan_EMailEmpfangen Then
                    Me.lockUnlock(False)
                    Me.toolbarsManagerMain.Toolbars(0).Tools("btnAntworten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.True
                    Me.toolbarsManagerMain.Toolbars(0).Tools("btnAllenAntworten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.True
                    Me.toolbarsManagerMain.Toolbars(0).Tools("btnWeiterleiten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.True

                    Me.contSelectBenutzer.lockUnlock(True)
                    Me.contSelectPatienten.lockUnlock(True)
                    Me.contListeAnhang.lockUnlockMain(True)

                    Me.winFormHtmlEditor1.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.ReadOnly_Preview

                ElseIf Me.IDArt = clPlan.typPlan_EMailGesendet Then
                    If Me.rPlan.IsgesendetAmNull() Then
                        Me.lockUnlock(True)
                    Else
                        Me.lockUnlock(False)
                        Me.toolbarsManagerMain.Toolbars(0).Tools("btnAntworten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.True
                        Me.toolbarsManagerMain.Toolbars(0).Tools("btnAllenAntworten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.True
                        Me.toolbarsManagerMain.Toolbars(0).Tools("btnWeiterleiten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.True
                    End If
                    Me.chkSendWithPostOfficeBoxForAll.Visible = True

                ElseIf Me.IDArt = clPlan.typPlan_AufgabeTermin Then
                    If Me.rPlan.IsgesendetAmNull() Then
                        Me.lockUnlock(True)
                    Else
                        Me.lockUnlock(Me.rPlan.IsOwner)
                        Me.winFormHtmlEditor1.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.ReadOnly_Preview
                    End If
                    Me.toolbarsManagerMain.Toolbars(0).Tools("btnAntworten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
                    Me.toolbarsManagerMain.Toolbars(0).Tools("btnAllenAntworten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
                    Me.toolbarsManagerMain.Toolbars(0).Tools("btnWeiterleiten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False

                ElseIf Me.IDArt = clPlan.typPlan_Notiz Then
                    Me.lockUnlock(True)
                    Me.toolbarsManagerMain.Toolbars(0).Tools("btnAntworten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
                    Me.toolbarsManagerMain.Toolbars(0).Tools("btnAllenAntworten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False
                    Me.toolbarsManagerMain.Toolbars(0).Tools("btnWeiterleiten").InstanceProps.Visible = Infragistics.Win.DefaultableBoolean.False

                End If

                Me.chkSendWithPostOfficeBoxForAll.Visible = False
                Me.chkSendWithPostOfficeBoxForAll.Checked = False

                If Me.IDArt = clPlan.typPlan_EMailEmpfangen Then
                    Me.lockUnlock(False)
                    Me.winFormHtmlEditor1.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.ReadOnly_Preview

                ElseIf Me.IDArt = clPlan.typPlan_EMailGesendet Then
                    Me.lockUnlock(True)
                    Me.chkSendWithPostOfficeBoxForAll.Visible = True
                    Dim PreferPostOfficeBoxForAll As Boolean = False
                    Me.chkSendWithPostOfficeBoxForAll.Checked = PreferPostOfficeBoxForAll

                ElseIf Me.IDArt = clPlan.typPlan_AufgabeTermin Then
                    Me.lockUnlock(True)
                ElseIf Me.IDArt = clPlan.typPlan_Notiz Then
                    Me.lockUnlock(True)

                End If
            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht.setEditAfterLoading: " + ex.ToString())
        End Try
    End Sub
    Public Sub lockUnlock(ByVal bEdit As Boolean)
        Try
            Me.isEditable = bEdit

            Me.btnSendEMails.Enabled = bEdit
            Me.btnSearchAn.Enabled = bEdit
            Me.btnSearchCc.Enabled = bEdit
            Me.btnBcc.Enabled = bEdit

            Me.btnSave.Enabled = bEdit
            Me.toolbarsManagerMain.Tools("DateiHinzufügen").SharedProps.Visible = bEdit
            Me.lblAutoEMailAn.Enabled = bEdit

            Dim styleButtDropDown As New Infragistics.Win.ButtonDisplayStyle
            If bEdit Then
                styleButtDropDown = Infragistics.Win.ButtonDisplayStyle.Always
            Else
                styleButtDropDown = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter
            End If

            Dim ui As New UI()
            ui.lockUnlockOneControl(Me.PanelMailAdr, bEdit)
            ui.lockUnlockOneControl(Me.PanelDatum, bEdit)
            ui.lockUnlockOneControl(Me.PanelBetreff, bEdit)

            'Me.lblMailVon.Enabled = bEdit
            'Me.labelEmpfangenGesendet.Enabled = bEdit
            'Me.lblEmpfangenAmGesendetAm.Enabled = bEdit

            Me.dteBeginntAm.DropDownButtonDisplayStyle = styleButtDropDown
            Me.cboPriorität.DropDownButtonDisplayStyle = styleButtDropDown
            'Me.cboArt2.cboComboBoxSelList.DropDownButtonDisplayStyle = styleButtDropDown

            Me.contSelectBenutzer.lockUnlock(True)
            Me.contSelectPatienten.lockUnlock(True)
            Me.contListeAnhang.lockUnlockMain(bEdit)

            If Me.frmStatus = General.eStatusForm.edit Then
                'Me.lblArt.Visible = False
                'Me.cboArt2.Visible = False
            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht.lockUnlock: " + ex.ToString())
        End Try
    End Sub




    Public Function isHtml() As Boolean
        Try
            Return Me.chkTextIsHtml.Checked

        Catch ex As Exception
            Throw New Exception("frmNachricht.isHtml: " + ex.ToString())
        End Try
    End Function
    Public Sub setHtml(ByVal isHTML As Boolean, ByRef setBodyText As Boolean)
        Try
            Me.chkTextIsHtml.Checked = isHTML
            Me.UltraTabControlText.Tabs(0).Visible = isHTML
            Me.toolbarsManagerText.Tools("btnWebbrowser").SharedProps.Visible = isHTML

            If setBodyText Then
                If isHTML Then
                    If Me.frmStatus = General.eStatusForm.edit Then
                        Me.winFormHtmlEditor1.Content.SetDocumentHtml(Me.rPlan.Text.Trim())
                    Else
                        Me.winFormHtmlEditor1.Content.SetDocumentHtml(Me.LastTextBody)
                    End If
                Else
                    If Me.frmStatus = General.eStatusForm.edit Then
                        Me.winFormHtmlEditor1.Content.SetBodyText(Me.rPlan.Text.Trim())
                    Else
                        Me.winFormHtmlEditor1.Content.SetBodyText(Me.LastTextBody)
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht.setHtml: " + ex.ToString())
        End Try
    End Sub

    Public Sub setLabelsEmpfangenAmGesendetAm(ByVal setLabelGesendetAm As Boolean, ByVal dDate As Date, ByVal MailVon As String)
        Try
            If setLabelGesendetAm Then
                Me.labelVon.Visible = False
                Me.lblMailVon.Visible = False
                Me.labelEmpfangenGesendet.Visible = True
                Me.lblEmpfangenAmGesendetAm.Visible = True
                Me.labelEmpfangenGesendet.Text = doUI.getRes("SendedOn") + ":"

            Else
                Me.labelVon.Visible = True
                Me.lblMailVon.Visible = True
                Me.labelEmpfangenGesendet.Visible = True
                Me.lblEmpfangenAmGesendetAm.Visible = True
                Me.labelEmpfangenGesendet.Text = doUI.getRes("ReceivedOn") + ":"

            End If

            If Not dDate = Nothing Then
                Me.lblEmpfangenAmGesendetAm.Text = dDate.ToString("dd.MM.yyyy HH:mm:ss")
            Else
                Me.lblEmpfangenAmGesendetAm.Text = ""
            End If

            Me.lblMailVon.Text = MailVon

        Catch ex As Exception
            Throw New Exception("frmNachricht.setLabelsEmpfangenAmGesendetAm: " + ex.ToString())
        End Try
    End Sub
    Public Sub setUIEMailAdressesOnOff()
        Try
            Me.lockToolbar = True

            If Me.txtMailAn.Text.Trim() <> "" Or Me.txtMailCC.Text.Trim() <> "" Or Me.txtMailBCC.Text.Trim() <> "" Then
                Me.PanelMail.Height = Me.heigthPanelMail
                Me.grpTop.Height = Me.heigthAllOnTop
            Else
                Me.PanelMail.Height = 0
                Me.grpTop.Height = Me.heigthMinimalOnTop
            End If
            Me.lockToolbar = False

        Catch ex As Exception
            Me.lockToolbar = False
            Throw New Exception("frmNachricht.setUIEMailAdressesOnOff: " + ex.ToString())
        End Try
    End Sub

    Public Sub doProtokoll(ByRef protkoll As String, ByRef title As String)
        Try
            If protkoll.Trim() <> "" Then
                Dim frmProt As New QS2.core.vb.frmProtocol()
                frmProt.initControl()
                frmProt.Show()
                frmProt.ContProtocol1.setText(protkoll.Trim())
                frmProt.Text = title
            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht.doProtokoll: " + ex.ToString())
        End Try
    End Sub
    Public Function searchObjekts(ByRef txtControl As Infragistics.Win.UltraWinEditors.UltraTextEditor,
                                    ByVal typUI As eTypUIPlan)
        Try


        Catch ex As Exception
            Throw New Exception("frmNachricht.searchObjekts: " + ex.ToString())
        End Try
    End Function

    Public Function doEMailsForObjectsForControl(ByRef txtControl As Infragistics.Win.UltraWinEditors.UltraTextEditor,
                                       ByRef protokoll As String, ByRef withSachbearbeiter As Boolean, ByVal withObjekte As Boolean) As String
        Try
            Dim AdressesFound As String = ""
            If withObjekte Then
                For Each rObj As dsPlan.planObjectRow In tPlanObjectsAllCopy
                    Dim mailFound As String = Me.doEMailsForOneObject(rObj.IDObject, protokoll)
                    If mailFound.Trim() <> "" Then
                        AdressesFound += mailFound.Trim()
                    End If
                Next
            End If

            If txtControl Is Nothing Then
                Return AdressesFound
            Else
                txtControl.Text += AdressesFound
            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht.doEMailsForObjectsForControl: " + ex.ToString())
        End Try
    End Function
    Public Function doEMailsForOneObject(ByRef IDObject As System.Guid, ByRef protokoll As String) As String
        Try
            Dim AdressesFound As String = ""
            Dim b As New PMDS.db.PMDSBusiness()
            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                Dim rUsr As PMDS.db.Entities.Benutzer = b.getUser(IDObject, db)
                Dim rKont As PMDS.db.Entities.Kontakt = b.getKontakt(rUsr.IDKontakt, db)
                Dim EMailToTake As String = ""
                If rKont.Email.Trim() <> "" Then
                    EMailToTake = rKont.Email.Trim()
                End If

                If EMailToTake.Trim() <> "" Then
                    If clPlan.IsValidEmail(EMailToTake, protokoll, rUsr.Nachname.Trim() + " " + rUsr.Vorname.Trim()) Then
                        AdressesFound = EMailToTake.Trim() + ";"
                    End If
                Else
                    Dim txt As String = doUI.getRes("NoEMailAdressFoundForObject")
                    txt = String.Format(txt, rUsr.Nachname.Trim() + " " + rUsr.Vorname.Trim())
                    protokoll = txt + "!" + vbNewLine + protokoll
                End If
            End Using

            Return AdressesFound

        Catch ex As Exception
            Throw New Exception("frmNachricht.doEMailsForOneObject: " + ex.ToString())
        End Try
    End Function

#End Region

    Public Sub setErstelltVon(ByVal ErstelltVon As String, ByVal ErstelltAm As Date)
        Try
            Me.lblErstelltAm.Text = doUI.getRes("Generated") + ": " + Format(ErstelltAm, "dd.MM.yyyy HH:mm").ToString
            Me.lblErstelltVon.Text = doUI.getRes("GeneratedFrom") + ": " + ErstelltVon

        Catch ex As Exception
            Throw New Exception("frmNachricht.setErstelltVon: " + ex.ToString())
        End Try
    End Sub
    Public Sub setInfoGeneral(IDUserAccount As Nullable(Of Guid), clear As Boolean)
        Try
            If clear Then
                Me.UltraToolTipManager1.SetUltraToolTip(Me.picInfo, Nothing)
            Else
                Dim txtInfo As String = ""

                txtInfo += IIf(Me.rPlan.Für.Trim() <> "", doUI.getRes("For") + ": " + Me.rPlan.Für.Trim(), "") + vbNewLine
                If Me.rPlan.IsIDPlanMainNull() Then
                    txtInfo += " (" + doUI.getRes("Producer2") + ")" + vbNewLine
                End If

                txtInfo += doUI.getRes("Owner") + ": " + IIf(Me.rPlan.IsOwner, doUI.getRes("Yes"), doUI.getRes("No")) + vbNewLine
                If Not Me.rPlan.IsempfangenAmNull() Then
                    txtInfo += doUI.getRes("ReceivedOn") + ": " + Me.rPlan.empfangenAm.ToString("dd.MM.yyyy HH:mm:ss") + vbNewLine
                End If

                If Me.rPlan.IsgesendetAmNull() Then
                    txtInfo += doUI.getRes("NotYetBeenSent") + vbNewLine
                Else
                    txtInfo += doUI.getRes("SendedOn") + ": " + Me.rPlan.gesendetAm.ToString("dd.MM.yyyy HH:mm:ss") + vbNewLine
                End If

                If Me.rPlan.design Then txtInfo += doUI.getRes("IsDesign") + vbNewLine
                If Me.rPlan.deleted Then txtInfo += doUI.getRes("IsDesign") + vbNewLine

                If Not IDUserAccount Is Nothing Then
                    Dim compUserAccounts1 As New compUserAccounts()
                    Dim rUserAccount As dsUserAccounts.tblUserAccountsRow = compUserAccounts1.getUserAccountsRow(IDUserAccount, "", compUserAccounts.eTypSelUserAccounts.id, compUserAccounts.eTypEMailAccount.SMTP, True, True)
                    If Me.chkSendWithPostOfficeBoxForAll.Checked Then
                        Dim dsUserAccountsRead As New dsUserAccounts()
                        compUserAccounts1.getUserAccounts(Nothing, "", dsUserAccountsRead, compUserAccounts.eTypSelUserAccounts.PostOfficeBoxForAll, compUserAccounts.eTypEMailAccount.SMTP, True)
                        If dsUserAccountsRead.tblUserAccounts.Rows.Count > 0 Then
                            rUserAccount = dsUserAccountsRead.tblUserAccounts.Rows(0)
                        End If
                    End If

                    txtInfo += vbNewLine + doUI.getRes("Name") + "Name: " + rUserAccount.Name + vbNewLine +
                                    doUI.getRes("User") + ": " + rUserAccount.Usr + vbNewLine +
                                    doUI.getRes("Type") + ": " + rUserAccount.typ + vbNewLine +
                                    doUI.getRes("AdressFrom") + ": " + rUserAccount.AdrFrom + vbNewLine +
                                    doUI.getRes("Server") + ": " + rUserAccount.Server + vbNewLine +
                                    doUI.getRes("UserAuthentication") + ": " + rUserAccount.UsrAuthentication + vbNewLine +
                                    doUI.getRes("Port") + ": " + rUserAccount.Port + vbNewLine +
                                    doUI.getRes("SSL") + ": " + rUserAccount.SSL.ToString()

                    'Me.UltraStatusBar1.Panels("UserAccount").Text = doUI.getRes("UsedAccount") + ": " + rUserAccount.Name
                    'Me.UltraStatusBar1.Panels("UserAccount").ToolTipText = txtToolTip
                    'Me.UltraStatusBar1.Panels("InfosGeneral").Text = txt
                End If

                Dim info As New UltraToolTipInfo()
                info.ToolTipText = txtInfo
                Me.UltraToolTipManager1.SetUltraToolTip(Me.picInfo, info)

            End If
        Catch ex As Exception
            Throw New Exception("frmNachricht.setInfoGeneral: " + ex.ToString())
        End Try
    End Sub

    Private Sub UDtDateBeginnt_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles dteBeginntAm.Enter
        Try
            dteBeginntAm.SelectionStart = 0
            dteBeginntAm.SelectionLength = 100

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub btnSearchAn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchAn.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.searchObjekts(Me.txtMailAn, eTypUIPlan.Mailadresses)

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnSearchCc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCc.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.searchObjekts(Me.txtMailCC, eTypUIPlan.Mailadresses)

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnBcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBcc.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.searchObjekts(Me.txtMailBCC, eTypUIPlan.Mailadresses)

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub lblAutoEMailAn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAutoEMailAn.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            'Me.txtMailAn.Text = ""
            Dim protokoll As String = ""
            Me.doEMailsForObjectsForControl(Me.txtMailAn, protokoll, False, True)
            If protokoll.Trim() <> "" Then
                protokoll = doUI.getRes("ErrorsEMailAdresses") + ":" + vbNewLine + vbNewLine + protokoll
                Me.doProtokoll(protokoll, doUI.getRes("Plans"))
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub toolbarsManagerText_ToolClick(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinToolbars.ToolClickEventArgs) Handles toolbarsManagerText.ToolClick
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.lockToolbarTxt Then Exit Sub

            Select Case e.Tool.Key

                Case "btnIntEditor"
                    Me.setToolBarBody(False)
                'Dim typUI As New ITSCont.editor.etyp()
                'If Me.isEditable Then
                '    typUI = editor.etyp.all
                'Else
                '    typUI = editor.etyp.onlyShow
                'End If
                'Dim StreamTypeShow As New TXTextControl.StreamType
                'If Me.rPlan.html Then
                '    StreamTypeShow = TXTextControl.StreamType.HTMLFormat
                'Else
                '    StreamTypeShow = TXTextControl.StreamType.PlainText
                'End If
                'Me.ContTxtEditor1.typUI = typUI
                'Me.ContTxtEditor1.showText(Me.rPlan.Text, StreamTypeShow, Me.isEditable, Me.standardViewExtEditor)

                Case "btnWebbrowser"
                    Me.setToolBarBody(True)
                    Me.showTabText(0)

            End Select

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub setToolBarBody(ByVal Browser As Boolean)
        Try
            Me.lockToolbarTxt = True
            Dim butt As StateButtonTool

            If Browser Then
                butt = Me.toolbarsManagerText.Tools("btnWebbrowser")
                butt.Checked = True
                Me.UltraTabControlText.SelectedTab = Me.UltraTabControlText.Tabs(0)
            Else
                butt = Me.toolbarsManagerText.Tools("btnIntEditor")
                butt.Checked = True
                Me.UltraTabControlText.SelectedTab = Me.UltraTabControlText.Tabs(1)
            End If

            Me.lockToolbarTxt = False

        Catch ex As Exception
            Me.lockToolbarTxt = False
            Throw New Exception("frmNachricht.setToolBarBody: " + ex.ToString())
        End Try
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendEMails.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim rSelUserAccount As dsUserAccounts.tblUserAccountsRow = Nothing
            If Me.savePlan2(eTypAction.sendEMailClicked, rSelUserAccount) Then
                Dim cOutlookWebAPI1 As New cOutlookWebAPI()
                cOutlookWebAPI1.saveToOutlook(Me.rPlan.ID, Me.rPlan.SendWithPostOfficeBoxForAll, rSelUserAccount, True)
                Me.abort = False
                Me.Close()
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub chkTextIsHtml_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTextIsHtml.CheckedChanged
        Try
            If Me.chkTextIsHtml.Focused Then
                Me.setHtml(Me.chkTextIsHtml.Checked, True)
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub labelVon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles labelVon.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.wechselnZuEMail()

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Public Sub wechselnZuEMail()
        Try


        Catch ex As Exception
            Throw New Exception("frmNachricht.wechselnZuEMail: " + ex.ToString())
        End Try
    End Sub

    Private Sub lblAutoEMailBcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAutoEMailBcc.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            'Me.txtMailBCC.Text = ""
            Dim protokoll As String = ""
            Me.doEMailsForObjectsForControl(Me.txtMailBCC, protokoll, False, True)
            If protokoll.Trim() <> "" Then
                protokoll = doUI.getRes("ErrorsEMailAdresses") + ":" + vbNewLine + vbNewLine + protokoll
                Me.doProtokoll(protokoll, doUI.getRes("Plans"))
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub lblAutoEMailCc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAutoEMailCc.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            'Me.txtMailCC.Text = ""
            Dim protokoll As String = ""
            Me.doEMailsForObjectsForControl(Me.txtMailCC, protokoll, False, True)
            If protokoll.Trim() <> "" Then
                protokoll = doUI.getRes("ErrorsEMailAdresses") + ":" + vbNewLine + vbNewLine + protokoll
                Me.doProtokoll(protokoll, doUI.getRes("Plans"))
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnSendPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendPlan.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim rSelUserAccount As dsUserAccounts.tblUserAccountsRow = Nothing
            If Me.savePlan2(eTypAction.sendPlanClicked, rSelUserAccount) Then
                Dim cOutlookWebAPI1 As New cOutlookWebAPI()
                cOutlookWebAPI1.saveToOutlook(Me.rPlan.ID, Me.rPlan.SendWithPostOfficeBoxForAll, rSelUserAccount, True)
                Me.abort = False
                Me.Close()
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub PlanungsenträgeDieZuDiesemEintragGehörenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlanungsenträgeDieZuDiesemEintragGehörenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim txtTitle As String = doUI.getRes("PlansForThisEntry")
            Dim ds As New dsPlan()
            Dim compPlanRead As New compPlan()
            compPlanRead.getPlan(Me.rPlan.ID, compPlan.eTypSelPlan.IDPlanMain, ds)
            Dim txt As String = ""
            For Each rPlan As dsPlan.planRow In ds.plan
                txt += "       " + doUI.getRes("Subject") + ": " + rPlan.Betreff + ",    " + doUI.getRes("Status") + ": " + rPlan.Status + ", " + doUI.getRes("Answer") + ": " + rPlan.ReplyTxt + ",   " + doUI.getRes("EMailTo") + ": " + rPlan.MailAn + ", " + doUI.getRes("Clerk") + ": " + rPlan.Teilnehmer + vbNewLine
            Next
            txt = ds.plan.Count.ToString() + " " + doUI.getRes("Founded") + "" + vbNewLine + txt
            Me.doProtokoll(txt, txtTitle)

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub EditierenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditierenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.lockUnlock(Me.EditierenToolStripMenuItem.Checked)
            Me.btnSendEMails.Enabled = Me.EditierenToolStripMenuItem.Checked
            Me.btnSendEMails.Visible = Me.EditierenToolStripMenuItem.Checked
            Me.btnSave.Enabled = Me.EditierenToolStripMenuItem.Checked

            Dim typUI As New General.etyp()
            If Me.EditierenToolStripMenuItem.Checked Then
                Me.btnSendPlan.Visible = False
                typUI = General.etyp.all
                Me.winFormHtmlEditor1.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.WYSIWYG_Design
            Else
                Me.btnSendPlan.Visible = False
                typUI = General.etyp.onlyShow
                Me.winFormHtmlEditor1.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.ReadOnly_Preview
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UltraTabControlText_SelectedTabChanged(sender As Object, e As Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs) Handles UltraTabControlText.SelectedTabChanged
        Try

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub frmNachricht_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            Me.Cursor = Cursors.WaitCursor
            If Me.Visible Then
                If Not Me.isOpend Then
                    Me.setTypeOnVisibleForModalDialog()
                End If
                Me.isOpend = True
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub setTypeOnVisibleForModalDialog()
        Try
            If Me.md_doForModalDialog Then
                If Me.md_eMail Then
                    Me.IDArt = 2
                    Me.setUIEMailPostausgang()
                    Me.txtMailAn.Text = Me.md_Mailadresse.Trim()
                    If md_body.Trim() <> "" Then
                        Me.textAnzeigenxy(md_body, md_bodyIsHtml, 2)
                    End If
                End If
                If Me.md_IDArt <> -1 Then
                    Me.IDArt = Me.md_IDArt
                End If
                If Me.md_betreff.Trim() <> "" Then
                    Me.txtBetreff.Text = Me.md_betreff.Trim()
                End If
            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht.setTypeOnVisibleForModalDialog: " + ex.ToString())
        End Try
    End Sub

    Private Sub PlanungseintragAusGesendeterListeLöschenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanungseintragAusGesendeterListeLöschenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim compPlanUpdate As New compPlan()
            compPlanUpdate.deletePlanStatus(Me.rPlan.ID, "sent")
            doUI.doMessageBox2("ItemIsMarkedAsNotSended", "", "!")

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim rSelUserAccount As dsUserAccounts.tblUserAccountsRow = Nothing
            If Me.savePlan2(eTypAction.saveButtClicked, rSelUserAccount) Then
                Dim cOutlookWebAPI1 As New cOutlookWebAPI()
                cOutlookWebAPI1.saveToOutlook(Me.rPlan.ID, Me.rPlan.SendWithPostOfficeBoxForAll, rSelUserAccount, True)
                Me.abort = False
                Me.Close()
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Close()

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub chkGanzerTag_CheckedChanged(sender As Object, e As EventArgs) Handles chkGanzerTag.CheckedChanged
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.setUIEndetAm(Me.chkGanzerTag.Checked)

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub cboDauer_ValueChanged(sender As Object, e As EventArgs) Handles cboDauer.ValueChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.cboDauer.Focused Then
                If (Not Me.dteBeginntAm.Value Is Nothing) And (Not Me.cboDauer.Value Is Nothing) Then
                    Dim iDauer As Integer = System.Convert.ToInt32(Me.cboDauer.Value.ToString().Trim())
                    Try
                        Me.dteEndetAm.DateTime = Me.dteBeginntAm.DateTime.AddMinutes(Me.cboDauer.Value)
                    Catch ex As Exception
                    End Try
                End If
            Else
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub chkIsSerientermin_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsSerientermin.CheckedChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.chkIsSerientermin.Checked Then
                Me.grpSerientermin.Visible = True
            Else
                Me.clearSerientermineUI()
                Me.grpSerientermin.Visible = False
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub optSerienterminType_ValueChanged(sender As Object, e As EventArgs) Handles optSerienterminType.ValueChanged
        Try
            Me.SerienterminTypeOrTagWochenMonat_ValueChanged()

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub opTagWochenMonat_ValueChanged(sender As Object, e As EventArgs) Handles opTagWochenMonat.ValueChanged
        Try
            Me.SerienterminTypeOrTagWochenMonat_ValueChanged()

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class
