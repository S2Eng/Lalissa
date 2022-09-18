

Public Class frmSys

    Public b As New qs2.core.vb.businessFramework()

    Private Sub frmSys_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl()
        Try
            Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.Allgemein.ico_Table, 32, 32)

        Catch ex As Exception
            Throw New Exception("frmSys.initControl: " + ex.ToString())
        End Try
    End Sub

End Class