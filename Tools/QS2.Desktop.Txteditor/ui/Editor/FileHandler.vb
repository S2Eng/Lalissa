Imports System
Imports System.Collections.Specialized
Imports System.IO
Imports System.Windows.Forms



Public Class FileHandler

    Const DefaultExportTypes As TXTextControl.StreamType = TXTextControl.StreamType.AdobePDF Or TXTextControl.StreamType.CascadingStylesheet
    Const DefaultSaveTypes As TXTextControl.StreamType = TXTextControl.StreamType.All And Not DefaultExportTypes And Not TXTextControl.StreamType.XMLFormat
    Const DefaultInsertTypes As TXTextControl.StreamType = TXTextControl.StreamType.All And Not DefaultExportTypes And Not TXTextControl.StreamType.XMLFormat
    Const XMLModeSaveTypes As TXTextControl.StreamType = TXTextControl.StreamType.XMLFormat
    Const XMLModeExportTypes As TXTextControl.StreamType = TXTextControl.StreamType.All And Not XMLModeSaveTypes
    Const XMLModeInsertTypes As TXTextControl.StreamType = TXTextControl.StreamType.PlainAnsiText Or TXTextControl.StreamType.PlainText
    Private m_DocumentFileName As String = ""
    Private m_DocumentStreamType As TXTextControl.StreamType
    Private m_TextControl As TXTextControl.TextControl
    Private m_DocumentDirty As Boolean
    Private m_CSSFileName As String = ""
    Private m_CSSSaveMode As TXTextControl.CssSaveMode
    Private m_PDFMasterPassword As String = ""
    Private m_PDFUserPassword As String = ""
    Private m_PDFDocumentAccessPermissions As TXTextControl.DocumentAccessPermissions = TXTextControl.DocumentAccessPermissions.AllowAll
    Private m_mainForm As System.Windows.Forms.UserControl
    Private m_ClientMenu As ToolStripMenuItem
    Private FileList As StringCollection
    Private maxFiles As Integer

    Private m_PDFImportSettings As TXTextControl.PDFImportSettings
    Const DefaultLoadTypes As TXTextControl.StreamType = TXTextControl.StreamType.All And Not TXTextControl.StreamType.XMLFormat And Not TXTextControl.StreamType.CascadingStylesheet
    Private _documentStreamType As TXTextControl.StreamType





    Public rootDir As String = ""


    Public WriteOnly Property TextControl() As TXTextControl.TextControl
        Set(ByVal value As TXTextControl.TextControl)
            m_TextControl = value
        End Set
    End Property

    Public WriteOnly Property RecentFilesMenuItem() As ToolStripMenuItem
        Set(ByVal value As ToolStripMenuItem)
            m_ClientMenu = value
        End Set
    End Property

    Public WriteOnly Property mainForm() As System.Windows.Forms.UserControl
        Set(ByVal value As System.Windows.Forms.UserControl)
            m_mainForm = value
        End Set
    End Property

    Public Property DocumentFileName() As String
        Get
            Return m_DocumentFileName
        End Get
        Set(ByVal value As String)
            m_DocumentFileName = value
        End Set
    End Property

    Public ReadOnly Property InXMLMode() As Boolean
        Get
            Return (m_DocumentStreamType = TXTextControl.StreamType.XMLFormat)
        End Get
    End Property

    Public Property DocumentDirty() As Boolean
        Get
            Return m_DocumentDirty
        End Get
        Set(ByVal value As Boolean)
            m_DocumentDirty = value
        End Set
    End Property

    Public Property CSSFileName() As String
        Get
            Return m_CSSFileName
        End Get
        Set(ByVal value As String)
            m_CSSFileName = value
        End Set
    End Property

    Public Property CSSSaveMode() As TXTextControl.CssSaveMode
        Get
            Return m_CSSSaveMode
        End Get
        Set(ByVal value As TXTextControl.CssSaveMode)
            m_CSSSaveMode = value
        End Set
    End Property

    Public Property PDFMasterPassword() As String
        Get
            Return m_PDFMasterPassword
        End Get
        Set(ByVal value As String)
            m_PDFMasterPassword = value
        End Set
    End Property

    Public Property PDFUserPassword() As String
        Get
            Return m_PDFUserPassword
        End Get
        Set(ByVal value As String)
            m_PDFUserPassword = value
        End Set
    End Property

    Public Property PDFDocumentAccessPermissions() As TXTextControl.DocumentAccessPermissions
        Get
            Return m_PDFDocumentAccessPermissions
        End Get
        Set(ByVal value As TXTextControl.DocumentAccessPermissions)
            m_PDFDocumentAccessPermissions = value
        End Set
    End Property

    Public Sub New(ByVal mainForm As System.Windows.Forms.UserControl)
        m_mainForm = mainForm
        FileList = My.Settings.MRUFiles
        maxFiles = My.Settings.MRUMaxFiles
    End Sub

    Public Function FileOpen() As Boolean
        AddHandler System.AppDomain.CurrentDomain.UnhandledException, AddressOf MyUnhandledExceptionHandler

        Dim Succeeded As Boolean = False
        Dim LoadSettings As TXTextControl.LoadSettings = New TXTextControl.LoadSettings
        Try
            'LoadSettings.DocumentBasePath = Me.rootDir
            If m_DocumentFileName = "" Then
                m_TextControl.Load(TXTextControl.StreamType.All, LoadSettings)
            Else
                If m_DocumentFileName.ToLower.EndsWith(".rtf") Then
                    m_TextControl.Load(m_DocumentFileName, TXTextControl.StreamType.RichTextFormat, LoadSettings)
                Else
                    If m_DocumentFileName.ToLower.EndsWith(".doc") Then
                        m_TextControl.Load(m_DocumentFileName, TXTextControl.StreamType.MSWord, LoadSettings)
                    Else
                        If m_DocumentFileName.ToLower.EndsWith(".txt") Then
                            m_TextControl.Load(m_DocumentFileName, TXTextControl.StreamType.PlainText, LoadSettings)
                        Else
                            If m_DocumentFileName.ToLower.EndsWith(".pdf") Then
                                m_TextControl.Load(m_DocumentFileName, TXTextControl.StreamType.AdobePDF, LoadSettings)
                            Else
                                If m_DocumentFileName.ToLower.EndsWith(".htm") OrElse m_DocumentFileName.EndsWith(".html") Then
                                    m_TextControl.Load(m_DocumentFileName, TXTextControl.StreamType.HTMLFormat, LoadSettings)
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            If Not (LoadSettings.LoadedFile = "") Then
                m_DocumentFileName = LoadSettings.LoadedFile
                m_DocumentStreamType = LoadSettings.LoadedStreamType
                'm_TextControl.PageMargins = LoadSettings.PageMargins
                'm_TextControl.PageSize = LoadSettings.PageSize
                m_CSSFileName = LoadSettings.CssFileName
                m_CSSSaveMode = TXTextControl.CssSaveMode.None
                m_DocumentDirty = False
                AddRecentFile(m_DocumentFileName)
                Succeeded = True
            End If

        Catch ex As System.IO.IOException
            If ex.ToString().Contains("SECURITY_ATTRIBUTES") Then
                MsgBox("Datei kann nicht geöffnet werden, da Sie von einem anderen Prozess geöffnet ist!", MsgBoxStyle.OkOnly, "QS2")
            Else
                Throw New Exception("FileHandler.FileOpen: Error when loading document " + vbNewLine + vbNewLine + ex.ToString())
            End If
        Catch ex As Exception
            Throw New Exception("FileHandler.FileOpen: Error when loading document " + vbNewLine + vbNewLine + ex.ToString())
            Succeeded = False
        End Try
        Return Succeeded
    End Function
    Sub MyUnhandledExceptionHandler(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        MsgBox("frmMainTest.appentTxt_Click" + e.ToString())
    End Sub
    Public Property PDFImportSettings() As TXTextControl.PDFImportSettings
        Get
            Return m_PDFImportSettings
        End Get
        Set(ByVal value As TXTextControl.PDFImportSettings)
            m_PDFImportSettings = value
        End Set
    End Property

    Public Function FileOpen2() As Boolean
        Dim bSucceeded As Boolean = False

        Dim ls = New TXTextControl.LoadSettings() With { _
           .ApplicationFieldFormat = TXTextControl.ApplicationFieldFormat.MSWord, _
           .PDFImportSettings = PDFImportSettings _
        }


        Try
            'if there is no file name, open a dialog to load a document
            If DocumentFileName = "" Then
                m_TextControl.Load(DefaultLoadTypes, ls)
            Else
                Select Case Path.GetExtension(DocumentFileName).ToLower()
                    Case ".rtf"
                        m_TextControl.Load(DocumentFileName, TXTextControl.StreamType.RichTextFormat, ls)
                        Exit Select

                    Case ".doc"
                        m_TextControl.Load(DocumentFileName, TXTextControl.StreamType.MSWord, ls)
                        Exit Select

                    Case ".docx"
                        m_TextControl.Load(DocumentFileName, TXTextControl.StreamType.WordprocessingML, ls)
                        Exit Select

                    Case ".txt"
                        m_TextControl.Load(DocumentFileName, TXTextControl.StreamType.PlainText, ls)
                        Exit Select

                    Case ".htm", ".html"
                        m_TextControl.Load(DocumentFileName, TXTextControl.StreamType.HTMLFormat, ls)
                        Exit Select

                    Case ".pdf"
                        m_TextControl.Load(DocumentFileName, TXTextControl.StreamType.AdobePDF, ls)
                        Exit Select

                    Case ".tx"
                        m_TextControl.Load(DocumentFileName, TXTextControl.StreamType.InternalUnicodeFormat, ls)
                        Exit Select

                End Select
            End If

            If ls.LoadedFile <> "" Then
                DocumentFileName = ls.LoadedFile
                _documentStreamType = ls.LoadedStreamType
                DocumentDirty = False
                CSSFileName = ls.CssFileName
                CSSSaveMode = TXTextControl.CssSaveMode.None
                AddRecentFile(DocumentFileName)
                bSucceeded = True
            End If
        Catch x As Exception
            MessageBox.Show(x.Message, "Error loading document.", MessageBoxButtons.OK, MessageBoxIcon.[Error])

            bSucceeded = False
        End Try
        Return bSucceeded
    End Function
    Public Function FileOpen_temp() As Boolean
        Dim Succeeded As Boolean = False
        Dim LoadSettings As TXTextControl.LoadSettings = New TXTextControl.LoadSettings
        Try
            '    If m_DocumentFileName = "" Then
            '        m_TextControl.Load(TXTextControl.StreamType.All, LoadSettings)
            '    Else
            '        If m_DocumentFileName.ToLower.EndsWith(".rtf") Then
            '            m_TextControl.Load(m_DocumentFileName, TXTextControl.StreamType.RichTextFormat, LoadSettings)
            '        Else
            '            If m_DocumentFileName.ToLower.EndsWith(".doc") Then
            '                m_TextControl.Load(m_DocumentFileName, TXTextControl.StreamType.MSWord, LoadSettings)
            '            Else
            '                If m_DocumentFileName.ToLower.EndsWith(".txt") Then
            '                    m_TextControl.Load(m_DocumentFileName, TXTextControl.StreamType.PlainText, LoadSettings)
            '                Else
            '                    If m_DocumentFileName.ToLower.EndsWith(".pdf") Then
            '                        m_TextControl.Load(m_DocumentFileName, TXTextControl.StreamType.AdobePDF, LoadSettings)
            '                    Else
            '                        If m_DocumentFileName.ToLower.EndsWith(".htm") OrElse m_DocumentFileName.EndsWith(".html") Then
            '                            m_TextControl.Load(m_DocumentFileName, TXTextControl.StreamType.HTMLFormat, LoadSettings)
            '                        End If
            '                    End If
            '                End If
            '            End If
            '        End If
            '    End If
            'If Not (LoadSettings.LoadedFile = "") Then
            m_DocumentFileName = LoadSettings.LoadedFile
            m_DocumentStreamType = LoadSettings.LoadedStreamType
            'm_TextControl.PageMargins = LoadSettings.PageMargins
            'm_TextControl.PageSize = LoadSettings.PageSize
            m_CSSFileName = LoadSettings.CssFileName
            m_CSSSaveMode = TXTextControl.CssSaveMode.None
            m_DocumentDirty = False
            AddRecentFile(m_DocumentFileName)
            Succeeded = True

            'End If

        Catch ex As Exception
            Throw New Exception("FileHandler.FileOpen_temp: Error when loading document " + vbNewLine + vbNewLine + ex.ToString())
            Succeeded = False
        End Try
        Return Succeeded
    End Function

    Public Sub FileSave()
        Dim SaveSettings As TXTextControl.SaveSettings = New TXTextControl.SaveSettings
        'SaveSettings.PageMargins = m_TextControl.PageMargins
        'SaveSettings.PageSize = m_TextControl.PageSize
        SaveSettings.CssFileName = m_CSSFileName
        SaveSettings.CssSaveMode = m_CSSSaveMode

        If Not (DocumentFileName Is Nothing) AndAlso Not (DocumentFileName = "") Then
            m_TextControl.Save(DocumentFileName, m_DocumentStreamType, SaveSettings)
        Else
            If InXMLMode Then
                m_TextControl.Save(XMLModeSaveTypes, SaveSettings)
            Else
                m_TextControl.Save(DefaultSaveTypes, SaveSettings)
            End If
        End If
        If Not (SaveSettings.SavedFile = "") Then
            m_DocumentFileName = SaveSettings.SavedFile
            m_DocumentStreamType = SaveSettings.SavedStreamType
            AddRecentFile(m_DocumentFileName)
            m_DocumentDirty = False
        End If
    End Sub

    Public Sub FileSaveAs()
        Dim SaveSettings As TXTextControl.SaveSettings = New TXTextControl.SaveSettings
        'SaveSettings.PageMargins = m_TextControl.PageMargins
        'SaveSettings.PageSize = m_TextControl.PageSize
        SaveSettings.CssFileName = m_CSSFileName
        SaveSettings.CssSaveMode = m_CSSSaveMode
        If InXMLMode Then
            m_TextControl.Save(XMLModeSaveTypes, SaveSettings)
        Else
            m_TextControl.Save(DefaultSaveTypes, SaveSettings)
        End If
        If Not (SaveSettings.SavedFile = "") Then
            Dim SaveWarning As DialogResult = DialogResult.OK
            If Not (m_DocumentStreamType = SaveSettings.SavedStreamType) Then
                If SaveSettings.SavedStreamType = TXTextControl.StreamType.HTMLFormat Or SaveSettings.SavedStreamType = TXTextControl.StreamType.PlainText Or SaveSettings.SavedStreamType = TXTextControl.StreamType.PlainAnsiText Then
                    SaveWarning = MessageBox.Show("Some formatting features are possibly not supported by the used save format.\nThese features may be lost or degraded when you reload this document.\nClick OK to reload the document anyway.\nTo keep all formatting features, click Cancel, and then save the file in another file format.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                End If
                If SaveWarning = DialogResult.OK Then
                    m_TextControl.ResetContents()
                    m_TextControl.Load(SaveSettings.SavedFile, SaveSettings.SavedStreamType)
                    m_DocumentFileName = SaveSettings.SavedFile
                    m_DocumentStreamType = SaveSettings.SavedStreamType
                    AddRecentFile(m_DocumentFileName)
                    m_DocumentDirty = False
                End If
            End If
        End If
    End Sub

    Public Sub Export()
        Dim SaveSettings As TXTextControl.SaveSettings = New TXTextControl.SaveSettings
        SaveSettings.UserPassword = m_PDFUserPassword
        SaveSettings.MasterPassword = m_PDFMasterPassword
        SaveSettings.DocumentAccessPermissions = m_PDFDocumentAccessPermissions
        If InXMLMode Then
            m_TextControl.Save(XMLModeExportTypes, SaveSettings)
        Else
            m_TextControl.Save(DefaultExportTypes, SaveSettings)
        End If
    End Sub
    Public Sub ExportPDF(ByVal sName As String)
        Dim SaveSettings As TXTextControl.SaveSettings = New TXTextControl.SaveSettings
        SaveSettings.UserPassword = m_PDFUserPassword
        SaveSettings.MasterPassword = m_PDFMasterPassword
        SaveSettings.DocumentAccessPermissions = m_PDFDocumentAccessPermissions

        Dim typ As TXTextControl.StreamType
        typ = TXTextControl.StreamType.AdobePDF

        If Not sName = "" Then
            Me.DocumentFileName = sName
            m_TextControl.Save(DocumentFileName, typ, SaveSettings)
        Else
            Dim res As System.Windows.Forms.DialogResult = m_TextControl.Save(typ, SaveSettings)
        End If

    End Sub
    Public Sub Insert()
        Dim LoadSettings As TXTextControl.LoadSettings = New TXTextControl.LoadSettings
        If InXMLMode Then
            m_TextControl.Append(XMLModeInsertTypes, LoadSettings, TXTextControl.AppendSettings.StartWithNewSection)
        Else
            m_TextControl.Append(DefaultInsertTypes, LoadSettings, TXTextControl.AppendSettings.StartWithNewSection)
        End If
        If Not (LoadSettings Is Nothing) AndAlso Not (LoadSettings.LoadedFile = "") Then
            m_DocumentDirty = True
        End If
    End Sub


#Region "  Recent File Handling "

    Public Sub UpdateMenu()
        Try
            Dim i As Integer
            For i = m_ClientMenu.DropDownItems.Count - 1 To 0 Step -1
                ' Clear current menu
                m_ClientMenu.DropDownItems.RemoveAt(i)
            Next
            ' Check all recent files if they still exist
            CheckFiles()
            For i = 0 To FileList.Count - 1
                ' Setup Recent files menu
                Dim mnuItm As ToolStripItem = New ToolStripMenuItem()
                mnuItm.Text = GetFileName(FileList(i))
                mnuItm.Tag = FileList(i)
                AddHandler mnuItm.Click, AddressOf mnuItm_Click

                m_ClientMenu.DropDownItems.Add(mnuItm)
            Next
            ' Insert Clear menu entry
            If m_ClientMenu.DropDownItems.Count >= 1 Then
                m_ClientMenu.Enabled = True
                m_ClientMenu.DropDownItems.Add("-")
                Dim clearListItm As New ToolStripMenuItem("Clear list")
                m_ClientMenu.DropDownItems.Add(clearListItm)
                AddHandler clearListItm.Click, AddressOf clearListItm_Click
            Else
                m_ClientMenu.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub clearListItm_Click(ByVal sender As Object, ByVal e As EventArgs)
        FileList.Clear()
        UpdateMenu()
    End Sub

    Private Sub mnuItm_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim Result As System.Windows.Forms.DialogResult

        If m_DocumentDirty Then
            Dim sText As String = generic.getRes("SaveChangesToX")
            sText = String.Format(sText, m_DocumentFileName)
            Result = generic.showMessageBox(sText, Windows.Forms.MessageBoxButtons.YesNo, "")
            If Result = DialogResult.Yes Then
                FileSave()
            End If
        End If
        Dim itm As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        Dim pos As Integer = itm.GetCurrentParent().Items.IndexOf(itm)
        If pos >= 0 AndAlso pos < FileList.Count Then
            m_DocumentFileName = itm.Tag.ToString()
            FileOpen()
        End If
    End Sub

    ''' <summary>
    ''' Retrieves the file title from the file path
    ''' </summary>
    Private Function GetFileName(ByVal path As String) As String
        Dim p1 As Integer = path.LastIndexOf("\")
        Dim p2 As Integer = path.LastIndexOf("/")
        p1 = Math.Max(p1, p2)
        Dim p3 As Integer = path.LastIndexOf(".")
        Dim rtn As String
        If p3 > p1 Then
            rtn = path.Substring(p1 + 1, p3 - p1 - 1)
        Else
            rtn = path.Substring(p1 + 1)
        End If
        Return rtn
    End Function

    ''' <summary>
    ''' Adds a new file path to the top of the list
    ''' </summary>
    Private Sub AddRecentFile(ByVal filePath As String)
        FileList.Insert(0, filePath)
        For last As Integer = FileList.Count - 1 To 1 Step -1

            For frst As Integer = 0 To last - 1
                If FileList(last) = FileList(frst) Then
                    FileList.RemoveAt(last)
                    Exit For
                End If
            Next
        Next
        TrimList()
        Try
            UpdateMenu()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TrimList()
        For bynd As Integer = FileList.Count - 1 To maxFiles Step -1
            FileList.RemoveAt(bynd)
        Next
    End Sub
    Public Sub InitRecentFilesxy()
        FileList = My.Settings.MRUFiles
        maxFiles = My.Settings.MRUMaxFiles
        UpdateMenu()
    End Sub
    Private Sub CheckFiles()
        Try
            For i As Integer = 0 To FileList.Count - 1
                If Not File.Exists(FileList(i)) Then
                    FileList.Remove(FileList(i))
                End If
            Next

        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
    End Sub

#End Region


End Class
