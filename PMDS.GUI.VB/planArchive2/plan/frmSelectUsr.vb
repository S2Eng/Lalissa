

Public Class frmSelectUsr

    Public gen As New General()
    Public abort As Boolean = True
    Public doUI1 As New doUI()






    Private Sub frmSelectUsr_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = doUI.getRes("SelectUser")

            Me.AcceptButton = btnOk
            Me.CancelButton = btnAbrechen

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32)
            Me.btnOk.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)

            Me.gen.getAllSachb(Me.cboUsers, Nothing)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub


    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try
            If Me.cboUsers.Text.Trim() <> "" Then
                Me.abort = False
                Me.Close()
            Else
                doUI.doMessageBox2("UserInputRequired", "", "!")
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub btnAbrechen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbrechen.Click
        Try
            Me.Close()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

End Class