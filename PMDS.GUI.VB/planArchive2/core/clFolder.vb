Imports System.IO
Imports System.Windows.Forms
Imports System.Data.OleDb
Imports Microsoft.Win32
Imports PMDS.GUI.ELGA

Public Class clFolder

    Public gen As New GeneralArchiv()

    Public EmptyGuid As New System.Guid
    Public Version As String = "2.60.002"

    Public Enum CSIDLS
        CSIDL_DESKTOP = &H0 ' Desktop
        CSIDL_INTERNET = &H1 ' Internet
        CSIDL_PROGRAMS = &H2 ' Startmenü: Programme
        CSIDL_CONTROLS = &H3 ' Systemsteuerung
        CSIDL_PRINTERS = &H4 ' Drucker
        CSIDL_PERSONAL = &H5 ' Eigene Dateien
        CSIDL_FAVORITES = &H6 ' IE: Favoriten
        CSIDL_STARTUP = &H7 ' Autostart
        CSIDL_RECENT = &H8 ' Zuletzt benutzte Dokumente
        CSIDL_SENDTO = &H9 ' Senden an / SendTo
        CSIDL_BITBUCKET = &HA ' Papierkorb
        CSIDL_STARTMENU = &HB ' Startmenü
        CSIDL_MYMUSIC = &HDS ' Eigene Musik
        CSIDL_MYVIDEO = &HES ' Eigene Videos
        CSIDL_DESKTOPDIRECTORY = &H10 ' Desktopverzeichnis
        CSIDL_DRIVES = &H11 ' Mein Computer
        CSIDL_NETWORK = &H12 ' Netzwerk
        CSIDL_NETHOOD = &H13 ' Netzwerkumgebung
        CSIDL_FONTS = &H14 ' Windows\Fonts
        CSIDL_TEMPLATES = &H15 ' Vorlagen
        CSIDL_COMMON_STARTMENU = &H16 ' "All Users" - Startmenü
        CSIDL_COMMON_PROGRAMS = &H17 ' "All Users" - Programme
        CSIDL_COMMON_STARTUP = &H18 ' "All Users" - Autostart
        CSIDL_COMMON_DESKTOPDIRECTORY = &H19 ' "All Users" - Desktop
        CSIDL_APPDATA = &H1A ' Anwendungsdaten
        CSIDL_PRINTHOOD = &H1B ' Druckumgebung
        CSIDL_LOCAL_APPDATA = &H1C ' Lokale Einstellungen\Anwendungsdaten
        CSIDL_COMMON_FAVORITES = &H1F ' "All Users" - Favoriten
        CSIDL_INTERNET_CACHE = &H20 ' IE: Temporäre Internetdateien
        CSIDL_COOKIES = &H21 ' IE: Cookies
        CSIDL_HISTORY = &H22 ' IE: Verlauf
        CSIDL_COMMON_APPDATA = &H23 ' "All Users" - Anwendungsdaten
        CSIDL_WINDOWS = &H24 ' Windows
        CSIDL_SYSTEM = &H25 ' Windows\System32
        CSIDL_PROGRAM_FILES = &H26 ' C:\Programme
        CSIDL_MYPICTURES = &H27 ' Eigene Bilder
        CSIDL_PROFILE = &H28 ' Anwenderprofil (Benutzername)
        CSIDL_SYSTEMX86 = &H29 ' Windows\System32
        CSIDL_PROGRAM_FILES_COMMON = &H2B ' Gemeinsame Dateien
        CSIDL_COMMON_TEMPLATES = &H2D ' "All Users" - Vorlagen
        CSIDL_COMMON_DOCUMENTS = &H2E ' "All Users" - Dokumente
        CSIDL_COMMON_ADMINTOOLS = &H2F ' "All Users" - Verwaltung
        CSIDL_ADMINTOOLS = &H30 ' Startmenü\Programme\Verwaltung
    End Enum
    Private Const CSIDL_FLAG_DONT_VERIFY As Integer = &H4000
    Private Const CSIDL_FLAG_CREATE As Integer = &H8000
    Private Const CSIDL_FLAG_MASK As Integer = &HFF00
    Private Const SHGFP_TYPE_CURRENT As Integer = 0
    Private Const SHGFP_TYPE_DEFAULT As Integer = 1
    Private Const MAX_PATH As Integer = 260
    Private Const S_OK As Integer = 0
    Private Const S_FALSE As Integer = 1
    Private Const E_INVALIDARG As Integer = &H80070057
    Private Declare Function SHGetFolderPath Lib "shfolder" Alias "SHGetFolderPathA" (ByVal hWndOwner As Integer, ByVal Folder As Integer, ByVal hToken As Integer, ByVal Flags As Integer, ByVal strPath As String) As Integer

    Public Class GetSubkey
        Public Result As String = ""
        Public KeyExists As Boolean = False
    End Class








    Public Function GetSpecialFolder(ByVal CSIDL As CSIDLS, Optional ByVal Create As Boolean = False, Optional ByVal Verify As Boolean = False) As String
        Try
            Dim sPath As String
            Dim RetVal As Integer
            Dim lFlags As Integer

            sPath = Space(MAX_PATH)
            lFlags = CSIDL
            If Create Then
                lFlags = lFlags Or CSIDL_FLAG_CREATE
            End If
            If Not Verify Then
                lFlags = lFlags Or CSIDL_FLAG_DONT_VERIFY
            End If

            RetVal = SHGetFolderPath(0, lFlags, 0, SHGFP_TYPE_CURRENT, sPath)

            Select Case RetVal
                Case S_OK
                    GetSpecialFolder = Left(sPath, InStr(1, sPath, vbNullChar) - 1)
                Case S_FALSE
                Case E_INVALIDARG
            End Select

        Catch ex As Exception
            Throw New Exception("clFolder.GetSpecialFolder: " + ex.ToString())
        End Try
    End Function
    Public Function GetSpecialFoldernet(ByVal typ As System.Environment.SpecialFolder) As String
        Try
            Return System.Environment.GetFolderPath(typ)

        Catch ex As Exception
            Throw New Exception("clFolder.GetSpecialFoldernet: " + ex.ToString())
        End Try
    End Function
    Public Function openFile(ByVal file As String, ByRef rDoku As dbArchiv.archDokuRow, ByVal openIntern As Boolean,
                           ByVal withMsgBox As Boolean, ByVal printFile As Boolean) As Boolean
        Try
            If System.IO.File.Exists(file) Then

                Dim dateiTyp As String = System.IO.Path.GetExtension(file)

                If openIntern Then
                    Return Me.openFileIntern(file, dateiTyp, rDoku, withMsgBox)
                Else
                    If Not printFile Then
                        System.Diagnostics.Process.Start(file)
                        Return True
                    Else
                        Me.printFile(file)
                        Return True
                    End If
                End If

            Else
                If withMsgBox Then
                    doUI.doMessageBox2("FileDoesNotExist", "OpenFile", "!")
                End If
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("clFolder.openFile: " + ex.ToString())
        End Try
    End Function
    Public Function openFileIntern(ByVal file As String, ByVal dateiTyp As String,
                           ByRef rDoku As dbArchiv.archDokuRow,
                           ByVal withMsgBox As Boolean) As Boolean
        Try
            If Not rDoku Is Nothing Then
                If rDoku.IsbinInternNull() Then
                    If withMsgBox Then
                        doUI.doMessageBox2("DocumentIsNoInternDocument", "OpenInternDocument", "!")
                    End If
                Else
                    Dim gen As New General()
                    Dim frmTxtEditor1 As QS2.Desktop.Txteditor.frmTxtEditor = gen.openTxtEditor(False)
                    Dim dOnSaveDocu As New QS2.Desktop.Txteditor.contTxtEditor.onSaveDocu(AddressOf Me.saveDocu)
                    frmTxtEditor1.ContTxtEditor1.delOnSaveDocu = dOnSaveDocu

                    frmTxtEditor1.ContTxtEditor1.IDDocu = rDoku.ID
                    frmTxtEditor1.ContTxtEditor1.TypDocu = rDoku.DateinameTyp
                    frmTxtEditor1.ContTxtEditor1.showUISaveDocuToDB(True)

                    frmTxtEditor1.Show()
                    'frm.openDokument(file, TXTextControl.StreamType.InternalFormat, False)
                    Dim doEditor1 As New QS2.Desktop.Txteditor.doEditor()
                    doEditor1.showText("", TXTextControl.StreamType.InternalFormat, True, TXTextControl.ViewMode.PageView, frmTxtEditor1.ContTxtEditor1.textControl1, rDoku.binIntern)
                End If
            Else
                Throw New Exception("clFolder.openFileIntern: rDoku Is Nothing!")
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("clFolder.openFileIntern: " + ex.ToString())
        End Try
    End Function
    Public Function saveDocu(ByRef IDDocu As System.Guid,
                                        ByRef binInt() As Byte, ByRef binExport() As Byte,
                                        ByRef typExport As String) As Boolean
        Try
            Dim compDokuSave As New compDoku()
            Dim dbArchivSave As New dbArchiv()
            compDokuSave.getDokuRow(IDDocu, dbArchivSave)
            Dim rDoku As dbArchiv.archDokuRow = dbArchivSave.archDoku.Rows(0)
            rDoku.binIntern = binInt
            rDoku.doku = binExport

            compDokuSave.daDoku.Update(dbArchivSave.archDoku)
            Return True

        Catch ex As Exception
            Throw New Exception("clFolder.saveDocu: " + ex.ToString())
        End Try
    End Function

    Public Function openFile(ByVal file As String,
                             ByVal printFile As Boolean) As Boolean
        Try
            If System.IO.File.Exists(file) Then

                Dim dateiTyp As String = System.IO.Path.GetExtension(file).ToLower()

                If Me.IsNull(dateiTyp) Then
                    Throw New Exception("openFile: No Type for open File '" + file + "'!")
                End If

                If Not printFile Then
                    If dateiTyp.Equals(".bef") Or dateiTyp.Equals(".lab") Then
                        Dim frmEdiFactViewer1 As New EDIFact.frmEdiFactViewer()
                        frmEdiFactViewer1.initControl(file, "", "")
                        frmEdiFactViewer1.Show()
                    ElseIf dateiTyp = ".xml" Then
                        Dim pr As New clsELGAPrint
                        Dim bData As Byte()
                        Dim br As BinaryReader = New BinaryReader(System.IO.File.OpenRead(file))
                        bData = br.ReadBytes(br.BaseStream.Length)
                        Using msXML As MemoryStream = New MemoryStream(bData, 0, bData.Length)
                            msXML.Write(bData, 0, bData.Length)
                            pr.ShowXMLInBrowser(msXML, "", True)
                        End Using
                    Else
                        System.Diagnostics.Process.Start(file)
                    End If
                Else
                    Me.printFile(file)
                End If
                Return True
            Else
                MsgBox("Datei existiert nicht und kann nicht geöffnet werden!", MsgBoxStyle.Information, "PMDS")
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("clFolder.openFile: " + ex.ToString())
        End Try
    End Function
    Public Function printFile(ByVal fileToPrint As String) As Boolean
        Try
            Dim startInfo As New ProcessStartInfo()

            startInfo.UseShellExecute = True
            startInfo.Verb = "Print"
            startInfo.CreateNoWindow = True
            startInfo.WindowStyle = ProcessWindowStyle.Minimized
            startInfo.FileName = fileToPrint

            Dim proc As New Process()
            proc.StartInfo = startInfo
            proc.Start()

            Return True

        Catch ex As Exception
            Throw New Exception("clFolder.printFile: " + ex.ToString())
        End Try
    End Function

    Public Function DateiSpeichernUnter(ByVal file As String, ByVal dateiTyp As String, ByVal mitTyp As Boolean) As Boolean
        Try
            Dim fileList As String = ""
            If Not mitTyp Then
                Dim cl As New clStringOperate
                dateiTyp = cl.GetFiletyp(file)
                If Not Me.IsNull(dateiTyp) Then
                    fileList = "" + dateiTyp + "|*" + dateiTyp + ""
                Else
                    'If LCase(dateiTyp) = LCase(".doc") Then
                    '    fileList = "Microsoft Word Files (*.doc)|*.doc"

                    fileList = "All Files (*.*)|*.*|" +
                                "bmp Dateien (*.bmp)|*.bmp|" +
                                "gif Dateien (*.gif)|*.gif|" +
                                "ini Dateien (*.ini)|*.ini|" +
                                "jpeg Dateien (*.jpeg)|*.jpeg|" +
                                "jpg Dateien (*.jpg)|*.jpg|" +
                                "Microsoft Excel Dateien (*.xls)|*.xls|" +
                                "Microsoft Word Dateien (*.doc)|*.doc|" +
                                "pdf Dateien (*.pdf)|*.pdf|" +
                                "Power Point Dateien (*.ppt)|*.ppt|" +
                                "rar Dateien (*.rar)|*.rar|" +
                                "Text Dateien (*.txt)|*.txt|" +
                                "tif Dateien (*.tif)|*.tif|" +
                                "rtf Dateien (*.Rtf)|*.rtf" +
                                "xls Dateien (*.xls)|*.xls|" +
                                "xsd Dateien (*.xsd)|*.xsd|" +
                                "zip Dateien (*.zip)|*.zip|"
                    'End If
                End If
            Else
                fileList = "" + dateiTyp + "|*" + dateiTyp + ""
            End If

            Dim xmlOp As New clStringOperate
            Dim fileToSave As String = ""
            fileToSave = Me.SaveFileDialog(fileList, "")
            If Not Me.IsNull(fileToSave) Then
                If System.IO.File.Exists(fileToSave) Then System.IO.File.Delete(fileToSave)
                System.IO.File.Copy(file, fileToSave)
                MsgBox("Die Datei wurde gesichert!", MsgBoxStyle.Information, "Archivsystem")
                Return True
            End If

        Catch ex As Exception
            Throw New Exception("clFolder.DateiSpeichernUnter: " + ex.ToString())
        End Try
    End Function


    Public Function SaveFileDialog(ByVal DateiTyp As String, ByVal initDir As String) As String
        Try
            Dim SaveFileD As New Windows.Forms.SaveFileDialog
            Dim File As String
            Dim Pfad As String

            SaveFileD.InitialDirectory = initDir

            SaveFileD.Filter = DateiTyp        '"Microsoft Excel Dateien (*.xls)|*.xls"
            SaveFileD.FilterIndex = 1
            SaveFileD.RestoreDirectory = True

            If SaveFileD.ShowDialog() = DialogResult.OK Then
                File = SaveFileD.FileName
                Return File
            End If

        Catch ex As Exception
            Throw New Exception("clFolder.SaveFileDialog: " + ex.ToString())
        End Try
    End Function

    Public Function MSDocumentImagingÖffnen() As Boolean
        Try

            Dim res As New GetSubkey
            res = Me.ReadKeyLocalMachine22("Software\Microsoft\Windows\CurrentVersion\App Paths\mspview.exe", "Path")
            If Not Me.IsNull(res.Result) Then
                Shell(res.Result + "\mspview.exe ", AppWinStyle.NormalFocus)
                Return True
            Else
                MsgBox("MS Document Imaging ist nicht installiert!", MsgBoxStyle.Information, "Archivsystem")
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("clFolder.MSDocumentImagingÖffnen: " + ex.ToString())
        End Try
    End Function
    Public Function ReadKeyLocalMachine22(ByVal PathSearch As String, ByVal keySearch As String) As GetSubkey
        Try
            Dim res As New GetSubkey
            Dim value As String
            Dim rk As RegistryKey = Registry.LocalMachine.OpenSubKey(PathSearch, True)
            res.Result = (CType(rk.GetValue(keySearch), String))
            res.KeyExists = True
            Return res

        Catch ex As Exception
            Dim res As New GetSubkey
            'Me.GetEcxeption(ex)
            Return res
        End Try
    End Function
    Public Function runShell(ByVal exe As String) As Boolean
        Try
            Shell(exe, AppWinStyle.NormalFocus, False)
            Return True

        Catch ex As Exception
            Throw New Exception("clFolder.runShell: " + ex.ToString())
        End Try
    End Function

    Public Function IsNull(ByVal Obj As Object) As Boolean
        Try
            Dim general As New GeneralArchiv
            Return general.IsNull(Obj)

        Catch ex As Exception
            Throw New Exception("clFolder.IsNull: " + ex.ToString())
        End Try
    End Function

End Class
