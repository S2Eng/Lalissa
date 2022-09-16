Imports System.Windows.Forms



Public Class functOld

    Public Shared path_logging As String = ""
    Public Shared path_temp As String = ""

    Public Shared MailServiceCenter As String = "ServiceCenter@s2-engineering.com;"




    Public Function GetFileName(ByVal File As String, ByVal ohneEndung As Boolean) As String

        If File = "" Then Return ""

        Dim pos As Integer = 1
        Dim pos_Prev As Integer = 0
        Dim Apport As Boolean = False
        While pos <> 0
            pos = Microsoft.VisualBasic.InStr(pos + 1, File, "\", CompareMethod.Text)
            If pos <> 0 Then pos_Prev = pos
        End While

        If pos_Prev > 0 Then
            Dim sName As String = Microsoft.VisualBasic.Right(File, Microsoft.VisualBasic.Len(File) - (pos_Prev))
            If ohneEndung Then
                sName = Me.GetFileName_ohneTyp(sName)
            End If
            Return sName
        Else
            Return ""
        End If

    End Function
    Public Function GetFileName_ohneTyp(ByVal sName As String) As String

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

    End Function
    Public Function GetFiletyp(ByVal File As String) As String

        If File = "" Then Return ""

        Dim pos As Integer = 1
        Dim pos_Prev As Integer = 0
        Dim Apport As Boolean = False
        While pos <> 0
            pos = Microsoft.VisualBasic.InStr(pos + 1, File, ".", CompareMethod.Text)
            If pos <> 0 Then pos_Prev = pos
        End While

        If pos_Prev > 0 Then
            Return Microsoft.VisualBasic.Right(File, Microsoft.VisualBasic.Len(File) - ((pos_Prev) - 1))
        Else
            Return ""
        End If

    End Function
    Public Function GetDir(ByVal File As String) As String

        If File = "" Then Return ""

        Dim pos As Integer = 1
        Dim pos_Prev As Integer = 0
        Dim Apport As Boolean = False
        While pos <> 0
            pos = Microsoft.VisualBasic.InStr(pos + 1, File, "\", CompareMethod.Text)
            If pos <> 0 Then pos_Prev = pos
        End While

        If pos_Prev > 0 Then
            Return Microsoft.VisualBasic.Left(File, pos_Prev)
        Else
            Return ""
        End If

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

        Dim fileTyp As String = Me.GetFiletyp(fileToSave)
        Dim dirToSave As String = Me.GetDir(fileToSave)
        Dim fileName As String = Me.GetFileName(fileToSave, True)
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

    Public Function getFileTypForDialog(ByVal typFile As String) As String
        Return "*" + typFile + "|*" + typFile
    End Function

End Class
