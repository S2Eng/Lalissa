

Public Class clStringOperate

    Public gen As New GeneralArchiv()




    Public Function GetDir(ByVal File As String) As String
        Try

            If Me.gen.IsNull(File) Then Return ""

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

        Catch ex As Exception
            Throw New Exception("GetDir: " + ex.ToString())
        End Try
    End Function

    Public Function GetFileName(ByVal File As String, ByVal ohneEndung As Boolean) As String
        Try

            If Me.gen.IsNull(File) Then Return ""

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

        Catch ex As Exception
            Throw New Exception("GetFileName: " + ex.ToString())
        End Try
    End Function
    Private Function GetFileName_ohneTyp(ByVal sName As String) As String
        Try
            If gen.IsNull(sName) Then Return sName

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
            Throw New Exception("GetFileName_ohneTyp: " + ex.ToString())
        End Try
    End Function
    Public Function GetFiletyp(ByVal File As String) As String
        Try

            If gen.IsNull(File) Then Return ""

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

        Catch ex As Exception
            Throw New Exception("GetFiletyp: " + ex.ToString())
        End Try
    End Function

End Class

