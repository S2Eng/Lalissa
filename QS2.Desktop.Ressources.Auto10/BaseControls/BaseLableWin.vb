

Public Class BaseLableWin

    Public doBaseElements1 As New doBaseElements()
    Public IsLoaded As Boolean = False
    Public rRes As QS2.core.language.dsLanguage.RessourcenRow = Nothing
    Public IDRes As String = ""
    Public DoIDResAuto As Boolean = True




    Private Sub BaseLableWin_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            Me.doBaseElements1.runControlManagment(Me.IDRes, Me, Me.contextMenuStrip1, Me.IsLoaded, rRes, True, False, Me.DoIDResAuto)

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub

    Private Sub BaseLableWin_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        Try

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub
End Class
