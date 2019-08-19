


Public Class frmUserAccounts


    Private Sub frmUserAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl()
        Try
            Me.Text = doUI.getRes("UserAccounts")

            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32)
            'Me.btnOk.Appearance.Image = ITSCont.core.SystemDb.getRes.getImage(getRes.ePicture.ico_OK, getRes.ePicTyp.ico)
            Me.ContUserAccouts1.initControl()


        Catch ex As Exception
            Throw New Exception("frmUserAccounts.initControl: " + ex.ToString())
        End Try
    End Sub

End Class