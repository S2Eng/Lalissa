Imports qs2.core.vb
Imports qs2.Resources



Public Class frmSelectObject



    Private Sub frmSelectObject_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl()
        Try
            Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.Allgemein.ico_ChooseAll, 32, 32)
            Me.Text = qs2.core.language.sqlLanguage.getRes("SelectObject")

            Me.ContSelectObject1.mainWindow = Me
            Me.ContSelectObject1.initControl()

        Catch ex As Exception
            Throw New Exception("frmSelectObject.initControl: " + ex.ToString())
        End Try
    End Sub

End Class