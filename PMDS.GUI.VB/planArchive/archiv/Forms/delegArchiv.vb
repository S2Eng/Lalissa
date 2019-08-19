

Public Class dArchiv

    Private gen As New GeneralArchiv
    Private Deleg As Funct
    Delegate Sub Funct()





    Public Sub RegisterDelegate(ByVal d As Funct)
        Try
            Deleg = d

        Catch ex As Exception
            Throw New Exception("RegisterDelegate: " + ex.ToString())
        End Try
    End Sub
    Public Sub UnRegisterDelegate()
        Try
            Deleg = Nothing

        Catch ex As Exception
            Throw New Exception("UnRegisterDelegate: " + ex.ToString())
        End Try
    End Sub
    Public Sub UseDelegate()
        Try
            If Not Deleg Is Nothing Then
                Deleg.Invoke()
            End If

        Catch ex As Exception
            Throw New Exception("UseDelegate: " + ex.ToString())
        End Try
    End Sub

End Class
