Imports System.Windows.Forms
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System

Imports System.Text
Imports Microsoft.VisualBasic

Imports Microsoft.Win32
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win



Public Class funct

    Public Shared xmlFileType As String = "XML Files (*.xml)|*.xml"
    Public Shared xsdFileType As String = "XSD Files (*.xsd)|*.xsd"
    Public Shared excelFileType As String = "Microsoft Excel Files (*.xlsx)|*.xlsx|Microsoft Excel Files (*.xls)|*.xls"
    Public Shared wordFileType As String = "Microsoft Word Files (*.doc)|*.doc"
    Public Shared pdfFileType As String = "Pdf Files (*.pdf)|*.pdf"
    Public Shared rtfileType As String = "Rtf Files (*.rtf)|*.rtf"
    Public Shared CsvFileType As String = "Csv Files (*.csv)|*.csv"
    Public Shared TxtFileTxtDialog As String = "Text Files (*.txt)|*.txt"
    Public Shared sqlFileType As String = "Sql Files (*.sql)|*.sql"

    Public Shared ressourcenFileType As String = "Pdf Files (*.pdf)|*.pdf|Rtf Files (*.rtf)|*.rtf|Microsoft Word Files (*.doc)|*.doc|Microsoft Excel Files (*.xls)|*.xls|jpg Files (*.jpg)|*.jpg|Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
    Public Shared fileTypeJpg As String = ".jpg"
    Public Shared fileTypeTxt As String = ".txt"
    Public Shared fileTypeCrystReport As String = ".rpt"
    Public Shared fileTypeFastReport As String = ".frx"
    Public Shared fileTypePDF As String = ".pdf"
    Public Shared fileTypeRTF As String = ".rtf"

    Public Shared typLogFile As String = "QS2 Log-File (*.xml)|*.xml"

    Public doLicense1 As New qs2.core.license.doLicense()


    Private Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Integer, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer

    Public Shared typeString As String = "System.String"
    Public Shared typeBoolean As String = "System.Boolean"
    Public Shared typeDate As String = "System.Date"
    Public Shared typeDateTime As String = "System.DateTime"
    Public Shared typeInt32 As String = "System.Int32"
    Public Shared typeInt64 As String = "System.In642"
    Public Shared typeDouble As String = "System.Double"
    Public Shared typeDecimal As String = "System.Decimal"
    Public Shared typeGuid As String = "System.Guid"
    Public Shared typeDBNull As String = "System.DBNull"






    Public Function getFileName(ByVal File As String, ByVal ohneEndung As Boolean) As String
        Try

            If File = "" Then Return ""

            If ohneEndung Then
                Return Path.GetFileNameWithoutExtension(File)
            Else
                Return Path.GetFileName(File)
            End If

        Catch ex As Exception
            Throw New Exception("funct.getFileName:" + vbNewLine + vbNewLine + ex.ToString())
            Return ""
        Finally
        End Try
    End Function

    Public Function getFileTypForDialog(ByVal typFile As String) As String
        Try
            Return "*" + typFile + "|*" + typFile

        Catch ex As Exception
            Throw New Exception("funct.getFileTypForDialog:" + vbNewLine + vbNewLine + ex.ToString())
            Return ""
        Finally
        End Try

    End Function

    Public Function selectFile(ByVal withDefaultTypes As Boolean, ByVal DateiTyp As String, _
                                Optional ByVal defaultDir As String = "") As String
        Try
            If withDefaultTypes Then _
                DateiTyp = funct.ressourcenFileType

            Dim openFileDialog As New OpenFileDialog

            openFileDialog.InitialDirectory = ""
            If defaultDir <> "" Then
                If Directory.Exists(defaultDir) Then
                    openFileDialog.InitialDirectory = defaultDir
                End If
            End If

            openFileDialog.Filter = DateiTyp
            openFileDialog.FilterIndex = 1
            openFileDialog.RestoreDirectory = True

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Return openFileDialog.FileName
            End If

        Catch ex As Exception
            Throw New Exception("funct.selectFile:" + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Function saveFile(ByVal withDefaultTypes As Boolean, ByVal DateiTyp As String, _
                                         Optional ByVal fileNameDefault As String = "", _
                                         Optional ByVal defaultDir As String = "") As String
        Try
            If withDefaultTypes Then _
                DateiTyp = funct.ressourcenFileType

            Dim SaveFileDialog As New SaveFileDialog
            SaveFileDialog.FileName = fileNameDefault
            SaveFileDialog.InitialDirectory = defaultDir
            SaveFileDialog.Filter = DateiTyp
            SaveFileDialog.FilterIndex = 1
            SaveFileDialog.RestoreDirectory = True

            If SaveFileDialog.ShowDialog() = DialogResult.OK Then
                Return SaveFileDialog.FileName
            End If

        Catch ex As Exception
            Throw New Exception("funct.saveFile:" + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function

    Public Function encryptMD5(ByVal txt As String) As String
        Dim rd As New RijndaelManaged

        Dim md5 As New MD5CryptoServiceProvider
        Dim key() As Byte = md5.ComputeHash(Encoding.UTF8.GetBytes(txt))

        md5.Clear()
        rd.Key = key
        rd.GenerateIV()

        Dim iv() As Byte = rd.IV
        Dim ms As New MemoryStream

        ms.Write(iv, 0, iv.Length)

        Dim cs As New CryptoStream(ms, rd.CreateEncryptor, CryptoStreamMode.Write)
        Dim data() As Byte = System.Text.Encoding.UTF8.GetBytes(txt)

        cs.Write(data, 0, data.Length)
        cs.FlushFinalBlock()

        Dim encdata() As Byte = ms.ToArray()
        txt = Convert.ToBase64String(encdata)
        cs.Close()
        rd.Clear()
        Return txt
    End Function
    Public Function decryptMD5(ByVal txt As String) As String
        Dim rd As New RijndaelManaged
        Dim rijndaelIvLength As Integer = 16
        Dim md5 As New MD5CryptoServiceProvider
        Dim key() As Byte = md5.ComputeHash(Encoding.UTF8.GetBytes(txt))

        md5.Clear()

        Dim encdata() As Byte = Convert.FromBase64String(txt)
        Dim ms As New MemoryStream(encdata)
        Dim iv(15) As Byte

        ms.Read(iv, 0, rijndaelIvLength)
        rd.IV = iv
        rd.Key = key

        Dim cs As New CryptoStream(ms, rd.CreateDecryptor, CryptoStreamMode.Read)

        Dim data(ms.Length - rijndaelIvLength) As Byte
        Dim i As Integer = cs.Read(data, 0, data.Length)

        txt = System.Text.Encoding.UTF8.GetString(data, 0, i)
        cs.Close()
        rd.Clear()
        Return txt
    End Function

    Public Function ByteToString(ByVal bytes() As Byte) As String

        Dim str As String = ""
        Dim i As Integer
        For i = 0 To bytes.Length - 1
            str += Chr(bytes(i))
        Next i
        Return str

    End Function
    Public Function StringToByte(ByVal Str As String) As Byte()

        Dim ByteStrings() As Char
        ByteStrings = Str.ToCharArray()
        Dim ByteOut(ByteStrings.Length - 1) As Byte
        For i As Integer = 0 To ByteStrings.Length - 1
            ByteOut(i) = Convert.ToByte(ByteStrings(i))
        Next
        Return ByteOut

    End Function

    Public Function checkComboBox(ByRef cmb As Infragistics.Win.UltraWinEditors.UltraComboEditor, ByVal auswahlPflicht As Boolean, _
                                  Optional ByVal setFocus As Boolean = True) As Boolean
        Try
            'If cmb.Focused Then

            Dim bFound As Boolean = False
            If auswahlPflicht Then
                If cmb.Value Is Nothing Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("InputNotExisting"), MessageBoxButtons.OK, "")
                    If setFocus Then cmb.Focus()
                    Return False
                End If
            Else
                If cmb.Value Is Nothing Then
                    Return True
                End If
            End If

            For Each itm As Infragistics.Win.ValueListItem In cmb.Items
                If cmb.Value.ToString = itm.DataValue.ToString Then
                    cmb.SelectedItem = itm
                    Return True
                End If
            Next
            If Not bFound Then
                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("InputNotExisting"), MessageBoxButtons.OK, "")
                If setFocus Then cmb.Focus()
                Return False
            End If
            Return False

        Catch ex As Exception
            Throw New Exception("funct.checkComboBox:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function checkComboBoxGrid(ByRef cmb As Infragistics.Win.UltraWinGrid.UltraCombo, _
                                  ByVal auswahlPflicht As Boolean, _
                                  ByVal table As DataTable, ByVal key As String, ByVal keyIsInteger As Boolean) As Boolean
        Try
            'If cmb.Focused Then
            If auswahlPflicht Then
                If cmb.SelectedRow Is Nothing Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("InputNotExisting"), MessageBoxButtons.OK, "")
                    cmb.Focus()
                    Return False
                End If
            Else
                If cmb.SelectedRow Is Nothing And cmb.Text = "" Then
                    Return True
                End If
            End If

            Dim keyToSearch As String = ""
            If Not cmb.SelectedRow Is Nothing Then
                keyToSearch = cmb.Value.ToString()
            End If

            Dim arrKeyFound() As DataRow = Nothing
            If keyIsInteger Then
                If keyToSearch.Trim() = "" Then
                    qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("InputNotExisting"), MessageBoxButtons.OK, "")
                    cmb.Focus()
                    Return False
                Else
                    arrKeyFound = table.Select(key + "=" + keyToSearch + "")
                End If
            Else
                arrKeyFound = table.Select(key + "='" + keyToSearch + "'")
            End If

            If arrKeyFound.Length > 0 Then
                Return True
            Else
                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("InputNotExisting"), MessageBoxButtons.OK, "")
                cmb.Focus()
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("funct.checkComboBoxGrid:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
   
    Public Shared Function searchEnumRights(ByVal keyToSearch As String, ByVal typEnum As Type) As qs2.core.Enums.eRights

        For Each val As Integer In [Enum].GetValues(typEnum)
            Dim str As String = [Enum].GetName(typEnum, val)
            If keyToSearch = str Then
                Return val          'return (qs2.core.vb.sqlAdmin.eGroups)val;
            End If
        Next

        Return Enums.eRights.rightNone

    End Function
    Public Shared Function getEnumAsList(ByVal typEnum As Type, ByVal valList As Infragistics.Win.ValueList) As System.Collections.Generic.List(Of String)

        Dim result As New System.Collections.Generic.List(Of String)()
        For Each val As Integer In [Enum].GetValues(typEnum)
            Dim strEnum As String = [Enum].GetName(typEnum, val)
            result.Add(strEnum)
            If Not valList Is Nothing Then valList.ValueListItems.Add(strEnum)
        Next
        Return result

    End Function
    Public Shared Function getEnumAsList2(ByVal typEnum As Type, ByVal valList As Infragistics.Win.ValueList) As System.Collections.Generic.List(Of String)

        Dim result As New System.Collections.Generic.List(Of String)()
        For Each val As Integer In [Enum].GetValues(typEnum)
            Dim strEnum As String = [Enum].GetName(typEnum, val)
            result.Add(strEnum)
            If Not valList Is Nothing Then valList.ValueListItems.Add(val, strEnum)
        Next
        Return result

    End Function
    Public Shared Function getFolder(ByVal typ As System.Environment.SpecialFolder) As String
        Return System.Environment.GetFolderPath(typ)
    End Function
    Public Shared Function GetAppFolder() As String
        Return System.Environment.CurrentDirectory
    End Function


    Public Function openFile(ByVal file As String, ByVal dateiTyp As String, ByVal openTemporär As Boolean ) As Boolean
        Me.openFile(file, dateiTyp, openTemporär, False, False, False, Nothing)
    End Function
    Public Function openFile(ByVal file As String, ByVal dateiTyp As String, ByVal openTemporär As Boolean, _
                      ByVal openIntern As Boolean, _
                       ByVal withMsgBox As Boolean, ByVal printFile As Boolean, binIntern() As Byte) As Boolean

        If System.IO.File.Exists(file) Then
            Dim dateiTemp As String = ""
            If openTemporär Then
                Dim IDNewFileNameTemp As New System.Guid
                IDNewFileNameTemp = System.Guid.NewGuid
                dateiTemp = Path.Combine(qs2.core.ENV.path_temp, IDNewFileNameTemp.ToString, dateiTyp)
                System.IO.File.Copy(file, dateiTemp)
            Else
                dateiTemp = file
            End If
            If dateiTyp.Trim() = "" Then
                dateiTyp = Path.GetExtension(file)
            End If

            If openIntern Then
                Return Me.openFileIntern(file, dateiTyp, openTemporär, openIntern, withMsgBox, binIntern)
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
                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("FileDoesNotExist"), Windows.Forms.MessageBoxButtons.OK, "")
            End If
            Return False
        End If
    End Function
    Public Function openFileIntern(ByVal file As String, ByVal dateiTyp As String, ByVal openTemporär As Boolean, _
                          ByVal openIntern As Boolean, ByVal withMsgBox As Boolean, binIntern() As Byte) As Boolean

        If binIntern Is Nothing Then
            If withMsgBox Then
                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("DocumentIsNoInternDocument"), Windows.Forms.MessageBoxButtons.OK, "")
            End If
        Else
            Dim frmTxtEditor1 As New qs2.Desktop.Txteditor.frmTxtEditor()
            'Dim dOnSaveDocu As New contTxtEditor.onSaveDocu(AddressOf Me.saveDocu)
            'frmTxtEditor1.ContTxtEditor1.delOnSaveDocu = dOnSaveDocu

            frmTxtEditor1.ContTxtEditor1.IDDocu = System.Guid.NewGuid()   'not ready    'lth
            frmTxtEditor1.ContTxtEditor1.TypDocu = "xy"
            frmTxtEditor1.ContTxtEditor1.showUISaveDocuToDB(True)

            frmTxtEditor1.Show()
            'frm.openDokument(file, TXTextControl.StreamType.InternalFormat, False)
            Dim doEditor1 As New qs2.Desktop.Txteditor.doEditor()
            doEditor1.showText("", TXTextControl.StreamType.InternalFormat, True, TXTextControl.ViewMode.PageView, frmTxtEditor1.ContTxtEditor1.textControl1, binIntern)
        End If

        Return True

    End Function
    Public Function printFile(ByVal fileToPrint As String) As Boolean

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

    End Function

    Public Function openFile_old(ByVal file As String, ByVal type As String, ByVal openTemp As Boolean) As Boolean
        Try
            If System.IO.File.Exists(file) Then
                Dim fileTemp As String = ""
                If openTemp Then
                    Dim IDNewFileNameTemp As New System.Guid
                    IDNewFileNameTemp = System.Guid.NewGuid
                    fileTemp = Me.getFolder(Environment.SpecialFolder.Templates) + "\" + IDNewFileNameTemp.ToString + type
                    System.IO.File.Copy(file, fileTemp)
                Else
                    fileTemp = file
                End If
                If type = "" Then
                    type = Path.GetExtension(file)
                End If

                Dim key_ProgEntry As String = ""
                Dim key_typ As RegistryKey
                Try
                    key_typ = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\" + type)
                    Dim keys() As String = key_typ.GetValueNames()
                    For Each s As String In keys
                        key_ProgEntry = key_typ.GetValue(s)
                    Next

                    If key_ProgEntry = "" Then
                        key_typ = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\" + type + "\OpenWithProgids")
                        keys = key_typ.GetValueNames()
                        For Each s As String In keys
                            key_ProgEntry = s
                        Next
                        If key_ProgEntry = "" Then
                            key_typ = Registry.ClassesRoot.OpenSubKey(type)
                            key_ProgEntry = key_typ.GetValue("")
                        End If
                    End If
                Catch ex As Exception
                    key_typ = Registry.ClassesRoot.OpenSubKey(type)
                    key_ProgEntry = key_typ.GetValue("")
                End Try

                If Me.openFile_reg(file, type, openTemp, key_ProgEntry, fileTemp, False) Then
                    Return True
                Else
                    key_typ = Registry.ClassesRoot.OpenSubKey(type)
                    key_ProgEntry = key_typ.GetValue("")
                    If Me.openFile_reg(file, type, openTemp, key_ProgEntry, fileTemp, True) Then
                        Return True
                    End If
                End If

            Else
                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("FileNotExists") + "!", Windows.Forms.MessageBoxButtons.OK, "")
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("funct.openFile_old:" + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Function openFile_reg(ByVal file As String, ByVal type As String, ByVal openTemp As Boolean, _
                                ByVal key_ProgEntry As String, ByVal fileTemp As String, ByVal message As Boolean) As Boolean
        Try
            If Not key_ProgEntry Is Nothing Then
                Dim key_prog As RegistryKey = Registry.ClassesRoot.OpenSubKey(key_ProgEntry + "\shell\open\command")
                If Not key_prog Is Nothing Then
                    Dim path_exe As String = key_prog.GetValue("")
                    If Microsoft.VisualBasic.Right(path_exe, 4) = Chr(34) + "%1" + Chr(34) Then
                        path_exe = Microsoft.VisualBasic.Left(path_exe, Len(path_exe) - 4)
                    End If
                    If Microsoft.VisualBasic.Right(path_exe, 2) = "%1" Then
                        path_exe = Microsoft.VisualBasic.Left(path_exe, Len(path_exe) - 2)
                    End If
                    If Microsoft.VisualBasic.Left(path_exe, 12) = "rundll32.exe" Or path_exe.Contains("PhotoViewer.dll") Then
                        'path_exe = ""
                        'Shell(dateiTemp)
                        Dim prog As String = ""
                        prog = Me.getFolder(Environment.SpecialFolder.System) + "\mspaint.exe"
                        If System.IO.File.Exists(prog) Then
                            Shell(prog + " " + Chr(34) + fileTemp + Chr(34), AppWinStyle.NormalFocus)
                            Return True
                        End If
                    End If
                    Shell(path_exe + " " + Chr(34) + fileTemp + Chr(34), AppWinStyle.NormalFocus)
                    Return True
                Else
                    'Throw New Exception("DateiÖffnen: Registry.ClassesRoot.OpenSubKey(key_ProgEintrag \shell\open\command) - no key")
                    If message Then qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoProgramForOpenFile") + "!", Windows.Forms.MessageBoxButtons.OK, "")
                    Return False
                End If
            Else
                'Throw New Exception("DateiÖffnen: Registry.ClassesRoot.OpenSubKey(typ) - no key")
                If message Then qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("NoProgramForOpenFile") + "!", Windows.Forms.MessageBoxButtons.OK, "")
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("funct.openFile_reg:" + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function

    Public Function saveFileAs(ByVal file As String, ByVal dateiTyp As String) As Boolean

        If dateiTyp.Trim() = "" Then
            dateiTyp = Path.GetExtension(file)
        End If

        Dim fileList As String = ""
        If LCase(dateiTyp) = LCase(".doc") Then
            fileList = "Microsoft Word Files (*.doc)|*.doc"
        ElseIf LCase(dateiTyp) = LCase(".docx") Then
            fileList = "Microsoft Word Xml-Files (*.doc)|*.docx"
        ElseIf LCase(dateiTyp) = LCase(".rtf") Then
            fileList = "rtf Files (*.Rtf)|*.rtf"
        ElseIf LCase(dateiTyp) = LCase(".xls") Then
            fileList = "xls Files (*.xls)|*.xls"
        ElseIf LCase(dateiTyp) = LCase(".xsd") Then
            fileList = "xsd Files (*.xsd)|*.xsd"
        ElseIf LCase(dateiTyp) = LCase(".txt") Then
            fileList = "Text Files (*.txt)|*.txt"
        ElseIf LCase(dateiTyp) = LCase(".pdf") Then
            fileList = "pdf Files (*.pdf)|*.pdf"
        ElseIf LCase(dateiTyp) = LCase(".zip") Then
            fileList = "zip Files (*.zip)|*.zip"
        ElseIf LCase(dateiTyp) = LCase(".rar") Then
            fileList = "rar Files (*.rar)|*.rar"
        ElseIf LCase(dateiTyp) = LCase(".ppt") Then
            fileList = "Power Point Files (*.ppt)|*.ppt"

        ElseIf LCase(dateiTyp) = LCase(".tif") Then
            fileList = "tif Files (*.tif)|*.tif"
        ElseIf LCase(dateiTyp) = LCase(".tiff") Then
            fileList = "tif Files (*.tiff)|*.tiff"
        ElseIf LCase(dateiTyp) = LCase(".bmp") Then
            fileList = "bmp Files (*.bmp)|*.bmp"
        ElseIf LCase(dateiTyp) = LCase(".jpg") Then
            fileList = "jpg Files (*.jpg)|*.jpg"
        ElseIf LCase(dateiTyp) = LCase(".jpeg") Then
            fileList = "jpeg Files (*.jpeg)|*.jpeg"
        ElseIf LCase(dateiTyp) = LCase(".gif") Then
            fileList = "gif Files (*.gif)|*.gif"

        ElseIf LCase(dateiTyp) = LCase(".mp3") Then
            fileList = "mp3 Files (*.mp3)|*.mp3"
        ElseIf LCase(dateiTyp) = LCase(".wav") Then
            fileList = "wav Files (*.wav)|*.wav"

        Else
            fileList = "All Files (*.*)|*.*|" + _
                        "bmp Files (*.bmp)|*.bmp|" + _
                        "gif Files (*.gif)|*.gif|" + _
                        "ini Files (*.ini)|*.ini|" + _
                        "jpeg Files (*.jpeg)|*.jpeg|" + _
                        "jpg Files (*.jpg)|*.jpg|" + _
                        "Microsoft Excel Files (*.xls)|*.xls|" + _
                        "Microsoft Word Files (*.doc)|*.doc|" + _
                        "pdf Files (*.pdf)|*.pdf|" + _
                        "Power Point Files (*.ppt)|*.ppt|" + _
                        "rar Files (*.rar)|*.rar|" + _
                        "Text Files (*.txt)|*.txt|" + _
                        "tif Files (*.tif)|*.tif|" + _
                        "rtf Files (*.Rtf)|*.rtf" + _
                        "xls Files (*.xls)|*.xls|" + _
                        "xsd Files (*.xsd)|*.xsd|" + _
                        "zip Files (*.zip)|*.zip|"

        End If

        Dim fileToSave As String = ""
        fileToSave = Me.SaveFileDialog(fileList, "", "")
        If Not fileToSave.Trim() = "" Then
            If System.IO.File.Exists(fileToSave) Then
                System.IO.File.Delete(fileToSave)
            End If
            System.IO.File.Copy(file, fileToSave)
            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("FileSaved"), Windows.Forms.MessageBoxButtons.OK, "")
            Return True
        End If

    End Function
    Public Function SaveFileDialog(ByVal DateiTyp As String, ByVal rootVerzeichnis As String, ByVal FileName As String) As String

        Dim SaveFileD As New SaveFileDialog
        Dim File As String
        'Dim Pfad As String

        SaveFileD.InitialDirectory = rootVerzeichnis
        SaveFileD.Filter = DateiTyp
        SaveFileD.FilterIndex = 1
        SaveFileD.RestoreDirectory = True
        If FileName <> "" Then
            SaveFileD.FileName = FileName
        End If

        If SaveFileD.ShowDialog() = DialogResult.OK Then
            File = SaveFileD.FileName
            Return File
        Else
            Return ""
        End If
    End Function

    Public Function SelectFileDialog(ByVal DateiTyp As String, ByVal rootVerzeichnis As String) As String

        Dim openFileDialog As New OpenFileDialog
        Dim File As String
        'Dim Pfad As String
        openFileDialog.InitialDirectory = ""
        If Not rootVerzeichnis = "" And System.IO.Directory.Exists(rootVerzeichnis) Then
            openFileDialog.InitialDirectory = rootVerzeichnis
        End If
        openFileDialog.Filter = DateiTyp        '"Microsoft Excel Dateien (*.xls)|*.xls"
        openFileDialog.FilterIndex = 1
        openFileDialog.RestoreDirectory = True
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            File = openFileDialog.FileName
            Return File
        End If
        Return ""

    End Function

    Public Function readByteStreamFile(ByVal file As String) As Byte()

        ' Read File into byte Array
        Dim fs As New System.IO.FileStream(file, FileMode.Open, FileAccess.Read)
        Dim r As New BinaryReader(fs)
        Dim fileByte(fs.Length) As Byte
        fileByte = r.ReadBytes(fs.Length)
        fs.Close()
        r.Close()
        Return fileByte

    End Function
    Public Function saveFileFromBytes(ByVal fileToSave As String, ByVal byteStream() As Byte, ByVal msgBox As Boolean) As Boolean
        Try
            Dim fileTyp As String = Path.GetExtension(fileToSave)
            Dim dirToSave As String = Path.GetFullPath(fileToSave)
            fileToSave = Me.getFileName(fileToSave, True)
            Me.saveFileFromBytes(dirToSave, fileToSave, fileTyp, byteStream)
            If msgBox Then
                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("FileWasSaved"), MessageBoxButtons.OK, "")
            End If
            Return True

        Catch ex As Exception
            Throw New Exception("funct.saveFileFromBytes:" + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Function saveFileFromBytes(ByVal path As String, ByVal Bezeichnung As String, ByVal DateiTyp As String, ByVal byteStream() As Byte) As String
        Try
            Dim file As String = Me.getFileName(path, Bezeichnung, DateiTyp, 0)
            Dim fs As IO.FileStream = New IO.FileStream(file, IO.FileMode.Create)
            Dim b() As Byte = byteStream
            fs.Write(b, 0, b.Length)
            fs.Close()
            Return file

        Catch ex As Exception
            Throw New Exception("funct.saveFileFromBytes:" + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Function saveFileFromString(ByVal path As String, ByVal Bezeichnung As String, ByVal DateiTyp As String, ByVal Text As String) As String
        Try
            Dim file As String = Me.getFileName(path, Bezeichnung, DateiTyp, 0)
            Dim sw As StreamWriter = New StreamWriter(file, False)
            sw.Write(Text)
            sw.Flush()
            sw.Close()
            Return file

        Catch ex As Exception
            Throw New Exception("funct.saveFileFromString:" + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Function
    Public Function getFilename(ByVal path As String, ByVal fileName As String, ByVal fileType As String, ByVal nr As String) As String
        Try
            Dim file As String = path + "\" + fileName + If(nr = 0, "", nr.ToString()) + fileType
            Try
                System.IO.File.Delete(file)
                Return file
            Catch ex As Exception
                Return Me.getFileName(path, fileName, fileType, nr + 1)
            End Try

        Catch ex As Exception
            Return Me.getFileName(path, fileName, fileType, nr + 1)
        Finally
        End Try
    End Function

    Public Shared Sub clearDirTemp()
        Try
            Dim allFiles() As String
            allFiles = System.IO.Directory.GetFiles(qs2.core.ENV.path_temp)
            For Each f As String In allFiles
                Try
                    System.IO.File.Delete(f)
                Catch ex As Exception
                Finally
                End Try
            Next

        Catch ex As Exception
            Throw New Exception("funct.clearDirTemp:" + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Sub
    Public Shared Sub openURL(ByVal url As String)
        Try
            Call ShellExecute(0, "open", url, "", "", 1)

        Catch ex As Exception
            Throw New Exception("funct.openURL:" + vbNewLine + vbNewLine + ex.ToString())
        Finally
        End Try
    End Sub
    Public Shared Sub openNewEMail(ByVal sTo As String, Optional ByVal sTitle As String = "", Optional ByVal sText As String = "")

        Dim sParam As String

        ' Betreff
        If sTitle.Length > 0 Then AddMailParam(sParam, "subject=" + sTitle)

        ' Nachrichtentext
        If sText.Length > 0 Then AddMailParam(sParam, "body=" + sText.Replace(Chr(10), "%0d").Replace(Chr(13), "%0a"))

        ' Fenster "Neue Nachricht" öffnen
        Process.Start("mailto: " + sTo + sParam)

    End Sub
    Private Shared Sub AddMailParam(ByRef sAllParam As String, ByVal sParam As String)
        If sAllParam = String.Empty Then
            sAllParam = "?" + sParam
        Else
            sAllParam &= "&" + sParam
        End If
    End Sub
    Public Shared Sub setFilterGrid(ByVal grid As UltraGrid, ByVal bOn As Boolean)

        If bOn Then
            grid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            grid.DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.Hidden
            grid.DisplayLayout.Override.FilterRowPrompt = qs2.core.language.sqlLanguage.getRes("ClickToFilterData")
            grid.DisplayLayout.Override.FilterOperandStyle = FilterOperandStyle.Combo
            grid.DisplayLayout.Override.FilterClearButtonLocation = FilterClearButtonLocation.Row
            grid.DisplayLayout.Override.FilterOperatorDropDownItems = FilterOperatorDropDownItems.Contains
            grid.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            grid.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None
            grid.DisplayLayout.Override.FixedRowIndicator = FixedRowIndicator.None
            grid.DisplayLayout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
            grid.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.OnlyWhenSorted
        Else
            grid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        End If
    End Sub
    Public Shared Sub setStyleGrid(ByRef grd As UltraGrid, ByVal setMergeOn As Boolean, ByVal doSplitterFunctions As Boolean)

        If setMergeOn Then
            grd.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.OnlyWhenSorted
            grd.DisplayLayout.Override.MergedCellAppearance.BackColor = System.Drawing.Color.Beige
        Else
            grd.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.Never
        End If

        grd.DisplayLayout.Override.RowSizing = RowSizing.Free
        grd.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.True

        If doSplitterFunctions Then
            grd.DisplayLayout.MaxColScrollRegions = 2
            grd.DisplayLayout.MaxRowScrollRegions = 2
        Else
            grd.DisplayLayout.MaxColScrollRegions = 1
            grd.DisplayLayout.MaxRowScrollRegions = 1
        End If

    End Sub

    Public Function setFilter(ByVal col As String, ByVal oper As FilterLogicalOperator, _
                          ByVal filterVal As Object, ByVal compxy As Infragistics.Win.UltraWinGrid.FilterComparisionOperator, _
                          ByVal grid As UltraGrid, ByVal bandIndex As Integer)

        Dim condition As FilterCondition
        grid.DisplayLayout.Bands(bandIndex).ColumnFilters.LogicalOperator = FilterLogicalOperator.Or
        grid.DisplayLayout.Bands(bandIndex).ColumnFilters(col).LogicalOperator = oper
        condition = grid.DisplayLayout.Bands(bandIndex).ColumnFilters(col).FilterConditions.Add(FilterComparisionOperator.Contains, filterVal)

    End Function
    Public Function clearFilter(ByVal col As DataColumn, ByVal filterVal As Object, ByVal grid As UltraGrid)
        For Each band As UltraGridBand In grid.DisplayLayout.Bands
            For Each colFilter As ColumnFilter In band.ColumnFilters
                If colFilter.Column.Key = col.ColumnName Then
                    For Each filterCond As FilterCondition In colFilter.FilterConditions
                        If filterCond.CompareValue.Equals(filterVal) Then
                            colFilter.FilterConditions.Remove(filterCond)
                        End If
                    Next
                End If
            Next
        Next
    End Function
    Public Function clearFilter(ByVal col As DataColumn, ByVal grid As UltraGrid)
        For Each band As UltraGridBand In grid.DisplayLayout.Bands
            For Each colFilter As ColumnFilter In band.ColumnFilters
                If colFilter.Column.Key = col.ColumnName Then
                    colFilter.ClearFilterConditions()
                End If
            Next
        Next
    End Function
    Public Function clearAllFilter(ByVal grid As UltraGrid)
        For Each band As UltraGridBand In grid.DisplayLayout.Bands
            For Each colFilter As ColumnFilter In band.ColumnFilters
                colFilter.ClearFilterConditions()
            Next
        Next
    End Function
    Public Function filterContainsCol(ByVal col As DataColumn, ByVal filterVal As Object, ByVal grid As UltraGrid)
        For Each band As UltraGridBand In grid.DisplayLayout.Bands
            For Each colFilter As ColumnFilter In band.ColumnFilters
                If colFilter.Column.Key = col.ColumnName Then
                    For Each filterCond As FilterCondition In colFilter.FilterConditions
                        If filterCond.CompareValue.Equals(filterVal) Then
                            Return True
                        End If
                    Next
                End If
            Next
        Next
    End Function

    Public Sub gridAdvancedView(ByVal bOn As Boolean, ByRef grid As UltraGrid, _
                            ByVal lstColAktivate As System.Collections.Generic.List(Of String), _
                            ByVal lstColDeaktivate As System.Collections.Generic.List(Of String), _
                            Optional ByVal lstColAktivateErweitert As System.Collections.Generic.List(Of String) = Nothing)

        Me.gridAdvancedView(bOn, grid.DisplayLayout.Bands(0), lstColAktivate, lstColDeaktivate, lstColAktivateErweitert)

    End Sub
    Public Sub gridAdvancedView(ByVal bOn As Boolean, ByRef band As UltraGridBand, _
                            ByVal lstColAktivate As System.Collections.Generic.List(Of String), _
                            ByVal lstColDeaktivate As System.Collections.Generic.List(Of String), _
                            Optional ByVal lstColAktivateErweitert As System.Collections.Generic.List(Of String) = Nothing, _
                            Optional ByVal showAllColumns As Boolean = False, _
                            Optional ByVal doNotChangeVisibilityState As Boolean = False)

        For Each col As UltraGridColumn In band.Columns
            Dim bDoFormat As Boolean = True
            If Not doNotChangeVisibilityState Then
                If col.DataType.ToString().ToLower().Trim() = funct.typeGuid.ToLower().Trim() Then
                    col.Hidden = True
                Else
                    col.Hidden = Not bOn
                End If
            Else
                If col.Hidden Then
                    bDoFormat = False
                End If
            End If

            If bDoFormat Then
                If col.DataType.ToString().ToLower().Trim() = funct.typeString.ToLower().Trim() Then
                    col.CellAppearance.TextHAlign = HAlign.Left
                    col.Header.Appearance.TextHAlign = HAlign.Left

                End If
                If col.DataType.ToString().ToLower().Trim() = funct.typeDouble.ToLower().Trim() Or _
                    col.DataType.ToString().ToLower().Trim() = funct.typeInt32.ToLower().Trim() Or _
                    col.DataType.ToString().ToLower().Trim() = funct.typeDecimal.ToLower().Trim() Then

                    col.CellAppearance.TextHAlign = HAlign.Right
                    col.Header.Appearance.TextHAlign = HAlign.Right
                End If

                If col.DataType.ToString().ToLower().Trim() = funct.typeDate.ToLower().Trim() Or _
                    col.DataType.ToString().ToLower().Trim() = funct.typeDateTime.ToLower().Trim() Then

                    col.CellAppearance.TextHAlign = HAlign.Center
                    col.Header.Appearance.TextHAlign = HAlign.Center
                End If

                For Each colDeaktivate As String In lstColDeaktivate
                    band.Columns(colDeaktivate).Hidden = True
                Next
            End If
        Next

        If Not bOn Then
            For Each col As String In lstColAktivate
                band.Columns(col).Hidden = False
            Next
        End If

        If Not lstColAktivateErweitert Is Nothing Then
            For Each col As String In lstColAktivateErweitert
                band.Columns(col).Hidden = False
            Next
        End If

        If showAllColumns Then
            For Each col As UltraGridColumn In band.Columns
                Try
                    If Not col.IsChaptered Then
                        col.Hidden = False
                    End If
                Catch ex As Exception
                    qs2.core.generic.getExep(ex.ToString(), ex.Message)
                End Try
            Next
        End If

    End Sub

    Public Function doSortPlusMinus1(ByVal toTop As Boolean, AnyNewPosition As Boolean, NewPositon As Integer, ByVal dtToSort As DataTable, _
                         ByVal sortColumn As String, ByVal IDToCheck As String, _
                         ByVal rSelList As DataRow, _
                         ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid, _
                         ByVal OnlyVisibleColumns As Boolean, _
                         ByVal KeyInGrid As String, _
                         ByVal colNameVisible As String) As Boolean
        Try
            Dim newNr As Integer = 0
            Dim lastNrVisible As Integer = 0
            Dim NrPlusNotVisible As Integer = 0
            If OnlyVisibleColumns Then
                NrPlusNotVisible = 1000
            End If
            Dim reached As Boolean = False
            Dim orderBy As String
            If toTop Then
                orderBy = " desc "
            Else
                orderBy = " asc "
            End If
            Dim colNewOrder As String = "NewOrder"
            Dim colVisible As String = "VisibleFct"
            dtToSort.Columns.Add(colNewOrder, newNr.GetType())
            dtToSort.Columns.Add(colVisible, GetType(String))

            Dim arrActualSelList() As DataRow = dtToSort.Select("", sortColumn + orderBy)
            For Each rActualSelList As DataRow In arrActualSelList
                Dim NrPlusNotVisibleTmp As Integer = 0
                If OnlyVisibleColumns Then
                    For Each ColInGrid As UltraGridColumn In grid.DisplayLayout.Bands(0).Columns
                        If ColInGrid.Key.Trim().ToLower().Equals(KeyInGrid.Trim().ToString().ToLower()) Then
                            If rActualSelList(colNameVisible) = True Then
                                NrPlusNotVisibleTmp = 0
                                rActualSelList(colVisible) = True
                            Else
                                NrPlusNotVisibleTmp = NrPlusNotVisible
                                rActualSelList(colVisible) = False
                            End If
                        End If
                    Next
                Else
                    NrPlusNotVisibleTmp = 0
                End If

                newNr += 1
                If (Not reached) And (rActualSelList(IDToCheck) = rSelList(IDToCheck)) Then
                    reached = True
                    rActualSelList(colNewOrder) = (newNr + 1 + NrPlusNotVisibleTmp)
                ElseIf reached And (rActualSelList(IDToCheck) <> rSelList(IDToCheck)) Then
                    reached = False
                    rActualSelList(colNewOrder) = (newNr - 1 + NrPlusNotVisibleTmp)
                ElseIf (Not reached) And (rActualSelList(IDToCheck) <> rSelList(IDToCheck)) Then
                    rActualSelList(colNewOrder) = newNr + NrPlusNotVisibleTmp
                End If
            Next

            lastNrVisible = newNr
            newNr = 0
            Dim newNrNotVisible As Integer = NrPlusNotVisible
            Dim arrActualSelListWrite() As DataRow = dtToSort.Select("", colNewOrder + orderBy)
            For Each rActualSelListWrite As DataRow In arrActualSelListWrite
                If rActualSelListWrite(colVisible) = True Then
                    newNr += 1
                    rActualSelListWrite(sortColumn) = newNr
                Else
                    newNrNotVisible += 1
                    rActualSelListWrite(sortColumn) = newNrNotVisible
                End If
            Next

            dtToSort.Columns.Remove(colNewOrder)
            dtToSort.Columns.Remove(colVisible)
            grid.DisplayLayout.Bands(0).SortedColumns.Clear()
            grid.DisplayLayout.Bands(0).SortedColumns.Add(sortColumn, False)

            Return True

        Catch ex As Exception
            Throw New Exception("funct.doSort:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function
    Public Function doSortAuto(ByVal dtToSort As DataTable, _
                        ByVal sortColumn As String, ByVal IDToCheck As String, _
                        ByVal rSelList As DataRow, _
                        ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid, _
                        ByVal OnlyVisibleColumns As Boolean, _
                        ByVal KeyInGrid As String, _
                        ByVal colNameVisible As String, ToTop As Boolean) As Boolean
        Try
            Dim orderBy As String = " asc "
            Dim colNewOrder As String = "NewOrder"
            Dim colVisible As String = "VisibleFct"
            Dim colDone As String = "Done"
            dtToSort.Columns.Add(colNewOrder, GetType(Integer))
            dtToSort.Columns.Add(colVisible, GetType(String))
            dtToSort.Columns.Add(colDone, GetType(Boolean))

            Dim reached As Boolean = False

            Dim rSortFromToxy As DataRow = Nothing
            Dim SortFromToxy As Integer = -1
            Dim rSortFromToBeforexy As DataRow = Nothing

            Dim arrActualSelList() As DataRow = dtToSort.Select("", sortColumn + " asc ")
            For Each rActualSelList As DataRow In arrActualSelList
                rActualSelList(colNewOrder) = -10000
                rActualSelList(colVisible) = False
                rActualSelList(colDone) = False

                If rActualSelList(IDToCheck) = rSelList(IDToCheck) Then
                    rSortFromToxy = rActualSelList
                    SortFromToxy = rActualSelList(sortColumn)

                    rSortFromToxy(colNewOrder) = rSortFromToxy(sortColumn)
                    rSortFromToxy(colDone) = True
                    reached = True
                    reached = True
                Else
                    If Not reached Then
                        rSortFromToBeforexy = rActualSelList
                    End If
                End If
            Next

            'Dim colNewOrder As String = "NewOrder"
            'Dim colVisible As String = "VisibleFct"
            'dtToSort.Columns.Add(colNewOrder, GetType(Integer))
            'dtToSort.Columns.Add(colVisible, GetType(String))
            'Dim arrActualSelList() As DataRow = dtToSort.Select("", sortColumn + " asc ")
            'For Each rActualSelList As DataRow In arrActualSelList
            '    If rActualSelList(IDToCheck) = rSelList(IDToCheck) Then
            '        If Not rLastActualSelList Is Nothing Then
            '            NewSortKeyRow = rLastActualSelList(sortColumn)
            '            'NewSortKeyRow = rActualSelList(sortColumn)
            '        Else
            '            NewSortKeyRow = rLastActualSelList(sortColumn)
            '        End If
            '    Else
            '        rLastActualSelList = rActualSelList
            '    End If
            'Next

            Dim newNrVisible As Integer = 0
            Dim newNrNotVisible As Integer = 0
            Dim newNrBefore As Integer = 0
            Dim NrPlusNotVisible As Integer = 1000
            reached = False
            Dim ColIsVisible As Boolean = False
            arrActualSelList = dtToSort.Select("", sortColumn + orderBy)

            Dim lstEqual As New System.Collections.Generic.List(Of DataRow)
            Dim lstBefore As New System.Collections.Generic.List(Of DataRow)
            For Each rActualSelList As DataRow In arrActualSelList
                If OnlyVisibleColumns Then
                    For Each ColInGrid As UltraGridColumn In grid.DisplayLayout.Bands(0).Columns
                        If ColInGrid.Key.Trim().ToLower().Equals(KeyInGrid.Trim().ToString().ToLower()) Then
                            If rActualSelList(colNameVisible) = True Then
                                ColIsVisible = True
                                rActualSelList(colVisible) = True
                            Else
                                ColIsVisible = False
                                rActualSelList(colVisible) = False
                            End If
                        End If
                    Next
                Else
                    ColIsVisible = True
                    rActualSelList(colVisible) = True
                End If

                If ColIsVisible Then
                    If rActualSelList(sortColumn) > SortFromToxy And rActualSelList(IDToCheck) <> rSortFromToxy(IDToCheck) Then
                        newNrVisible += 1
                        rActualSelList(colNewOrder) = SortFromToxy + newNrVisible
                        rActualSelList(colDone) = True
                    ElseIf rActualSelList(sortColumn) = SortFromToxy And ToTop And rActualSelList(IDToCheck) <> rSortFromToxy(IDToCheck) Then
                        newNrVisible += 1
                        rActualSelList(colNewOrder) = SortFromToxy + newNrVisible
                        rActualSelList(colDone) = True
                    ElseIf rActualSelList(sortColumn) = SortFromToxy And Not ToTop And rActualSelList(IDToCheck) <> rSortFromToxy(IDToCheck) Then
                        newNrBefore -= 1
                        rActualSelList(colNewOrder) = SortFromToxy + newNrBefore
                        lstBefore.Add(rActualSelList)
                    Else
                        Dim str As String = ""
                    End If
                Else
                    newNrNotVisible += 1
                    rActualSelList(colNewOrder) = NrPlusNotVisible + newNrNotVisible
                    rActualSelList(colDone) = True
                End If
            Next

            reached = False
            newNrVisible = SortFromToxy
            arrActualSelList = dtToSort.Select("", colNewOrder + " asc ")
            For Each rActualSelList As DataRow In arrActualSelList
                Dim IsInList As Boolean = False
                For Each rEqual As DataRow In lstEqual
                    If rEqual(IDToCheck) = rActualSelList(IDToCheck) Then
                        IsInList = True
                    End If
                Next
                If IsInList Then
                    newNrVisible += 1
                    rActualSelList(colNewOrder) = newNrVisible
                    rActualSelList(colDone) = True
                    reached = True
                Else
                    If reached And rActualSelList(colDone) And rActualSelList(colNewOrder) >= SortFromToxy And rActualSelList(IDToCheck) <> rSortFromToxy(IDToCheck) Then
                        newNrVisible += 1
                        rActualSelList(colNewOrder) = newNrVisible
                        rActualSelList(colDone) = True
                    Else
                        Dim str As String = ""
                    End If
                End If
            Next

            newNrVisible = SortFromToxy
            arrActualSelList = dtToSort.Select(colNewOrder + "=-10000", sortColumn + " desc ")
            For Each rActualSelList As DataRow In arrActualSelList
                newNrVisible -= 1
                rActualSelList(colNewOrder) = newNrVisible
                rActualSelList(colDone) = True
                reached = True
            Next

            Dim lfdNrVisible As Integer = 0
            Dim lfdNrNotVisible As Integer = NrPlusNotVisible
            Dim arrActualSelListWrite() As DataRow = dtToSort.Select("", colNewOrder + orderBy)
            For Each rActualSelListWrite As DataRow In arrActualSelListWrite
                If rActualSelListWrite(colVisible) = True Then
                    lfdNrVisible += 1
                    rActualSelListWrite(sortColumn) = lfdNrVisible
                Else
                    lfdNrNotVisible += 1
                    rActualSelListWrite(sortColumn) = lfdNrNotVisible
                End If
            Next

            dtToSort.Columns.Remove(colNewOrder)
            dtToSort.Columns.Remove(colVisible)
            dtToSort.Columns.Remove(colDone)

            If grid.DisplayLayout.Bands(0).SortedColumns.Count = 1 Then
                For Each colSortedExists As UltraGridColumn In grid.DisplayLayout.Bands(0).SortedColumns
                    If colSortedExists.Key.Trim().ToLower().Equals((sortColumn).Trim().ToLower()) Then
                        grid.DisplayLayout.Bands(0).SortedColumns.Clear()
                        grid.DisplayLayout.Bands(0).SortedColumns.Add(sortColumn, False)
                    End If
                Next
            End If

            grid.Refresh()

            Return True

        Catch ex As Exception
            Throw New Exception("funct.doSort:" + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Function getLastSortNumber(ByVal dtToSort As DataTable, ByVal columnNameSort As String) As Integer
        Try
            Dim lastNr As Integer = 0
            For Each rSelList As DataRow In dtToSort.Rows
                If rSelList.RowState <> DataRowState.Deleted Then
                    If Not rSelList(columnNameSort) Is System.DBNull.Value Then _
                        lastNr = IIf(lastNr < rSelList(columnNameSort), rSelList(columnNameSort), lastNr)
                End If
            Next
            Return (lastNr + 1)

        Catch ex As Exception
            Throw New Exception("funct.getLastSortNumber:" + vbNewLine + vbNewLine + ex.ToString())
            Return 5000
        End Try
    End Function

    Public Shared Function getDate235959(ByVal datOrig As Date) As Date
        Dim datReturn As New Date(datOrig.Year, datOrig.Month, datOrig.Day, 23, 59, 59)
        Return datReturn
    End Function

    Public Sub setMergeStyle(ByRef grd As UltraGrid, ByVal setMergeOn As Boolean, ByVal doSplitterFunctions As Boolean)

        If setMergeOn Then
            grd.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.OnlyWhenSorted
            grd.DisplayLayout.Override.MergedCellAppearance.BackColor = System.Drawing.Color.Beige
        Else
            grd.DisplayLayout.Override.MergedCellStyle = MergedCellStyle.Never
        End If

        grd.DisplayLayout.Override.RowSizing = RowSizing.Free
        grd.DisplayLayout.Override.CellMultiLine = DefaultableBoolean.True

        If doSplitterFunctions Then
            grd.DisplayLayout.MaxColScrollRegions = 2
            grd.DisplayLayout.MaxRowScrollRegions = 2
        Else
            grd.DisplayLayout.MaxColScrollRegions = 1
            grd.DisplayLayout.MaxRowScrollRegions = 1
        End If

    End Sub
    Public Sub setFilterGridKomplex(ByRef grd As UltraGrid, ByVal bIsOn As Boolean, ByVal doSplitterFunctions As Boolean)

        If bIsOn Then
            grd.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
            grd.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            grd.DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.Hidden
            grd.DisplayLayout.Override.FilterRowPrompt = qs2.core.language.sqlLanguage.getRes("ClickHereToFilterData")
            grd.DisplayLayout.Override.FilterRowAppearance.ForeColor = System.Drawing.Color.DarkGray
            grd.DisplayLayout.Override.FilterRowAppearance.BackColor = System.Drawing.Color.White
            grd.DisplayLayout.Override.FilterRowAppearance.FontData.Bold = DefaultableBoolean.False
            grd.DisplayLayout.Override.FilterOperandStyle = FilterOperandStyle.Combo
            grd.DisplayLayout.Override.FilterClearButtonLocation = FilterClearButtonLocation.Row
            grd.DisplayLayout.Override.FilterOperatorDropDownItems = FilterOperatorDropDownItems.Contains
            grd.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            grd.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None
            grd.DisplayLayout.Override.FixedRowIndicator = FixedRowIndicator.None
            'grd.DisplayLayout.Override.GroupByColumnsHidden = DefaultableBoolean.Default
            'grd.DisplayLayout.Override.GroupByRowExpansionStyle = GroupByRowExpansionStyle.Default
            'grd.DisplayLayout.Override.GroupByRowInitialExpansionState = GroupByRowInitialExpansionState.Default
            '      grd.DisplayLayout.Override.GroupBySummaryDisplayStyle = 
            grd.DisplayLayout.Override.SpecialRowSeparator = SpecialRowSeparator.FilterRow
            ' grd.DisplayLayout.Override.SpecialRowSeparatorAppearance.BackColor = Color.LightSteelBlue
            Me.setMergeStyle(grd, True, doSplitterFunctions)
            'grd.DisplayLayout.Override.FilterRowPromptAppearance.FontData.SizeInPoints = 10
            grd.DisplayLayout.Override.FilterRowPromptAppearance.ForeColor = System.Drawing.Color.DarkGray

        Else
            grd.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False
        End If

    End Sub

    Public Shared Sub copyDataset(ByRef dsToCopy As DataSet, ByRef resultDs As DataSet)

        For Each tableToCopy As DataTable In dsToCopy.Tables
            Dim newDataTable As DataTable = tableToCopy.Copy()
            resultDs.Tables.Add(newDataTable)
            'For Each columnToCopy As DataColumn In tableToCopy.Columns
            '    newTable.Columns.Add(columnToCopy)
            'Next
            'For Each rowToCopy As DataRow In tableToCopy.Rows
            '    Dim newRow As DataRow = newTable.NewRow()
            '    newRow.ItemArray = rowToCopy.ItemArray
            '    newTable.Rows.Add(newRow)
            'Next
        Next

    End Sub
    Public Shared Sub getVariablesLefRightOfPoint(ByVal strToSearch As String, ByRef leftStr As String, ByRef rightStr As String, _
                                           Separator As String)

        Dim posPoint As Integer = strToSearch.IndexOf(Separator.Trim())
        If posPoint <> -1 Then
            leftStr = strToSearch.Substring(0, posPoint).Trim()
            rightStr = strToSearch.Substring(posPoint + 1, strToSearch.Length - (posPoint + 1)).Trim()
        Else
            Throw New Exception("funct.getVariablesLefRightOfPoint: In variable '" + strToSearch + "' is no Separator '" + Separator.Trim() + "'!")
        End If

    End Sub
    Public Shared Function getComputerName() As String
        Return My.Computer.Name
    End Function

    Public Shared Function base64Encode(ByVal sText As String) As String
        Try
            Dim nBytes() As Byte = System.Text.Encoding.Default.GetBytes(sText)
            Return System.Convert.ToBase64String(nBytes)

        Catch ex As Exception
            Throw New Exception("funct.base64Encode: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Shared Function base64Decode(ByVal sText As String) As String
        Try
            Dim nBytes() As Byte = System.Convert.FromBase64String(sText)
            Return System.Text.Encoding.Default.GetString(nBytes)

        Catch ex As Exception
            Throw New Exception("funct.base64Decode: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

    Public Shared Function ContainsSpecialChars(s As String) As String
        Try
            Return s.IndexOfAny("[~`!@#$%^&*()-+=|{}':;.,<>/?]".ToCharArray) <> -1

        Catch ex As Exception
            Throw New Exception("funct.ContainsSpecialChars: " + vbNewLine + vbNewLine + ex.ToString())
        End Try
    End Function

End Class
