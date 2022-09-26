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

            If File = "" Then
                Return ""
            End If

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


    Public Function getDir(ByVal File As String) As String
        Try
            If File = "" Then
                Return ""
            End If

            Return Path.GetFullPath(File)

        Catch ex As Exception
            Throw New Exception("funct.getDir:" + vbNewLine + vbNewLine + ex.ToString())
            Return ""
        Finally
        End Try

    End Function

    Public Function selectFile(ByVal DateiTyp As String,
                                Optional ByVal defaultDir As String = "") As String
        Try

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
                dateiTyp = System.IO.Path.GetExtension(file)
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

    Public Function getFilename(ByVal path As String, ByVal fileName As String, ByVal fileType As String, ByVal nr As String) As String
        Try
            Dim file As String = path + "\" + fileName + If(nr = 0, "", nr.ToString()) + fileType
            Try
                System.IO.File.Delete(file)
                Return file
            Catch ex As Exception
                Return Me.getFilename(path, fileName, fileType, nr + 1)
            End Try

        Catch ex As Exception
            Return Me.getFilename(path, fileName, fileType, nr + 1)
        Finally
        End Try
    End Function
End Class
