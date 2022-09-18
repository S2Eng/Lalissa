Imports qs2.core.vb
Imports qs2.Resources


Public Class frmAddIns




    Private Sub frmAdjustMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub initControl()
        Try
            Me.Text = qs2.core.language.sqlLanguage.getRes("AddInManager")
            Me.ContAddIns1.initControl()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub frmAddIns_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Me.Visible Then
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class