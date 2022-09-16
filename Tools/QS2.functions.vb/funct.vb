Imports System.Windows.Forms
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports System

Imports System.Text
Imports Microsoft.VisualBasic

Imports Microsoft.Win32





Public Class funct

    Public Shared xmlFileType As String = "XML Files (*.xml)|*.xml"
    Public Shared xsdFileType As String = "XSD Files (*.xsd)|*.xsd"
    Public Shared excelFileType As String = "Microsoft Excel Files (*.xls)|*.xls"
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
    Public Shared typLogFile As String = "QS2 Log-File (*.xml)|*.xml"


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








    Public Shared Sub getExcept(ex As String, title As String)
        MessageBox.Show(ex, "Error", MessageBoxButtons.OK)
    End Sub


    Public Function getFileName(ByVal File As String, ByVal ohneEndung As Boolean) As String
        Try

            If File = "" Then Return ""

            If ohneEndung Then
                Return Path.GetFileNameWithoutExtension(File)
            Else
                Return Path.GetFileName(File)
            End If

            'geändert os, 22.2.2011
            'Dim pos As Integer = 1
            'Dim pos_Prev As Integer = 0
            'Dim Apport As Boolean = False
            'While pos <> 0
            '    pos = Microsoft.VisualBasic.InStr(pos + 1, File, "\", CompareMethod.Text)
            '    If pos <> 0 Then pos_Prev = pos
            'End While

            'If pos_Prev > 0 Then
            '    Dim sName As String = Microsoft.VisualBasic.Right(File, Microsoft.VisualBasic.Len(File) - (pos_Prev))
            '    If ohneEndung Then
            '        sName = Me.getFileNameWithoutTyp(sName)
            '    End If
            '    Return sName
            'Else
            '    Return ""
            'End If

        Catch ex As Exception
            Throw New Exception("funct.getFileName:" + vbNewLine + vbNewLine + ex.ToString())
            Return ""
        Finally
        End Try
    End Function
    Public Function getFileNameWithoutTyp(ByVal sName As String) As String
        Try
            If sName = "" Then Return sName

            Dim pos As Integer = 1
            Dim pos_Prev As Integer = 0
            Dim Apport As Boolean = False
            While pos <> 0
                pos = Microsoft.VisualBasic.InStr(pos + 1, sName, ".", CompareMethod.Text)
                If pos <> 0 Then pos_Prev = pos
            End While

            If pos_Prev > 0 Then
                Return Microsoft.VisualBasic.Left(sName, pos_Prev - 1)
            Else
                Return ""
            End If

        Catch ex As Exception
            Throw New Exception("funct.getFileNameWithoutTyp:" + vbNewLine + vbNewLine + ex.ToString())
            Return ""
        Finally
        End Try

    End Function
    Public Function getFiletyp(ByVal File As String) As String
        Try
            If File = "" Then Return ""

            Return Path.GetExtension(File)

            'geändert os, 22.2.2011
            'Dim pos As Integer = 1
            'Dim pos_Prev As Integer = 0
            'Dim Apport As Boolean = False
            'While pos <> 0
            '    pos = Microsoft.VisualBasic.InStr(pos + 1, File, ".", CompareMethod.Text)
            '    If pos <> 0 Then pos_Prev = pos
            'End While

            'If pos_Prev > 0 Then
            '    Return Microsoft.VisualBasic.Right(File, Microsoft.VisualBasic.Len(File) - ((pos_Prev) - 1))
            'Else
            '    Return ""
            'End If

        Catch ex As Exception
            Throw New Exception("funct.getFiletyp:" + vbNewLine + vbNewLine + ex.ToString())
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


    Public Function getDir(ByVal File As String) As String
        Try
            If File = "" Then Return ""

            Return Path.GetFullPath(File)

            'geändert os, 22.2.2011
            'Dim pos As Integer = 1
            'Dim pos_Prev As Integer = 0
            'Dim Apport As Boolean = False
            'While pos <> 0
            '    pos = Microsoft.VisualBasic.InStr(pos + 1, File, "\", CompareMethod.Text)
            '    If pos <> 0 Then pos_Prev = pos
            'End While

            'If pos_Prev > 0 Then
            '    Return Microsoft.VisualBasic.Left(File, pos_Prev)
            'Else
            '    Return ""
            'End If

        Catch ex As Exception
            Throw New Exception("funct.getDir:" + vbNewLine + vbNewLine + ex.ToString())
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
    Public Shared Function getFolder(ByVal typ As System.Environment.SpecialFolder) As String
        Return System.Environment.GetFolderPath(typ)
    End Function
    Public Shared Function GetAppFolder() As String
        Return System.Environment.CurrentDirectory
    End Function


    Public Function openFile(ByVal file As String, ByVal dateiTyp As String, ByVal openTemporär As Boolean, PathTemp As String) As Boolean
        Me.openFile(file, dateiTyp, openTemporär, False, False, False, Nothing, PathTemp)
    End Function
    Public Function openFile(ByVal file As String, ByVal dateiTyp As String, ByVal openTemporär As Boolean, _
                      ByVal openIntern As Boolean, _
                       ByVal withMsgBox As Boolean, ByVal printFile As Boolean, binIntern() As Byte, PathTemp As String) As Boolean

        If System.IO.File.Exists(file) Then
            Dim dateiTemp As String = ""
            If openTemporär Then
                Dim IDNewFileNameTemp As New System.Guid
                IDNewFileNameTemp = System.Guid.NewGuid
                dateiTemp = PathTemp + "\" + IDNewFileNameTemp.ToString + dateiTyp
                System.IO.File.Copy(file, dateiTemp)
            Else
                dateiTemp = file
            End If
            If dateiTyp.Trim() = "" Then
                Dim cl As New funct()
                dateiTyp = cl.getFiletyp(file)
            End If

            If Not printFile Then
                System.Diagnostics.Process.Start(file)
                Return True
            Else
                Me.printFile(file)
                Return True
            End If

        Else
            If withMsgBox Then
                MsgBox("File does not exist", MsgBoxStyle.Information, "Open file")
            End If
            Return False
        End If

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
 
    Public Function saveFileAs(ByVal file As String, ByVal dateiTyp As String) As Boolean

        If dateiTyp.Trim() = "" Then
            Dim cl As New funct()
            dateiTyp = cl.GetFiletyp(file)
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
        fileToSave = Me.SaveFileDialog(fileList, "")
        If Not fileToSave.Trim() = "" Then
            If System.IO.File.Exists(fileToSave) Then
                System.IO.File.Delete(fileToSave)
            End If
            System.IO.File.Copy(file, fileToSave)
            MessageBox.Show("File saved!", "Save file", MessageBoxButtons.OK)
            Return True
        End If

    End Function
    Public Function SaveFileDialog(ByVal DateiTyp As String, ByVal rootVerzeichnis As String) As String

        Dim SaveFileD As New SaveFileDialog
        Dim File As String
        Dim Pfad As String

        SaveFileD.InitialDirectory = rootVerzeichnis
        SaveFileD.Filter = DateiTyp
        SaveFileD.FilterIndex = 1
        SaveFileD.RestoreDirectory = True

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
        Dim Pfad As String
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
            Dim fileTyp As String = Me.getFiletyp(fileToSave)
            Dim dirToSave As String = Me.getDir(fileToSave)
            fileToSave = Me.getFileName(fileToSave, True)
            Me.saveFileFromBytes(dirToSave, fileToSave, fileTyp, byteStream)
            If msgBox Then
                MessageBox.Show("File was saved!", "", MessageBoxButtons.OK)
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
            Throw New Exception("getVariablesLefRightOfPoint: In variable '" + strToSearch + "' is no Separator '" + Separator.Trim() + "'!")
        End If

    End Sub
    Public Shared Function getComputerName() As String
        Return My.Computer.Name
    End Function

End Class
