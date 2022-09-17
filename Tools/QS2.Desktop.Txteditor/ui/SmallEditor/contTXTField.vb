Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Globalization
Imports System.Drawing.Printing




Public Class contTXTField
    Inherits System.Windows.Forms.UserControl

    Private _fileHandler As FileHandler2
    Private _fileDragDrop As FileDragDropHandler
    Private _bLoadFileOnCreate As Boolean = False
    Private _customColors As New List(Of Integer)()
    Private _objSel As TXTextControl.FrameBase
    ' Currently selected object
    Private Const ExpressEditionInfoMessage As String = "Not available in Express Edition."

    Public IsInitialized As Boolean = False
    Public _SpellChecking As Boolean = False
    Public _ViewMode As TXTextControl.ViewMode = Nothing

    Public doEditor1 As New doEditor()
    Public _bReadOnly As Boolean = False

    Public delonValueChanged As onValueChanged
    Public Delegate Sub onValueChanged()

    Public delOnHyperlinkClicked As onHyperlinkClicked
    Public Delegate Function onHyperlinkClicked(ByRef ID As String) As String

    Public delOnKeyUp As onKeyUp
    Public Delegate Sub onKeyUp(sender As Object, e As KeyEventArgs)
    Public doCopySelectAll As Boolean = False










    Public Sub New()
        Dim currentCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        InitializeComponent()
        System.Threading.Thread.CurrentThread.CurrentCulture = currentCultureInfo

        If Not DesignMode Then
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("de-DE")
            TXTControlField.RulerBar = rulerBar2
            TXTControlField.ButtonBar = buttonBarFormat
            TXTControlField.StatusBar = StatusBar2
            TXTControlField.VerticalRulerBar = rulerBar1

            _fileHandler = New FileHandler2(Me, Me.TXTControlField)
            _fileDragDrop = New FileDragDropHandler()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ' Set Text Control language to english to enable spell checking using the
            ' default dictionary included in TXSpell

            Me.TXTControlField.SpellChecker = Spelling.getSpellChecker()

            Dim cultEN = CultureInfo.GetCultureInfo("de-DE")    '("en-US")
            Me.TXTControlField.SelectAll()
            Me.TXTControlField.Selection.Culture = cultEN

            'Me.txSpellChecker1.Language = "de-DE"

            'InputLanguageManager.SetInputLanguage(this.TestSpellChecker, CultureInfo.CreateSpecificCulture("de-DE"));

            If _bLoadFileOnCreate Then
                If Not _fileHandler.FileOpen() Then
                    Return
                End If
                If _fileHandler.DocumentFileName <> "" Then
                End If
            End If

            _fileHandler.DocumentDirty = False
            'Me.TXTControlField.Load("H:\SampleText.rtf", TXTextControl.StreamType.RichTextFormat)

        Catch ex As Exception
            Throw New Exception("contTXTField.Load: " + ex.ToString())
        End Try
    End Sub


    Public Sub initControl(ViewMode As TXTextControl.ViewMode, BarButton As Boolean, BarFormat As Boolean,
                             RulerBarOnOff As Boolean, StatusbarOnOff As Boolean, SpellChecking As Boolean,
                             SpellCheckingButton As Boolean)
        Try
            If Not Me.IsInitialized Then
                Me.rulerBar1.Visible = RulerBarOnOff
                Me.rulerBar2.Visible = RulerBarOnOff
                Me.buttonBarFormat.Visible = BarFormat
                Me.toolStripButtons.Visible = BarButton
                Me.TXTControlField.ViewMode = ViewMode
                Me._ViewMode = ViewMode
                Me.btnSpellChecking.Visible = SpellCheckingButton

                Me._SpellChecking = SpellChecking
                Me.TXTControlField.IsSpellCheckingEnabled = Me._SpellChecking
                Me.PanelBottom.Visible = SpellCheckingButton

                Me.IsInitialized = True
            End If

        Catch ex As Exception
            Throw New Exception("contTXTField.initControl: " + ex.ToString())
        End Try
    End Sub



    Public Sub FileNew()
        _fileHandler.DocumentFileName = ""
        Me.TXTControlField.ResetContents()
        Me.Text = Me.ProductName.ToString() & " - " & Convert.ToString(_fileHandler.DocumentFileName)
        _fileHandler.DocumentDirty = False
    End Sub
    Public Sub FileOpen()
        _fileHandler.DocumentFileName = ""
        _fileHandler.FileOpen()
    End Sub
    Public Sub FileSave()
        Try
            _fileHandler.FileSave()
        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub FileSaveAs()
        Try
            _fileHandler.FileSave()
        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub Print()
        Dim pd As New PrintDocument()
        If Not pd.PrinterSettings Is Nothing Then
            If (Not pd.PrinterSettings.PrinterName Is Nothing) AndAlso pd.PrinterSettings.PrinterName.Trim() <> "" Then
                Dim Standarddrucker As String = pd.PrinterSettings.PrinterName
                If (Not Standarddrucker Is Nothing) AndAlso Standarddrucker.Trim() <> "" Then
                    Me.TXTControlField.Print(ProductName & " - " & Convert.ToString(_fileHandler.DocumentFileName))
                Else
                    MsgBox("No standard-printer is installed in windows!")
                End If
            Else
                MsgBox("No standard-printer is installed in windows!")
            End If
        Else
            MsgBox("No standard-printer is installed in windows!")
        End If

    End Sub

    Public Function GetNumberOfPages() As Integer
        Try
            Dim pages As Integer = 0

            Try
                For i As Integer = 1 To Me.TXTControlField.Pages
                    If Me.TXTControlField.GetPages()(i).Section = Me.TXTControlField.Sections.GetItem().Number Then
                        pages += 1
                    End If
                Next
            Catch
            End Try

            Return pages

        Catch ex As Exception
            Throw New Exception("contTXTField.GetNumberOfPages: " + ex.ToString())
        End Try
    End Function

    Public Function getText(typ As TXTextControl.StringStreamType) As String
        Try
            Return Me.doEditor1.getText(typ, Me.TXTControlField)

        Catch ex As Exception
            Throw New Exception("contTXTField.getPlainText: " + ex.ToString())
        End Try
    End Function
    Public Function showText(ByVal txt As String, ByVal typ As TXTextControl.StreamType) As Boolean
        Try
            Return Me.doEditor1.showText(txt, typ, True, Me._ViewMode, Me.TXTControlField, Nothing, Nothing)

        Catch ex As Exception
            Throw New Exception("contTXTField.showText: " + ex.ToString())
        End Try
    End Function
    Public Function showText(ByVal txt As String, ByVal typ As TXTextControl.StreamType, _
                                Optional ByRef bytes() As Byte = Nothing, Optional ByRef bytesPdf() As Byte = Nothing) As Boolean
        Try
            Return Me.doEditor1.showText(txt, typ, True, Me._ViewMode, Me.TXTControlField, bytes, bytesPdf)

        Catch ex As Exception
            Throw New Exception("contTXTField.showText: " + ex.ToString())
        End Try
    End Function
    Public Property bReadOnly() As Boolean
        Get
            Return Me._bReadOnly
        End Get
        Set(value As Boolean)
            Me._bReadOnly = value

            If Me._bReadOnly Then
                Me.TXTControlField.EditMode = TXTextControl.EditMode.ReadAndSelect
            Else
                Me.TXTControlField.EditMode = TXTextControl.EditMode.Edit
            End If
            Me.buttonBarFormat.Visible = Not Me._bReadOnly
            Me.toolStripButtonNew.Visible = Not Me._bReadOnly
            Me.toolStripButtonOpen.Visible = Not Me._bReadOnly
            Me.toolStripButtonSave.Visible = Me._bReadOnly
            Me.ToolStripButtonPrint.Visible = True
            Me.toolStripButtonCut.Visible = Not Me._bReadOnly
            Me.toolStripButtonCopy.Visible = True
            Me.toolStripButtonPaste.Visible = Not Me._bReadOnly
            Me.toolStripButtonUndo.Visible = Not Me._bReadOnly
            Me.toolStripButtonRedo.Visible = Not Me._bReadOnly
            Me.toolStripButtoSearch.Visible = True
            'Me.TXTControlField.Enabled = Not Me._bReadOnly
        End Set
    End Property
    Public Sub doSmallVersion()
        Try
            Me.toolStripButtonNew.Visible = False
            Me.toolStripButtonOpen.Visible = False
            Me.toolStripButtonSave.Visible = True
            Me.toolStripButtonCut.Visible = False
            Me.toolStripButtonCopy.Visible = True
            Me.toolStripButtonPaste.Visible = False
            Me.toolStripButtonUndo.Visible = False
            Me.toolStripButtonRedo.Visible = False
            Me.toolStripButtoSearch.Visible = True
            Me.toolStripButtonLanguages.Visible = True
            Me.doCopySelectAll = True
            Me.buttonBarFormat.Visible = False

        Catch ex As Exception
            Throw New Exception("contTXTField.doSmallVersion: " + ex.ToString())
        End Try
    End Sub
    Private Sub toolStripButtonNew_Click_1(sender As Object, e As EventArgs) Handles toolStripButtonNew.Click
        Try
            Me.FileNew()
        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub toolStripButtonOpen_Click_1(sender As Object, e As EventArgs) Handles toolStripButtonOpen.Click
        Try
            Me.FileOpen()
        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub toolStripButtonSave_Click_1(sender As Object, e As EventArgs) Handles toolStripButtonSave.Click
        Try
            Me.FileSaveAs()
        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub ToolStripButtonPrint_Click_1(sender As Object, e As EventArgs) Handles ToolStripButtonPrint.Click
        Try
            Me.Print()
        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub toolStripButtonCut_Click_1(sender As Object, e As EventArgs) Handles toolStripButtonCut.Click
        Try
            Me.TXTControlField.Cut()
        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub toolStripButtonCopy_Click_1(sender As Object, e As EventArgs) Handles toolStripButtonCopy.Click
        Try
            If Me.doCopySelectAll Then
                System.Windows.Forms.Clipboard.SetDataObject(Me.TXTControlField.Text.Trim())
            Else
                Me.TXTControlField.Copy()
            End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub toolStripButtonPaste_Click_1(sender As Object, e As EventArgs) Handles toolStripButtonPaste.Click
        Try
            Me.TXTControlField.Paste()
        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub toolStripButtonUndo_Click_1(sender As Object, e As EventArgs) Handles toolStripButtonUndo.Click
        Try
            Me.TXTControlField.Undo()
        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub toolStripButtonRedo_Click_1(sender As Object, e As EventArgs) Handles toolStripButtonRedo.Click
        Try
            Me.TXTControlField.Redo()
        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub toolStripButtoSearch_Click_1(sender As Object, e As EventArgs) Handles toolStripButtoSearch.Click
        Try
            Me.TXTControlField.Find()
        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub TXTControlField_TextContextMenuOpening_1(sender As Object, e As TXTextControl.TextContextMenuEventArgs) Handles TXTControlField.TextContextMenuOpening
        Try
            Dim cContextMenü1 As New cContextMenü()
            cContextMenü1.TXTControlField_TextContextMenuOpening(sender, e, Me.contextMenuStripSpell, Spelling.getSpellChecker(), Me._SpellChecking, Me.DesignMode, Me.TXTControlField)

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub TXTControlField_TextChanged(sender As Object, e As EventArgs)
        'Try
        '    If textChangedEventEnabled Then
        '        txSpellChecker1.Check(Me.TXTControlField.Text)
        '    End If

        'Catch ex As Exception
        '    MsgBox("contTXTField.TXTControlField_TextChanged: " + ex.ToString(), "Error")
        'End Try
    End Sub

    Private Sub TXTControlField_MouseDown(sender As Object, e As MouseEventArgs)
        'currentIncorrectWord = Nothing
        'If e.Button = Windows.Forms.MouseButtons.Right Then
        '    Dim txtTemp As String = Me.TXTControlField.Text
        '    currentCursorPosition = txtTemp.GetCharIndexFromPosition(New Point(e.X, e.Y))
        '    If currentCursorPosition > 0 Then
        '        For Each incorrectWord As TXTextControl.Proofing.IncorrectWord In txSpellChecker1.IncorrectWords
        '            If incorrectWord.Start <= currentCursorPosition Then
        '                If currentCursorPosition <= incorrectWord.Start + incorrectWord.Length Then
        '                    currentIncorrectWord = incorrectWord
        '                    Exit For
        '                End If
        '            Else
        '                Exit For
        '            End If
        '        Next
        '    End If
        'End If
    End Sub

    Private Sub TXTControlField_Changed(sender As Object, e As EventArgs) Handles TXTControlField.Changed
        Try
            If TXTControlField.Focused Then
                If Me.delonValueChanged <> Nothing Then
                    Me.delonValueChanged.Invoke()
                End If
            End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub TXTControlField_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTControlField.KeyDown
        Try
            If e.KeyCode = Keys.F7 Then
                If Me._SpellChecking Then
                    Spelling.getSpellChecker().SpellCheckDialog.Show(Me.TXTControlField)
                End If
            End If
            'If Me._bReadOnly Then
            '    e.SuppressKeyPress = True
            'End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub TXTControlField_HypertextLinkClicked(sender As Object, e As TXTextControl.HypertextLinkEventArgs) Handles TXTControlField.HypertextLinkClicked
        Try
            If e.HypertextLink.Target.Trim().ToLower().StartsWith(("var_").Trim().ToLower()) Then
                If Me.delOnHyperlinkClicked <> Nothing Then
                    Dim retStr As String = Me.delOnHyperlinkClicked.Invoke(e.HypertextLink.Target.Trim())

                End If
            End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub TXTControlField_KeyUp(sender As Object, e As KeyEventArgs) Handles TXTControlField.KeyUp
        If Me.delOnKeyUp <> Nothing Then
            Me.delOnKeyUp.Invoke(sender, e)
        End If
    End Sub

    Private Sub btnSpellChecking_Click(sender As Object, e As EventArgs) Handles btnSpellChecking.Click
        Try
            Spelling.getSpellChecker().SpellCheckDialog.Show(Me.TXTControlField)

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub toolStripButtonLanguages_Click(sender As Object, e As EventArgs) Handles toolStripButtonLanguages.Click
        Try
            Me.TXTControlField.LanguageDialog()

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class


