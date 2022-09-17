'-------------------------------------------------------------------------------------------------------------
' module:			TX Text Control Words
'	file:				FormMain.vb
' description:	This file contains the main form.
'
' copyright:		© Text Control GmbH, 1991-2013
' author:			T. Kummerow
'-----------------------------------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms
Imports RibbonLib
Imports RibbonLib.Controls
Imports RibbonLib.Controls.Events
Imports RibbonLib.Interop
Imports System.Diagnostics
Imports System.Reflection
Imports System.Globalization
Imports TXTextControl


''' <summary>
''' The main form.
''' </summary>
Public Class FormMain

#Region "  Enumerations  "

    ''' <summary>
    ''' Ribbon application modes
    ''' </summary>
    Public Enum RibbonApplicationMode
        Normal = 0
        MergePreview = 1
    End Enum
    ' enum RibbonApplicationMode
#End Region

#Region "  Private fields  "

    Private _fileHandler As FileHandler
    Private _fileDragDrop As FileDragDropHandler
    Private _bLoadFileOnCreate As Boolean = False
    Private _btnHelp As RibbonHelpButton
    Private _tabGroupTableTools As RibbonTabGroup
    Private _tabGroupObjectTools As RibbonTabGroup
    Private _objSel As TXTextControl.FrameBase
    ' Currently selected object
    Private _objSelPrev As TXTextControl.FrameBase
    ' Previously selected object (Text Control deselection workaround)

    Private Const ExpressEditionInfoMessage As String = "Not available in Express Edition."
    Private Const MsgDocDoesNotContainAny As String = "The document doesn't contain any {0}."
    Private Const HelpButtonCommandID As UInteger = 1999
    Private Const DynamicCommandIdStart As UInteger = 10000

#End Region

#Region "  Constructors  "

    ''' <summary>
    ''' Creates a main form and opens a document given as the first string argument.
    ''' </summary>
    Public Sub New()
        InitializeComponent()

        Me.SuspendLayout()


        If My.Settings.Default.FirstRun Then
            ' Check system text direction
            My.Settings.Default.RightToLeft = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, RightToLeft.Yes, RightToLeft.No)

            My.Settings.Default.FirstRun = False
            My.Settings.Default.Save()
        End If

        Me.RightToLeft = My.Settings.Default.RightToLeft

        Select Case Me.RightToLeft
            Case RightToLeft.No
                _rulerBarVert.Dock = DockStyle.Left
                Exit Select

            Case RightToLeft.Yes
                _rulerBarVert.Dock = DockStyle.Right
                Exit Select
        End Select

        Me.ResumeLayout()

        _textControl.RulerBar = _rulerBarHor
        _textControl.StatusBar = _statusBar
        _textControl.VerticalRulerBar = _rulerBarVert

        _fileHandler = New FileHandler(Me, _textControl) With { _
         .RibbonMain = _ribbonMain _
        }
        _fileDragDrop = New FileDragDropHandler()
    End Sub

#End Region

#Region "  Form event handlers  "

    Private Sub FormMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Text = ProductName

        ' Create ribbon element objects and attach events
        CreateRibbonItems()
        AttachRibbonEvents()
        InitRecentItems()
        InitInputFormatDependentControls()

        LoadAppSettings()

        If Not _bLoadFileOnCreate Then
            LoadBlankDocTemplate()
        End If

        AttachTextControlEvents()

        ' Init list of formatting styles shown in the styles gallery
        TextControl_FormattingStyleListChanged(Me, Nothing)

        _fileHandler.RecentFiles = _recentItemsList
        _fileHandler.InitRecentFiles()

        UpdateZoomCheckBoxes()

        _tglBtnTblViewGridlines.BooleanValue = _textControl.Tables.GridLines
        _tglBtnShowTextFrameMarkerLines.BooleanValue = _textControl.TextFrameMarkerLines
        _tglBtnHighlightMergeFields.BooleanValue = _bHighlightFields
        _tglBtnShowBookmarkMarkers.BooleanValue = _textControl.DocumentTargetMarkers

        ' Disable mail merge buttons which are not usable until a data
        ' source has been selected
        _drpDnGlryMailMrgSelTable.Enabled = False
        _btnEditDataRelations.Enabled = False
        _tglBtnPreviewFields.Enabled = False
        _spltBtnFinishAndMerge.Enabled = False

        SelectCurrentStyleItem()

        ToggleFieldDisplayButtons()

        Select Case Me.RightToLeft
            Case RightToLeft.No
                _tglBtnsFormLayout(CInt(FormLayoutButton.LTR)).BooleanValue = True
                Exit Select

            Case RightToLeft.Yes
                _tglBtnsFormLayout(CInt(FormLayoutButton.RTL)).BooleanValue = True
                Exit Select
        End Select

        Select Case _textControl.Selection.ParagraphFormat.Direction
            Case TXTextControl.Direction.LeftToRight
                _tglBtnsTextDir(CInt(TextDirButton.LTR)).BooleanValue = True
                Exit Select

            Case TXTextControl.Direction.RightToLeft
                _tglBtnsTextDir(CInt(TextDirButton.RTL)).BooleanValue = True
                Exit Select
        End Select

        _dlgMergeWait.Owner = ENV.FrmMain

        If _bLoadFileOnCreate Then
            If Not _fileHandler.FileOpen() Then
                Return
            End If
            If _fileHandler.DocumentFileName <> "" Then
                Me.Text = _fileHandler.PrintDocumentName
            End If
        End If

        UpdateGUIState()
    End Sub

    'Private Sub FormMain_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing   //lthxy
    '    If _fileHandler.DocumentDirty Then
    '        e.Cancel = Not FileSaveQuestion()
    '    End If
    '    SaveAppSettings()
    'End Sub

    Private Sub FormMain_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        If e.Alt AndAlso e.Shift AndAlso Not e.Control Then
            Select Case e.KeyCode
                Case Keys.K
                    If Not _bIsInMergePreviewMode Then
                        _tglBtnPreviewFields.BooleanValue = True
                        EnterMergePreviewMode()
                    End If
                    Exit Select

                Case Keys.N
                    If Not _bIsInMergePreviewMode AndAlso MergePossible() Then
                        MergeSaveSingleDocAsync(StreamType.AdobePDF)
                    End If
                    Exit Select

                Case Keys.M
                    If Not _bIsInMergePreviewMode AndAlso MergePossible() Then
                        MergePrintAsync()
                    End If
                    Exit Select

                Case Keys.F
                    If Not _bIsInMergePreviewMode Then
                        InsertMergeField()
                    End If
                    Exit Select
            End Select
        ElseIf Not e.Alt AndAlso Not e.Shift AndAlso Not e.Control Then
            Select Case e.KeyCode
                Case Keys.Escape
                    If _bIsInMergePreviewMode Then
                        _tglBtnPreviewFields.BooleanValue = False
                        ExitMergePreviewMode()
                    End If
                    Exit Select

                Case Keys.Right
                    If _bIsInMergePreviewMode Then
                        GoToNextRecord()
                    End If
                    Exit Select

                Case Keys.Left
                    If _bIsInMergePreviewMode Then
                        GoToPreviousRecord()
                    End If
                    Exit Select
            End Select
        ElseIf Not e.Alt AndAlso Not e.Shift AndAlso e.Control Then
            Select Case e.KeyCode
                Case Keys.Right
                    If _bIsInMergePreviewMode Then
                        GoToLastRecord()
                    End If
                    Exit Select

                Case Keys.Left
                    If _bIsInMergePreviewMode Then
                        GoToFirstRecord()
                    End If
                    Exit Select
            End Select
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Alt Or Keys.Shift Or Keys.F) OrElse keyData = (Keys.Alt Or Keys.Shift Or Keys.N) OrElse keyData = (Keys.Alt Or Keys.Shift Or Keys.K) OrElse keyData = (Keys.Alt Or Keys.Shift Or Keys.M) Then
            ' Intercept some "Alt + Shift + ..." key combinations 
            ' because the ribbon misinterprets them as "Alt + ..."
            Return True
        Else
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If
    End Function

#End Region

#Region "  Ribbon event handlers  "

    Private Sub BtnHelp_ExecuteEvent(ByVal sender As Object, ByVal e As ExecuteEventArgs)
        About()
    End Sub

#End Region

#Region "  Helpers  "

    Private Sub CreateRibbonItems()
        _btnHelp = New RibbonHelpButton(_ribbonMain, HelpButtonCommandID)
        _tabGroupTableTools = New RibbonTabGroup(_ribbonMain, CUInt(RibbonMarkupCommand_TabGrpTableTools.cmdTabGrpTableTools))
        _tabGroupObjectTools = New RibbonTabGroup(_ribbonMain, CUInt(RibbonMarkupCommand_TabGrpObjectTools.cmdTabGrpObjectTools))

        CreateRibbonItems_TabHome()
        CreateRibbonItems_TabInsert()
        CreateRibbonItems_TabPageLayout()
        CreateRibbonItems_TabMailings()
        CreateRibbonItems_TabView()
        CreateRibbonItems_ApplicationMenu()
        CreateRibbonItems_TabGrpTableTools()
        CreateRibbonItems_TabGrpObjectTools()

    End Sub

    Private Sub AttachRibbonEvents()
        AddHandler _btnHelp.ExecuteEvent, AddressOf BtnHelp_ExecuteEvent

        AttachRibbonEvents_TabHome()
        AttachRibbonEvents_TabInsert()
        AttachRibbonEvents_TabPageLayout()
        AttachRibbonEvents_TabMailings()
        AttachRibbonEvents_TabView()
        AttachRibbonEvents_ApplicationMenu()
        AttachRibbonEvents_TabGrpTableTools()
        AttachRibbonEvents_TabGrpObjectTools()

    End Sub

    Private Sub UpdateGUIState()
        UpdateCopyPaste()
        UpdateUndoRedo()
        UpdateViewCheckBoxes()
        UpdateLinkButtons()

        UpdateContextualTableTabGroup()

        _btnRemoveHeader.Enabled = HeaderExists()
        _btnRemoveFooter.Enabled = FooterExists()

        Select Case _textControl.Selection.ParagraphFormat.Direction
            Case TXTextControl.Direction.LeftToRight
                _tglBtnsTextDir(CInt(TextDirButton.LTR)).BooleanValue = True
                _tglBtnsTextDir(CInt(TextDirButton.RTL)).BooleanValue = False
                Exit Select

            Case TXTextControl.Direction.RightToLeft
                _tglBtnsTextDir(CInt(TextDirButton.LTR)).BooleanValue = False
                _tglBtnsTextDir(CInt(TextDirButton.RTL)).BooleanValue = True
                Exit Select
        End Select
    End Sub

    Private Sub UpdateLinkButtons()
        ' Hypertext links are not available in the Standard version. Accessing them  
        ' would throw an exception if this sample program is used with a Standard version
        ' of Text Control.
        Try
            _btnEditHyperlink.Enabled = (_textControl.HypertextLinks.GetItem() IsNot Nothing) OrElse (_textControl.DocumentLinks.GetItem() IsNot Nothing)
            _btnEditBookmark.Enabled = (_textControl.DocumentTargets.GetItem() IsNot Nothing)
        Catch
        End Try
    End Sub

    Private Sub UntoggleToggleButtons(ByVal btns As RibbonToggleButton())
        UntoggleToggleButtons(btns, DirectCast(Nothing, RibbonToggleButton))
    End Sub

    Private Sub UntoggleToggleButtons(ByVal buttons As RibbonToggleButton(), ByVal exceptThisOne As RibbonToggleButton)
        UntoggleToggleButtons(buttons, New List(Of RibbonToggleButton)(New RibbonToggleButton() {exceptThisOne}))
    End Sub

    Private Sub UntoggleToggleButtons(ByVal buttons As RibbonToggleButton(), ByVal exceptThese As List(Of RibbonToggleButton))
        For Each btn As RibbonToggleButton In buttons
            If exceptThese.Contains(btn) Then
                Continue For
            End If
            btn.BooleanValue = False
        Next
    End Sub

    Private Sub UntoggleCheckboxes(ByVal chk As RibbonCheckBox())
        UntoggleCheckboxes(chk, DirectCast(Nothing, RibbonCheckBox))
    End Sub

    Private Sub UntoggleCheckboxes(ByVal checkBoxes As RibbonCheckBox(), ByVal exceptThisOne As RibbonCheckBox)
        UntoggleCheckboxes(checkBoxes, New List(Of RibbonCheckBox)(New RibbonCheckBox() {exceptThisOne}))
    End Sub

    Private Sub UntoggleCheckboxes(ByVal checkBoxes As RibbonCheckBox(), ByVal exceptThese As List(Of RibbonCheckBox))
        For Each cb As RibbonCheckBox In checkBoxes
            If exceptThese.Contains(cb) Then
                Continue For
            End If
            cb.BooleanValue = False
        Next
    End Sub

    Private Sub LoadAppSettings()
        ' Take over initial resizing
        'Me.StartPosition = FormStartPosition.Manual   //lthxy

        ' Resize form
        Me.Size = My.Settings.Default.LastWindowSize
        Me.Location = My.Settings.Default.LastWindowPos
        'Me.WindowState = My.Settings.Default.LastWindowState   //lthxy
    End Sub

    Private Sub SaveAppSettings()
        'If Me.WindowState = FormWindowState.Normal Then     //lthxy
        '    My.Settings.Default.LastWindowPos = New System.Drawing.Point(CInt(Me.Left), CInt(Me.Top))
        '    My.Settings.Default.LastWindowSize = New System.Drawing.Size(CInt(Me.Width), CInt(Me.Height))
        'Else
        '    My.Settings.Default.LastWindowPos = New System.Drawing.Point(CInt(Me.RestoreBounds.Left), CInt(Me.RestoreBounds.Top))
        '    My.Settings.Default.LastWindowSize = New System.Drawing.Size(CInt(Me.RestoreBounds.Width), CInt(Me.RestoreBounds.Height))
        'End If
        'My.Settings.Default.Save()
    End Sub

    ''' <summary>
    ''' Attaches text control events which can't be set in the properies explorer.
    ''' </summary>
    Private Sub AttachTextControlEvents()
        ' Font properties:

        AddHandler _textControl.InputFormat.BoldChanged, AddressOf InputFormat_BoldChanged
        AddHandler _textControl.InputFormat.FontFamilyChanged, AddressOf InputFormat_FontFamilyChanged
        AddHandler _textControl.InputFormat.FontSizeChanged, AddressOf InputFormat_FontSizeChanged
        AddHandler _textControl.InputFormat.ItalicChanged, AddressOf InputFormat_ItalicChanged
        AddHandler _textControl.InputFormat.StrikeoutChanged, AddressOf InputFormat_StrikeoutChanged
        AddHandler _textControl.InputFormat.SubscriptChanged, AddressOf InputFormat_SubscriptChanged
        AddHandler _textControl.InputFormat.SuperscriptChanged, AddressOf InputFormat_SuperscriptChanged
        AddHandler _textControl.InputFormat.TextBackColorChanged, AddressOf InputFormat_TextBackColorChanged
        AddHandler _textControl.InputFormat.TextColorChanged, AddressOf InputFormat_TextColorChanged
        AddHandler _textControl.InputFormat.UnderlineChanged, AddressOf InputFormat_UnderlineChanged

        ' Paragraph properties:

        AddHandler _textControl.InputFormat.AllFrameLinesChanged, AddressOf InputFormat_AllFrameLinesChanged
        AddHandler _textControl.InputFormat.BottomFrameLineChanged, AddressOf InputFormat_BottomFrameLineChanged
        AddHandler _textControl.InputFormat.BoxFrameChanged, AddressOf InputFormat_BoxFrameChanged
        AddHandler _textControl.InputFormat.BulletCharacterChanged, AddressOf InputFormat_BulletCharacterChanged
        AddHandler _textControl.InputFormat.BulletedListChanged, AddressOf InputFormat_BulletedListChanged
        AddHandler _textControl.InputFormat.CenteredChanged, AddressOf InputFormat_CenteredChanged
        AddHandler _textControl.InputFormat.InnerHorizontalFrameLinesChanged, AddressOf InputFormat_InnerHorizontalFrameLinesChanged
        AddHandler _textControl.InputFormat.InnerVerticalFrameLinesChanged, AddressOf InputFormat_InnerVerticalFrameLinesChanged
        AddHandler _textControl.InputFormat.JustifiedChanged, AddressOf InputFormat_JustifiedChanged
        AddHandler _textControl.InputFormat.LeftAlignedChanged, AddressOf InputFormat_LeftAlignedChanged
        AddHandler _textControl.InputFormat.LeftFrameLineChanged, AddressOf InputFormat_LeftFrameLineChanged
        AddHandler _textControl.InputFormat.LineSpacingChanged, AddressOf InputFormat_LineSpacingChanged
        AddHandler _textControl.InputFormat.NumberedListChanged, AddressOf InputFormat_NumberedListChanged
        AddHandler _textControl.InputFormat.NumberedListFormatChanged, AddressOf InputFormat_NumberedListFormatChanged
        AddHandler _textControl.InputFormat.RightAlignedChanged, AddressOf InputFormat_RightAlignedChanged
        AddHandler _textControl.InputFormat.RightFrameLineChanged, AddressOf InputFormat_RightFrameLineChanged
        AddHandler _textControl.InputFormat.StructuredListChanged, AddressOf InputFormat_StructuredListChanged
        AddHandler _textControl.InputFormat.StructuredListFormatChanged, AddressOf InputFormat_StructuredListFormatChanged
        AddHandler _textControl.InputFormat.TopFrameLineChanged, AddressOf InputFormat_TopFrameLineChanged

        ' Style properties:

        AddHandler _textControl.InputFormat.StyleNameChanged, AddressOf InputFormat_StyleNameChanged

        ' Various:

        AddHandler _textControl.GotFocus, AddressOf TextControl_GotFocus
    End Sub

    Private Sub UpdateCurrentObject()
        GetSelectedObject()
        UpdateContextualTabs()
    End Sub

    Private Sub UpdateContextualTabs()
        UpdateContextualObjectTabGroup()
        UpdateContextualTableTabGroup()

    End Sub

    Public Sub About()
        AboutBox.Show()
    End Sub

    Private Sub FormattingStyleListChanged()
        Dim itemsSource As IUICollection = _spltBtnGlryStyles.ItemsSource
        itemsSource.Clear()

        For Each styleName As String In _textControl.InputFormat.StyleNames
            itemsSource.Add(New GalleryItemPropertySet() With { _
             .Label = styleName, _
             .CategoryID = 1 _
            })
        Next
    End Sub

    ''' <summary>
    ''' Enables / disables buttons which must not be clickable during merge preview
    ''' but can not be hidden using application modes.
    ''' </summary>
    ''' <param name="bEnable">Enable / disable buttons.</param>
    Private Sub EnableMergePreviewCriticalButtons(ByVal bEnable As Boolean)
        _btnNew.Enabled = bEnable
        _btnPrint.Enabled = bEnable
        _btnOpen.Enabled = bEnable
        _btnSave.Enabled = bEnable
        _spltBtnGlrySaveAs.Enabled = bEnable
        _spltBtnGlryPrint.Enabled = bEnable
        _drpDnGlryLoadTemplate.Enabled = bEnable
    End Sub

#End Region

End Class
