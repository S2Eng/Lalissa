Imports System.IO
Imports System.Windows.Forms

Public Class FileFunctions

    Private Shared ressourcenFileType As String = "Pdf Files (*.pdf)|*.pdf|Rtf Files (*.rtf)|*.rtf|Microsoft Word Files (*.doc)|*.doc|Microsoft Excel Files (*.xls)|*.xls|jpg Files (*.jpg)|*.jpg|Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

    Public Shared path_temp As String = ""
    Public Shared fileTypeTxt As String = ".txt"
    Public Shared typLogFile As String = "QS2 Log-File (*.xml)|*.xml"

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

    Public Function saveFile(ByVal withDefaultTypes As Boolean, ByVal DateiTyp As String,
                             Optional ByVal fileNameDefault As String = "",
                             Optional ByVal defaultDir As String = "") As String
        Try
            If withDefaultTypes Then _
                DateiTyp = FileFunctions.ressourcenFileType

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

    Public Function GetFiletyp(ByVal File As String) As String

        Return System.IO.Path.GetExtension(File)
    End Function

    Public Function GetDir(ByVal File As String) As String
        Return System.IO.Path.GetFullPath(File)
    End Function

    Public Function SaveFileDialog(ByVal DateiTyp As String, ByVal rootVerzeichnis As String) As String

        Dim SaveFileD As New SaveFileDialog
        Dim File As String
        Dim Pfad As String

        SaveFileD.InitialDirectory = rootVerzeichnis
        SaveFileD.Filter = DateiTyp        '"Microsoft Excel Dateien (*.xls)|*.xls"
        SaveFileD.FilterIndex = 1
        SaveFileD.RestoreDirectory = True

        If SaveFileD.ShowDialog() = DialogResult.OK Then
            File = SaveFileD.FileName
            Return File
        End If

    End Function

    Public Function SelectFileDialog(ByVal DateiTyp As String, ByVal rootVerzeichnis As String) As String

        Dim openFileDialog As New OpenFileDialog
        Dim File As String
        Dim Pfad As String
        openFileDialog.InitialDirectory = ""
        If rootVerzeichnis <> "" And System.IO.Directory.Exists(rootVerzeichnis) Then
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

    Public Function saveFileFromBytes(ByVal fileToSave As String, ByVal byteStream() As Byte, ByVal msgBox As Boolean) As Boolean

        Me.saveFileFromBytes(fileToSave, byteStream)
        Return True
    End Function

    Public Function saveFileFromBytes(ByVal fileToSave As String, ByVal byteStream() As Byte) As Boolean

        'Dim file As String = Me.GetFileName(path, True)
        Dim fs As IO.FileStream = New IO.FileStream(fileToSave, IO.FileMode.Create)
        Dim b() As Byte = byteStream
        fs.Write(b, 0, b.Length)
        fs.Close()
        Return True

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

End Class
