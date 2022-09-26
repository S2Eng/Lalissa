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

    Public Function showText(ByVal txt As String, ByVal typ As TXTextControl.StreamType,
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
End Class


