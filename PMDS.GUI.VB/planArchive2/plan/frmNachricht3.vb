'Imports Infragistics.Win.UltraWinTree
'Imports Infragistics.Win.UltraWinListView
Imports Infragistics.Win.UltraWinToolbars
Imports System.Windows.Forms
'Imports System.Drawing
'Imports Infragistics.Win.UltraWinGrid
'Imports Microsoft.Exchange.WebServices.Data
Imports Infragistics.Win.UltraWinToolTip
Imports Infragistics.Win
Imports PMDS.Global.db.ERSystem
Imports S2Extensions

Public Class frmNachricht3
    Inherits System.Windows.Forms.Form

    Private contListTextTemplates1 As New contListTextTemplates()
    Private contSelectPatienten As New contSelectPatientenBenutzer()
    Private contSelectBenutzer As New contSelectPatientenBenutzer()
    Private compPlan1 As New compPlan()
    Private dsPlan1 As New dsPlan()
    Private General As New General
    Private standardViewExtEditor As TXTextControl.ViewMode
    Private genMain As New General()
    Private isLoaded As Boolean
    Private abort As Boolean = True
    Private lockToolbar As Boolean
    Private isEditable As Boolean = True
    Private clPlan1 As New clPlan()
    Private doUI1 As New doUI()
    Private typAntworten As eAntworten
    Private isFirstShow As Boolean = True
    Private doEditor1 As New QS2.Desktop.Txteditor.doEditor()
    Private contSelectSelListCategories As New contSelectSelList()
    Private b As New PMDS.db.PMDSBusiness()
    Private contTxtEditor1 As New QS2.Desktop.Txteditor.contTxtEditor()

    'Private doEditor As New QS2.Desktop.Txteditor.doEditor()
    'Public compUserAccounts1 As New compUserAccounts()

    Private _IDArt As Integer = -999
    Public Property IDArt As Integer
        Get
            Return _IDArt
        End Get
        Set(value As Integer)
            _IDArt = value
        End Set
    End Property

    Private _modalWindow As contPlanung2
    Public Property modalWindow As contPlanung2
        Get
            Return _modalWindow
        End Get
        Set(value As contPlanung2)
            _modalWindow = value
        End Set
    End Property

    Private _TypeUI As contPlanungData.eTypeUI
    Public Property TypeUI As contPlanungData.eTypeUI
        Get
            Return _TypeUI
        End Get
        Set(ByVal Value As contPlanungData.eTypeUI)
            _TypeUI = Value
        End Set
    End Property


    Private _PlanArchive As contPlanungData.cPlanArchive = New contPlanungData.cPlanArchive()
    Public Property PlanArchive As contPlanungData.cPlanArchive
        Get
            Return _PlanArchive
        End Get
        Set(value As contPlanungData.cPlanArchive)
            _PlanArchive = value
        End Set
    End Property


    Private frmStatus As New General.eStatusForm
    Private _rPlan
    Public Property rPlan As dsPlan.planRow
        Get
            Return _rPlan
        End Get
        Set(value As dsPlan.planRow)
            _rPlan = value
        End Set
    End Property


    Private _contListeAnhang As New contListeAnhang2
    Public Property contListeAnhang As contListeAnhang2
        Get
            Return _contListeAnhang
        End Get
        Set(value As contListeAnhang2)
            _contListeAnhang = value
        End Set
    End Property


    ' Public lockToolbarTxt = False
    Private _generatePlanForEachObj As Boolean
    Public Property generatePlanForEachObj As Boolean
        Get
            Return _generatePlanForEachObj
        End Get
        Set(value As Boolean)
            _generatePlanForEachObj = value
        End Set
    End Property

    Private _IDActivityForNewPlan As System.Guid = Nothing
    Public Property IDActivityForNewPlan As System.Guid
        Get
            Return _IDActivityForNewPlan
        End Get
        Set(value As System.Guid)
            _IDActivityForNewPlan = value
        End Set
    End Property

    Public Enum eTypAction
        sendEMailClicked = 0
        sendPlanClicked = 1
        saveButtClicked = 2
    End Enum


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

    Private _InSharedMemory As Boolean
    Public Property InSharedMemory As Boolean
        Get
            Return _InSharedMemory
        End Get
        Set(value As Boolean)
            _InSharedMemory = value
        End Set
    End Property

    Private LastTextBody As String = ""

    Private ElementHost As New System.Windows.Forms.Integration.ElementHost()
    Private IExplorer1 As New IExplorer()

    Private _Messages As HandleMessage.Messages
    Public Property Messages As HandleMessage.Messages
        Get
            Return _Messages
        End Get
        Set(value As HandleMessage.Messages)
            _Messages = value
        End Set
    End Property

    Private _isOpend As Boolean
    Public Property isOpend As Boolean
        Get
            Return _isOpend
        End Get
        Set(value As Boolean)
            _isOpend = value
        End Set
    End Property




#Region "initCodeAuto"

    Public WithEvents txtMailCC As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Public WithEvents txtMailAn As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Public WithEvents UltraToolTipManager1 As Infragistics.Win.UltraWinToolTip.UltraToolTipManager
    Friend WithEvents cboPriorität As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Public WithEvents txtMailBCC As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnBcc As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSearchCc As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSearchAn As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblAutoEMailAn As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents chkTextIsHtml As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents toolbarsManagerText As Infragistics.Win.UltraWinToolbars.UltraToolbarsManager
    Friend WithEvents btnSendEMails As Infragistics.Win.Misc.UltraButton
    Friend WithEvents PanelMailTop As System.Windows.Forms.Panel
    Friend WithEvents PanelMailAdr As System.Windows.Forms.Panel
    Friend WithEvents lblMailVon As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblEmpfangenAmGesendetAm As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents labelEmpfangenGesendet As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblStartAt As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents labelVon As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblAutoEMailBcc As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblAutoEMailCc As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ContextMenuStripSysMode As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditierenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkSendWithPostOfficeBoxForAll As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents PlanungseintragAusGesendeterListeLöschenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dropDownCategories As Infragistics.Win.Misc.UltraDropDownButton
    Private WithEvents uPopupContCategories As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents dropDownPatienten As Infragistics.Win.Misc.UltraDropDownButton
    Friend WithEvents dropDownUsers As Infragistics.Win.Misc.UltraDropDownButton
    Private WithEvents uPopUpContBenutzer As Infragistics.Win.Misc.UltraPopupControlContainer
    Private WithEvents uPopUpContPatienten As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents PanelBottom As Panel
    Friend WithEvents btnAbort As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnSave As Infragistics.Win.Misc.UltraButton
    Friend WithEvents lblErstelltVon As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lblErstelltAm As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents picInfo As Infragistics.Win.UltraWinEditors.UltraPictureBox
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
    Friend WithEvents btnDel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents dropDownAnhänge As Infragistics.Win.Misc.UltraDropDownButton
    Friend WithEvents lblStatus As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents lbkPriorität As Infragistics.Win.Misc.UltraLabel
    Public WithEvents cboDauerSerientermin As Infragistics.Win.UltraWinEditors.UltraComboEditor
    Friend WithEvents btnWeiterleiten As Infragistics.Win.Misc.UltraButton
    Friend WithEvents btnAntworten As Infragistics.Win.Misc.UltraButton
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Public WithEvents winFormHtmlEditor1 As SpiceLogic.WinHTMLEditor.WinForm.WinFormHtmlEditor
    Friend WithEvents Panel1 As Panel
    Friend WithEvents UltraPanel1 As Infragistics.Win.Misc.UltraPanel
    Friend WithEvents PanelDescription As Panel
    Friend WithEvents PanelBetreff As Panel
    Public WithEvents txtBetreff As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents dropDownTextvorlagen As Infragistics.Win.Misc.UltraDropDownButton
    Friend WithEvents lblBetreff As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents PanelBody As Panel
    Private WithEvents uPopUpContTextvorlagen As Infragistics.Win.Misc.UltraPopupControlContainer
    Private WithEvents uPopUpContAnhänge As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents PanelTxtEditor As Panel
    Friend WithEvents PanelSerientermineUISub As Panel
    Friend WithEvents EditorTmp1 As TXTextControl.TextControl
    Friend WithEvents PanelEditor As Panel
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
                compPlan1.Dispose()
                dsPlan1.Dispose()
                contListeAnhang.Dispose()
                contListTextTemplates1.Dispose()
                contSelectPatienten.Dispose()
                contSelectBenutzer.Dispose()
                contTxtEditor1.Dispose()
                contSelectSelListCategories.Dispose()
                _contListeAnhang.Dispose()
                ElementHost.Dispose()

                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer
    Public WithEvents dteBeginntAm As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DictionaryFileInfo1 As SpiceLogic.HtmlEditorControl.Domain.DesignTime.DictionaryFileInfo = New SpiceLogic.HtmlEditorControl.Domain.DesignTime.DictionaryFileInfo()
        Dim OptionSet1 As Infragistics.Win.UltraWinToolbars.OptionSet = New Infragistics.Win.UltraWinToolbars.OptionSet("lblOnOffEditor")
        Dim UltraToolbar1 As Infragistics.Win.UltraWinToolbars.UltraToolbar = New Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1")
        Dim StateButtonTool3 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("btnIntEditor", "lblOnOffEditor")
        Dim StateButtonTool4 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("btnWebbrowser", "lblOnOffEditor")
        Dim StateButtonTool1 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("btnIntEditor", "lblOnOffEditor")
        Dim StateButtonTool2 As Infragistics.Win.UltraWinToolbars.StateButtonTool = New Infragistics.Win.UltraWinToolbars.StateButtonTool("btnWebbrowser", "lblOnOffEditor")
        Dim LabelTool1 As Infragistics.Win.UltraWinToolbars.LabelTool = New Infragistics.Win.UltraWinToolbars.LabelTool("lblOnOffEditor")
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo5 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], "Html", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo6 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("E-Mail versenden", Infragistics.Win.ToolTipImage.[Default], "Senden", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo3 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("Objekt zur E-Mail-Adresse öffnen", Infragistics.Win.ToolTipImage.[Default], "Objekt öffnen", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem9 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem10 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo1 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], "Html", Infragistics.Win.DefaultableBoolean.[Default])
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
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
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem7 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim ValueListItem8 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem()
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo2 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], "Html", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNachricht3))
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraToolTipInfo4 As Infragistics.Win.UltraWinToolTip.UltraToolTipInfo = New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("", Infragistics.Win.ToolTipImage.[Default], "Html", Infragistics.Win.DefaultableBoolean.[Default])
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.winFormHtmlEditor1 = New SpiceLogic.WinHTMLEditor.WinForm.WinFormHtmlEditor()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.UltraPanel1 = New Infragistics.Win.Misc.UltraPanel()
        Me.toolbarsManagerText = New Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(Me.components)
        Me.PanelMailAdr = New System.Windows.Forms.Panel()
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
        Me.PanelMailTop = New System.Windows.Forms.Panel()
        Me.labelVon = New Infragistics.Win.Misc.UltraLabel()
        Me.lblMailVon = New Infragistics.Win.Misc.UltraLabel()
        Me.lblEmpfangenAmGesendetAm = New Infragistics.Win.Misc.UltraLabel()
        Me.labelEmpfangenGesendet = New Infragistics.Win.Misc.UltraLabel()
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel()
        Me.dropDownPatienten = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.dropDownUsers = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.lblStatus = New Infragistics.Win.Misc.UltraLabel()
        Me.dropDownCategories = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.optStatus = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.chkIsSerientermin = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.cboDauer = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.grpSerientermin = New Infragistics.Win.Misc.UltraGroupBox()
        Me.PanelSerientermineUISub = New System.Windows.Forms.Panel()
        Me.optSerienterminType = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.iNTenMonat = New QS2.Desktop.ControlManagment.BaseMaskEdit()
        Me.lblTagWochenMonatnTen = New QS2.Desktop.ControlManagment.BaseLabel()
        Me.grpWochentage = New Infragistics.Win.Misc.UltraGroupBox()
        Me.cbSo = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.cbSa = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.cbFr = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.cbDo = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.cbMi = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.cbDi = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.cbMo = New QS2.Desktop.ControlManagment.BaseCheckBox()
        Me.iWiedWertJeden = New QS2.Desktop.ControlManagment.BaseMaskEdit()
        Me.opTagWochenMonat = New Infragistics.Win.UltraWinEditors.UltraOptionSet()
        Me.cboDauerSerientermin = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.dteSerienterminEndetAm = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblSerienterminEnde = New Infragistics.Win.Misc.UltraLabel()
        Me.chkGanzerTag = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.dteEndetAm = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblEndAt = New Infragistics.Win.Misc.UltraLabel()
        Me.picInfo = New Infragistics.Win.UltraWinEditors.UltraPictureBox()
        Me.lblErstelltVon = New Infragistics.Win.Misc.UltraLabel()
        Me.lblErstelltAm = New Infragistics.Win.Misc.UltraLabel()
        Me.dteBeginntAm = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor()
        Me.lblStartAt = New Infragistics.Win.Misc.UltraLabel()
        Me.cboPriorität = New Infragistics.Win.UltraWinEditors.UltraComboEditor()
        Me.lbkPriorität = New Infragistics.Win.Misc.UltraLabel()
        Me.dropDownAnhänge = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.chkTextIsHtml = New Infragistics.Win.UltraWinEditors.UltraCheckEditor()
        Me.ContextMenuStripSysMode = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditierenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanungsenträgeDieZuDiesemEintragGehörenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlanungseintragAusGesendeterListeLöschenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.UltraToolTipManager1 = New Infragistics.Win.UltraWinToolTip.UltraToolTipManager(Me.components)
        Me.uPopupContCategories = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.uPopUpContBenutzer = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.uPopUpContPatienten = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.btnWeiterleiten = New Infragistics.Win.Misc.UltraButton()
        Me.btnAntworten = New Infragistics.Win.Misc.UltraButton()
        Me.btnAbort = New Infragistics.Win.Misc.UltraButton()
        Me.btnSave = New Infragistics.Win.Misc.UltraButton()
        Me.btnDel = New Infragistics.Win.Misc.UltraButton()
        Me.PanelBetreff = New System.Windows.Forms.Panel()
        Me.txtBetreff = New Infragistics.Win.UltraWinEditors.UltraTextEditor()
        Me.dropDownTextvorlagen = New Infragistics.Win.Misc.UltraDropDownButton()
        Me.lblBetreff = New Infragistics.Win.Misc.UltraLabel()
        Me.PanelDescription = New System.Windows.Forms.Panel()
        Me.PanelEditor = New System.Windows.Forms.Panel()
        Me.EditorTmp1 = New TXTextControl.TextControl()
        Me.PanelBody = New System.Windows.Forms.Panel()
        Me.PanelTxtEditor = New System.Windows.Forms.Panel()
        Me.uPopUpContTextvorlagen = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.uPopUpContAnhänge = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.winFormHtmlEditor1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.UltraPanel1.SuspendLayout()
        CType(Me.toolbarsManagerText, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMailAdr.SuspendLayout()
        CType(Me.txtMailCC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSendWithPostOfficeBoxForAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMailBCC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMailAn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMailTop.SuspendLayout()
        CType(Me.optStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIsSerientermin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDauer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grpSerientermin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSerientermin.SuspendLayout()
        Me.PanelSerientermineUISub.SuspendLayout()
        CType(Me.optSerienterminType, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.cboDauerSerientermin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteSerienterminEndetAm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkGanzerTag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteEndetAm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteBeginntAm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPriorität, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkTextIsHtml, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripSysMode.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBottom.SuspendLayout()
        Me.PanelBetreff.SuspendLayout()
        CType(Me.txtBetreff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDescription.SuspendLayout()
        Me.PanelBody.SuspendLayout()
        Me.SuspendLayout()
        '
        'winFormHtmlEditor1
        '
        Me.winFormHtmlEditor1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.winFormHtmlEditor1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.winFormHtmlEditor1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.winFormHtmlEditor1.Charset = "utf-8"
        Me.winFormHtmlEditor1.Controls.Add(Me.Panel1)
        Me.winFormHtmlEditor1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.winFormHtmlEditor1.DocumentHtml = "<!DOCTYPE html>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<html><head>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<meta http-equiv=""Content-Type"" content=""text/html" &
    "; charset=unicode"" />" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</head>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<body></body></html>"
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
        Me.winFormHtmlEditor1.Size = New System.Drawing.Size(1122, 433)
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
        Me.winFormHtmlEditor1.Toolbar1.Size = New System.Drawing.Size(1122, 29)
        Me.winFormHtmlEditor1.Toolbar1.TabIndex = 0
        '
        'winFormHtmlEditor1.WinFormHtmlEditor_Toolbar2
        '
        Me.winFormHtmlEditor1.Toolbar2.Location = New System.Drawing.Point(0, 29)
        Me.winFormHtmlEditor1.Toolbar2.Name = "WinFormHtmlEditor_Toolbar2"
        Me.winFormHtmlEditor1.Toolbar2.Size = New System.Drawing.Size(1122, 29)
        Me.winFormHtmlEditor1.Toolbar2.TabIndex = 0
        Me.winFormHtmlEditor1.ToolbarContextMenuStrip = Nothing
        '
        'winFormHtmlEditor1.WinFormHtmlEditor_ToolbarFooter
        '
        Me.winFormHtmlEditor1.ToolbarFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.winFormHtmlEditor1.ToolbarFooter.Location = New System.Drawing.Point(0, 408)
        Me.winFormHtmlEditor1.ToolbarFooter.Name = "WinFormHtmlEditor_ToolbarFooter"
        Me.winFormHtmlEditor1.ToolbarFooter.Size = New System.Drawing.Size(1122, 25)
        Me.winFormHtmlEditor1.ToolbarFooter.TabIndex = 7
        Me.winFormHtmlEditor1.VerticalScroll = Nothing
        Me.winFormHtmlEditor1.z__ignore = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.UltraPanel1)
        Me.Panel1.Location = New System.Drawing.Point(766, 177)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(562, 30)
        Me.Panel1.TabIndex = 0
        '
        'UltraPanel1
        '
        Me.UltraPanel1.Cursor = System.Windows.Forms.Cursors.Default
        Me.UltraPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraPanel1.Location = New System.Drawing.Point(0, 0)
        Me.UltraPanel1.Name = "UltraPanel1"
        Me.UltraPanel1.Size = New System.Drawing.Size(562, 30)
        Me.UltraPanel1.TabIndex = 0
        '
        'toolbarsManagerText
        '
        Me.toolbarsManagerText.DesignerFlags = 1
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
        'PanelMailAdr
        '
        Me.PanelMailAdr.BackColor = System.Drawing.Color.Transparent
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
        Me.PanelMailAdr.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelMailAdr.Location = New System.Drawing.Point(0, 21)
        Me.PanelMailAdr.Name = "PanelMailAdr"
        Me.PanelMailAdr.Size = New System.Drawing.Size(1122, 87)
        Me.PanelMailAdr.TabIndex = 0
        Me.PanelMailAdr.Visible = False
        '
        'btnSearchAn
        '
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Appearance1.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance1.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnSearchAn.Appearance = Appearance1
        Me.btnSearchAn.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchAn.Location = New System.Drawing.Point(65, 5)
        Me.btnSearchAn.Name = "btnSearchAn"
        Me.btnSearchAn.Size = New System.Drawing.Size(34, 19)
        Me.btnSearchAn.TabIndex = 1
        Me.btnSearchAn.Tag = "ResID.To3"
        Me.btnSearchAn.Text = "An"
        '
        'txtMailCC
        '
        Me.txtMailCC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.White
        Appearance2.BackColor2 = System.Drawing.Color.White
        Appearance2.BackColorDisabled = System.Drawing.Color.White
        Appearance2.BackColorDisabled2 = System.Drawing.Color.White
        Appearance2.FontData.BoldAsString = "False"
        Appearance2.FontData.ItalicAsString = "False"
        Appearance2.FontData.Name = "Microsoft Sans Serif"
        Appearance2.FontData.SizeInPoints = 8.25!
        Appearance2.FontData.StrikeoutAsString = "False"
        Appearance2.FontData.UnderlineAsString = "False"
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtMailCC.Appearance = Appearance2
        Me.txtMailCC.AutoSize = False
        Me.txtMailCC.BackColor = System.Drawing.Color.White
        Me.txtMailCC.Location = New System.Drawing.Point(105, 38)
        Me.txtMailCC.MaxLength = 0
        Me.txtMailCC.Multiline = True
        Me.txtMailCC.Name = "txtMailCC"
        Me.txtMailCC.Size = New System.Drawing.Size(620, 30)
        Me.txtMailCC.TabIndex = 1
        Me.txtMailCC.Tag = "Vorname"
        '
        'chkSendWithPostOfficeBoxForAll
        '
        Me.chkSendWithPostOfficeBoxForAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.Color.Transparent
        Appearance3.BackColorDisabled = System.Drawing.Color.Transparent
        Appearance3.ForeColor = System.Drawing.Color.Black
        Appearance3.ForeColorDisabled = System.Drawing.Color.Black
        Appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.chkSendWithPostOfficeBoxForAll.Appearance = Appearance3
        Me.chkSendWithPostOfficeBoxForAll.BackColor = System.Drawing.Color.Transparent
        Me.chkSendWithPostOfficeBoxForAll.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkSendWithPostOfficeBoxForAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkSendWithPostOfficeBoxForAll.Location = New System.Drawing.Point(9, 70)
        Me.chkSendWithPostOfficeBoxForAll.Name = "chkSendWithPostOfficeBoxForAll"
        Me.chkSendWithPostOfficeBoxForAll.Size = New System.Drawing.Size(274, 13)
        Me.chkSendWithPostOfficeBoxForAll.TabIndex = 425
        Me.chkSendWithPostOfficeBoxForAll.Tag = "ResID.SendWithPostOfficeBoxForAll"
        Me.chkSendWithPostOfficeBoxForAll.Text = "Allg. E-Mail-Adresse zum versenden verwenden"
        UltraToolTipInfo5.ToolTipTextFormatted = "Text unterhalb in Html oder als normalen Text darstellen"
        UltraToolTipInfo5.ToolTipTitle = "Html"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.chkSendWithPostOfficeBoxForAll, UltraToolTipInfo5)
        Me.chkSendWithPostOfficeBoxForAll.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.chkSendWithPostOfficeBoxForAll.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'lblAutoEMailBcc
        '
        Me.lblAutoEMailBcc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance47.BackColor = System.Drawing.Color.Transparent
        Appearance47.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance47.FontData.SizeInPoints = 7.0!
        Appearance47.ForeColor = System.Drawing.Color.RoyalBlue
        Appearance47.ForeColorDisabled = System.Drawing.Color.RoyalBlue
        Me.lblAutoEMailBcc.Appearance = Appearance47
        Me.lblAutoEMailBcc.AutoSize = True
        Appearance48.FontData.UnderlineAsString = "True"
        Me.lblAutoEMailBcc.HotTrackAppearance = Appearance48
        Me.lblAutoEMailBcc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAutoEMailBcc.Location = New System.Drawing.Point(739, 58)
        Me.lblAutoEMailBcc.Name = "lblAutoEMailBcc"
        Me.lblAutoEMailBcc.Size = New System.Drawing.Size(23, 12)
        Me.lblAutoEMailBcc.TabIndex = 9
        Me.lblAutoEMailBcc.Tag = "ResID.Auto"
        Me.lblAutoEMailBcc.Text = "Auto"
        Me.lblAutoEMailBcc.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'lblAutoEMailCc
        '
        Appearance49.BackColor = System.Drawing.Color.Transparent
        Appearance49.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance49.FontData.SizeInPoints = 7.0!
        Appearance49.ForeColor = System.Drawing.Color.RoyalBlue
        Appearance49.ForeColorDisabled = System.Drawing.Color.RoyalBlue
        Me.lblAutoEMailCc.Appearance = Appearance49
        Me.lblAutoEMailCc.AutoSize = True
        Appearance50.FontData.UnderlineAsString = "True"
        Me.lblAutoEMailCc.HotTrackAppearance = Appearance50
        Me.lblAutoEMailCc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAutoEMailCc.Location = New System.Drawing.Point(72, 56)
        Me.lblAutoEMailCc.Name = "lblAutoEMailCc"
        Me.lblAutoEMailCc.Size = New System.Drawing.Size(23, 12)
        Me.lblAutoEMailCc.TabIndex = 8
        Me.lblAutoEMailCc.Tag = "ResID.Auto"
        Me.lblAutoEMailCc.Text = "Auto"
        Me.lblAutoEMailCc.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'btnSendEMails
        '
        Appearance51.ForeColor = System.Drawing.Color.Black
        Appearance51.ForeColorDisabled = System.Drawing.Color.Black
        Appearance51.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance51.ImageVAlign = Infragistics.Win.VAlign.Top
        Appearance51.TextHAlignAsString = "Center"
        Me.btnSendEMails.Appearance = Appearance51
        Me.btnSendEMails.Location = New System.Drawing.Point(8, 5)
        Me.btnSendEMails.Name = "btnSendEMails"
        Me.btnSendEMails.Size = New System.Drawing.Size(55, 56)
        Me.btnSendEMails.TabIndex = 0
        Me.btnSendEMails.Tag = "ResID.Send"
        Me.btnSendEMails.Text = "Senden"
        UltraToolTipInfo6.ToolTipText = "E-Mail versenden"
        UltraToolTipInfo6.ToolTipTitle = "Senden"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.btnSendEMails, UltraToolTipInfo6)
        '
        'lblAutoEMailAn
        '
        Appearance52.BackColor = System.Drawing.Color.Transparent
        Appearance52.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance52.FontData.SizeInPoints = 7.0!
        Appearance52.ForeColor = System.Drawing.Color.RoyalBlue
        Appearance52.ForeColorDisabled = System.Drawing.Color.RoyalBlue
        Me.lblAutoEMailAn.Appearance = Appearance52
        Me.lblAutoEMailAn.AutoSize = True
        Appearance53.FontData.UnderlineAsString = "True"
        Me.lblAutoEMailAn.HotTrackAppearance = Appearance53
        Me.lblAutoEMailAn.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAutoEMailAn.Location = New System.Drawing.Point(69, 22)
        Me.lblAutoEMailAn.Name = "lblAutoEMailAn"
        Me.lblAutoEMailAn.Size = New System.Drawing.Size(23, 12)
        Me.lblAutoEMailAn.TabIndex = 7
        Me.lblAutoEMailAn.Tag = "ResID.Auto"
        Me.lblAutoEMailAn.Text = "Auto"
        Me.lblAutoEMailAn.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'btnBcc
        '
        Me.btnBcc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance54.ForeColor = System.Drawing.Color.Black
        Appearance54.ForeColorDisabled = System.Drawing.Color.Black
        Appearance54.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance54.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnBcc.Appearance = Appearance54
        Me.btnBcc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnBcc.Location = New System.Drawing.Point(732, 39)
        Me.btnBcc.Name = "btnBcc"
        Me.btnBcc.Size = New System.Drawing.Size(34, 19)
        Me.btnBcc.TabIndex = 5
        Me.btnBcc.Tag = "ResID.Bcc"
        Me.btnBcc.Text = "Bcc"
        '
        'btnSearchCc
        '
        Appearance55.ForeColor = System.Drawing.Color.Black
        Appearance55.ForeColorDisabled = System.Drawing.Color.Black
        Appearance55.ImageHAlign = Infragistics.Win.HAlign.Center
        Appearance55.ImageVAlign = Infragistics.Win.VAlign.Middle
        Me.btnSearchCc.Appearance = Appearance55
        Me.btnSearchCc.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchCc.Location = New System.Drawing.Point(65, 38)
        Me.btnSearchCc.Name = "btnSearchCc"
        Me.btnSearchCc.Size = New System.Drawing.Size(34, 19)
        Me.btnSearchCc.TabIndex = 3
        Me.btnSearchCc.Tag = "ResID.Cc"
        Me.btnSearchCc.Text = "Cc"
        '
        'txtMailBCC
        '
        Me.txtMailBCC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance56.BackColor = System.Drawing.Color.White
        Appearance56.BackColorDisabled = System.Drawing.Color.White
        Appearance56.FontData.BoldAsString = "False"
        Appearance56.FontData.ItalicAsString = "False"
        Appearance56.FontData.Name = "Microsoft Sans Serif"
        Appearance56.FontData.SizeInPoints = 8.25!
        Appearance56.FontData.StrikeoutAsString = "False"
        Appearance56.FontData.UnderlineAsString = "False"
        Appearance56.ForeColor = System.Drawing.Color.Black
        Appearance56.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtMailBCC.Appearance = Appearance56
        Me.txtMailBCC.AutoSize = False
        Me.txtMailBCC.BackColor = System.Drawing.Color.White
        Me.txtMailBCC.Location = New System.Drawing.Point(768, 38)
        Me.txtMailBCC.MaxLength = 0
        Me.txtMailBCC.Multiline = True
        Me.txtMailBCC.Name = "txtMailBCC"
        Me.txtMailBCC.Size = New System.Drawing.Size(347, 30)
        Me.txtMailBCC.TabIndex = 2
        Me.txtMailBCC.Tag = "Vorname"
        '
        'txtMailAn
        '
        Me.txtMailAn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance57.BackColor = System.Drawing.Color.White
        Appearance57.BackColorDisabled = System.Drawing.Color.White
        Appearance57.FontData.BoldAsString = "False"
        Appearance57.FontData.ItalicAsString = "False"
        Appearance57.FontData.Name = "Microsoft Sans Serif"
        Appearance57.FontData.SizeInPoints = 8.25!
        Appearance57.FontData.StrikeoutAsString = "False"
        Appearance57.FontData.UnderlineAsString = "False"
        Appearance57.ForeColor = System.Drawing.Color.Black
        Appearance57.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtMailAn.Appearance = Appearance57
        Me.txtMailAn.AutoSize = False
        Me.txtMailAn.BackColor = System.Drawing.Color.White
        Me.txtMailAn.Location = New System.Drawing.Point(105, 3)
        Me.txtMailAn.MaxLength = 0
        Me.txtMailAn.Multiline = True
        Me.txtMailAn.Name = "txtMailAn"
        Me.txtMailAn.Size = New System.Drawing.Size(1010, 33)
        Me.txtMailAn.TabIndex = 0
        Me.txtMailAn.Tag = "Vorname"
        '
        'PanelMailTop
        '
        Me.PanelMailTop.BackColor = System.Drawing.Color.Transparent
        Me.PanelMailTop.Controls.Add(Me.labelVon)
        Me.PanelMailTop.Controls.Add(Me.lblMailVon)
        Me.PanelMailTop.Controls.Add(Me.lblEmpfangenAmGesendetAm)
        Me.PanelMailTop.Controls.Add(Me.labelEmpfangenGesendet)
        Me.PanelMailTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelMailTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelMailTop.Name = "PanelMailTop"
        Me.PanelMailTop.Size = New System.Drawing.Size(1122, 21)
        Me.PanelMailTop.TabIndex = 1
        Me.PanelMailTop.Visible = False
        '
        'labelVon
        '
        Appearance36.BackColor = System.Drawing.Color.Transparent
        Appearance36.Cursor = System.Windows.Forms.Cursors.Hand
        Appearance36.FontData.SizeInPoints = 8.0!
        Appearance36.ForeColor = System.Drawing.Color.RoyalBlue
        Appearance36.ForeColorDisabled = System.Drawing.Color.RoyalBlue
        Me.labelVon.Appearance = Appearance36
        Me.labelVon.AutoSize = True
        Appearance37.FontData.UnderlineAsString = "True"
        Me.labelVon.HotTrackAppearance = Appearance37
        Me.labelVon.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.labelVon.Location = New System.Drawing.Point(72, 4)
        Me.labelVon.Name = "labelVon"
        Me.labelVon.Size = New System.Drawing.Size(27, 14)
        Me.labelVon.TabIndex = 385
        Me.labelVon.Tag = "ResID.From"
        Me.labelVon.Text = "Von:"
        UltraToolTipInfo3.ToolTipText = "Objekt zur E-Mail-Adresse öffnen"
        UltraToolTipInfo3.ToolTipTitle = "Objekt öffnen"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.labelVon, UltraToolTipInfo3)
        Me.labelVon.UseHotTracking = Infragistics.Win.DefaultableBoolean.[True]
        '
        'lblMailVon
        '
        Me.lblMailVon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance38.BackColor = System.Drawing.Color.Transparent
        Appearance38.ForeColor = System.Drawing.Color.Black
        Appearance38.ForeColorDisabled = System.Drawing.Color.Black
        Appearance38.TextVAlignAsString = "Middle"
        Me.lblMailVon.Appearance = Appearance38
        Me.lblMailVon.Location = New System.Drawing.Point(105, 2)
        Me.lblMailVon.Name = "lblMailVon"
        Me.lblMailVon.Size = New System.Drawing.Size(746, 17)
        Me.lblMailVon.TabIndex = 382
        Me.lblMailVon.Text = "hannes.le@s2-engineering.com"
        '
        'lblEmpfangenAmGesendetAm
        '
        Me.lblEmpfangenAmGesendetAm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance39.BackColor = System.Drawing.Color.Transparent
        Appearance39.ForeColorDisabled = System.Drawing.Color.Black
        Appearance39.TextVAlignAsString = "Middle"
        Me.lblEmpfangenAmGesendetAm.Appearance = Appearance39
        Me.lblEmpfangenAmGesendetAm.Location = New System.Drawing.Point(943, 3)
        Me.lblEmpfangenAmGesendetAm.Name = "lblEmpfangenAmGesendetAm"
        Me.lblEmpfangenAmGesendetAm.Size = New System.Drawing.Size(171, 17)
        Me.lblEmpfangenAmGesendetAm.TabIndex = 384
        Me.lblEmpfangenAmGesendetAm.Text = "2011-03-02 12:34:04"
        '
        'labelEmpfangenGesendet
        '
        Me.labelEmpfangenGesendet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance40.BackColor = System.Drawing.Color.Transparent
        Appearance40.ForeColor = System.Drawing.Color.Black
        Appearance40.ForeColorDisabled = System.Drawing.Color.Black
        Appearance40.TextHAlignAsString = "Right"
        Appearance40.TextVAlignAsString = "Middle"
        Me.labelEmpfangenGesendet.Appearance = Appearance40
        Me.labelEmpfangenGesendet.Location = New System.Drawing.Point(851, 3)
        Me.labelEmpfangenGesendet.Name = "labelEmpfangenGesendet"
        Me.labelEmpfangenGesendet.Size = New System.Drawing.Size(91, 17)
        Me.labelEmpfangenGesendet.TabIndex = 383
        Me.labelEmpfangenGesendet.Text = "Empfangen am:"
        '
        'UltraLabel1
        '
        Appearance4.BackColor = System.Drawing.Color.Transparent
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.ForeColorDisabled = System.Drawing.Color.Black
        Appearance4.TextVAlignAsString = "Middle"
        Me.UltraLabel1.Appearance = Appearance4
        Me.UltraLabel1.Location = New System.Drawing.Point(7, 93)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.Size = New System.Drawing.Size(77, 20)
        Me.UltraLabel1.TabIndex = 505
        Me.UltraLabel1.Tag = "ResID.Zuordnungen"
        Me.UltraLabel1.Text = "Zuordnungen"
        '
        'dropDownPatienten
        '
        Appearance6.BorderColor = System.Drawing.Color.Black
        Me.dropDownPatienten.Appearance = Appearance6
        Me.dropDownPatienten.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.dropDownPatienten.Location = New System.Drawing.Point(92, 93)
        Me.dropDownPatienten.Name = "dropDownPatienten"
        Me.dropDownPatienten.Size = New System.Drawing.Size(97, 22)
        Me.dropDownPatienten.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.dropDownPatienten.TabIndex = 10
        Me.dropDownPatienten.Tag = "ResID.Patienten"
        Me.dropDownPatienten.Text = "Patienten"
        '
        'dropDownUsers
        '
        Appearance7.BorderColor = System.Drawing.Color.Black
        Me.dropDownUsers.Appearance = Appearance7
        Me.dropDownUsers.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.dropDownUsers.Location = New System.Drawing.Point(192, 93)
        Me.dropDownUsers.Name = "dropDownUsers"
        Me.dropDownUsers.Size = New System.Drawing.Size(97, 22)
        Me.dropDownUsers.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.dropDownUsers.TabIndex = 11
        Me.dropDownUsers.Tag = "ResID.Benutzer"
        Me.dropDownUsers.Text = "Benutzer"
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance9.BackColor = System.Drawing.Color.Transparent
        Appearance9.ForeColor = System.Drawing.Color.Black
        Appearance9.ForeColorDisabled = System.Drawing.Color.Black
        Appearance9.TextVAlignAsString = "Middle"
        Me.lblStatus.Appearance = Appearance9
        Me.lblStatus.Location = New System.Drawing.Point(875, 49)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(44, 17)
        Me.lblStatus.TabIndex = 504
        Me.lblStatus.Tag = "ResID.Status"
        Me.lblStatus.Text = "Status"
        Me.lblStatus.Visible = False
        '
        'dropDownCategories
        '
        Appearance35.TextHAlignAsString = "Left"
        Me.dropDownCategories.Appearance = Appearance35
        Me.dropDownCategories.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.dropDownCategories.Location = New System.Drawing.Point(9, 7)
        Me.dropDownCategories.Name = "dropDownCategories"
        Me.dropDownCategories.Size = New System.Drawing.Size(154, 22)
        Me.dropDownCategories.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.dropDownCategories.TabIndex = 12
        Me.dropDownCategories.Tag = "ResID.Categories"
        Me.dropDownCategories.Text = "Kategorien"
        '
        'optStatus
        '
        Me.optStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.optStatus.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.optStatus.CheckedIndex = 0
        ValueListItem1.CheckState = System.Windows.Forms.CheckState.Checked
        ValueListItem1.DataValue = 0
        ValueListItem1.DisplayText = "Offen"
        ValueListItem1.Tag = "ResID.Openly"
        ValueListItem2.DataValue = "Completed"
        ValueListItem2.DisplayText = "Erledigt"
        ValueListItem2.Tag = "ResID.Completed"
        ValueListItem9.DataValue = "Failed"
        ValueListItem9.DisplayText = "Erfolglos"
        ValueListItem9.Tag = "ResID.Failed"
        ValueListItem10.DataValue = "Canceled"
        ValueListItem10.DisplayText = "Storniert"
        ValueListItem10.Tag = "ResID.Canceled"
        Me.optStatus.Items.AddRange(New Infragistics.Win.ValueListItem() {ValueListItem1, ValueListItem2, ValueListItem9, ValueListItem10})
        Me.optStatus.Location = New System.Drawing.Point(929, 52)
        Me.optStatus.Name = "optStatus"
        Me.optStatus.Size = New System.Drawing.Size(129, 62)
        Me.optStatus.TabIndex = 4
        Me.optStatus.Text = "Offen"
        Me.optStatus.Visible = False
        '
        'chkIsSerientermin
        '
        Appearance14.BackColor = System.Drawing.Color.Transparent
        Appearance14.BackColorDisabled = System.Drawing.Color.Transparent
        Appearance14.ForeColor = System.Drawing.Color.Black
        Appearance14.ForeColorDisabled = System.Drawing.Color.Black
        Appearance14.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.chkIsSerientermin.Appearance = Appearance14
        Me.chkIsSerientermin.BackColor = System.Drawing.Color.Transparent
        Me.chkIsSerientermin.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkIsSerientermin.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkIsSerientermin.Location = New System.Drawing.Point(421, 7)
        Me.chkIsSerientermin.Name = "chkIsSerientermin"
        Me.chkIsSerientermin.Size = New System.Drawing.Size(90, 11)
        Me.chkIsSerientermin.TabIndex = 20
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
        Me.cboDauer.Location = New System.Drawing.Point(219, 40)
        Me.cboDauer.Name = "cboDauer"
        Me.cboDauer.Size = New System.Drawing.Size(103, 21)
        Me.cboDauer.TabIndex = 3
        '
        'grpSerientermin
        '
        Me.grpSerientermin.Controls.Add(Me.PanelSerientermineUISub)
        Me.grpSerientermin.Controls.Add(Me.cboDauerSerientermin)
        Me.grpSerientermin.Controls.Add(Me.dteSerienterminEndetAm)
        Me.grpSerientermin.Controls.Add(Me.lblSerienterminEnde)
        Me.grpSerientermin.Location = New System.Drawing.Point(412, 19)
        Me.grpSerientermin.Name = "grpSerientermin"
        Me.grpSerientermin.Size = New System.Drawing.Size(457, 96)
        Me.grpSerientermin.TabIndex = 21
        Me.grpSerientermin.Tag = ""
        Me.grpSerientermin.Visible = False
        '
        'PanelSerientermineUISub
        '
        Me.PanelSerientermineUISub.BackColor = System.Drawing.Color.Transparent
        Me.PanelSerientermineUISub.Controls.Add(Me.optSerienterminType)
        Me.PanelSerientermineUISub.Controls.Add(Me.iNTenMonat)
        Me.PanelSerientermineUISub.Controls.Add(Me.lblTagWochenMonatnTen)
        Me.PanelSerientermineUISub.Controls.Add(Me.grpWochentage)
        Me.PanelSerientermineUISub.Controls.Add(Me.iWiedWertJeden)
        Me.PanelSerientermineUISub.Controls.Add(Me.opTagWochenMonat)
        Me.PanelSerientermineUISub.Location = New System.Drawing.Point(8, 30)
        Me.PanelSerientermineUISub.Name = "PanelSerientermineUISub"
        Me.PanelSerientermineUISub.Size = New System.Drawing.Size(443, 60)
        Me.PanelSerientermineUISub.TabIndex = 506
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
        Me.optSerienterminType.Location = New System.Drawing.Point(2, 1)
        Me.optSerienterminType.Name = "optSerienterminType"
        Me.optSerienterminType.Size = New System.Drawing.Size(55, 55)
        Me.optSerienterminType.TabIndex = 1
        Me.optSerienterminType.Text = "täglich"
        '
        'iNTenMonat
        '
        Appearance16.BackColorDisabled = System.Drawing.SystemColors.Control
        Appearance16.ForeColorDisabled = System.Drawing.Color.Black
        Me.iNTenMonat.Appearance = Appearance16
        Me.iNTenMonat.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.[Integer]
        Me.iNTenMonat.InputMask = "nnn"
        Me.iNTenMonat.Location = New System.Drawing.Point(75, 37)
        Me.iNTenMonat.MaxValue = CType(31, Short)
        Me.iNTenMonat.MinValue = CType(1, Short)
        Me.iNTenMonat.Name = "iNTenMonat"
        Me.iNTenMonat.NonAutoSizeHeight = 20
        Me.iNTenMonat.Size = New System.Drawing.Size(35, 20)
        Me.iNTenMonat.TabIndex = 4
        Me.iNTenMonat.Text = "                   "
        '
        'lblTagWochenMonatnTen
        '
        Appearance17.FontData.SizeInPoints = 8.0!
        Me.lblTagWochenMonatnTen.Appearance = Appearance17
        Me.lblTagWochenMonatnTen.AutoSize = True
        Me.lblTagWochenMonatnTen.Location = New System.Drawing.Point(116, 41)
        Me.lblTagWochenMonatnTen.Name = "lblTagWochenMonatnTen"
        Me.lblTagWochenMonatnTen.Size = New System.Drawing.Size(82, 14)
        Me.lblTagWochenMonatnTen.TabIndex = 500
        Me.lblTagWochenMonatnTen.Tag = "ResID.TenDesMonats"
        Me.lblTagWochenMonatnTen.Text = ".ten des Monats"
        '
        'grpWochentage
        '
        Appearance18.BackColorDisabled = System.Drawing.Color.White
        Me.grpWochentage.Appearance = Appearance18
        Me.grpWochentage.Controls.Add(Me.cbSo)
        Me.grpWochentage.Controls.Add(Me.cbSa)
        Me.grpWochentage.Controls.Add(Me.cbFr)
        Me.grpWochentage.Controls.Add(Me.cbDo)
        Me.grpWochentage.Controls.Add(Me.cbMi)
        Me.grpWochentage.Controls.Add(Me.cbDi)
        Me.grpWochentage.Controls.Add(Me.cbMo)
        Me.grpWochentage.Location = New System.Drawing.Point(288, 2)
        Me.grpWochentage.Name = "grpWochentage"
        Me.grpWochentage.Size = New System.Drawing.Size(153, 57)
        Me.grpWochentage.TabIndex = 5
        Me.grpWochentage.Tag = "ResID.Wochentage"
        Me.grpWochentage.Text = "Wochentage"
        Me.grpWochentage.UseAppStyling = False
        '
        'cbSo
        '
        Appearance19.TextHAlignAsString = "Center"
        Appearance19.TextVAlignAsString = "Middle"
        Me.cbSo.Appearance = Appearance19
        Me.cbSo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbSo.Location = New System.Drawing.Point(126, 16)
        Me.cbSo.Name = "cbSo"
        Me.cbSo.Size = New System.Drawing.Size(24, 34)
        Me.cbSo.TabIndex = 13
        Me.cbSo.Text = "So"
        '
        'cbSa
        '
        Appearance20.TextHAlignAsString = "Center"
        Appearance20.TextVAlignAsString = "Middle"
        Me.cbSa.Appearance = Appearance20
        Me.cbSa.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbSa.Location = New System.Drawing.Point(106, 16)
        Me.cbSa.Name = "cbSa"
        Me.cbSa.Size = New System.Drawing.Size(24, 34)
        Me.cbSa.TabIndex = 12
        Me.cbSa.Text = "Sa"
        '
        'cbFr
        '
        Appearance21.TextHAlignAsString = "Center"
        Appearance21.TextVAlignAsString = "Middle"
        Me.cbFr.Appearance = Appearance21
        Me.cbFr.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbFr.Location = New System.Drawing.Point(86, 16)
        Me.cbFr.Name = "cbFr"
        Me.cbFr.Size = New System.Drawing.Size(24, 34)
        Me.cbFr.TabIndex = 11
        Me.cbFr.Text = "Fr"
        '
        'cbDo
        '
        Appearance22.TextHAlignAsString = "Center"
        Appearance22.TextVAlignAsString = "Middle"
        Me.cbDo.Appearance = Appearance22
        Me.cbDo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbDo.Location = New System.Drawing.Point(66, 16)
        Me.cbDo.Name = "cbDo"
        Me.cbDo.Size = New System.Drawing.Size(24, 34)
        Me.cbDo.TabIndex = 10
        Me.cbDo.Text = "Do"
        '
        'cbMi
        '
        Appearance23.TextHAlignAsString = "Center"
        Appearance23.TextVAlignAsString = "Middle"
        Me.cbMi.Appearance = Appearance23
        Me.cbMi.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbMi.Location = New System.Drawing.Point(46, 16)
        Me.cbMi.Name = "cbMi"
        Me.cbMi.Size = New System.Drawing.Size(24, 34)
        Me.cbMi.TabIndex = 9
        Me.cbMi.Text = "Mi"
        '
        'cbDi
        '
        Appearance24.TextHAlignAsString = "Center"
        Appearance24.TextVAlignAsString = "Middle"
        Me.cbDi.Appearance = Appearance24
        Me.cbDi.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbDi.Location = New System.Drawing.Point(26, 16)
        Me.cbDi.Name = "cbDi"
        Me.cbDi.Size = New System.Drawing.Size(24, 34)
        Me.cbDi.TabIndex = 8
        Me.cbDi.Text = "Di"
        '
        'cbMo
        '
        Appearance25.TextHAlignAsString = "Center"
        Appearance25.TextVAlignAsString = "Middle"
        Me.cbMo.Appearance = Appearance25
        Me.cbMo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cbMo.Location = New System.Drawing.Point(6, 16)
        Me.cbMo.Name = "cbMo"
        Me.cbMo.Size = New System.Drawing.Size(24, 34)
        Me.cbMo.TabIndex = 7
        Me.cbMo.Text = "Mo"
        '
        'iWiedWertJeden
        '
        Appearance26.BackColorDisabled = System.Drawing.SystemColors.Control
        Appearance26.ForeColorDisabled = System.Drawing.Color.Black
        Me.iWiedWertJeden.Appearance = Appearance26
        Me.iWiedWertJeden.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.[Integer]
        Me.iWiedWertJeden.InputMask = "nnn"
        Me.iWiedWertJeden.Location = New System.Drawing.Point(75, 16)
        Me.iWiedWertJeden.MaxValue = 1000
        Me.iWiedWertJeden.MinValue = 1
        Me.iWiedWertJeden.Name = "iWiedWertJeden"
        Me.iWiedWertJeden.NonAutoSizeHeight = 20
        Me.iWiedWertJeden.Size = New System.Drawing.Size(35, 20)
        Me.iWiedWertJeden.TabIndex = 2
        Me.iWiedWertJeden.Text = "                 "
        '
        'opTagWochenMonat
        '
        Appearance27.BackColorDisabled = System.Drawing.Color.White
        Me.opTagWochenMonat.Appearance = Appearance27
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
        Me.opTagWochenMonat.Location = New System.Drawing.Point(116, 19)
        Me.opTagWochenMonat.Name = "opTagWochenMonat"
        Me.opTagWochenMonat.Size = New System.Drawing.Size(168, 15)
        Me.opTagWochenMonat.TabIndex = 3
        Me.opTagWochenMonat.Text = "Tage"
        '
        'cboDauerSerientermin
        '
        Me.cboDauerSerientermin.Location = New System.Drawing.Point(180, 7)
        Me.cboDauerSerientermin.Name = "cboDauerSerientermin"
        Me.cboDauerSerientermin.Size = New System.Drawing.Size(93, 21)
        Me.cboDauerSerientermin.TabIndex = 506
        '
        'dteSerienterminEndetAm
        '
        Appearance28.BackColor = System.Drawing.Color.White
        Appearance28.BackColor2 = System.Drawing.Color.White
        Appearance28.BackColorDisabled = System.Drawing.Color.White
        Appearance28.BackColorDisabled2 = System.Drawing.Color.White
        Appearance28.FontData.BoldAsString = "False"
        Appearance28.FontData.ItalicAsString = "False"
        Appearance28.FontData.Name = "Microsoft Sans Serif"
        Appearance28.FontData.SizeInPoints = 8.25!
        Appearance28.FontData.StrikeoutAsString = "False"
        Appearance28.FontData.UnderlineAsString = "False"
        Appearance28.ForeColor = System.Drawing.Color.Black
        Appearance28.ForeColorDisabled = System.Drawing.Color.Black
        Me.dteSerienterminEndetAm.Appearance = Appearance28
        Me.dteSerienterminEndetAm.BackColor = System.Drawing.Color.White
        Me.dteSerienterminEndetAm.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dteSerienterminEndetAm.Location = New System.Drawing.Point(81, 7)
        Me.dteSerienterminEndetAm.MaskInput = "{date}"
        Me.dteSerienterminEndetAm.Name = "dteSerienterminEndetAm"
        Me.dteSerienterminEndetAm.Size = New System.Drawing.Size(93, 21)
        Me.dteSerienterminEndetAm.TabIndex = 0
        Me.dteSerienterminEndetAm.Value = Nothing
        '
        'lblSerienterminEnde
        '
        Appearance29.BackColor = System.Drawing.Color.Transparent
        Appearance29.ForeColor = System.Drawing.Color.Black
        Appearance29.ForeColorDisabled = System.Drawing.Color.Black
        Appearance29.TextVAlignAsString = "Middle"
        Me.lblSerienterminEnde.Appearance = Appearance29
        Me.lblSerienterminEnde.Location = New System.Drawing.Point(8, 9)
        Me.lblSerienterminEnde.Name = "lblSerienterminEnde"
        Me.lblSerienterminEnde.Size = New System.Drawing.Size(67, 17)
        Me.lblSerienterminEnde.TabIndex = 505
        Me.lblSerienterminEnde.Tag = "ResID.plan.EndetAm"
        Me.lblSerienterminEnde.Text = "Endet am"
        '
        'chkGanzerTag
        '
        Appearance31.BackColor = System.Drawing.Color.Transparent
        Appearance31.BackColorDisabled = System.Drawing.Color.Transparent
        Appearance31.ForeColor = System.Drawing.Color.Black
        Appearance31.ForeColorDisabled = System.Drawing.Color.Black
        Appearance31.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.chkGanzerTag.Appearance = Appearance31
        Me.chkGanzerTag.BackColor = System.Drawing.Color.Transparent
        Me.chkGanzerTag.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkGanzerTag.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkGanzerTag.Location = New System.Drawing.Point(220, 14)
        Me.chkGanzerTag.Name = "chkGanzerTag"
        Me.chkGanzerTag.Size = New System.Drawing.Size(88, 18)
        Me.chkGanzerTag.TabIndex = 1
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
        Me.dteEndetAm.Appearance = Appearance32
        Me.dteEndetAm.BackColor = System.Drawing.Color.White
        Me.dteEndetAm.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dteEndetAm.Location = New System.Drawing.Point(93, 40)
        Me.dteEndetAm.MaskInput = "{date} {time}"
        Me.dteEndetAm.Name = "dteEndetAm"
        Me.dteEndetAm.Size = New System.Drawing.Size(120, 21)
        Me.dteEndetAm.TabIndex = 2
        Me.dteEndetAm.Value = Nothing
        '
        'lblEndAt
        '
        Appearance30.BackColor = System.Drawing.Color.Transparent
        Appearance30.ForeColor = System.Drawing.Color.Black
        Appearance30.ForeColorDisabled = System.Drawing.Color.Black
        Appearance30.TextVAlignAsString = "Middle"
        Me.lblEndAt.Appearance = Appearance30
        Me.lblEndAt.Location = New System.Drawing.Point(7, 43)
        Me.lblEndAt.Name = "lblEndAt"
        Me.lblEndAt.Size = New System.Drawing.Size(78, 17)
        Me.lblEndAt.TabIndex = 503
        Me.lblEndAt.Tag = "ResID.plan.EndetAm"
        Me.lblEndAt.Text = "Endet am"
        '
        'picInfo
        '
        Me.picInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picInfo.BorderShadowColor = System.Drawing.Color.Empty
        Me.picInfo.Image = CType(resources.GetObject("picInfo.Image"), Object)
        Me.picInfo.Location = New System.Drawing.Point(1095, 10)
        Me.picInfo.Name = "picInfo"
        Me.picInfo.Size = New System.Drawing.Size(20, 21)
        Me.picInfo.TabIndex = 495
        Me.picInfo.Visible = False
        '
        'lblErstelltVon
        '
        Me.lblErstelltVon.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance15.BackColor = System.Drawing.Color.Transparent
        Appearance15.FontData.SizeInPoints = 7.5!
        Appearance15.ForeColor = System.Drawing.Color.Black
        Appearance15.ForeColorDisabled = System.Drawing.Color.Black
        Appearance15.TextVAlignAsString = "Middle"
        Me.lblErstelltVon.Appearance = Appearance15
        Me.lblErstelltVon.AutoSize = True
        Me.lblErstelltVon.Location = New System.Drawing.Point(961, 15)
        Me.lblErstelltVon.Name = "lblErstelltVon"
        Me.lblErstelltVon.Size = New System.Drawing.Size(90, 13)
        Me.lblErstelltVon.TabIndex = 421
        Me.lblErstelltVon.Tag = ""
        Me.lblErstelltVon.Text = "Erstellt von: Admin"
        Me.lblErstelltVon.Visible = False
        '
        'lblErstelltAm
        '
        Me.lblErstelltAm.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance13.BackColor = System.Drawing.Color.Transparent
        Appearance13.FontData.SizeInPoints = 7.5!
        Appearance13.ForeColor = System.Drawing.Color.Black
        Appearance13.ForeColorDisabled = System.Drawing.Color.Black
        Appearance13.TextVAlignAsString = "Middle"
        Me.lblErstelltAm.Appearance = Appearance13
        Me.lblErstelltAm.AutoSize = True
        Me.lblErstelltAm.Location = New System.Drawing.Point(961, 30)
        Me.lblErstelltAm.Name = "lblErstelltAm"
        Me.lblErstelltAm.Size = New System.Drawing.Size(154, 13)
        Me.lblErstelltAm.TabIndex = 493
        Me.lblErstelltAm.Tag = ""
        Me.lblErstelltAm.Text = "Erstellt am: 2017-08-23 12:23:21"
        Me.lblErstelltAm.Visible = False
        '
        'dteBeginntAm
        '
        Appearance12.BackColor = System.Drawing.Color.White
        Appearance12.BackColor2 = System.Drawing.Color.White
        Appearance12.BackColorDisabled = System.Drawing.Color.White
        Appearance12.BackColorDisabled2 = System.Drawing.Color.White
        Appearance12.FontData.BoldAsString = "False"
        Appearance12.FontData.ItalicAsString = "False"
        Appearance12.FontData.Name = "Microsoft Sans Serif"
        Appearance12.FontData.SizeInPoints = 8.25!
        Appearance12.FontData.StrikeoutAsString = "False"
        Appearance12.FontData.UnderlineAsString = "False"
        Appearance12.ForeColor = System.Drawing.Color.Black
        Appearance12.ForeColorDisabled = System.Drawing.Color.Black
        Me.dteBeginntAm.Appearance = Appearance12
        Me.dteBeginntAm.BackColor = System.Drawing.Color.White
        Me.dteBeginntAm.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dteBeginntAm.Location = New System.Drawing.Point(93, 13)
        Me.dteBeginntAm.MaskInput = "{date} {time}"
        Me.dteBeginntAm.Name = "dteBeginntAm"
        Me.dteBeginntAm.Size = New System.Drawing.Size(121, 21)
        Me.dteBeginntAm.TabIndex = 0
        Me.dteBeginntAm.Value = Nothing
        '
        'lblStartAt
        '
        Appearance5.BackColor = System.Drawing.Color.Transparent
        Appearance5.ForeColor = System.Drawing.Color.Black
        Appearance5.ForeColorDisabled = System.Drawing.Color.Black
        Appearance5.TextVAlignAsString = "Middle"
        Me.lblStartAt.Appearance = Appearance5
        Me.lblStartAt.Location = New System.Drawing.Point(7, 15)
        Me.lblStartAt.Name = "lblStartAt"
        Me.lblStartAt.Size = New System.Drawing.Size(78, 17)
        Me.lblStartAt.TabIndex = 382
        Me.lblStartAt.Tag = "ResID.plan.BeginntAm"
        Me.lblStartAt.Text = "Beginnt am"
        '
        'cboPriorität
        '
        Appearance10.BackColor = System.Drawing.Color.White
        Appearance10.BackColor2 = System.Drawing.Color.White
        Appearance10.BackColorDisabled = System.Drawing.Color.White
        Appearance10.BackColorDisabled2 = System.Drawing.Color.White
        Appearance10.FontData.Name = "Microsoft Sans Serif"
        Appearance10.ForeColor = System.Drawing.Color.Black
        Appearance10.ForeColorDisabled = System.Drawing.Color.Black
        Me.cboPriorität.Appearance = Appearance10
        Me.cboPriorität.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.SuggestAppend
        Me.cboPriorität.AutoSize = False
        Me.cboPriorität.BackColor = System.Drawing.Color.White
        Me.cboPriorität.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched
        Me.cboPriorität.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Appearance11.BackColor = System.Drawing.Color.White
        Appearance11.BackColorDisabled = System.Drawing.Color.White
        Appearance11.BorderColor = System.Drawing.Color.Black
        Appearance11.ForeColor = System.Drawing.Color.Black
        Appearance11.ForeColorDisabled = System.Drawing.Color.Black
        Me.cboPriorität.ItemAppearance = Appearance11
        Me.cboPriorität.Location = New System.Drawing.Point(93, 67)
        Me.cboPriorität.Name = "cboPriorität"
        Me.cboPriorität.Size = New System.Drawing.Size(81, 20)
        Me.cboPriorität.TabIndex = 5
        '
        'lbkPriorität
        '
        Appearance8.BackColor = System.Drawing.Color.Transparent
        Appearance8.ForeColor = System.Drawing.Color.Black
        Appearance8.ForeColorDisabled = System.Drawing.Color.Black
        Appearance8.TextVAlignAsString = "Middle"
        Me.lbkPriorität.Appearance = Appearance8
        Me.lbkPriorität.Location = New System.Drawing.Point(7, 69)
        Me.lbkPriorität.Name = "lbkPriorität"
        Me.lbkPriorität.Size = New System.Drawing.Size(77, 17)
        Me.lbkPriorität.TabIndex = 420
        Me.lbkPriorität.Tag = "ResID.Priority"
        Me.lbkPriorität.Text = "Priorität"
        '
        'dropDownAnhänge
        '
        Me.dropDownAnhänge.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.dropDownAnhänge.Location = New System.Drawing.Point(292, 93)
        Me.dropDownAnhänge.Name = "dropDownAnhänge"
        Me.dropDownAnhänge.Size = New System.Drawing.Size(97, 22)
        Me.dropDownAnhänge.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.dropDownAnhänge.TabIndex = 13
        Me.dropDownAnhänge.Tag = "ResID.Anhang"
        Me.dropDownAnhänge.Text = "Anhänge"
        '
        'chkTextIsHtml
        '
        Me.chkTextIsHtml.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Appearance44.BackColor = System.Drawing.Color.Transparent
        Appearance44.BackColorDisabled = System.Drawing.Color.Transparent
        Appearance44.ForeColor = System.Drawing.Color.Black
        Appearance44.ForeColorDisabled = System.Drawing.Color.Black
        Appearance44.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent
        Me.chkTextIsHtml.Appearance = Appearance44
        Me.chkTextIsHtml.BackColor = System.Drawing.Color.Transparent
        Me.chkTextIsHtml.BackColorInternal = System.Drawing.Color.Transparent
        Me.chkTextIsHtml.Cursor = System.Windows.Forms.Cursors.Default
        Me.chkTextIsHtml.Location = New System.Drawing.Point(9, 12)
        Me.chkTextIsHtml.Name = "chkTextIsHtml"
        Me.chkTextIsHtml.Size = New System.Drawing.Size(57, 15)
        Me.chkTextIsHtml.TabIndex = 0
        Me.chkTextIsHtml.TabStop = False
        Me.chkTextIsHtml.Tag = "ResID.Html"
        Me.chkTextIsHtml.Text = "Html"
        UltraToolTipInfo4.ToolTipTextFormatted = "Text unterhalb in Html oder als normalen Text darstellen"
        UltraToolTipInfo4.ToolTipTitle = "Html"
        Me.UltraToolTipManager1.SetUltraToolTip(Me.chkTextIsHtml, UltraToolTipInfo4)
        Me.chkTextIsHtml.UseFlatMode = Infragistics.Win.DefaultableBoolean.[True]
        Me.chkTextIsHtml.UseOsThemes = Infragistics.Win.DefaultableBoolean.[False]
        '
        'ContextMenuStripSysMode
        '
        Me.ContextMenuStripSysMode.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditierenToolStripMenuItem, Me.PlanungsenträgeDieZuDiesemEintragGehörenToolStripMenuItem, Me.PlanungseintragAusGesendeterListeLöschenToolStripMenuItem})
        Me.ContextMenuStripSysMode.Name = "ContextMenuStripStatBar"
        Me.ContextMenuStripSysMode.Size = New System.Drawing.Size(329, 70)
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
        'PanelBottom
        '
        Me.PanelBottom.BackColor = System.Drawing.Color.Transparent
        Me.PanelBottom.Controls.Add(Me.btnWeiterleiten)
        Me.PanelBottom.Controls.Add(Me.btnAntworten)
        Me.PanelBottom.Controls.Add(Me.btnAbort)
        Me.PanelBottom.Controls.Add(Me.chkTextIsHtml)
        Me.PanelBottom.Controls.Add(Me.btnSave)
        Me.PanelBottom.Controls.Add(Me.btnDel)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 694)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(1122, 39)
        Me.PanelBottom.TabIndex = 100
        '
        'btnWeiterleiten
        '
        Me.btnWeiterleiten.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance41.ForeColor = System.Drawing.Color.Black
        Appearance41.ForeColorDisabled = System.Drawing.Color.Black
        Me.btnWeiterleiten.Appearance = Appearance41
        Me.btnWeiterleiten.Location = New System.Drawing.Point(727, 6)
        Me.btnWeiterleiten.Name = "btnWeiterleiten"
        Me.btnWeiterleiten.Size = New System.Drawing.Size(98, 26)
        Me.btnWeiterleiten.TabIndex = 101
        Me.btnWeiterleiten.Tag = "ResID.ReplyAll"
        Me.btnWeiterleiten.Text = "Weiterleiten"
        '
        'btnAntworten
        '
        Me.btnAntworten.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance42.ForeColor = System.Drawing.Color.Black
        Appearance42.ForeColorDisabled = System.Drawing.Color.Black
        Me.btnAntworten.Appearance = Appearance42
        Me.btnAntworten.Location = New System.Drawing.Point(640, 6)
        Me.btnAntworten.Name = "btnAntworten"
        Me.btnAntworten.Size = New System.Drawing.Size(87, 26)
        Me.btnAntworten.TabIndex = 100
        Me.btnAntworten.Tag = "ResID.Reply"
        Me.btnAntworten.Text = "Antworten"
        '
        'btnAbort
        '
        Me.btnAbort.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance43.ForeColor = System.Drawing.Color.Black
        Appearance43.ForeColorDisabled = System.Drawing.Color.Black
        Me.btnAbort.Appearance = Appearance43
        Me.btnAbort.Location = New System.Drawing.Point(930, 6)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(84, 26)
        Me.btnAbort.TabIndex = 103
        Me.btnAbort.Tag = "ResID.Abort"
        Me.btnAbort.Text = "Abbrechen"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance45.ForeColor = System.Drawing.Color.Black
        Appearance45.ForeColorDisabled = System.Drawing.Color.Black
        Me.btnSave.Appearance = Appearance45
        Me.btnSave.Location = New System.Drawing.Point(1014, 6)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 26)
        Me.btnSave.TabIndex = 104
        Me.btnSave.Tag = "ResID.Save"
        Me.btnSave.Text = "Speichern"
        '
        'btnDel
        '
        Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance46.Cursor = System.Windows.Forms.Cursors.Default
        Appearance46.TextHAlignAsString = "Center"
        Appearance46.TextVAlignAsString = "Middle"
        Me.btnDel.Appearance = Appearance46
        Me.btnDel.ImageSize = New System.Drawing.Size(20, 20)
        Me.btnDel.Location = New System.Drawing.Point(893, 6)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(30, 26)
        Me.btnDel.TabIndex = 102
        '
        'PanelBetreff
        '
        Me.PanelBetreff.BackColor = System.Drawing.Color.Transparent
        Me.PanelBetreff.Controls.Add(Me.txtBetreff)
        Me.PanelBetreff.Controls.Add(Me.dropDownTextvorlagen)
        Me.PanelBetreff.Controls.Add(Me.lblBetreff)
        Me.PanelBetreff.Controls.Add(Me.dropDownCategories)
        Me.PanelBetreff.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelBetreff.Location = New System.Drawing.Point(0, 108)
        Me.PanelBetreff.Name = "PanelBetreff"
        Me.PanelBetreff.Size = New System.Drawing.Size(1122, 33)
        Me.PanelBetreff.TabIndex = 1
        '
        'txtBetreff
        '
        Me.txtBetreff.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance33.BackColor = System.Drawing.Color.White
        Appearance33.BackColor2 = System.Drawing.Color.White
        Appearance33.BackColorDisabled = System.Drawing.Color.White
        Appearance33.BackColorDisabled2 = System.Drawing.Color.White
        Appearance33.FontData.BoldAsString = "False"
        Appearance33.FontData.ItalicAsString = "False"
        Appearance33.FontData.Name = "Microsoft Sans Serif"
        Appearance33.FontData.SizeInPoints = 8.25!
        Appearance33.FontData.StrikeoutAsString = "False"
        Appearance33.FontData.UnderlineAsString = "False"
        Appearance33.ForeColor = System.Drawing.Color.Black
        Appearance33.ForeColorDisabled = System.Drawing.Color.Black
        Me.txtBetreff.Appearance = Appearance33
        Me.txtBetreff.AutoSize = False
        Me.txtBetreff.BackColor = System.Drawing.Color.White
        Me.txtBetreff.Location = New System.Drawing.Point(208, 6)
        Me.txtBetreff.MaxLength = 0
        Me.txtBetreff.Name = "txtBetreff"
        Me.txtBetreff.Size = New System.Drawing.Size(808, 23)
        Me.txtBetreff.TabIndex = 0
        Me.txtBetreff.Tag = "Vorname"
        '
        'dropDownTextvorlagen
        '
        Me.dropDownTextvorlagen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dropDownTextvorlagen.ButtonStyle = Infragistics.Win.UIElementButtonStyle.Flat
        Me.dropDownTextvorlagen.Location = New System.Drawing.Point(1031, 7)
        Me.dropDownTextvorlagen.Name = "dropDownTextvorlagen"
        Me.dropDownTextvorlagen.Size = New System.Drawing.Size(83, 22)
        Me.dropDownTextvorlagen.Style = Infragistics.Win.Misc.SplitButtonDisplayStyle.DropDownButtonOnly
        Me.dropDownTextvorlagen.TabIndex = 1
        Me.dropDownTextvorlagen.Tag = "ResID.Templates"
        Me.dropDownTextvorlagen.Text = "Vorlagen"
        '
        'lblBetreff
        '
        Appearance34.BackColor = System.Drawing.Color.Transparent
        Appearance34.ForeColor = System.Drawing.Color.Black
        Appearance34.ForeColorDisabled = System.Drawing.Color.Black
        Appearance34.TextVAlignAsString = "Middle"
        Me.lblBetreff.Appearance = Appearance34
        Me.lblBetreff.Location = New System.Drawing.Point(167, 9)
        Me.lblBetreff.Name = "lblBetreff"
        Me.lblBetreff.Size = New System.Drawing.Size(77, 17)
        Me.lblBetreff.TabIndex = 421
        Me.lblBetreff.Tag = "ResID.Subject"
        Me.lblBetreff.Text = "Betreff"
        '
        'PanelDescription
        '
        Me.PanelDescription.BackColor = System.Drawing.Color.Transparent
        Me.PanelDescription.Controls.Add(Me.optStatus)
        Me.PanelDescription.Controls.Add(Me.PanelEditor)
        Me.PanelDescription.Controls.Add(Me.EditorTmp1)
        Me.PanelDescription.Controls.Add(Me.UltraLabel1)
        Me.PanelDescription.Controls.Add(Me.lblStartAt)
        Me.PanelDescription.Controls.Add(Me.dropDownPatienten)
        Me.PanelDescription.Controls.Add(Me.dropDownAnhänge)
        Me.PanelDescription.Controls.Add(Me.dropDownUsers)
        Me.PanelDescription.Controls.Add(Me.lbkPriorität)
        Me.PanelDescription.Controls.Add(Me.lblStatus)
        Me.PanelDescription.Controls.Add(Me.cboPriorität)
        Me.PanelDescription.Controls.Add(Me.dteBeginntAm)
        Me.PanelDescription.Controls.Add(Me.lblErstelltAm)
        Me.PanelDescription.Controls.Add(Me.chkIsSerientermin)
        Me.PanelDescription.Controls.Add(Me.lblErstelltVon)
        Me.PanelDescription.Controls.Add(Me.cboDauer)
        Me.PanelDescription.Controls.Add(Me.picInfo)
        Me.PanelDescription.Controls.Add(Me.grpSerientermin)
        Me.PanelDescription.Controls.Add(Me.lblEndAt)
        Me.PanelDescription.Controls.Add(Me.chkGanzerTag)
        Me.PanelDescription.Controls.Add(Me.dteEndetAm)
        Me.PanelDescription.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelDescription.Location = New System.Drawing.Point(0, 141)
        Me.PanelDescription.Name = "PanelDescription"
        Me.PanelDescription.Size = New System.Drawing.Size(1122, 120)
        Me.PanelDescription.TabIndex = 2
        '
        'PanelEditor
        '
        Me.PanelEditor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelEditor.BackColor = System.Drawing.Color.Transparent
        Me.PanelEditor.Location = New System.Drawing.Point(1064, 69)
        Me.PanelEditor.Name = "PanelEditor"
        Me.PanelEditor.Size = New System.Drawing.Size(54, 46)
        Me.PanelEditor.TabIndex = 507
        '
        'EditorTmp1
        '
        Me.EditorTmp1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EditorTmp1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.EditorTmp1.Location = New System.Drawing.Point(1064, 71)
        Me.EditorTmp1.Name = "EditorTmp1"
        Me.EditorTmp1.Size = New System.Drawing.Size(51, 44)
        Me.EditorTmp1.TabIndex = 506
        Me.EditorTmp1.Text = "TextControl1"
        Me.EditorTmp1.UserNames = Nothing
        '
        'PanelBody
        '
        Me.PanelBody.BackColor = System.Drawing.Color.Transparent
        Me.PanelBody.Controls.Add(Me.PanelTxtEditor)
        Me.PanelBody.Controls.Add(Me.winFormHtmlEditor1)
        Me.PanelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBody.Location = New System.Drawing.Point(0, 261)
        Me.PanelBody.Name = "PanelBody"
        Me.PanelBody.Size = New System.Drawing.Size(1122, 433)
        Me.PanelBody.TabIndex = 2
        '
        'PanelTxtEditor
        '
        Me.PanelTxtEditor.BackColor = System.Drawing.Color.Transparent
        Me.PanelTxtEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelTxtEditor.Location = New System.Drawing.Point(0, 0)
        Me.PanelTxtEditor.Name = "PanelTxtEditor"
        Me.PanelTxtEditor.Size = New System.Drawing.Size(1122, 433)
        Me.PanelTxtEditor.TabIndex = 7
        '
        'frmNachricht3
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1122, 733)
        Me.Controls.Add(Me.PanelBody)
        Me.Controls.Add(Me.PanelDescription)
        Me.Controls.Add(Me.PanelBetreff)
        Me.Controls.Add(Me.PanelMailAdr)
        Me.Controls.Add(Me.PanelMailTop)
        Me.Controls.Add(Me.PanelBottom)
        Me.DoubleBuffered = True
        Me.MinimumSize = New System.Drawing.Size(1022, 600)
        Me.Name = "frmNachricht3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planungseintrag"
        Me.winFormHtmlEditor1.ResumeLayout(False)
        Me.winFormHtmlEditor1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.UltraPanel1.ResumeLayout(False)
        CType(Me.toolbarsManagerText, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMailAdr.ResumeLayout(False)
        Me.PanelMailAdr.PerformLayout()
        CType(Me.txtMailCC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSendWithPostOfficeBoxForAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMailBCC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMailAn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMailTop.ResumeLayout(False)
        Me.PanelMailTop.PerformLayout()
        CType(Me.optStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIsSerientermin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDauer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grpSerientermin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSerientermin.ResumeLayout(False)
        Me.grpSerientermin.PerformLayout()
        Me.PanelSerientermineUISub.ResumeLayout(False)
        Me.PanelSerientermineUISub.PerformLayout()
        CType(Me.optSerienterminType, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.cboDauerSerientermin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteSerienterminEndetAm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkGanzerTag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteEndetAm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteBeginntAm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPriorität, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkTextIsHtml, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripSysMode.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBottom.ResumeLayout(False)
        Me.PanelBetreff.ResumeLayout(False)
        CType(Me.txtBetreff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDescription.ResumeLayout(False)
        Me.PanelDescription.PerformLayout()
        Me.PanelBody.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Sub loadForm()
        Try
            If Me.isLoaded Then Exit Sub

            Me.standardViewExtEditor = TXTextControl.ViewMode.PageView

            Me.loadRes()
            Me.contListeAnhang.initControl()
            Me.typAntworten = eAntworten.None

            'Me.btnTeilnehmer.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_persons, 32, 32)
            'Me.btnSendAnswer.Appearance.Image = ITSCont.core.SystemDb.getRes.getImage(core.SystemDb.getRes.ePicture.ico_send, core.SystemDb.getRes.ePicTyp.ico)

            Dim MaxIDSelListEntryReturn As Integer = -1
            Dim tSelListEntriesReturn As System.Collections.Generic.List(Of PMDS.db.Entities.tblSelListEntries) = Nothing
            MaxIDSelListEntryReturn = -1
            tSelListEntriesReturn = Nothing

            Me.initTxtControl()

            Me.contSelectPatienten.initControl(contSelectPatientenBenutzer.eTypeUI.Patients, False, False, Me.dropDownPatienten)
            Me.contSelectBenutzer.initControl(contSelectPatientenBenutzer.eTypeUI.Users, False, False, Me.dropDownUsers)

            Me.contListeAnhang.modalWindow = Me
            Me.uPopUpContAnhänge.PopupControl = Me.contListeAnhang
            Me.dropDownAnhänge.PopupItem = Me.uPopUpContAnhänge
            Me.contListeAnhang.popupContMainSearch = Me.uPopUpContAnhänge

            Me.contListTextTemplates1.mainWindow = Me
            Me.contListTextTemplates1.initControl()
            Me.uPopUpContTextvorlagen.PopupControl = Me.contListTextTemplates1
            Me.dropDownTextvorlagen.PopupItem = Me.uPopUpContTextvorlagen
            Me.contListTextTemplates1.popupContMainSearch = Me.uPopUpContTextvorlagen

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
            Me.contSelectSelListCategories.initControl("PlanCategory", False, False, Me.dropDownCategories, False, "Categories", "", False)
            Me.uPopupContCategories.PopupControl = Me.contSelectSelListCategories
            Me.dropDownCategories.PopupItem = Me.uPopupContCategories
            Me.contSelectSelListCategories.popupContMainSearch = Me.uPopupContCategories

            Me.loadCboDauer()
            Me.loadCboDauerSerientermin()

            If PMDS.Global.ENV.adminSecure Then
                Me.EditierenToolStripMenuItem.Visible = True
                Me.PlanungseintragAusGesendeterListeLöschenToolStripMenuItem.Visible = True
                Me.PlanungsenträgeDieZuDiesemEintragGehörenToolStripMenuItem.Visible = True
            Else
                Me.EditierenToolStripMenuItem.Visible = False
                Me.PlanungseintragAusGesendeterListeLöschenToolStripMenuItem.Visible = False
                Me.PlanungsenträgeDieZuDiesemEintragGehörenToolStripMenuItem.Visible = False
            End If

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            'Me.AcceptButton = Me.btnSave
            Me.CancelButton = Me.btnAbort

            Me.isLoaded = True

        Catch ex As Exception
            Throw New Exception("frmNachricht2.loadForm: " + ex.ToString())
        Finally
            Me.txtBetreff.Focus()
        End Try
    End Sub

    Public Sub initTxtControl()
        Try
            Me.contTxtEditor1.Dock = DockStyle.Fill
            Me.PanelTxtEditor.Controls.Add(Me.contTxtEditor1)
            Me.contTxtEditor1.typUI = QS2.Desktop.Txteditor.etyp.all
            Me.contTxtEditor1.LinealeOnOff(True)
            Me.contTxtEditor1.SetUIReadOnOff(False)
            Me.contTxtEditor1.loadForm(False, Nothing, False)
            Me.contTxtEditor1.setControlTyp()
            Me.contTxtEditor1.buttonBar1.Visible = False
            Me.contTxtEditor1.FileNew(False, False)

            AddHandler Me.contTxtEditor1.textControl1_IsToSave, AddressOf Me.textControl1_IsToSave

        Catch ex As Exception
            Throw New Exception("frmNachricht2.initTxtControl: " + ex.ToString())
        End Try
    End Sub
    Public Sub textControl1_IsToSave()
        Try


        Catch ex As Exception
            Throw New Exception("frmNachricht2.initTxtControl: " + ex.ToString())
        End Try
    End Sub

    Public Sub loadRes()
        Try
            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein2.ico_Message, 32, 32)

            Me.btnSendEMails.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_send, 32, 32)

            Me.btnSave.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Speichern, 32, 32)
            Me.btnDel.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)
            Me.btnAntworten.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_antworten, 32, 32)
            Me.btnWeiterleiten.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_antworten, 32, 32)

            Dim IsAdmin As Boolean = False
            If IsAdmin Then
            Else
            End If

            'If Not ITSCont.core.SystemDb.actUsr.rUsr.IsAdmin And Not Settings.adminSecure Then
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
    Public Sub loadCboDauerSerientermin()
        Try
            Me.cboDauerSerientermin.Clear()

            Dim itm As ValueListItem = Me.cboDauerSerientermin.Items.Add(7, doUI.getRes("1Week"))
            itm.Tag = "W"
            itm = Me.cboDauerSerientermin.Items.Add(14, doUI.getRes("2Week"))
            itm.Tag = "W"
            itm = Me.cboDauerSerientermin.Items.Add(21, doUI.getRes("3Week"))
            itm.Tag = "W"
            itm = Me.cboDauerSerientermin.Items.Add(28, doUI.getRes("4Week"))
            itm.Tag = "W"

            itm = Me.cboDauerSerientermin.Items.Add(1, doUI.getRes("1Month"))
            itm.Tag = "M"
            itm = Me.cboDauerSerientermin.Items.Add(2, doUI.getRes("2Month"))
            itm.Tag = "M"
            itm = Me.cboDauerSerientermin.Items.Add(3, doUI.getRes("3Month"))
            itm.Tag = "M"
            itm = Me.cboDauerSerientermin.Items.Add(4, doUI.getRes("4Month"))
            itm.Tag = "M"
            itm = Me.cboDauerSerientermin.Items.Add(5, doUI.getRes("5Month"))
            itm.Tag = "M"
            itm = Me.cboDauerSerientermin.Items.Add(6, doUI.getRes("6Month"))
            itm.Tag = "M"

            itm = Me.cboDauerSerientermin.Items.Add(1, doUI.getRes("1Year"))
            itm.Tag = "Y"
            itm = Me.cboDauerSerientermin.Items.Add(2, doUI.getRes("2Year"))
            itm.Tag = "Y"
            itm = Me.cboDauerSerientermin.Items.Add(3, doUI.getRes("3Year"))
            itm.Tag = "Y"
            itm = Me.cboDauerSerientermin.Items.Add(4, doUI.getRes("4Year"))
            itm.Tag = "Y"
            itm = Me.cboDauerSerientermin.Items.Add(5, doUI.getRes("5Year"))
            itm.Tag = "Y"
            itm = Me.cboDauerSerientermin.Items.Add(10, doUI.getRes("10Year"))
            itm.Tag = "Y"

        Catch ex As Exception
            Throw New Exception("frmNachricht.loadCboDauerSerientermin: " + ex.ToString())
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


    Private Sub AufgabeTerminNeu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If Me.InSharedMemory Then
                Me.contTxtEditor1.textControl1.Text = ""
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

    Public Function clear(ByRef refreshBenutzerpatients As Boolean) As Boolean
        Try
            Me.lblMailVon.Text = ""
            Me.lblEmpfangenAmGesendetAm.Text = ""

            Me.txtBetreff.Text = ""
            Me.dteBeginntAm.Value = Nothing
            Me.chkGanzerTag.Checked = False
            Me.dteEndetAm.Value = Nothing
            Me.cboDauer.Value = Nothing
            Me.setUIEndetAm(False, False)
            Me.setUISerientermine("", "")
            Me.cboDauerSerientermin.Value = Nothing

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
            Me.contSelectSelListCategories.txtSearch.Text = ""
            Me.contSelectSelListCategories.clearFilterSearch()
            Me.LastTextBody = ""

            Me.lblErstelltVon.Text = ""
            Me.lblErstelltAm.Text = ""
            Me.setInfoGeneral(Nothing, True)

            Me.EditierenToolStripMenuItem.Checked = False

            Me.clearSerientermineUI()

            If refreshBenutzerpatients Then
                Me.contSelectPatienten.DsPlan1.Clear()
                Me.contSelectPatienten.cboBerufsgruppen.Value = Nothing
                Me.contSelectPatienten._IDToSelect = Nothing
                Me.contSelectPatienten.loadDataAbtBereiche()
                Me.contSelectPatienten.loadBenutzerPatients(Nothing, Nothing, Nothing, False, True)
                Me.contSelectPatienten.utreeAbtBereiche.ActiveNode = Me.contSelectPatienten.utreeAbtBereiche.Nodes(0)

                Me.contSelectBenutzer.DsPlan1.Clear()
                Me.contSelectBenutzer.cboBerufsgruppen.Value = Nothing
                Me.contSelectBenutzer._IDToSelect = Nothing
                Me.contSelectBenutzer.loadDataAbtBereiche()
                Me.contSelectBenutzer.loadBenutzerPatients(Nothing, Nothing, Nothing, False, True)
                Me.contSelectBenutzer.utreeAbtBereiche.ActiveNode = Me.contSelectBenutzer.utreeAbtBereiche.Nodes(0)
            End If

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
            Me.opTagWochenMonat.Enabled = True
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
                    Me.grpWochentage.Enabled = False
                    Me.setWochentageAllOnOff(True)

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

    Public Function Init(ByVal Exch As General.exchPlan, IDArtNewPlan As Integer, TypeUI As contPlanungData.eTypeUI, PlanArchive As contPlanungData.cPlanArchive) As Boolean
        Try
            Me._TypeUI = TypeUI
            Me._PlanArchive = PlanArchive

            Me.Cursor = Cursors.WaitCursor
            Me.clear(True)

            Me.contSelectPatienten.utreeAbtBereiche.Enabled = True
            Me.contSelectBenutzer.utreeAbtBereiche.Enabled = True
            If Me._TypeUI = contPlanungData.eTypeUI.PlanKlienten Then

            ElseIf Me._TypeUI = contPlanungData.eTypeUI.PlanMy Then
                Me.contSelectBenutzer.utreeAbtBereiche.Enabled = False
            ElseIf Me._TypeUI = contPlanungData.eTypeUI.PlansAll Then

            ElseIf Me._TypeUI = contPlanungData.eTypeUI.IDKlient Then
                Me.contSelectPatienten.utreeAbtBereiche.Enabled = False
            Else
                Throw New Exception("frmNachricht2.Init: Me.ContPlanung1._TypeUI '" + Me._TypeUI.ToString() + "' not allowed!")
            End If


            Me.typAntworten = eAntworten.None
            If Exch.app = General.InitApplicationAufgabenTermine.nachrichtAnzeigen Then
                Me.frmStatus = General.eStatusForm.edit

                Me.dsPlan1 = New dsPlan()
                Me.compPlan1 = New compPlan()
                Me.compPlan1.getPlan(General.StrToGuid(Exch.str), compPlan.eTypSelPlan.id, Me.dsPlan1)
                Me.rPlan = Me.dsPlan1.plan.Rows(0)
                Me.loadData()
                'Me.initObjectControls(Me.IDArt, Me._TypeUI, Me._PlanArchive)

                Me.setUIAfterLoading()
                Me.setTitleWindow()
                Me.textAnzeigenxy(Me.rPlan.Text, Me.rPlan.html, Me.rPlan.IDArt)

                Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                    Dim tUser As IQueryable(Of PMDS.db.Entities.Benutzer) = Me.b.getUserByUserName2(Me.rPlan.ErstelltVon.Trim(), db)
                    If tUser.Count = 1 Then
                        Dim rUsr As PMDS.db.Entities.Benutzer = tUser.First
                        If Not rUsr.IDBerufsstand Is Nothing Then
                            If Me.b.UserCanSign(rUsr.IDBerufsstand.Value) Then
                                Me.lockUnlock(True)
                            Else
                                Me.lockUnlock(False)
                            End If
                        Else
                            Dim rUsrLoggedIn As PMDS.db.Entities.Benutzer = Me.b.LogggedOnUser(db)
                            If Me.rPlan.ErstelltVon.Trim() = "" Then
                                Throw New Exception("Init: Me.rPlan.ErstelltVon='' not allowed for IDPlan '" + Me.rPlan.ID.ToString() + "'!")
                            End If
                            If rUsrLoggedIn.Benutzer1.Trim().ToLower().Equals(Me.rPlan.ErstelltVon.Trim().ToLower()) Then
                                Me.lockUnlock(True)
                            Else
                                Me.lockUnlock(False)
                            End If
                        End If
                    ElseIf tUser.Count = 0 Then
                        Me.lockUnlock(False)
                    Else
                        Throw New Exception("frmNachricht.Init: tUser.Count>0 for Usr '" + Me.rPlan.ErstelltVon.Trim() + "' not allowed!")
                    End If

                End Using

                If Not Me.rPlan.IsIDSerienterminNull() Then
                    Me.PanelSerientermineUISub.Enabled = False
                Else
                    Me.PanelSerientermineUISub.Enabled = True
                End If

                Me.optStatus.Visible = False
                Me.lblStatus.Visible = False

                Me.dropDownPatienten.Text = Me.contSelectPatienten.setLabelCount2()
                Me.dropDownUsers.Text = Me.contSelectBenutzer.setLabelCount2()
                Me.contSelectSelListCategories.setLabelCount2()
                Me.dropDownAnhänge.Text = Me.contListeAnhang.setLabelCount2("Anhang")

                If Me.rPlan.IsIDSerienterminNull() Then
                    Me.chkIsSerientermin.Visible = False
                End If

                'Me.lblArt.Visible = False
                'Me.cboArt2.Visible = False
            Else
                Me.frmStatus = General.eStatusForm.neu
                Me.IDArt = IDArtNewPlan
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
                Dim dNow As DateTime = Now
                Me.dteBeginntAm.DateTime = dNow
                Me.dteEndetAm.DateTime = dNow.AddMinutes(30)
                Me.cboDauer.Value = 30

                Me.optStatus.Visible = False
                Me.lblStatus.Visible = False

                Me.contSelectBenutzer._IDPlan = Me.rPlan.ID
                Me.contSelectPatienten._IDPlan = Me.rPlan.ID
                Me.contListeAnhang.loadData(rPlan.ID)
                Me.initObjectControls(Me.IDArt, Me._TypeUI, Me._PlanArchive)

                Me.setUIAfterLoading()
                'Me.genMain.loadSignature(Me.ContTxtEditor1)
                Me.setTitleWindow()
                Dim sHtmlSignature As String = Me.genMain.loadSignatureAsHTMLxy()
                If Me.IDArt = clPlan.typPlan_EMailEmpfangen Or Me.IDArt = clPlan.typPlan_EMailGesendet Then
                    Me.winFormHtmlEditor1.DocumentHtml = sHtmlSignature
                Else
                    If Not Me.isFirstShow Then
                        Me.contTxtEditor1.textControl1.Load(sHtmlSignature, TXTextControl.StreamType.HTMLFormat)
                    End If
                End If
                Me.LastTextBody = Me.winFormHtmlEditor1.DocumentHtml

                Me.PanelSerientermineUISub.Enabled = True
                Me.lockUnlock(True)

                Me.dropDownPatienten.Text = Me.contSelectPatienten.setLabelCount2()
                Me.dropDownUsers.Text = Me.contSelectBenutzer.setLabelCount2()
                Me.contSelectSelListCategories.setLabelCount2()
                Me.dropDownAnhänge.Text = Me.contListeAnhang.setLabelCount2("Anhang")

            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht.Init: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Function
    Public Sub initObjectControls(IDArt As Integer, TypeUI As contPlanungData.eTypeUI, PlanArchive As contPlanungData.cPlanArchive)
        Try
            If Me.frmStatus = General.eStatusForm.edit Then
            ElseIf Me.frmStatus = General.eStatusForm.neu Then
            End If

            Dim _UserCanChangeBenutzerPatientsTmp1 As Boolean = Me.contSelectBenutzer._UserCanChangeBenutzerPatients
            Dim _UserCanChangeBenutzerPatientsTmp2 As Boolean = Me.contSelectPatienten._UserCanChangeBenutzerPatients
            Me.contSelectBenutzer._UserCanChangeBenutzerPatients = True
            Me.contSelectPatienten._UserCanChangeBenutzerPatients = True

            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                Dim rUsrLoggedOn As PMDS.db.Entities.Benutzer = Me.b.LogggedOnUser(db)

                If TypeUI = contPlanungData.eTypeUI.PlanKlienten Then
                    Me.contSelectBenutzer.addIDObjectToList(rUsrLoggedOn.ID)
                    Dim IDFoundTree As Boolean = False
                    Me.contSelectPatienten.autoSelectAllForAbtBereich(PlanArchive.IDAbteilung_Patienten, PlanArchive.IDBereich_Patienten, False, Nothing, True, TypeUI, IDFoundTree)
                    'Me.contSelectPatienten.autoSelectAllForAbtBereich(PMDS.Global.Settings.CurrentIDAbteilung, PMDS.Global.Settings.IDBereich, False, Nothing, True)
                    Me.contSelectBenutzer.cboBerufsgruppen.Value = Nothing
                    IDFoundTree = False
                    Me.contSelectBenutzer.autoSelectAllForAbtBereich(PlanArchive.IDAbteilung_Benutzer, PlanArchive.IDBereich_Benutzer, False, rUsrLoggedOn.ID, True, TypeUI, IDFoundTree)

                    Me.contSelectBenutzer.setLabelCount2()

                ElseIf TypeUI = contPlanungData.eTypeUI.PlanMy Then
                    Me.contSelectBenutzer.addIDObjectToList(rUsrLoggedOn.ID)
                    Dim IDFoundTree As Boolean = False
                    Me.contSelectPatienten.autoSelectAllForAbtBereich(PlanArchive.IDAbteilung_Patienten, PlanArchive.IDBereich_Patienten, False, Nothing, True, TypeUI, IDFoundTree)
                    Me.contSelectBenutzer.cboBerufsgruppen.Value = Nothing
                    IDFoundTree = False
                    Me.contSelectBenutzer.autoSelectAllForAbtBereich(Nothing, Nothing, False, rUsrLoggedOn.ID, False, TypeUI, IDFoundTree)

                    Me.contSelectBenutzer.setLabelCount2()

                ElseIf TypeUI = contPlanungData.eTypeUI.PlansAll Then
                    Me.contSelectBenutzer.addIDObjectToList(rUsrLoggedOn.ID)

                    Dim IDFoundTree As Boolean = False
                    Me.contSelectPatienten.autoSelectAllForAbtBereich(PlanArchive.IDAbteilung_Patienten, PlanArchive.IDBereich_Patienten, False, Nothing, True, TypeUI, IDFoundTree)
                    Me.contSelectBenutzer.cboBerufsgruppen.Value = Nothing
                    IDFoundTree = False
                    Me.contSelectBenutzer.autoSelectAllForAbtBereich(PlanArchive.IDAbteilung_Benutzer, PlanArchive.IDBereich_Benutzer, False, rUsrLoggedOn.ID, True, TypeUI, IDFoundTree)

                    Me.contSelectBenutzer.setLabelCount2()

                ElseIf TypeUI = contPlanungData.eTypeUI.IDKlient Then
                    Me.contSelectBenutzer.addIDObjectToList(rUsrLoggedOn.ID)
                    Me.contSelectPatienten.addIDObjectToList(PMDS.Global.ENV.CurrentIDPatient)

                    Dim IDFoundTree As Boolean = False
                    Me.contSelectPatienten.autoSelectAllForAbtBereich(Nothing, Nothing, False, PMDS.Global.ENV.CurrentIDPatient, False, TypeUI, IDFoundTree)
                    Me.contSelectBenutzer.cboBerufsgruppen.Value = Nothing
                    IDFoundTree = False
                    Me.contSelectBenutzer.autoSelectAllForAbtBereich(PlanArchive.IDAbteilung_Benutzer, PlanArchive.IDBereich_Benutzer, False, rUsrLoggedOn.ID, False, TypeUI, IDFoundTree)

                    Me.contSelectBenutzer.setLabelCount2()
                    Me.contSelectPatienten.setLabelCount2()
                Else
                    Throw New Exception("frmNachricht2.initObjectControls: TypeUITypeUI '" + TypeUI.ToString() + "' not allowed!")
                End If
            End Using

            Me.contSelectBenutzer._UserCanChangeBenutzerPatients = _UserCanChangeBenutzerPatientsTmp1
            Me.contSelectPatienten._UserCanChangeBenutzerPatients = _UserCanChangeBenutzerPatientsTmp2

        Catch ex As Exception
            Throw New Exception("frmNachricht2.initObjectControls: " + ex.ToString())
        End Try
    End Sub

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

            If Not Me.rPlan.Status.sEquals("") Then
                If Me.rPlan.Status.sEquals("Offen") Then
                    Me.optStatus.CheckedIndex = 0
                ElseIf Me.rPlan.Status.sEquals("Erledigt") Then
                    Me.optStatus.CheckedIndex = 1
                ElseIf Me.rPlan.Status.sEquals("Erfolglos") Then
                    Me.optStatus.CheckedIndex = 2
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
            Me.setUIEndetAm(Me.rPlan.GanzerTag, False)

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

            Dim _UserCanChangeBenutzerPatientsTmp1 As Boolean = Me.contSelectBenutzer._UserCanChangeBenutzerPatients
            Me.contSelectBenutzer._UserCanChangeBenutzerPatients = True
            Me.contSelectBenutzer.loadData2(Me.rPlan.ID, Nothing, False)
            Me.contSelectBenutzer._UserCanChangeBenutzerPatients = _UserCanChangeBenutzerPatientsTmp1

            Dim _UserCanChangeBenutzerPatientsTmp2 As Boolean = Me.contSelectPatienten._UserCanChangeBenutzerPatients
            Me.contSelectPatienten._UserCanChangeBenutzerPatients = True
            Me.contSelectPatienten.loadData2(Me.rPlan.ID, Nothing, False)
            Me.contSelectPatienten._UserCanChangeBenutzerPatients = _UserCanChangeBenutzerPatientsTmp2
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

            Me.contTxtEditor1.textControl1.Text = ""
            If General.InitHTMLEditorEveryClick Then
                contPlanungData.reloadHTMLControl(Me.PanelTxtEditor, Me.winFormHtmlEditor1)
            Else
                contPlanungData.ClearHTMLBrowser(Me.winFormHtmlEditor1)
            End If

            Me.chkTextIsHtml.Checked = html
            If html Then
                System.Windows.Forms.Application.DoEvents()
                If Me.IDArt = clPlan.typPlan_EMailEmpfangen Or Me.IDArt = clPlan.typPlan_EMailGesendet Then
                    Me.winFormHtmlEditor1.DocumentHtml = text
                Else
                    If Not Me.isFirstShow Then
                        Me.doEditor1.showText(text, TXTextControl.StreamType.HTMLFormat, Me.isEditable, TXTextControl.ViewMode.PageView, Me.contTxtEditor1.textControl1)
                    End If
                End If
                Me.LastTextBody = text
            Else
                System.Windows.Forms.Application.DoEvents()
                If Me.IDArt = clPlan.typPlan_EMailEmpfangen Or Me.IDArt = clPlan.typPlan_EMailGesendet Then
                    If clPlan.checkIfTextIsHtmlText(text.Trim()) Then
                        Me.chkTextIsHtml.Checked = True
                        Me.winFormHtmlEditor1.DocumentHtml = text
                    Else
                        Me.winFormHtmlEditor1.Content.SetBodyText(text)
                    End If
                Else
                    If Not Me.isFirstShow Then
                        Me.doEditor1.showText(text, TXTextControl.StreamType.PlainText, Me.isEditable, TXTextControl.ViewMode.PageView, Me.contTxtEditor1.textControl1)
                    End If
                End If
                Me.LastTextBody = text
            End If

            'If html Then
            '    Me.setHtml(True, False)
            'Else
            '    If clPlan.checkIfTextIsHtmlText(text.Trim()) Then
            '        Me.setHtml(True, False)
            '    Else
            '        Me.setHtml(False, False)
            '    End If
            'End If

        Catch ex As Exception
            Throw New Exception("frmNachricht.textAnzeigen: " + ex.ToString())
        End Try
    End Sub

    Public Sub antworten(ByVal typ As eAntworten)
        Try
            Dim IDActivity As System.Guid = Nothing             'Me.getSelActivity(False)

            Me._PlanArchive = New contPlanungData.cPlanArchive()
            Me.contSelectPatienten.getSelectedAbtBereich(Me._PlanArchive.IDKlinik_Patienten, Me._PlanArchive.IDAbteilung_Patienten, Me._PlanArchive.IDBereich_Patienten, Nothing, True)
            Me.contSelectBenutzer.getSelectedAbtBereich(Me._PlanArchive.IDKlinik_Benutzer, Me._PlanArchive.IDAbteilung_Benutzer, Me._PlanArchive.IDBereich_Benutzer, Nothing, True)

            Dim frmNewPlan As frmNachricht3 = Me.genMain.newMessage(Now, Now, Nothing, IDActivity, False, False, "", "", Nothing, False, True, Me._TypeUI, Me._PlanArchive)
            frmNewPlan.loadForm()
            Dim exch As New General.exchPlan
            exch.app = General.InitApplicationAufgabenTermine.terminNeu
            frmNewPlan.Init(exch, clPlan.typPlan_EMailGesendet, Me._TypeUI, Me._PlanArchive)
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

            Me.contListeAnhang.copyAnhänge(frmNewPlan.contListeAnhang.DsPlan2.planAnhang, frmNewPlan.rPlan.ID)
            frmNewPlan.contListeAnhang.doCount()
            frmNewPlan.setUIAfterLoading()
            If frmNewPlan.IDArt <> clPlan.typPlan_EMailGesendet And
               frmNewPlan.IDArt <> clPlan.typPlan_EMailEmpfangen Then

                frmNewPlan.setUIEMailAdressesOnOff()
            End If

            If General.InitHTMLEditorEveryClick Then
                contPlanungData.reloadHTMLControl(frmNewPlan.PanelTxtEditor, frmNewPlan.winFormHtmlEditor1)
            Else
                contPlanungData.ClearHTMLBrowser(frmNewPlan.winFormHtmlEditor1)
            End If

            frmNewPlan.textAnzeigenxy("", Me.isHtml, frmNewPlan.IDArt)
            frmNewPlan.winFormHtmlEditor1.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.WYSIWYG_Design

            If Me.isHtml Then
                frmNewPlan.winFormHtmlEditor1.Content.SetDocumentHtml(Me.winFormHtmlEditor1.DocumentHtml)
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
            frmNewPlan.dteBeginntAm.DateTime = Now
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
            doEditor1.showText(rTextTemplates.Txt, TXTextControl.StreamType.RichTextFormat, False, TXTextControl.ViewMode.PageView, Me.EditorTmp1)

            Dim sBodyOrig As String = ""
            If Me.chkTextIsHtml.Checked Then
                If Me.IDArt = clPlan.typPlan_EMailEmpfangen Or Me.IDArt = clPlan.typPlan_EMailGesendet Then
                    sBodyOrig = Me.winFormHtmlEditor1.DocumentHtml
                Else
                    Me.contTxtEditor1.textControl1.Save(sBodyOrig, TXTextControl.StringStreamType.HTMLFormat)
                End If
            Else
                If Me.IDArt = clPlan.typPlan_EMailEmpfangen Or Me.IDArt = clPlan.typPlan_EMailGesendet Then
                    sBodyOrig = Me.winFormHtmlEditor1.Content.GetBodyText()
                Else
                    Me.contTxtEditor1.textControl1.Save(sBodyOrig, TXTextControl.StringStreamType.PlainText)
                End If
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
                    Me.doEditor1.appendText2(sBodyOrig, Me.EditorTmp1, TXTextControl.StringStreamType.PlainText)
                End If
            End If

            If Me.IDArt = clPlan.typPlan_EMailEmpfangen Or Me.IDArt = clPlan.typPlan_EMailGesendet Then
                If General.InitHTMLEditorEveryClick Then
                    contPlanungData.reloadHTMLControl(Me.PanelTxtEditor, Me.winFormHtmlEditor1)
                Else
                    contPlanungData.ClearHTMLBrowser(Me.winFormHtmlEditor1)
                End If
            Else
                Me.contTxtEditor1.textControl1.Text = ""
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

            If Me._TypeUI = contPlanungData.eTypeUI.PlanKlienten Or Me._TypeUI = contPlanungData.eTypeUI.PlansAll Then
                Dim _UserCanChangeBenutzerPatientsTmp1 As Boolean = Me.contSelectBenutzer._UserCanChangeBenutzerPatients
                Dim _UserCanChangeBenutzerPatientsTmp2 As Boolean = Me.contSelectPatienten._UserCanChangeBenutzerPatients
                Me.contSelectBenutzer._UserCanChangeBenutzerPatients = True
                Me.contSelectPatienten._UserCanChangeBenutzerPatients = True
                Me.contSelectBenutzer.loadDataColl(rTextTemplates.lstIDBenutzer.Trim())
                Me.contSelectPatienten.loadDataColl(rTextTemplates.lstIDPatienten.Trim())
                Me.contSelectBenutzer._UserCanChangeBenutzerPatients = _UserCanChangeBenutzerPatientsTmp1
                Me.contSelectPatienten._UserCanChangeBenutzerPatients = _UserCanChangeBenutzerPatientsTmp2

                Me.dropDownPatienten.Text = Me.contSelectPatienten.setLabelCount2()
                Me.dropDownUsers.Text = Me.contSelectBenutzer.setLabelCount2()

                Me.contSelectSelListCategories.setSelectionOnOff(False)
                Me.contSelectSelListCategories.loadDataColl(rTextTemplates.lstCategories.Trim())
                Me.contSelectSelListCategories.setLabelCount2()
            End If

            If Me.IDArt = clPlan.typPlan_EMailEmpfangen Or Me.IDArt = clPlan.typPlan_EMailGesendet Then
                Me.winFormHtmlEditor1.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.WYSIWYG_Design
                If Me.chkTextIsHtml.Checked Then
                    BodyTmp = doEditor1.getText(TXTextControl.StringStreamType.HTMLFormat, Me.EditorTmp1)
                    Me.winFormHtmlEditor1.DocumentHtml = BodyTmp
                Else
                    BodyTmp = doEditor1.getText(TXTextControl.StringStreamType.PlainText, Me.EditorTmp1)
                    Me.winFormHtmlEditor1.Content.SetBodyText(BodyTmp)
                End If
            Else
                If Me.chkTextIsHtml.Checked Then
                    BodyTmp = doEditor1.getText(TXTextControl.StringStreamType.HTMLFormat, Me.EditorTmp1)
                    Me.doEditor1.showText(BodyTmp, TXTextControl.StreamType.HTMLFormat, Me.isEditable, TXTextControl.ViewMode.PageView, Me.contTxtEditor1.textControl1)
                Else
                    BodyTmp = doEditor1.getText(TXTextControl.StringStreamType.PlainText, Me.EditorTmp1)
                    Me.doEditor1.showText(BodyTmp, TXTextControl.StreamType.PlainText, Me.isEditable, TXTextControl.ViewMode.PageView, Me.contTxtEditor1.textControl1)
                End If
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

            Dim lstSelectedCategories As New System.Collections.Generic.List(Of String)()
            Dim sCategoriesSelected As String = Me.contSelectSelListCategories.getSelectedData2(lstSelectedCategories)
            If sCategoriesSelected.Trim() = "" Then
                Dim txt As String = doUI.getRes("CategorySelectionRequired")
                Me.ErrorProvider1.SetError(Me.txtBetreff, txt)
                doUI.doMessageBox2("CategorySelectionRequired", "", "!")
                txtBetreff.Focus()
                Return False
            End If

            If sCategoriesSelected.Trim() = "" And General.IsNull(Me.txtBetreff.Text) Then
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

            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                If Me._TypeUI = contPlanungData.eTypeUI.PlanKlienten Then
                    Dim lstPatientsSelected As System.Collections.Generic.List(Of Guid) = Me.contSelectPatienten.getList()
                    If lstPatientsSelected.Count = 0 Then
                        doUI.doMessageBox2("NoPatientsSelected", "", "!")
                        Return False
                    End If

                ElseIf Me._TypeUI = contPlanungData.eTypeUI.IDKlient Then
                    Dim lstPatientsSelected As System.Collections.Generic.List(Of Guid) = Me.contSelectPatienten.getList()
                    If lstPatientsSelected.Count = 0 Then
                        doUI.doMessageBox2("NoPatientsSelected", "", "!")
                        Return False
                    End If
                    If Not lstPatientsSelected.Contains(PMDS.Global.ENV.CurrentIDPatient) Then
                        Me.contSelectPatienten.addIDObjectToList(PMDS.Global.ENV.CurrentIDPatient)
                        'Throw New Exception("frmNachricht.checkInput: lstPatientsSelected not contains Settings.CurrentIDPatient (='" + PMDS.Global.Settings.CurrentIDPatient.ToString() + "')!")
                    End If

                ElseIf Me._TypeUI = contPlanungData.eTypeUI.PlanMy Then
                    Dim lstUsersSelected As System.Collections.Generic.List(Of Guid) = Me.contSelectBenutzer.getList()
                    Dim rUsrLoggedOn As PMDS.db.Entities.Benutzer = b.LogggedOnUser(db)
                    If Not lstUsersSelected.Contains(rUsrLoggedOn.ID) Then
                        Throw New Exception("frmNachricht.checkInput: lstUsersSelected not contains Settings.CurrentIDPatient (='" + PMDS.Global.ENV.CurrentIDPatient.ToString() + "')!")
                    End If

                End If
            End Using

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
                Using compUserAccounts1 As New compUserAccounts()
                    rUsrAccount = compUserAccounts1.getUserAccountsRow(Nothing, UserLoggedIn.Trim(), compUserAccounts.eTypSelUserAccounts.usr, compUserAccounts.eTypEMailAccount.SMTP, False, False)
                    If rUsrAccount Is Nothing Then
                        If withMsgBox Then
                            doUI.doMessageBox2("NoAccountForUserDefined", "", "!")
                        End If
                        Return False
                    Else
                        Return True
                    End If
                End Using
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
        Dim sInfoKlientPatients As String = ""
        Dim protokollOk As String = ""
        Dim protokollErr As String = ""
        Try
            If Not Me.checkInput(typAction) Then
                Return False
            End If

            Dim bSendOnServer As Boolean = False
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

            Dim EndetAmSerientermin As Nullable(Of Date) = Nothing
            If Me.frmStatus = General.eStatusForm.edit And (Not rPlan.IsIDSerienterminNull()) Then
                EndetAmSerientermin = rPlan.SerienterminEndetAm
            End If
            Dim IDSerientermin As Nullable(Of Guid) = Nothing
            Dim lstSerientermineResult As New System.Collections.Generic.List(Of General.cSerientermine)
            If Me.chkIsSerientermin.Checked Then
                If Me.frmStatus = General.eStatusForm.edit Then
                    If Not Me.rPlan.IsIDSerienterminNull() Then
                        IDSerientermin = Me.rPlan.IDSerientermin
                    Else
                        IDSerientermin = System.Guid.NewGuid()
                    End If
                Else
                    IDSerientermin = System.Guid.NewGuid()
                End If

                Dim sWochentage As String = Me.getWochentage()

                Dim iWiedWertJedenTmp As Nullable(Of Integer) = Nothing
                If (Not Me.iWiedWertJeden.Value Is Nothing) AndAlso (Not Me.iWiedWertJeden.Value Is System.DBNull.Value) Then
                    iWiedWertJedenTmp = Me.iWiedWertJeden.Value
                End If
                Dim iNTenMonatTmp As Nullable(Of Integer) = Nothing
                If (Not Me.iNTenMonat.Value Is Nothing) AndAlso (Not Me.iNTenMonat.Value Is System.DBNull.Value) Then
                    iNTenMonatTmp = Me.iNTenMonat.Value
                End If

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


            Dim STVerlängerung As Boolean = False
            Dim STKürzung As Boolean = False
            Dim ownerSucessfullySaved As Boolean = False
            Dim rPlanOwner As dsPlan.planRow = Me.dsPlan1.plan.Rows(0)
            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                If Me.setPlanRowTemp(rPlanOwner, Producer, Nothing, typAction, IDSerientermin) Then
                    db.Configuration.LazyLoadingEnabled = False
                    Dim rPlanOrigDB As PMDS.db.Entities.plan = Nothing
                    If Me.frmStatus <> General.eStatusForm.neu Then
                        rPlanOrigDB = Me.b.getPlan(rPlanOwner.ID, db)
                    End If

                    Dim iCounterKlientPatients As Integer = 0
                    Dim sInfoTmp As String = Me.contSelectPatienten.getObjectInfo(True, False, iCounterKlientPatients)
                    If iCounterKlientPatients > 0 Then
                        sInfoKlientPatients += vbNewLine + doUI.getRes("Patienten") + " (" + iCounterKlientPatients.ToString() + "): " + sInfoTmp
                    End If

                    iCounterKlientPatients = 0
                    sInfoTmp = ""
                    sInfoTmp = Me.contSelectBenutzer.getObjectInfo(False, True, iCounterKlientPatients)
                    If iCounterKlientPatients > 0 Then
                        sInfoKlientPatients += doUI.getRes("Benutzer") + " (" + iCounterKlientPatients.ToString() + "): " + sInfoTmp
                    End If

                    If UsrExchangeKto.Trim() <> "" Then
                        rPlanOwner.Für = UsrExchangeKto.Trim()
                        rSelUserAccountReturn = rSelUserAccount
                    End If
                    rPlanOwner.IsOwner = True

                    If Me.chkIsSerientermin.Checked Then
                        If Me.frmStatus = General.eStatusForm.neu Then
                            ownerSucessfullySaved = True
                        Else
                            If Me.dteSerienterminEndetAm.Value.Equals(EndetAmSerientermin) Then
                                If Me.saveNachrichtToDb2() Then
                                    ownerSucessfullySaved = True
                                    If typAction = eTypAction.saveButtClicked Then
                                        protokollOk = doUI.getRes("EntrySave") + vbNewLine + protokollOk
                                        If Me.chkIsSerientermin.Checked Then
                                            Me.updateSerientermine(rPlanOwner, rPlanOrigDB, db)
                                        End If
                                        Return True
                                    End If
                                End If
                            Else
                                Dim MsggResult As MsgBoxResult = MsgBoxResult.No
                                If Me.dteSerienterminEndetAm.DateTime > EndetAmSerientermin.Value Then
                                    MsggResult = doUI.doMessageBox3("SerienterminChangedVerlängern  ", "", MsgBoxStyle.YesNo, "?")
                                    If MsggResult = MsgBoxResult.Yes Then
                                        STVerlängerung = True
                                    End If

                                ElseIf Me.dteSerienterminEndetAm.DateTime < EndetAmSerientermin.Value Then
                                    MsggResult = doUI.doMessageBox3("SerienterminChangedVerkürzen", "", MsgBoxStyle.YesNo, "?")
                                    If MsggResult = MsgBoxResult.Yes Then
                                        STKürzung = True
                                    End If
                                End If

                                If MsggResult = MsgBoxResult.Yes Then
                                    If STKürzung Then
                                        'Me.compPlan1.deletePlan(rPlan.ID, rPlan.MessageId, rPlan.Für, Me.rPlan.IDArt, Me.rPlan.Betreff)
                                        If Me.saveNachrichtToDb2() Then
                                            Me.compPlan1.updatePlanSerienterminEndetAm(rPlan.IDSerientermin, rPlan.SerienterminEndetAm.Date)
                                            Me.compPlan1.deletePlanSerienterminEndetAm(rPlan.IDSerientermin, rPlan.SerienterminEndetAm.Date)
                                            ownerSucessfullySaved = True
                                            If typAction = eTypAction.saveButtClicked Then
                                                If Me.chkIsSerientermin.Checked Then
                                                    Me.updateSerientermine(rPlanOwner, rPlanOrigDB, db)
                                                End If
                                                protokollOk = doUI.getRes("EntrySave") + vbNewLine + protokollOk
                                                Return True
                                            End If
                                        End If
                                    End If
                                Else
                                    If Me.saveNachrichtToDb2() Then
                                        ownerSucessfullySaved = True
                                        If typAction = eTypAction.saveButtClicked Then
                                            If Me.chkIsSerientermin.Checked Then
                                                Me.updateSerientermine(rPlanOwner, rPlanOrigDB, db)
                                            End If
                                            protokollOk = doUI.getRes("EntrySave") + vbNewLine + protokollOk
                                            Return True
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If Me.saveNachrichtToDb2() Then
                            ownerSucessfullySaved = True
                            If typAction = eTypAction.saveButtClicked Then
                                protokollOk = doUI.getRes("EntrySave") + vbNewLine + protokollOk
                                Return True
                            End If
                        End If
                    End If
                Else
                    Throw New Exception("savePlan: Error saving E-Mail!")
                End If
            End Using

            Using db As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                db.Configuration.LazyLoadingEnabled = False
                Dim rPlanOrigDB As PMDS.db.Entities.plan = Nothing
                If Me.frmStatus <> General.eStatusForm.neu Then
                    rPlanOrigDB = Me.b.getPlan(rPlanOwner.ID, db)
                End If

                If ownerSucessfullySaved Then
                    Me.contListeAnhang.anhangTempSichern()
                    'Me.setPlanRowTemp(rPlanTemp, saveClicked, "", Nothing)

                    If Me.rPlan.IDArt = clPlan.typPlan_AufgabeTermin Then
                        ' Save Users
                        'Dim lstUsers As System.Collections.Generic.List(Of String) = PMDS.Global.generic.readStrVariables(Me.rPlan.Teilnehmer.Trim())
                        'If lstUsers.Count > 0 Then
                        If lstSerientermineResult.Count > 0 And (Not STKürzung) Then
                            Dim dsPlanNew As New dsPlan()
                            Dim compPlanNew As New compPlan()

                            For Each SerientermineAct As General.cSerientermine In lstSerientermineResult
                                Dim b As New PMDS.db.PMDSBusiness()

                                'Dim rUsr As PMDS.db.Entities.Benutzer = b.getUserByUserName(usr.Trim(), db)
                                Dim bWritePlan As Boolean = False
                                If Me.frmStatus = General.eStatusForm.edit Then
                                    If SerientermineAct.dFrom.Date >= Me.rPlan.BeginntAm.Date Then
                                        bWritePlan = True
                                    End If
                                Else
                                    bWritePlan = True
                                End If

                                If STVerlängerung Then
                                    Dim rPlan As PMDS.db.Entities.plan = b.getPlan(Me.rPlan.ID, db)
                                    Dim STEndetAmOrig As Date = Nothing
                                    If Not rPlan.IDSerientermin Is Nothing Then
                                        If SerientermineAct.dFrom.Date <= rPlan.SerienterminEndetAm.Value.Date Then
                                            bWritePlan = False
                                        End If
                                    Else
                                        bWritePlan = True
                                    End If
                                End If

                                If bWritePlan Then
                                    dsPlanNew.Clear()
                                    compPlanNew.getPlan(System.Guid.NewGuid(), compPlan.eTypSelPlan.id, dsPlanNew)
                                    compPlanNew.getPlanAnhang(System.Guid.NewGuid(), compPlan.eTypSelPlanAnhang.idPlan, dsPlanNew)
                                    compPlanNew.getPlanObject(System.Guid.NewGuid, compPlan.eTypSelPlanObject.id, dsPlanNew)

                                    Dim rPlanNew As dsPlan.planRow = Me.compPlan1.getNewRowPlan(dsPlanNew)
                                    rPlanNew.ItemArray = rPlanOwner.ItemArray
                                    rPlanNew.ID = System.Guid.NewGuid()
                                    rPlanNew.IDKlinik = PMDS.Global.ENV.IDKlinik
                                    'rPlanNew.Für = usr
                                    rPlanNew.IDPlanMain = rPlanOwner.ID
                                    rPlanNew.BeginntAm = SerientermineAct.dFrom
                                    rPlanNew.EndetAm = SerientermineAct.dTo

                                    Me.contSelectBenutzer.copyPlanObjects(dsPlanNew, rPlanNew.ID)
                                    Me.contSelectPatienten.copyPlanObjects(dsPlanNew, rPlanNew.ID)

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
                                End If
                            Next

                            If STVerlängerung Then
                                Me.compPlan1.updatePlanSerienterminEndetAm(rPlan.IDSerientermin, rPlan.SerienterminEndetAm.Date)
                            End If

                            If typAction = eTypAction.saveButtClicked Then
                                If Me.frmStatus <> General.eStatusForm.neu Then
                                    If Me.chkIsSerientermin.Checked Then
                                        Me.updateSerientermine(rPlanOwner, rPlanOrigDB, db)
                                    End If
                                End If
                            End If

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

                    Using dsInteropPar1 = New dsInteropPar()
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
                    End Using
                End If
            End Using

            Throw New Exception("savePlan: Error saving Plan!")
            Return False

        Catch ex As Exception
            Throw New Exception("frmNachricht.savePlan2: " + ex.ToString())
        Finally
            If Not protokollOk.Trim() = "" Then
                MsgBox(protokollOk + sInfoKlientPatients, MsgBoxStyle.Information, doUI.getRes("Save"))
            End If
            Me.doProtokoll(protokollErr, doUI.getRes("SavePlan"))
        End Try
    End Function

    Public Sub updateSerientermine(ByRef rPlanOrig As dsPlan.planRow, ByRef rPlanOrigDB As PMDS.db.Entities.plan, db As PMDS.db.Entities.ERModellPMDSEntities)
        Try
            Dim tPlansST As IQueryable(Of PMDS.db.Entities.plan) = Me.b.getPlansSerientermin5(rPlanOrig.IDSerientermin, db)
            If tPlansST.Count() > 0 Then
                Dim frmInputDate1 As New frmInputDate()
                frmInputDate1.initControl(frmInputDate.eTypUI.SerientermineSaveChanged)
                frmInputDate1.ShowDialog(Me)
                If Not frmInputDate1.abort Then
                    'Dim resUpdateStatusÜbernehmen As DialogResult = DialogResult.No
                    'If Not rPlanOrig.Status.Trim().ToLower().Equals(rPlanOrigDB.Status.Trim().ToLower()) Then
                    '    Dim sMsgBoxTxt11 As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Der Status des Serientermines wurde geändert!")
                    '    Dim sMsgBoxTxt12 As String = QS2.Desktop.ControlManagment.ControlManagment.getRes("Sollen der Status für alle Beteiligten dieses Serientermines übernommen werden?")
                    '    resUpdateStatusÜbernehmen = QS2.Desktop.ControlManagment.ControlManagment.MessageBox(sMsgBoxTxt11 + vbNewLine + sMsgBoxTxt12, "", MessageBoxButtons.YesNo, True)
                    'End If

                    Dim lstPlanIDToUpdate As New System.Collections.Generic.List(Of Guid)()
                    For Each rPlanToUpdate As PMDS.db.Entities.plan In tPlansST
                        'If rPlanToUpdate.BeginntAm.Value.Date >= rPlanOrig.BeginntAm.Date Then
                        If rPlanToUpdate.BeginntAm.Value >= frmInputDate1.udteDateAt.DateTime Then
                            If rPlanToUpdate.ID = rPlanOrig.ID Then
                                Dim bStop As Boolean = True
                            Else
                                rPlanToUpdate.Betreff = rPlanOrig.Betreff.Trim()
                                rPlanToUpdate.Text = rPlanOrig.Text
                                rPlanToUpdate.html = rPlanOrig.html
                                rPlanToUpdate.Priorität = rPlanOrig.Priorität
                                rPlanToUpdate.Status = rPlanOrig.Status
                                rPlanToUpdate.Category = rPlanOrig.Category
                                'rPlanToUpdate.Dauer = rPlanOrig.Dauer
                                'rPlanToUpdate.GanzerTag = rPlanOrig.GanzerTag
                                'rPlanToUpdate.EndetAm = rPlanOrig.EndetAm
                            End If
                            lstPlanIDToUpdate.Add(rPlanToUpdate.ID)
                        Else
                            Dim bOldTermin As Boolean = True
                        End If

                        'If resUpdateStatusÜbernehmen = DialogResult.Yes Then
                        '    rPlanToUpdate.Status = rPlanOrig.Status.Trim()
                        'Else
                        '    rPlanToUpdate.Status = "Offen"
                        'End If
                    Next
                    db.SaveChanges()

                    Dim lstObjectsInOrigPlanForAdd As System.Collections.Generic.List(Of Guid) = contSelectPatienten.getList()
                    'Dim lstObjectsInOrigPlanForDelete As New System.Collections.Generic.List(Of Guid)()
                    'Dim tPlansObjectOrig As IQueryable(Of PMDS.db.Entities.planObject) = Me.b.getPlanObjects(rPlanOrig.ID, db)
                    'For Each rPlanObjectsOrig As PMDS.db.Entities.planObject In tPlansObjectOrig
                    '    lstObjectsInOrigPlanForDelete.Add(rPlanObjectsOrig.IDObject)
                    'Next

                    For Each IDPlanToUpdate As Guid In lstPlanIDToUpdate
                        'If Not IDPlanToUpdate.Equals(rPlanOrig.ID) Then
                        Dim lstObjectsInPlan As New System.Collections.Generic.List(Of Guid)()
                        Dim tPlansObjectST As IQueryable(Of PMDS.db.Entities.planObject) = Me.b.getPlanObjects(IDPlanToUpdate, db)
                        For Each rPlanObjectUpdate As PMDS.db.Entities.planObject In tPlansObjectST
                            lstObjectsInPlan.Add(rPlanObjectUpdate.IDObject)

                            'If resUpdateStatusÜbernehmen = DialogResult.Yes Then
                            '    If rPlanOrig.Status.Trim().ToLower().Equals(("Offen").Trim.ToLower()) Then
                            '        rPlanObjectUpdate.Status = ""
                            '    Else
                            '        rPlanObjectUpdate.Status = rPlanOrig.Status.Trim()
                            '    End If
                            'Else
                            '    rPlanObjectUpdate.Status = ""
                            'End If
                        Next

                        For Each IDObjectInOrig As Guid In lstObjectsInOrigPlanForAdd
                            If Not lstObjectsInPlan.Contains(IDObjectInOrig) Then
                                Dim rNewPlanObject As PMDS.db.Entities.planObject = EFEntities.newPlanObject(db)
                                rNewPlanObject.ID = System.Guid.NewGuid()
                                rNewPlanObject.IDPlan = IDPlanToUpdate
                                rNewPlanObject.IDObject = IDObjectInOrig
                                rNewPlanObject.IDSelList = Nothing
                                'If resUpdateStatusÜbernehmen = DialogResult.Yes Then
                                '    If rPlanOrig.Status.Trim().ToLower().Equals(("Offen").Trim.ToLower()) Then
                                '        rNewPlanObject.Status = ""
                                '    Else
                                '        rNewPlanObject.Status = rPlanOrig.Status.Trim()
                                '    End If
                                'Else
                                '    rNewPlanObject.Status = ""
                                'End If

                                db.planObject.Add(rNewPlanObject)
                            End If
                        Next

                        For Each IDObjectInPlan As Guid In lstObjectsInPlan
                            If Not lstObjectsInOrigPlanForAdd.Contains(IDObjectInPlan) Then
                                Dim tPlanObjectToRemove As IQueryable(Of PMDS.db.Entities.planObject) = From o In db.planObject Where o.IDObject = IDObjectInPlan And o.IDPlan = IDPlanToUpdate
                                For Each rPlanObjectToRemove As PMDS.db.Entities.planObject In tPlanObjectToRemove
                                    db.planObject.Remove(rPlanObjectToRemove)
                                Next
                            End If
                        Next

                        db.SaveChanges()
                        'End If
                    Next
                End If
            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht.updateSerientermine: " + ex.ToString())
        End Try
    End Sub

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
                    rPlanToSet.Status = "Offen"
                ElseIf Me.optStatus.CheckedIndex = 1 Then
                    rPlanToSet.Status = "Erledigt"
                Else
                    Throw New Exception("setPlanRowTemp: Me.optStatus.CheckedIndex '" + Me.optStatus.CheckedIndex.ToString() + "' not allowed!")
                End If
            Else
                rPlanToSet.Status = "Offen"
            End If

            If Not Me.General.IsNull(IDPlanMain) Then
                rPlanToSet.IDPlanMain = IDPlanMain
            Else
                rPlanToSet.SetIDPlanMainNull()
            End If

            rPlanToSet.SetIDActivityNull()
            Dim lstSelectedCategories As New System.Collections.Generic.List(Of String)()
            rPlanToSet.Category = Me.contSelectSelListCategories.getSelectedData2(lstSelectedCategories)
            If rPlanToSet.Betreff.Trim() = "" Then
                rPlanToSet.Betreff = rPlanToSet.Category.Trim()
            End If

            Dim text As String = ""
            Dim typTxt As New TXTextControl.StreamType
            If Me.isHtml Then
                typTxt = TXTextControl.StreamType.HTMLFormat
            Else
                typTxt = TXTextControl.StreamType.PlainText
            End If

            If Me.IDArt = clPlan.typPlan_EMailEmpfangen Or Me.IDArt = clPlan.typPlan_EMailGesendet Then
                If Me.isHtml Then
                    text = Me.winFormHtmlEditor1.DocumentHtml
                Else
                    text = Me.winFormHtmlEditor1.Content.GetBodyText()
                End If
            Else
                If Me.isHtml Then
                    Me.contTxtEditor1.textControl1.Save(text, TXTextControl.StringStreamType.HTMLFormat)
                Else
                    Me.contTxtEditor1.textControl1.Save(text, TXTextControl.StringStreamType.PlainText)
                End If
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
                rPlanToSet.SetEndetAmNull()
            Else
                rPlanToSet.EndetAm = Me.dteEndetAm.DateTime
            End If
            If Me.cboDauer.Value Is Nothing OrElse Me.cboDauer.Value Is System.DBNull.Value OrElse Me.cboDauer.Value = -1 Then
                rPlanToSet.Dauer = -1
            Else
                rPlanToSet.Dauer = Me.cboDauer.Value
            End If
            rPlanToSet.GanzerTag = Me.chkGanzerTag.Checked

            If rPlanToSet.GanzerTag Then
                If Not Me.dteEndetAm.Value Is Nothing Then
                    Dim EndetAmEndeTmp As Date = New Date(Me.dteEndetAm.DateTime.Year, Me.dteEndetAm.DateTime.Month, Me.dteEndetAm.DateTime.Day, 0, 0, 0)
                    'EndetAmEndeTmp = EndetAmEndeTmp.AddDays(1)
                    rPlanToSet.EndetAm = EndetAmEndeTmp.Date
                Else
                    Dim EndetAmEndeTmp As Date = New Date(rPlanToSet.BeginntAm.Date.Year, rPlanToSet.BeginntAm.Date.Month, rPlanToSet.BeginntAm.Date.Day, 0, 0, 0)
                    EndetAmEndeTmp = EndetAmEndeTmp.AddDays(1)
                    rPlanToSet.EndetAm = EndetAmEndeTmp
                End If
            End If

            'Dim diffBeginnEndDate As TimeSpan = rPlanToSet.EndetAm - rPlanToSet.BeginntAm
            Me.rPlan.Dauer = DateDiff(DateInterval.Minute, rPlanToSet.BeginntAm, rPlanToSet.EndetAm)
            'Me.rPlan.Dauer = diffBeginnEndDate.TotalMinutes
            'Me.rPlan.Dauer = DateDiff(DateInterval.Minute, rPlanToSet.BeginntAm, rPlanToSet.EndetAm)

            rPlanToSet.IsSerientermin = Me.chkIsSerientermin.Checked
            If IDSerientermin Is Nothing Then
                rPlanToSet.SetIDSerienterminNull()
            Else
                rPlanToSet.IDSerientermin = IDSerientermin.Value
            End If

            If Me.dteSerienterminEndetAm.Value Is Nothing Then
                rPlanToSet.SetSerienterminEndetAmNull()
            Else
                rPlanToSet.SerienterminEndetAm = Me.dteSerienterminEndetAm.DateTime.Date
            End If

            If (Not Me.optSerienterminType.Value Is Nothing) Then
                If Me.optSerienterminType.CheckedIndex = 0 Then
                    rPlanToSet.SerienterminType = "1"
                ElseIf Me.optSerienterminType.CheckedIndex = 1 Then
                    rPlanToSet.SerienterminType = "2"
                ElseIf Me.optSerienterminType.CheckedIndex = 2 Then
                    rPlanToSet.SerienterminType = "3"
                Else
                    Throw New Exception("frmNachricht.setPlanRowTemp: Me.optSerienterminType.CheckedIndex '" + Me.optSerienterminType.CheckedIndex.ToString() + "' not allowed!")
                End If
            Else
                rPlanToSet.SerienterminType = ""
            End If

            If Me.iWiedWertJeden.Value Is System.DBNull.Value Then
                rPlanToSet.SetWiedWertJedenNull()
            Else
                rPlanToSet.WiedWertJeden = Me.iWiedWertJeden.Value
            End If

            If (Not Me.opTagWochenMonat.Value Is Nothing) Then
                If Me.opTagWochenMonat.CheckedIndex = 0 Then
                    rPlanToSet.TagWochenMonat = "0"
                ElseIf Me.opTagWochenMonat.CheckedIndex = 1 Then
                    rPlanToSet.TagWochenMonat = "1"
                ElseIf Me.opTagWochenMonat.CheckedIndex = 2 Then
                    rPlanToSet.TagWochenMonat = "2"
                Else
                    Throw New Exception("frmNachricht.setPlanRowTemp: Me.opTagWochenMonat.CheckedIndex '" + Me.opTagWochenMonat.CheckedIndex.ToString() + "' not allowed!")
                End If
            Else
                rPlanToSet.TagWochenMonat = ""
            End If

            If Me.iNTenMonat.Value Is System.DBNull.Value Then
                rPlanToSet.SetnTenMonatNull()
            Else
                rPlanToSet.nTenMonat = Me.iNTenMonat.Value
            End If

            rPlanToSet.Wochentage = Me.getWochentage()

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

            If Me.frmStatus = General.eStatusForm.edit Then
                If Not Me.chkIsSerientermin.Checked Then
                    Me.contSelectBenutzer.saveData()
                    Me.contSelectPatienten.saveData()
                End If
            Else
                Me.contSelectBenutzer.saveData()
                Me.contSelectPatienten.saveData()
            End If

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
    Public Sub setWochentageAllOnOff(ByRef bOn As Boolean)
        Try
            Me.cbMo.Checked = bOn
            Me.cbDi.Checked = bOn
            Me.cbMi.Checked = bOn
            Me.cbDo.Checked = bOn
            Me.cbFr.Checked = bOn
            Me.cbSa.Checked = bOn
            Me.cbSo.Checked = bOn

        Catch ex As Exception
            Throw New Exception("frmNachricht.setWochentageAllOnOff: " + ex.ToString())
        End Try
    End Sub

    Public Sub setUIEndetAm(IsGanzerTag As Boolean, bSetEndetAm As Boolean)
        Try
            If IsGanzerTag Then
                'Me.dteEndetAm.Value = Nothing
                Me.cboDauer.Value = Nothing
                Me.dteEndetAm.Visible = True
                Me.lblEndAt.Visible = True
                Me.cboDauer.Visible = False
                If Not Me.dteBeginntAm.Value Is Nothing Then
                    Me.dteBeginntAm.DateTime = New Date(Me.dteBeginntAm.DateTime.Year, Me.dteBeginntAm.DateTime.Month, Me.dteBeginntAm.DateTime.Day, 0, 0, 0)
                End If
                If bSetEndetAm Then
                    If Not Me.dteEndetAm.Value Is Nothing Then
                        Dim dEndetAmTmp As Date = New Date(Me.dteEndetAm.DateTime.Year, Me.dteEndetAm.DateTime.Month, Me.dteEndetAm.DateTime.Day, 0, 0, 0)
                        dEndetAmTmp = dEndetAmTmp.AddDays(1)
                        Me.dteEndetAm.DateTime = dEndetAmTmp
                    End If
                End If
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
            Using dsPlanToSend As New dsPlan()
                Me.compPlan1.getPlanAnhang(rPlanToSend.ID, compPlan.eTypSelPlanAnhang.idPlan, dsPlanToSend)
                If rPlanToSend.MailAn.Trim() <> "" Or rPlanToSend.MailCC.Trim() <> "" Then
                    Dim bSendOK As Boolean = False
                    If bSendOnServer Then
                        bSendOK = Me.genMain.addInteropPar(rPlanToSend.ID, IDParent, dsInteropPar1)
                        If doSendServer Then
                            bSendOK = Me.genMain.addInteropSendEMail(dsInteropPar1)
                        End If
                    Else
                        bSendOK = Me.clPlan1.sendEMail(rPlanToSend.MailAn.Trim(), rPlanToSend.MailCC.Trim(), rPlanToSend.MailBcc.Trim(), False,
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
            End Using

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
            Me.rPlan.IDKlinik = PMDS.Global.ENV.IDKlinik

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
            Me.PanelMailTop.Visible = True
            Me.PanelMailAdr.Visible = True

            If Me.frmStatus = General.eStatusForm.neu Or Me.rPlan.IsgesendetAmNull() Then
                Me.PanelMailTop.Height = 24
                Me.btnAntworten.Visible = False
                Me.btnWeiterleiten.Visible = False
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

            Me.chkIsSerientermin.Visible = False
            Me.grpSerientermin.Visible = False

        Catch ex As Exception
            Throw New Exception("frmNachricht.setUIEMailPostausgang: " + ex.ToString())
        End Try
    End Sub
    Public Sub setUIEMailPosteingang(ByVal showMIMEButt As Boolean)
        Try
            Me.PanelMailTop.Visible = True
            Me.PanelMailAdr.Visible = True

            Me.btnAntworten.Visible = True
            Me.btnWeiterleiten.Visible = True
            Me.btnSendEMails.Visible = False

            Me.setEditAfterLoading()

            Me.chkIsSerientermin.Visible = False
            Me.grpSerientermin.Visible = False

        Catch ex As Exception
            Throw New Exception("frmNachricht.setUIEMailPosteingang: " + ex.ToString())
        End Try
    End Sub

    Public Sub setUIAufgabeTermin()
        Try
            Me.PanelMailTop.Visible = False
            Me.PanelMailAdr.Visible = False

            Me.btnAntworten.Visible = False
            Me.btnWeiterleiten.Visible = False
            Me.btnSendEMails.Visible = False
            Me.setEditAfterLoading()

            Me.chkIsSerientermin.Visible = True

        Catch ex As Exception
            Throw New Exception("frmNachricht.setUIAufgabeTermin: " + ex.ToString())
        End Try
    End Sub

    Public Sub setUINotiz()
        Try
            Me.PanelMailTop.Visible = False
            Me.PanelMailAdr.Visible = False

            Me.btnAntworten.Visible = False
            Me.btnWeiterleiten.Visible = False
            Me.btnSendEMails.Visible = False
            Me.setEditAfterLoading()

            Me.chkIsSerientermin.Visible = False
            Me.grpSerientermin.Visible = False

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
                    Me.btnAntworten.Visible = True
                    Me.btnWeiterleiten.Visible = True

                    Me.contSelectBenutzer.lockUnlock(True)
                    Me.contSelectPatienten.lockUnlock(True)
                    Me.contListeAnhang.lockUnlockMain(True)

                    Me.winFormHtmlEditor1.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.ReadOnly_Preview
                    Me.contTxtEditor1.lockEingbe = True

                ElseIf Me.IDArt = clPlan.typPlan_EMailGesendet Then
                    If Me.rPlan.IsgesendetAmNull() Then
                        Me.lockUnlock(True)
                    Else
                        Me.lockUnlock(False)
                        Me.btnAntworten.Visible = True
                        Me.btnWeiterleiten.Visible = True
                    End If
                    Me.chkSendWithPostOfficeBoxForAll.Visible = True

                ElseIf Me.IDArt = clPlan.typPlan_AufgabeTermin Then
                    If Me.rPlan.IsgesendetAmNull() Then
                        Me.lockUnlock(True)
                    Else
                        Me.lockUnlock(Me.rPlan.IsOwner)
                        Me.winFormHtmlEditor1.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.ReadOnly_Preview
                    End If
                    Me.btnAntworten.Visible = False
                    Me.btnWeiterleiten.Visible = False

                ElseIf Me.IDArt = clPlan.typPlan_Notiz Then
                    Me.lockUnlock(True)
                    Me.btnAntworten.Visible = False
                    Me.btnWeiterleiten.Visible = False

                End If

                Me.chkSendWithPostOfficeBoxForAll.Visible = False
                Me.chkSendWithPostOfficeBoxForAll.Checked = False

                If Me.IDArt = clPlan.typPlan_EMailEmpfangen Then
                    Me.lockUnlock(False)
                    Me.winFormHtmlEditor1.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.ReadOnly_Preview
                    Me.contTxtEditor1.lockEingbe = True

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
            Me.lblAutoEMailAn.Enabled = bEdit

            Dim styleButtDropDown As New Infragistics.Win.ButtonDisplayStyle
            If bEdit Then
                styleButtDropDown = Infragistics.Win.ButtonDisplayStyle.Always
            Else
                styleButtDropDown = Infragistics.Win.ButtonDisplayStyle.OnMouseEnter
            End If

            Dim ui As New UI()
            ui.lockUnlockOneControl(Me.PanelMailAdr, bEdit)
            ui.lockUnlockOneControl(Me.PanelDescription, bEdit)
            ui.lockUnlockOneControl(Me.PanelBetreff, bEdit)
            Me.contTxtEditor1.lockEingbe = Not bEdit

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
    Public Sub setHtml(ByVal isHTML As Boolean)
        Try
            Me.chkTextIsHtml.Checked = isHTML
            If isHTML Then
                If Me.frmStatus = General.eStatusForm.edit Then
                    If Me.IDArt = clPlan.typPlan_EMailEmpfangen Or Me.IDArt = clPlan.typPlan_EMailGesendet Then
                        Me.winFormHtmlEditor1.Content.SetDocumentHtml(Me.rPlan.Text.Trim())
                    Else
                        Me.doEditor1.showText(Me.rPlan.Text.Trim(), TXTextControl.StreamType.HTMLFormat, Me.isEditable, TXTextControl.ViewMode.PageView, Me.contTxtEditor1.textControl1)
                    End If
                Else
                    If Me.IDArt = clPlan.typPlan_EMailEmpfangen Or Me.IDArt = clPlan.typPlan_EMailGesendet Then
                        Me.winFormHtmlEditor1.Content.SetDocumentHtml(Me.LastTextBody)
                    Else
                        Me.doEditor1.showText(Me.LastTextBody, TXTextControl.StreamType.HTMLFormat, Me.isEditable, TXTextControl.ViewMode.PageView, Me.contTxtEditor1.textControl1)
                    End If
                End If
            Else
                If Me.frmStatus = General.eStatusForm.edit Then
                    If Me.IDArt = clPlan.typPlan_EMailEmpfangen Or Me.IDArt = clPlan.typPlan_EMailGesendet Then
                        Me.winFormHtmlEditor1.Content.SetBodyText(Me.rPlan.Text.Trim())
                    Else
                        Me.doEditor1.showText(Me.rPlan.Text.Trim(), TXTextControl.StreamType.PlainText, Me.isEditable, TXTextControl.ViewMode.PageView, Me.contTxtEditor1.textControl1)
                    End If
                Else
                    If Me.IDArt = clPlan.typPlan_EMailEmpfangen Or Me.IDArt = clPlan.typPlan_EMailGesendet Then
                        Me.winFormHtmlEditor1.Content.SetBodyText(Me.LastTextBody)
                    Else
                        Me.doEditor1.showText(Me.LastTextBody, TXTextControl.StreamType.PlainText, Me.isEditable, TXTextControl.ViewMode.PageView, Me.contTxtEditor1.textControl1)
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
            Else
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
                'Fct  deactivated
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

                    Using compUserAccounts1 As New compUserAccounts()
                        Dim rUserAccount As dsUserAccounts.tblUserAccountsRow = compUserAccounts1.getUserAccountsRow(IDUserAccount, "", compUserAccounts.eTypSelUserAccounts.id, compUserAccounts.eTypEMailAccount.SMTP, True, True)
                        If Me.chkSendWithPostOfficeBoxForAll.Checked Then
                            Using dsUserAccountsRead As New dsUserAccounts()
                                compUserAccounts1.getUserAccounts(Nothing, "", dsUserAccountsRead, compUserAccounts.eTypSelUserAccounts.PostOfficeBoxForAll, compUserAccounts.eTypEMailAccount.SMTP, True)
                                If dsUserAccountsRead.tblUserAccounts.Rows.Count > 0 Then
                                    rUserAccount = dsUserAccountsRead.tblUserAccounts.Rows(0)
                                End If
                            End Using
                        End If

                        txtInfo += vbNewLine + doUI.getRes("Name") + "Name: " + rUserAccount.Name + vbNewLine +
                                    doUI.getRes("User") + ": " + rUserAccount.Usr + vbNewLine +
                                    doUI.getRes("Type") + ": " + rUserAccount.typ + vbNewLine +
                                    doUI.getRes("AdressFrom") + ": " + rUserAccount.AdrFrom + vbNewLine +
                                    doUI.getRes("Server") + ": " + rUserAccount.Server + vbNewLine +
                                    doUI.getRes("UserAuthentication") + ": " + rUserAccount.UsrAuthentication + vbNewLine +
                                    doUI.getRes("Port") + ": " + rUserAccount.Port + vbNewLine +
                                    doUI.getRes("SSL") + ": " + rUserAccount.SSL.ToString()
                    End Using

                    'Me.UltraStatusBar1.Panels("UserAccount").Text = doUI.getRes("UsedAccount") + ": " + rUserAccount.Name
                    'Me.UltraStatusBar1.Panels("UserAccount").ToolTipText = txtToolTip
                    'Me.UltraStatusBar1.Panels("InfosGeneral").Text = txt
                End If

                Using info As New UltraToolTipInfo()
                    info.ToolTipText = txtInfo
                    Me.UltraToolTipManager1.SetUltraToolTip(Me.picInfo, info)
                End Using

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

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendEMails.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim rSelUserAccount As dsUserAccounts.tblUserAccountsRow = Nothing
            If Me.savePlan2(eTypAction.sendEMailClicked, rSelUserAccount) Then
                Dim cOutlookWebAPI1 As New cOutlookWebAPI()
                'cOutlookWebAPI1.saveToOutlook(Me.rPlan.ID, Me.rPlan.SendWithPostOfficeBoxForAll, rSelUserAccount, True)
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
                Me.setHtml(Me.chkTextIsHtml.Checked)
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

    Public Sub SendPlanClick()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim rSelUserAccount As dsUserAccounts.tblUserAccountsRow = Nothing
            If Me.savePlan2(eTypAction.sendPlanClicked, rSelUserAccount) Then
                Dim cOutlookWebAPI1 As New cOutlookWebAPI()
                'cOutlookWebAPI1.saveToOutlook(Me.rPlan.ID, Me.rPlan.SendWithPostOfficeBoxForAll, rSelUserAccount, True)
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
    Public Sub editierenOnOff(bOn)
        Try
            Me.lockUnlock(Me.EditierenToolStripMenuItem.Checked)
            Me.btnSendEMails.Enabled = Me.EditierenToolStripMenuItem.Checked
            Me.btnSendEMails.Visible = Me.EditierenToolStripMenuItem.Checked
            Me.btnSave.Enabled = Me.EditierenToolStripMenuItem.Checked

            Dim typUI As New General.etyp()
            If Me.EditierenToolStripMenuItem.Checked Then
                typUI = General.etyp.all
                Me.winFormHtmlEditor1.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.WYSIWYG_Design
            Else
                typUI = General.etyp.onlyShow
                Me.winFormHtmlEditor1.EditorMode = SpiceLogic.HtmlEditorControl.Domain.BOs.EditorModes.ReadOnly_Preview
            End If

        Catch ex As Exception
            Throw New Exception("frmNachricht2.editierenOnOff: " + ex.ToString())
        End Try
    End Sub

    Private Sub frmNachricht_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            Me.Cursor = Cursors.WaitCursor
            If Me.Visible Then
                If Not Me.isOpend Then
                    If Me.isFirstShow Then
                        If Me.IDArt <> clPlan.typPlan_EMailEmpfangen And Me.IDArt <> clPlan.typPlan_EMailGesendet Then
                            If Me.frmStatus = General.eStatusForm.edit Then
                                If Me.rPlan.html Then
                                    Me.doEditor1.showText(Me.rPlan.Text, TXTextControl.StreamType.HTMLFormat, Me.isEditable, TXTextControl.ViewMode.PageView, Me.contTxtEditor1.textControl1)
                                Else
                                    Me.doEditor1.showText(Me.rPlan.Text, TXTextControl.StreamType.PlainText, Me.isEditable, TXTextControl.ViewMode.PageView, Me.contTxtEditor1.textControl1)
                                End If
                            Else
                                Dim sHtmlSignature As String = Me.genMain.loadSignatureAsHTMLxy()
                                Me.contTxtEditor1.textControl1.Load(sHtmlSignature, TXTextControl.StreamType.HTMLFormat)
                            End If
                        End If
                    End If
                End If

                Me.isFirstShow = False
                Me.isOpend = True
            End If

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
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
                'cOutlookWebAPI1.saveToOutlook(Me.rPlan.ID, Me.rPlan.SendWithPostOfficeBoxForAll, rSelUserAccount, True)
                Me.abort = False
                If Not Me.modalWindow Is Nothing Then
                    Me.modalWindow.ContPlanung1.search(False, False, False, False)
                End If
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
            Me.setUIEndetAm(Me.chkGanzerTag.Checked, True)

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
                Me.SerienterminTypeOrTagWochenMonat_ValueChanged()
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
            Me.Cursor = Cursors.WaitCursor
            Me.SerienterminTypeOrTagWochenMonat_ValueChanged()

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub opTagWochenMonat_ValueChanged(sender As Object, e As EventArgs) Handles opTagWochenMonat.ValueChanged
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.SerienterminTypeOrTagWochenMonat_ValueChanged()

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub btnAntworten_Click(sender As Object, e As EventArgs) Handles btnAntworten.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.antworten(eAntworten.antworten)

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnWeiterleiten_Click(sender As Object, e As EventArgs) Handles btnWeiterleiten.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.antworten(eAntworten.weiterleiten)

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.clPlan1.deletePlan(Me.rPlan, Me.abort, Me.modalWindow, Me)

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub EditierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditierenToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.editierenOnOff(Me.EditierenToolStripMenuItem.Checked)

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboDauerSerientermin_ValueChanged(sender As Object, e As EventArgs) Handles cboDauerSerientermin.ValueChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.cboDauerSerientermin.Focused Then
                If (Not Me.dteBeginntAm.Value Is Nothing) And (Not Me.cboDauerSerientermin.Value Is Nothing) Then
                    Dim iDauer As Integer = System.Convert.ToInt32(Me.cboDauerSerientermin.Value.ToString().Trim())
                    Try
                        Try
                            If Me.cboDauerSerientermin.SelectedItem Is Nothing Then
                                Try
                                    Me.dteSerienterminEndetAm.DateTime = Me.dteBeginntAm.DateTime.AddMonths(iDauer)
                                Catch ex As Exception
                                End Try
                            Else
                                Dim sTypeTime As String = Me.cboDauerSerientermin.SelectedItem.Tag.ToString()
                                If sTypeTime.Trim().ToLower().Equals(("W").Trim().ToLower()) Then
                                    Me.dteSerienterminEndetAm.DateTime = Me.dteBeginntAm.DateTime.AddDays(Me.cboDauerSerientermin.Value)
                                ElseIf sTypeTime.Trim().ToLower().Equals(("M").Trim().ToLower()) Then
                                    Me.dteSerienterminEndetAm.DateTime = Me.dteBeginntAm.DateTime.AddMonths(Me.cboDauerSerientermin.Value)
                                ElseIf sTypeTime.Trim().ToLower().Equals(("Y").Trim().ToLower()) Then
                                    Me.dteSerienterminEndetAm.DateTime = Me.dteBeginntAm.DateTime.AddYears(Me.cboDauerSerientermin.Value)
                                Else
                                    Me.dteSerienterminEndetAm.DateTime = Me.dteBeginntAm.DateTime.AddMonths(iDauer)
                                End If
                            End If

                        Catch ex2 As Exception
                            Throw New Exception("cboDauerSerientermin_ValueChanged: " + ex2.ToString())
                        End Try

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

    Private Sub dropDownPatienten_DroppingDown(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dropDownPatienten.DroppingDown
        Try
            Me.Cursor = Cursors.WaitCursor

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dropDownUsers_DroppingDown(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dropDownUsers.DroppingDown
        Try
            Me.Cursor = Cursors.WaitCursor

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dropDownCategories_DroppingDown(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dropDownCategories.DroppingDown
        Try
            Me.Cursor = Cursors.WaitCursor

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dropDownAnhänge_DroppingDown(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dropDownAnhänge.DroppingDown
        Try
            Me.Cursor = Cursors.WaitCursor

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub dropDownPatienten_ClosedUp(sender As Object, e As EventArgs) Handles dropDownPatienten.ClosedUp
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.dropDownPatienten.Text = Me.contSelectPatienten.setLabelCount2()

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dropDownUsers_ClosedUp(sender As Object, e As EventArgs) Handles dropDownUsers.ClosedUp
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.dropDownUsers.Text = Me.contSelectBenutzer.setLabelCount2()

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dropDownCategories_ClosedUp(sender As Object, e As EventArgs) Handles dropDownCategories.ClosedUp
        Try
            Me.Cursor = Cursors.WaitCursor
            'Me.dropDownCategories.Text = Me.contSelectSelListCategories.setLabelCount2()

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dropDownAnhänge_ClosedUp(sender As Object, e As EventArgs) Handles dropDownAnhänge.ClosedUp
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.dropDownAnhänge.Text = Me.contListeAnhang.setLabelCount2("Anhang")

        Catch ex As Exception
            General.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dteBeginntAm_ValueChanged(sender As Object, e As EventArgs) Handles dteBeginntAm.ValueChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.dteBeginntAm.Focused Then
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
    Private Sub dteBeginntAm_AfterCloseUp(sender As Object, e As EventArgs) Handles dteBeginntAm.AfterCloseUp
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.dteBeginntAm.Focused Then
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

    Private Sub toolbarsManagerText_ToolClick(sender As Object, e As ToolClickEventArgs) Handles toolbarsManagerText.ToolClick

    End Sub
End Class
