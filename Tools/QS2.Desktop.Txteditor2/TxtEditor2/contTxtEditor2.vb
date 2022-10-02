'-------------------------------------------------------------------------------------------------------------
' module:			TX Text Control Words
'	file:				FormMain.vb
'
' copyright:		© Text Control GmbH, 1991-2013
' author:			T. Kummerow
'-----------------------------------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Reflection
Imports System.Threading
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Globalization


Partial Public Class contTxtEditor2
    Inherits System.Windows.Forms.UserControl

#Region " Form Variables "

    Public _fileHandler As FileHandler
    Private _fileDragDrop As FileDragDropHandler
    Private _bLoadFileOnCreate As Boolean = False
    Private _customColors As New List(Of Integer)()
    Private _objSel As TXTextControl.FrameBase
    ' Currently selected object
    Private Const ExpressEditionInfoMessage As String = "Not available in Express Edition."

    Public mainForm As frmTxtEditor2 = Nothing
    Public mainForm2 As Form = Nothing

    Public Enum eTypeUI
        OnlyShowText = 0
        Small = 1
        extremSmall = 2
        All = 10
    End Enum
    Public lockEingbe As Boolean = False

    Delegate Sub delDoActionParentControl(ByVal TypeAction As eTypeAction)
    Public callDoActionParentControl As delDoActionParentControl

    Public Enum eTypeAction
        OpenFile = 1
        NewFile = 2
    End Enum
#End Region

#Region " Enumerations "

    Private Enum TXEdition
        Unknown
        Standard
        Professional
        Enterprise
        Server
        Trial
    End Enum
    ' enum TXEdition
#End Region

#Region " Form Properties "

    Public Sub New()
        Dim currentCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        InitializeComponent()
        System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo

        If Not DesignMode Then
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("de-DE")
        End If
        _textControl.ButtonBar = buttonBar1
        _textControl.RulerBar = rulerBar1
        _textControl.VerticalRulerBar = rulerBar2
        _textControl.StatusBar = statusBar1

        _fileHandler = New FileHandler(Me, _textControl)
        _fileDragDrop = New FileDragDropHandler()

        ' Check system text direction
        Me.RightToLeft = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, RightToLeft.Yes, RightToLeft.No)

    End Sub

    Public ReadOnly Property CanCopy() As Boolean
        Get
            Return _textControl.CanCopy
        End Get
    End Property

    Public ReadOnly Property CanPaste() As Boolean
        Get
            Return _textControl.CanPaste
        End Get
    End Property

    Public ReadOnly Property CanUndo() As Boolean
        Get
            Return _textControl.CanUndo
        End Get
    End Property

    Public ReadOnly Property CanRedo() As Boolean
        Get
            Return _textControl.CanRedo
        End Get
    End Property

#End Region

#Region " Form Events "

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LoadAppSettings()
        Dim cultEN = CultureInfo.GetCultureInfo("de-DE")    '("en-US")
        Me._textControl.SelectAll()
        Me._textControl.Selection.Culture = cultEN
        _fileHandler.RecentFilesMenuItem = recentFilesToolStripMenuItem

        If _bLoadFileOnCreate Then
            If Not _fileHandler.FileOpen() Then
                Return
            End If
            If _fileHandler.DocumentFileName <> "" Then
                If Not Me.mainForm Is Nothing Then
                    Me.mainForm.Text = Me.ProductName.ToString() & " - " & Convert.ToString(_fileHandler.DocumentTitle)
                End If
                If Not Me.mainForm2 Is Nothing Then
                    Me.mainForm2.Text = Me.ProductName.ToString() & " - " & Convert.ToString(_fileHandler.DocumentTitle)
                End If
            End If
        End If

        _fileHandler.DocumentDirty = True
    End Sub

    'Private Sub FrmMain_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing     'lthxy
    '    If _fileHandler.DocumentDirty Then
    '        Dim dlgRes As System.Windows.Forms.DialogResult = MessageBox.Show("Save changes to " & Convert.ToString(_fileHandler.DocumentTitle) & "?", "Question", MessageBoxButtons.YesNoCancel)
    '        If dlgRes = System.Windows.Forms.DialogResult.Yes Then
    '            _fileHandler.FileSave()
    '            If _fileHandler.DocumentFileName = "" Then
    '                e.Cancel = True
    '            End If
    '        ElseIf dlgRes = System.Windows.Forms.DialogResult.Cancel Then
    '            e.Cancel = True
    '        End If
    '    End If
    '    SaveAppSettings()
    'End Sub

#End Region

#Region " File menu event handlers "

    Private Sub mnuFile_Open_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFile_Open.Click
        FileOpen()
    End Sub

    Private Sub mnuFile_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFile.DropDownOpening
        _fileHandler.InitRecentFiles()
    End Sub

    Private Sub mnuFile_New_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFile_New.Click
        FileNew()
    End Sub

    Private Sub mnuFile_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile_Save.Click
        FileSave()
    End Sub

    Private Sub mnuFile_SaveAs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile_SaveAs.Click
        FileSaveAs()
    End Sub

    Private Sub mnuFile_PrintPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile_PrintPreview.Click
        PrintPreview()
    End Sub

    Private Sub mnuFile_Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile_Print.Click
        Print()
    End Sub

    Private Sub mnuFile_Exit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFile_Exit.Click
        'Close()  'lthxy
    End Sub

    Private Sub mnuFile_Export_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile_Export.Click
        Try
            ' Force exception in standard version:
            _textControl.Sections.GetItem()

            _fileHandler.FileSaveAs(TXTextControl.StreamType.AdobePDF)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error when exporting document", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub mnuFile_PageSetup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile_PageSetup.Click
        Try
            If _textControl.SectionFormatDialog(0) = System.Windows.Forms.DialogResult.OK Then
                _fileHandler.DocumentDirty = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ProductName)
        End Try
    End Sub

#End Region

#Region " Edit menu event handlers "

    Private Sub mnuEdit_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit.DropDownOpening
        mnuEdit_Undo.Enabled = _textControl.CanUndo
        mnuEdit_Redo.Enabled = _textControl.CanRedo
        mnuEdit_Cut.Enabled = _textControl.CanCopy
        mnuEdit_Copy.Enabled = _textControl.CanCopy
        mnuEdit_Paste.Enabled = _textControl.CanPaste

        mnuEdit_Undo.Text = "Undo " + _textControl.UndoActionName
        mnuEdit_Redo.Text = "Redo " + _textControl.RedoActionName

        ' Hypertext links are not available in the Standard version. Accessing them  
        ' would throw an exception if this sample program is used with a Standard version
        ' of Text Control.
        Try
            mnuEdit_Hyperlink.Enabled = (_textControl.HypertextLinks.GetItem() IsNot Nothing) OrElse (_textControl.DocumentLinks.GetItem() IsNot Nothing)
            mnuEdit_Target.Enabled = (_textControl.DocumentTargets.GetItem() IsNot Nothing)
        Catch
        End Try
    End Sub

    Private Sub mnuEdit_Undo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Undo.Click
        _textControl.Undo()
    End Sub

    Private Sub mnuEdit_Redo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Redo.Click
        _textControl.Redo()
    End Sub

    Private Sub mnuEdit_Cut_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Cut.Click
        _textControl.Cut()
    End Sub

    Private Sub mnuEdit_Copy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Copy.Click
        _textControl.Copy()
    End Sub

    Private Sub mnuEdit_Paste_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Paste.Click
        _textControl.Paste()
    End Sub

    Private Sub mnuEdit_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Delete.Click
        _textControl.Clear()
    End Sub

    Private Sub mnuEdit_SelectAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_SelectAll.Click
        _textControl.SelectAll()
    End Sub

    Private Sub mnuEdit_Find_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Find.Click
        _textControl.Find()
    End Sub

    Private Sub mnuEdit_Replace_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Replace.Click
        _textControl.Replace()
    End Sub

    Private Sub mnuEdit_Hyperlink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Hyperlink.Click
        Try
            ' Force exception if standard version:
            _textControl.HypertextLinks.GetItem()

            If FrmHyperlink.ShowDialog(_textControl, Settings.frmMain) = System.Windows.Forms.DialogResult.OK Then
                _fileHandler.DocumentDirty = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ProductName)
        End Try
    End Sub

    Private Sub mnuEdit_Target_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit_Target.Click
        Try
            ' Force exception if standard version:
            Dim target As TXTextControl.DocumentTarget = _textControl.DocumentTargets.GetItem()

            Dim targetName As String = ""

            If target IsNot Nothing Then
                targetName = target.Name
                If FrmInputBox.ShowInputBox("Enter a name for this target:", targetName, Settings.frmMain) Then
                    target.Name = targetName
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ProductName)
        End Try
    End Sub

#End Region

#Region " View menu event handlers "

    Private Sub mnuView_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView.DropDownOpening
        mnuView_Draft.Checked = (_textControl.ViewMode = TXTextControl.ViewMode.Normal)
        mnuView_PageLayout.Checked = (_textControl.ViewMode = TXTextControl.ViewMode.PageView)
        mnuView_Toolbar.Checked = _toolStrip.Visible
        mnuView_ButtonBar.Checked = buttonBar1.Visible
        mnuView_StatusBar.Checked = statusBar1.Visible
        mnuView_HorizontalRuler.Checked = rulerBar1.Visible
        mnuView_VerticalRuler.Checked = rulerBar2.Visible
        mnuView_HeadersAndFooters.Enabled = (_textControl.ViewMode = TXTextControl.ViewMode.PageView)

        mnuView_TextFrameMarkerLines.Checked = _textControl.TextFrameMarkerLines
        mnuView_DocumentTargetMarkers.Checked = _textControl.DocumentTargetMarkers
    End Sub

    Private Sub mnuView_Normal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Draft.Click
        _textControl.ViewMode = TXTextControl.ViewMode.Normal
    End Sub

    Private Sub mnuView_PageLayout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_PageLayout.Click
        _textControl.ViewMode = TXTextControl.ViewMode.PageView
    End Sub

    Private Sub mnuView_Toolbar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Toolbar.Click
        _toolStrip.Visible = Not _toolStrip.Visible
    End Sub

    Private Sub mnuView_ButtonBar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_ButtonBar.Click
        buttonBar1.Visible = Not buttonBar1.Visible
    End Sub

    Private Sub mnuView_StatusBar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_StatusBar.Click
        statusBar1.Visible = Not statusBar1.Visible
    End Sub

    Private Sub mnuView_HorizontalRuler_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_HorizontalRuler.Click
        rulerBar1.Visible = Not rulerBar1.Visible
    End Sub

    Private Sub mnuView_VerticalRuler_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_VerticalRuler.Click
        rulerBar2.Visible = Not rulerBar2.Visible
    End Sub

    Private Sub mnuView_Zoom_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles mnuView_Zoom.DropDownOpening
        mnuView_Zoom_25.Checked = (_textControl.ZoomFactor = 25)
        mnuView_Zoom_50.Checked = (_textControl.ZoomFactor = 50)
        mnuView_Zoom_75.Checked = (_textControl.ZoomFactor = 75)
        mnuView_Zoom_100.Checked = (_textControl.ZoomFactor = 100)
        mnuView_Zoom_150.Checked = (_textControl.ZoomFactor = 150)
        mnuView_Zoom_200.Checked = (_textControl.ZoomFactor = 200)
        mnuView_Zoom_300.Checked = (_textControl.ZoomFactor = 300)
    End Sub

    Private Sub mnuView_Zoom_25_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Zoom_25.Click
        _textControl.ZoomFactor = 25
    End Sub

    Private Sub mnuView_Zoom_50_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Zoom_50.Click
        _textControl.ZoomFactor = 50
    End Sub

    Private Sub mnuView_Zoom_75_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Zoom_75.Click
        _textControl.ZoomFactor = 75
    End Sub

    Private Sub mnuView_Zoom_100_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Zoom_100.Click
        _textControl.ZoomFactor = 100
    End Sub

    Private Sub mnuView_Zoom_150_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Zoom_150.Click
        _textControl.ZoomFactor = 150
    End Sub

    Private Sub mnuView_Zoom_200_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Zoom_200.Click
        _textControl.ZoomFactor = 200
    End Sub

    Private Sub mnuView_Zoom_300_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_Zoom_300.Click
        _textControl.ZoomFactor = 300
    End Sub

    Private Sub mnuView_FormLayout_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuView_FormLayout.DropDownOpening
        _mnuView_FormLayout_LTR.Checked = (Me.RightToLeft = System.Windows.Forms.RightToLeft.No)
        _mnuView_FormLayout_RTL.Checked = (Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes)
    End Sub

    Private Sub mnuView_FormLayout_LTR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuView_FormLayout_LTR.Click
        rulerBar2.Dock = DockStyle.Left
        RightToLeft = System.Windows.Forms.RightToLeft.No
        Focus()
        _textControl.Focus()
    End Sub

    Private Sub mnuView_FormLayout_RTL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mnuView_FormLayout_RTL.Click
        rulerBar2.Dock = DockStyle.Right
        RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Focus()
        _textControl.Focus()
    End Sub

    Private Sub mnuView_HeadersAndFooters_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_HeadersAndFooters.Click
        Try
            Dim currentSection As TXTextControl.Section = _textControl.Sections.GetItem()
            Dim headerFooter As TXTextControl.HeaderFooter = Nothing
            If currentSection.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader) IsNot Nothing Then
                headerFooter = currentSection.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.FirstPageHeader)
            ElseIf currentSection.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header) IsNot Nothing Then
                headerFooter = currentSection.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header)
            Else
                currentSection.HeadersAndFooters.Add(TXTextControl.HeaderFooterType.Header)
                _textControl.HeaderFooterActivationStyle = TXTextControl.HeaderFooterActivationStyle.ActivateClick
                headerFooter = currentSection.HeadersAndFooters.GetItem(TXTextControl.HeaderFooterType.Header)
            End If
            headerFooter.Activate()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ProductName)
        End Try
    End Sub

    Private Sub mnuView_TextFrameMarkerLines_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuView_TextFrameMarkerLines.Click
        _textControl.TextFrameMarkerLines = Not _textControl.TextFrameMarkerLines
    End Sub

    Private Sub mnuView_DocumentTargetMarkers_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuView_DocumentTargetMarkers.Click
        _textControl.DocumentTargetMarkers = Not _textControl.DocumentTargetMarkers
    End Sub

#End Region

#Region " Insert menu event handlers "

    Private Sub mnuInsert_File_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuInsert_File.Click
        Try
            _fileHandler.Insert()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ProductName)
        End Try
    End Sub

    Private Sub mnuInsert_Image_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuInsert_Image.Click
        Dim imageNew As New TXTextControl.Image()
        _textControl.Images.Add(imageNew, TXTextControl.HorizontalAlignment.Left, -1, TXTextControl.ImageInsertionMode.DisplaceText)
    End Sub

    Private Sub MnuPageNum_delete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuPageNum_delete.Click
        RemovePageNumbers()
    End Sub

    Private Sub MnuField_delete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuInsert_Fields_deleteField.Click
        DeleteField()
    End Sub


    Private Sub mnuInsert_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuInsert.DropDownOpening
        ' Try/Catch is required because hypertext links are not available in the Standard version. 
        ' of Text Control. Accessing them would throw an exception if this sample program is used 
        ' with a Standard Version.
        Try
            mnuInsert_Hyperlink.Enabled = _textControl.HypertextLinks.CanAdd
            mnuInsert_Target.Enabled = _textControl.DocumentTargets.CanAdd
        Catch
        End Try
    End Sub

    Private Sub mnuInsert_TextFrame_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuInsert_TextFrame.Click
        Try
            ' Force Exception if standard version:
            _textControl.TextFrames.GetItem()
            Dim sizeTextFrame As New Size(2268, 2268)
            ' 4 x 4 cm
            Dim textFrameNew As New TXTextControl.TextFrame(sizeTextFrame)
            _textControl.TextFrames.Add(textFrameNew, TXTextControl.HorizontalAlignment.Left, -1, TXTextControl.TextFrameInsertionMode.DisplaceCompleteLines)
        Catch ex As Exception
            MessageBox.Show(ex.Message, ProductName)
        End Try
    End Sub

    Private Sub mnuInsert_Hyperlink_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuInsert_Hyperlink.Click
        Try
            ' Force Exception if standard version:
            _textControl.HypertextLinks.GetItem()

            FrmHyperlink.ShowDialog(_textControl, Settings.frmMain)
        Catch ex As Exception
            MessageBox.Show(ex.Message, ProductName)
        End Try
    End Sub

    Private Sub mnuInsert_Target_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuInsert_Target.Click
        Try
            ' Force Exception if standard version:
            _textControl.DocumentTargets.GetItem()

            Dim TargetName As String = ""

            If FrmInputBox.ShowInputBox("Target Name:", TargetName, Settings.frmMain) Then
                Dim Target As New TXTextControl.DocumentTarget(TargetName)
                Target.Deleteable = False
                _textControl.DocumentTargets.Add(Target)
                _fileHandler.DocumentDirty = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ProductName)
        End Try
    End Sub

    Private Sub MnuInsert_Fields_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuInsert_Fields.DropDownOpening
        Select Case _fldDispModeCur
            Case FieldDisplayMode.ShowFieldText
                _mnuInsert_Fields_showFieldCodes.Checked = False
                _mnuInsert_Fields_showFieldText.Checked = True
                Exit Select

            Case FieldDisplayMode.ShowFieldCodes
                _mnuInsert_Fields_showFieldCodes.Checked = True
                _mnuInsert_Fields_showFieldText.Checked = False
                Exit Select
        End Select

        _mnuInsert_Fields_highlightMergeFields.Checked = _bHighlightFields
        _mnuInsert_Fields_deleteField.Enabled = FieldAtCurrentPos()
    End Sub

    Private Sub MnuInsert_Fields_insertMergeField_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuInsert_Fields_insertMergeField.Click
        InsertMergeField()
        UpdateFieldValues()
    End Sub

    Private Sub MnuInsert_Fields_insertSpecialField_IF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuInsert_Fields_insertSpecialField_IF.Click
        InsertIfField()
        UpdateFieldValues()
    End Sub

    Private Sub MnuInsert_Fields_insertSpecialField_inclText_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuInsert_Fields_insertSpecialField_inclText.Click
        InsertIncludeTextField()
        UpdateFieldValues()
    End Sub

    Private Sub MnuInsert_Fields_insertSpecialField_date_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuInsert_Fields_insertSpecialField_date.Click
        InsertDateField()
        UpdateFieldValues()
    End Sub

    Private Sub mnuInsert_Fields_insertSpecialField_next_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuInsert_Fields_insertSpecialField_Next.Click
        InsertNextField()
        UpdateFieldValues()
    End Sub

    Private Sub mnuInsert_Fields_insertSpecialField_nextif_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuInsert_Fields_insertSpecialField_NextIf.Click
        InsertNextIfField()
        UpdateFieldValues()
    End Sub

    Private Sub MnuInsert_Fields_highlightMergeFields_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuInsert_Fields_highlightMergeFields.Click
        _bHighlightFields = Not _bHighlightFields
        _mnuInsert_Fields_highlightMergeFields.Checked = _bHighlightFields
        SetDefaultFieldProperties()
    End Sub

    Private Sub MnuInsert_Fields_showFieldCodes_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuInsert_Fields_showFieldCodes.Click
        If _mnuInsert_Fields_showFieldCodes.Checked Then
            Return
        End If

        _fldDispModeCur = FieldDisplayMode.ShowFieldCodes
        CheckFieldDisplayModeMenuItems()
        UpdateFieldValues()
    End Sub

    Private Sub MnuInsert_Fields_showFieldText_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuInsert_Fields_showFieldText.Click
        If _mnuInsert_Fields_showFieldText.Checked Then
            Return
        End If

        _fldDispModeCur = FieldDisplayMode.ShowFieldText
        CheckFieldDisplayModeMenuItems()
        UpdateFieldValues()
    End Sub

    Private Sub MnuItm_page_top_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuItm_page_top.Click
        InsertPageNumber(TXTextControl.HeaderFooterType.Header)
    End Sub

    Private Sub MnuItm_page_bottom_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuItm_page_bottom.Click
        InsertPageNumber(TXTextControl.HeaderFooterType.Footer)
    End Sub

#End Region

#Region " Format menu event handlers "

    Private Sub mnuFormat_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat.DropDownOpening
        mnuFormat_Image.Enabled = (_textControl.Images.GetItem() IsNot Nothing)

        Try
            mnuFormat_TextFrame.Enabled = (_textControl.TextFrames.GetItem() IsNot Nothing)
        Catch
            mnuFormat_TextFrame.Enabled = False
        End Try
    End Sub

    Private Sub mnuFormat_Character_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_Character.Click
        If _textControl.FontDialog() = System.Windows.Forms.DialogResult.OK Then
            _fileHandler.DocumentDirty = True
        End If
    End Sub

    Private Sub mnuFormat_Paragraph_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_Paragraph.Click
        If _textControl.ParagraphFormatDialog() = System.Windows.Forms.DialogResult.OK Then
            _fileHandler.DocumentDirty = True
        End If
    End Sub

    Private Sub mnuFormat_Tabs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_Tabs.Click
        If _textControl.TabDialog() = System.Windows.Forms.DialogResult.OK Then
            _fileHandler.DocumentDirty = True
        End If
    End Sub

    Private Sub mnuFormat_Styles_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_Styles.Click
        If _textControl.FormattingStylesDialog() = System.Windows.Forms.DialogResult.OK Then
            _fileHandler.DocumentDirty = True
        End If
    End Sub

    Private Sub mnuFormat_HeadersFooters_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFormat_HeadersAndFooters.Click
        Try
            If _textControl.SectionFormatDialog(1) = System.Windows.Forms.DialogResult.OK Then
                _fileHandler.DocumentDirty = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ProductName)
        End Try
    End Sub

    Private Sub mnuFormat_Image_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_Image.Click
        If _textControl.ImageAttributesDialog() = System.Windows.Forms.DialogResult.OK Then
            _fileHandler.DocumentDirty = True
        End If
    End Sub

    Private Sub mnuFormat_List_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFormat_List.DropDownOpening
        mnuFormat_List_IncreaseLevel.Enabled = (_textControl.Selection.ListFormat.Type <> TXTextControl.ListType.None) AndAlso (_textControl.Selection.ListFormat.Level < TXTextControl.ListFormat.MaxLevel)
        mnuFormat_List_DecreaseLevel.Enabled = (_textControl.Selection.ListFormat.Type <> TXTextControl.ListType.None) AndAlso (_textControl.Selection.ListFormat.Level > 1)

        CheckListMenuItem()
    End Sub

    Private Sub mnuFormat_List_Attributes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_List_Attributes.Click
        If _textControl.ListFormatDialog() = System.Windows.Forms.DialogResult.OK Then
            _fileHandler.DocumentDirty = True
        End If
    End Sub

    Private Sub mnuFormat_List_IncreaseLevel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_List_IncreaseLevel.Click
        _textControl.Selection.ListFormat.Level += 1
        _textControl.Selection.IncreaseIndent()
    End Sub

    Private Sub mnuFormat_List_DecreaseLevel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_List_DecreaseLevel.Click
        If _textControl.Selection.ListFormat.Level >= 2 Then
            _textControl.Selection.ListFormat.Level -= 1
            _textControl.Selection.DecreaseIndent()
        End If
    End Sub

    Private Sub mnuFormat_List_ArabicNumbers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_List_ArabicNumbers.Click
        If mnuFormat_List_ArabicNumbers.Checked Then
            _textControl.Selection.ListFormat.Type = TXTextControl.ListType.None
            _textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.None
            Return
        End If

        _textControl.Selection.ListFormat.Type = TXTextControl.ListType.Numbered
        _textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.ArabicNumbers
    End Sub

    Private Sub mnuFormat_List_CapitalLetters_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_List_CapitalLetters.Click
        If mnuFormat_List_CapitalLetters.Checked Then
            _textControl.Selection.ListFormat.Type = TXTextControl.ListType.None
            _textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.None
            Return
        End If

        _textControl.Selection.ListFormat.Type = TXTextControl.ListType.Numbered
        _textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.CapitalLetters
    End Sub

    Private Sub mnuFormat_List_Letters_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_List_Letters.Click
        If mnuFormat_List_Letters.Checked Then
            _textControl.Selection.ListFormat.Type = TXTextControl.ListType.None
            _textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.None
            Return
        End If

        _textControl.Selection.ListFormat.Type = TXTextControl.ListType.Numbered
        _textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.Letters
    End Sub

    Private Sub mnuFormat_List_RomanNumbers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_List_RomanNumbers.Click
        If mnuFormat_List_RomanNumbers.Checked Then
            _textControl.Selection.ListFormat.Type = TXTextControl.ListType.None
            _textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.None
            Return
        End If

        _textControl.Selection.ListFormat.Type = TXTextControl.ListType.Numbered
        _textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.RomanNumbers
    End Sub

    Private Sub mnuFormat_List_SmallRomanNumbers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_List_SmallRomanNumbers.Click
        If mnuFormat_List_SmallRomanNumbers.Checked Then
            _textControl.Selection.ListFormat.Type = TXTextControl.ListType.None
            _textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.None
            Return
        End If

        _textControl.Selection.ListFormat.Type = TXTextControl.ListType.Numbered
        _textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.SmallRomanNumbers
    End Sub

    Private Sub mnuFormat_List_Bullets_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_List_Bullets.Click
        If mnuFormat_List_Bullets.Checked Then
            _textControl.Selection.ListFormat.Type = TXTextControl.ListType.None
            _textControl.Selection.ListFormat.NumberFormat = TXTextControl.NumberFormat.None
            Return
        End If

        _textControl.Selection.ListFormat.Type = TXTextControl.ListType.Bulleted
    End Sub

    Private Sub mnuFormat_borders_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFormat_pageframe.Click
        Try
            If _textControl.SectionFormatDialog(3) = System.Windows.Forms.DialogResult.OK Then
                _fileHandler.DocumentDirty = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ProductName)
        End Try
    End Sub

    Private Sub mnuFormat_Columns_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFormat_Columns.Click
        Try
            If _textControl.SectionFormatDialog(2) = System.Windows.Forms.DialogResult.OK Then
                _fileHandler.DocumentDirty = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ProductName)
        End Try
    End Sub

    Private Sub mnuFormat_TextFrame_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFormat_TextFrame.Click
        Try
            If _textControl.TextFrameAttributesDialog() = System.Windows.Forms.DialogResult.OK Then
                _fileHandler.DocumentDirty = True
            End If
        Catch
        End Try
    End Sub

    Private Sub mnuFormat_SetLanguage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuFormat_SetLanguage.Click
        _textControl.LanguageDialog()
    End Sub

#End Region

#Region " Table menu event handlers "

    Private Sub mnuTable_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable.DropDownOpening
        Dim ThisTable As TXTextControl.Table = _textControl.Tables.GetItem()

        mnuTable_Properties.Enabled = (ThisTable IsNot Nothing)
        mnuTable_GridLines.Checked = _textControl.Tables.GridLines

        If ThisTable IsNot Nothing Then
            mnuTable_Delete.Enabled = True
            mnuTable_Split.Enabled = ThisTable.CanSplit
            mnuTable_Merge_Cells.Enabled = ThisTable.CanMergeCells
            mnuTable_Split_Cells.Enabled = ThisTable.CanSplitCells
            mnuTable_Select.Enabled = True
        Else
            mnuTable_Split.Enabled = False
            mnuTable_Delete.Enabled = False
            mnuTable_Merge_Cells.Enabled = False
            mnuTable_Split_Cells.Enabled = False
            mnuTable_Select.Enabled = False
        End If
    End Sub

    Private Sub mnuTable_Insert_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Insert.DropDownOpening
        mnuTable_Insert_Table.Enabled = _textControl.Tables.CanAdd

        Dim tableAtInputPosition As TXTextControl.Table = _textControl.Tables.GetItem()
        If tableAtInputPosition Is Nothing Then
            mnuTable_Insert_ColumnToTheLeft.Enabled = False
            mnuTable_Insert_ColumnToTheRight.Enabled = False
            mnuTable_Insert_RowAbove.Enabled = False
            mnuTable_Insert_RowBelow.Enabled = False
        Else
            mnuTable_Insert_ColumnToTheLeft.Enabled = tableAtInputPosition.Columns.CanAdd
            mnuTable_Insert_ColumnToTheRight.Enabled = tableAtInputPosition.Columns.CanAdd
            mnuTable_Insert_RowAbove.Enabled = tableAtInputPosition.Rows.CanAdd
            mnuTable_Insert_RowBelow.Enabled = tableAtInputPosition.Rows.CanAdd
        End If
    End Sub

    Private Sub mnuTable_Insert_Table_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Insert_Table.Click
        InsertTable()
    End Sub

    Private Sub mnuTable_Insert_ColumnToTheLeft_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Insert_ColumnToTheLeft.Click
        _textControl.Tables.GetItem().Columns.Add(TXTextControl.TableAddPosition.Before)
    End Sub

    Private Sub mnuTable_Insert_ColumnToTheRight_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Insert_ColumnToTheRight.Click
        _textControl.Tables.GetItem().Columns.Add(TXTextControl.TableAddPosition.After)
    End Sub

    Private Sub mnuTable_Insert_RowAbove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Insert_RowAbove.Click
        _textControl.Tables.GetItem().Rows.Add(TXTextControl.TableAddPosition.Before, 1)
    End Sub

    Private Sub mnuTable_Insert_RowBelow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Insert_RowBelow.Click
        _textControl.Tables.GetItem().Rows.Add(TXTextControl.TableAddPosition.After, 1)
    End Sub

    Private Sub mnuTable_Delete_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Delete.DropDownOpening
        Dim tableAtInputPosition As TXTextControl.Table = _textControl.Tables.GetItem()

        If tableAtInputPosition Is Nothing Then
            mnuTable_Delete_Table.Enabled = False
            mnuTable_Delete_Column.Enabled = False
            mnuTable_Delete_Rows.Enabled = False
            mnuTable_Delete_Cells.Enabled = False
        Else
            mnuTable_Delete_Table.Enabled = tableAtInputPosition.Columns.CanRemove
            mnuTable_Delete_Column.Enabled = tableAtInputPosition.Columns.CanRemove
            mnuTable_Delete_Rows.Enabled = tableAtInputPosition.Rows.CanRemove
            mnuTable_Delete_Cells.Enabled = tableAtInputPosition.Cells.CanRemove
            mnuTable_Delete_Cells_entireColumn.Enabled = tableAtInputPosition.Columns.CanRemove
            mnuTable_Delete_Cells_entireRow.Enabled = tableAtInputPosition.Rows.CanRemove
        End If
    End Sub

    Private Sub mnuTable_Delete_Table_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Delete_Table.Click
        _textControl.Tables.Remove()
    End Sub

    Private Sub mnuTable_Delete_Column_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Delete_Column.Click
        _textControl.Tables.GetItem().Columns.Remove()
    End Sub

    Private Sub mnuTable_Delete_Rows_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Delete_Rows.Click
        _textControl.Tables.GetItem().Rows.Remove()
    End Sub

    Private Sub mnuTable_Delete_Cells_shiftLeft_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuTable_Delete_Cells_shiftLeft.Click
        _textControl.Tables.GetItem().Cells.Remove()
    End Sub

    Private Sub mnuTable_Delete_Cells_entireRow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuTable_Delete_Cells_entireRow.Click
        _textControl.Tables.GetItem().Rows.Remove()
    End Sub

    Private Sub mnuTable_Delete_Cells_entireColumn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuTable_Delete_Cells_entireColumn.Click
        _textControl.Tables.GetItem().Columns.Remove()
    End Sub

    Private Sub mnuTable_Merge_Cells_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuTable_Merge_Cells.Click
        _textControl.Tables.GetItem().MergeCells()
    End Sub

    Private Sub mnuTable_Split_Cells_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuTable_Split_Cells.Click
        _textControl.Tables.GetItem().SplitCells()
    End Sub

    Private Sub mnuTable_Split_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles mnuTable_Split.DropDownOpening
        Dim tableAtInputPosition As TXTextControl.Table = _textControl.Tables.GetItem()

        If tableAtInputPosition Is Nothing Then
            mnuTable_Split_Above.Enabled = False
            mnuTable_Split_Below.Enabled = False
        Else
            mnuTable_Split_Above.Enabled = True
            mnuTable_Split_Below.Enabled = True
        End If

    End Sub

    Private Sub mnuTable_Split_Above_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Split_Above.Click
        _textControl.Tables.GetItem().Split(TXTextControl.TableAddPosition.Before)
    End Sub

    Private Sub mnuTable_Split_Below_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Split_Below.Click
        _textControl.Tables.GetItem().Split(TXTextControl.TableAddPosition.After)
    End Sub

    Private Sub mnuTable_Select_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Select.DropDownOpening
        Dim tableAtInputPosition As TXTextControl.Table = Nothing
        Dim rowAtInputPosition As TXTextControl.TableRow = Nothing
        Dim cellAtInputPosition As TXTextControl.TableCell = Nothing
        Dim columnAtInputPosition As TXTextControl.TableColumn = Nothing

        tableAtInputPosition = _textControl.Tables.GetItem()
        If tableAtInputPosition IsNot Nothing Then
            rowAtInputPosition = tableAtInputPosition.Rows.GetItem()
            cellAtInputPosition = tableAtInputPosition.Cells.GetItem()
            columnAtInputPosition = tableAtInputPosition.Columns.GetItem()
        End If

        mnuTable_Select_Table.Enabled = (tableAtInputPosition IsNot Nothing)
        mnuTable_Select_Row.Enabled = (rowAtInputPosition IsNot Nothing)
        mnuTable_Select_Cell.Enabled = (cellAtInputPosition IsNot Nothing)
        mnuTable_Select_Column.Enabled = (columnAtInputPosition IsNot Nothing)
    End Sub

    Private Sub mnuTable_Select_Table_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Select_Table.Click
        _textControl.Tables.GetItem().[Select]()
    End Sub

    Private Sub mnuTable_Select_Row_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Select_Row.Click
        _textControl.Tables.GetItem().Rows.GetItem().[Select]()
    End Sub

    Private Sub mnuTable_Select_Column_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuTable_Select_Column.Click
        _textControl.Tables.GetItem().Columns.GetItem().[Select]()
    End Sub

    Private Sub mnuTable_Select_Cell_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Select_Cell.Click
        _textControl.Tables.GetItem().Cells.GetItem().[Select]()
    End Sub

    Private Sub mnuTable_GridLines_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_GridLines.Click
        _textControl.Tables.GridLines = Not _textControl.Tables.GridLines
    End Sub

    Private Sub mnuTable_Properties_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTable_Properties.Click
        _textControl.TableFormatDialog()
    End Sub

#End Region

#Region " Help menu event handlers "

    Private Sub mnuHelp_AboutTXTextControlWords_Click(ByVal sender As Object, ByVal e As EventArgs) Handles mnuHelp_AboutTXTextControlWords.Click
        About()
    End Sub
#End Region

#Region " Menu item and toolbar button functions "

    Public Sub FileNew()
        If _fileHandler.DocumentDirty Then
            Select Case MessageBox.Show("Save changes to " & Convert.ToString(_fileHandler.DocumentTitle) & "?", "Question", MessageBoxButtons.YesNoCancel)
                Case System.Windows.Forms.DialogResult.Cancel
                    Return
                Case System.Windows.Forms.DialogResult.Yes
                    _fileHandler.FileSave()
                    If _fileHandler.DocumentFileName = "" Then
                        Return
                    End If
                    Exit Select
                Case System.Windows.Forms.DialogResult.No
                    Exit Select
            End Select
        End If
        _fileHandler.DocumentFileName = ""
        _textControl.ResetContents()
        If Not Me.mainForm Is Nothing Then
            Me.mainForm.Text = Me.ProductName.ToString() & " - " & Convert.ToString(_fileHandler.DocumentTitle)
        End If
        If Not Me.mainForm2 Is Nothing Then
            Me.mainForm2.Text = Me.ProductName.ToString() & " - " & Convert.ToString(_fileHandler.DocumentTitle)
        End If
        _fileHandler.DocumentDirty = False

        If Not Me.callDoActionParentControl Is Nothing Then
            Me.callDoActionParentControl.Invoke(eTypeAction.NewFile)
        End If
    End Sub

    Public Sub FileOpen()
        Dim Result As System.Windows.Forms.DialogResult

        If _fileHandler.DocumentDirty Then
            Result = MessageBox.Show("Save changes to " & Convert.ToString(_fileHandler.DocumentTitle) & "?", "Question", MessageBoxButtons.YesNoCancel)
            If Result = System.Windows.Forms.DialogResult.Yes Then
                _fileHandler.FileSave()
                If _fileHandler.DocumentFileName = "" Then
                    Return
                End If
            ElseIf Result = System.Windows.Forms.DialogResult.Cancel Then
                Return
            End If
        End If

        _fileHandler.DocumentFileName = ""
        _fileHandler.FileOpen()

        If Not Me.callDoActionParentControl Is Nothing Then
            Me.callDoActionParentControl.Invoke(eTypeAction.OpenFile)
        End If

    End Sub

    Public Sub FileSave()
        Try
            _fileHandler.FileSave()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error when saving document", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Public Sub FileSaveAs()
        Try
            _fileHandler.FileSaveAs(TXTextControl.StreamType.RichTextFormat)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error when saving document", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Public Sub Print()
        _textControl.Print(ProductName & " - " & Convert.ToString(_fileHandler.DocumentTitle))
    End Sub

    Public Sub PrintPreview()
        _textControl.PrintPreview(ProductName & " - " & Convert.ToString(_fileHandler.DocumentTitle))
    End Sub

    Public Sub About()
        Dim copyright As String = DirectCast(Attribute.GetCustomAttribute(Me.[GetType]().Assembly, GetType(AssemblyCopyrightAttribute)), AssemblyCopyrightAttribute).Copyright
        Dim asmTitle As String = DirectCast(Attribute.GetCustomAttribute(Me.[GetType]().Assembly, GetType(AssemblyTitleAttribute)), AssemblyTitleAttribute).Title

        MessageBox.Show(asmTitle & vbCr & vbLf & copyright, "About " & ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Function GetNumberOfPages() As Integer
        Dim pages As Integer = 0

        Try
            For i As Integer = 1 To _textControl.Pages
                If _textControl.GetPages()(i).Section = _textControl.Sections.GetItem().Number Then
                    pages += 1
                End If
            Next
        Catch
        End Try

        Return pages
    End Function


#End Region

#Region " Form methods and functions "
    Private Sub LoadAppSettings()
        ' Take over initial resizing
        'Me.StartPosition = FormStartPosition.Manual      'lthxy

        ' Resize form
        Me.Size = My.Settings.Default.LastWindowSize
        Me.Location = My.Settings.Default.LastWindowPos
        'Me.WindowState = My.Settings.Default.LastWindowState

    End Sub

    Public Sub SaveAppSettings()
        ' Store location and size data, using RestoreBounds to remember normal position if minimized or maximized

        'If Me.WindowState = FormWindowState.Normal Then      'lthxy
        '    My.Settings.Default.LastWindowPos = Me.Location
        '    My.Settings.Default.LastWindowSize = Me.Size
        'Else
        '    My.Settings.Default.LastWindowPos = Me.RestoreBounds.Location
        '    My.Settings.Default.LastWindowSize = Me.RestoreBounds.Size
        'End If
        'My.Settings.Default.LastWindowState = Me.WindowState
        'My.Settings.Default.Save()
    End Sub

#End Region

#Region " Toolbar event handlers "

    Public Sub UpdateSaveStatus()
        _toolStrip.Items("toolStripSave").Enabled = _fileHandler.DocumentDirty
        mnuFile.DropDownItems(4).Enabled = _fileHandler.DocumentDirty
    End Sub

    Private Sub toolStripButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripNewFile.Click
        FileNew()
    End Sub

    Private Sub toolStripButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripOpenFile.Click
        FileOpen()
    End Sub

    Private Sub toolStripButton3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripSave.Click
        FileSave()
    End Sub

    Private Sub toolStripButton4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripPrint.Click
        Print()
    End Sub

    Private Sub toolStripButton5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripPrintPreview.Click
        PrintPreview()
    End Sub

    Private Sub toolStripButton6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripCut.Click
        _textControl.Cut()
    End Sub

    Private Sub toolStripButton7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripCopy.Click
        _textControl.Copy()
    End Sub

    Private Sub toolStripButton8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripPaste.Click
        _textControl.Paste()
    End Sub

    Private Sub toolStripButton9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripDelete.Click
        _textControl.Clear()
    End Sub

    Private Sub toolStripButton10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripUndo.Click
        _textControl.Undo()
    End Sub

    Private Sub toolStripButton11_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripRedo.Click
        _textControl.Redo()
    End Sub

    Private Sub toolStripButton12_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripFind.Click
        _textControl.Find()
    End Sub

    Private Sub toolStripMarginsAndPaper_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripMarginsAndPaper.Click
        Try
            _textControl.SectionFormatDialog(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message, ProductName)
        End Try
    End Sub

    Private Sub toolStripHeadersAndFooters_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripHeadersAndFooters.Click
        Try
            _textControl.SectionFormatDialog(1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, ProductName)
        End Try
    End Sub

    Private Sub toolStripColumns_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripColumns.Click
        Try
            _textControl.SectionFormatDialog(2)
        Catch ex As Exception
            MessageBox.Show(ex.Message, ProductName)
        End Try
    End Sub

    Private Sub toolStripPageBorders_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripPageBorders.Click
        Try
            _textControl.SectionFormatDialog(3)
        Catch ex As Exception
            MessageBox.Show(ex.Message, ProductName)
        End Try
    End Sub

    Private Sub sectionToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles sectionToolStripMenuItem.Click
        Dim frm As New frmInsertBreak()

        frm.tx = _textControl
        If frm.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            _fileHandler.DocumentDirty = True
        End If
    End Sub

#End Region

#Region "  Options menu event handlers  "

    Private Sub mnuOptions_HTML_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuOptions_HTML.Click
        Dim HTMLOptionsDialog As New FrmHTMLOptions(_fileHandler)
        HTMLOptionsDialog.ShowDialog()
    End Sub

    Private Sub mnuOptions_PDF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuOptions_PDF.Click
        If GetTXEdition() > TXEdition.Standard Then
            Dim PDFOptionsDialog As New FrmPDFOptions(_textControl)

            PDFOptionsDialog.FileHandler = _fileHandler
            PDFOptionsDialog.ShowDialog()
        Else
            MessageBox.Show(ExpressEditionInfoMessage, ProductName, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End If
    End Sub

#End Region

#Region " Helpers "

    Private Function ColorToBGR(ByVal color As Color) As Integer
        Return color.B << 16 Or color.G << 8 Or color.R
    End Function

    Private Function GetTXEdition() As TXEdition
        Dim strVersionString As String = _textControl.GetVersionString()
        If strVersionString.Contains(TXEdition.Standard.ToString()) Then
            Return TXEdition.Standard
        ElseIf strVersionString.Contains(TXEdition.Professional.ToString()) Then
            Return TXEdition.Professional
        ElseIf strVersionString.Contains(TXEdition.Enterprise.ToString()) Then
            Return TXEdition.Enterprise
        ElseIf strVersionString.Contains(TXEdition.Server.ToString()) Then
            Return TXEdition.Server
        ElseIf strVersionString.Contains(TXEdition.Trial.ToString()) Then
            Return TXEdition.Trial
        End If

        Return TXEdition.Unknown
    End Function

    Private Function GetSelectedObjInsMode() As TXTextControl.FrameInsertionMode
        If _objSel Is Nothing Then
            Return TXTextControl.FrameInsertionMode.AsCharacter
        End If
        Return _objSel.InsertionMode And Not (TXTextControl.FrameInsertionMode.MoveWithText Or TXTextControl.FrameInsertionMode.FixedOnPage)
    End Function

    Private Sub SetSelectedObjectInsertionMode(ByVal mnuItem As Object, ByVal insMode As TXTextControl.FrameInsertionMode)
        Dim mi As ToolStripMenuItem = TryCast(mnuItem, ToolStripMenuItem)
        If (mi Is Nothing) OrElse mi.Checked Then
            Return
        End If

        ' Set new insertion mode
        SetObjectInsertionMode(_objSel, insMode)
        mi.Checked = True
    End Sub

    Private Sub SetObjectInsertionMode(ByVal obj As TXTextControl.FrameBase, ByVal insMode As TXTextControl.FrameInsertionMode)
        If obj Is Nothing Then
            Return
        End If

        ' If new insertion mode is "as character" discard previous insertion mode flags
        If insMode = TXTextControl.FrameInsertionMode.AsCharacter Then
            obj.InsertionMode = insMode
            Return
        End If

        ' Get current insertion mode flags
        Dim insModeFlags As TXTextControl.FrameInsertionMode = (obj.InsertionMode And (TXTextControl.FrameInsertionMode.FixedOnPage Or TXTextControl.FrameInsertionMode.MoveWithText))

        ' If currently no insertion mode flags are set, set to "move with text"
        If insModeFlags = DirectCast(0, TXTextControl.FrameInsertionMode) Then
            insModeFlags = TXTextControl.FrameInsertionMode.MoveWithText
        End If

        ' Combine new insertion mode with current insertion mode flags
        obj.InsertionMode = insModeFlags Or insMode
    End Sub

    Private Sub UpdateCurrentObject()
        GetSelectedObject()
    End Sub

    Private Sub GetSelectedObject()
        Try
            _objSel = _textControl.Frames.GetItem()
        Catch
        End Try
    End Sub

    Private Sub InsertTable()
        If _textControl.Tables.Add() Then
            _fileHandler.DocumentDirty = True
        End If
    End Sub

    Private Sub CheckFieldDisplayModeMenuItems()
        Select Case _fldDispModeCur
            Case FieldDisplayMode.ShowFieldText
                _mnuInsert_Fields_showFieldCodes.Checked = False
                _mnuInsert_Fields_showFieldText.Checked = True
                Exit Select

            Case FieldDisplayMode.ShowFieldCodes
                _mnuInsert_Fields_showFieldCodes.Checked = True
                _mnuInsert_Fields_showFieldText.Checked = False
                Exit Select
        End Select
    End Sub

    Public Sub UpdateGUIState()
        _toolStrip.Items("toolStripCut").Enabled = Me.CanCopy
        _toolStrip.Items("toolStripCopy").Enabled = Me.CanCopy
        _toolStrip.Items("toolStripPaste").Enabled = Me.CanPaste
        _toolStrip.Items("toolStripDelete").Enabled = Me.CanCopy
        _toolStrip.Items("toolStripUndo").Enabled = Me.CanUndo
        _toolStrip.Items("toolStripRedo").Enabled = Me.CanRedo
        _toolStrip.Items("toolStripColumns").Enabled = True
    End Sub

    Private Sub CheckListMenuItem()
        ' Uncheck all list items
        For Each obj In mnuFormat_List.DropDownItems
            Dim item = TryCast(obj, ToolStripMenuItem)
            If item Is Nothing Then
                Continue For
            End If

            item.Checked = False
        Next

        Select Case _textControl.Selection.ListFormat.Type
            Case TXTextControl.ListType.Bulleted
                mnuFormat_List_Bullets.Checked = True
                Return

            Case TXTextControl.ListType.None
                Return
        End Select

        Select Case _textControl.Selection.ListFormat.NumberFormat
            Case TXTextControl.NumberFormat.ArabicNumbers
                mnuFormat_List_ArabicNumbers.Checked = True
                Exit Select

            Case TXTextControl.NumberFormat.CapitalLetters
                mnuFormat_List_CapitalLetters.Checked = True
                Exit Select

            Case TXTextControl.NumberFormat.Letters
                mnuFormat_List_Letters.Checked = True
                Exit Select

            Case TXTextControl.NumberFormat.RomanNumbers
                mnuFormat_List_RomanNumbers.Checked = True
                Exit Select

            Case TXTextControl.NumberFormat.SmallRomanNumbers
                mnuFormat_List_SmallRomanNumbers.Checked = True
                Exit Select
        End Select
    End Sub

#End Region

    Public Sub SetUI(TypeUI As eTypeUI)

        If TypeUI = eTypeUI.All Then
            Me.buttonBar1.Visible = True
            Me._menuStrip.Visible = True
            Me.TopToolStripPanel.Visible = True
            Me.rulerBar1.Visible = True
            Me.rulerBar2.Visible = True
            Me.statusBar1.Visible = True
            Me.rulerBar1.Visible = True

        ElseIf TypeUI = eTypeUI.OnlyShowText Then
            Me.buttonBar1.Visible = False
            Me._menuStrip.Visible = False
            Me.TopToolStripPanel.Visible = False
            Me.rulerBar1.Visible = False
            Me.rulerBar2.Visible = False
            Me.statusBar1.Visible = False
            Me.rulerBar1.Visible = False

        ElseIf TypeUI = eTypeUI.Small Then
            Me._menuStrip.Visible = False
            Me.buttonBar1.Visible = False

        ElseIf TypeUI = eTypeUI.extremSmall Then
            Me._menuStrip.Visible = False
            Me.buttonBar1.Visible = False
            Me.rulerBar1.Visible = False
            Me.rulerBar2.Visible = False
            Me.statusBar1.Visible = False
            Me.rulerBar1.Visible = False

        End If

    End Sub

    Private Sub _textControl_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _textControl.KeyPress
        If Me.lockEingbe Then
            e.KeyChar = ""
        Else

        End If
    End Sub

End Class

