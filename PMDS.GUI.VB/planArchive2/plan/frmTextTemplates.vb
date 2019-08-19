Imports System.Windows.Forms



Public Class frmTextTemplates

    Public gen As New General()



    Private Sub frmTextTemplates2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.initControl()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Public Sub initControl()
        Try
            Me.Text = doUI.getRes("TextTemplates")

            Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.Launcher.ico_PMDS, 32, 32)
            'Me.btnOk.Appearance.Image = ITSCont.core.SystemDb.getRes.getImage(getRes.ePicture.ico_OK, getRes.ePicTyp.ico)

            Me.ContTextTemplates1.modalWindow = Me
            Me.ContTextTemplates1.initControl()

            Me.CancelButton = Me.ContTextTemplates1.btnClose

        Catch ex As Exception
            Throw New Exception("frmTextTemplates.initControl: " + ex.ToString())
        End Try
    End Sub

    Private Sub frmTextTemplates2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            e.Cancel = True
            Me.Visible = False

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

End Class