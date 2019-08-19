'Imports ITSCont.core.SystemDb



Public Class frmMailInputSrv

    Private gen As New General



    Private Sub frmMailInputSrv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Text = doUI.getRes("ImportEMailFromAnInboxServer")

            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32)

            Me.AcceptButton = Me.ContMailInputSrv1.btnReadMails
            Me.CancelButton = Me.ContMailInputSrv1.btnClose

            Me.ContMailInputSrv1.mainWindow = Me
            Me.ContMailInputSrv1.initControl()

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub


End Class