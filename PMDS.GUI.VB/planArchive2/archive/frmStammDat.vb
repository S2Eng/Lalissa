Imports System.Windows.Forms
Imports System.Drawing



Public Class frmStammDat

    Private gen As New General




    Private Sub ArchivStammdatenForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Text = doUI.getRes("folderArchiv")

            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32)

            Me.Show()

            Me.Cursor = Cursors.WaitCursor
            Dim dbwork As New db()

            Me.ContStammdaten1.mainForm = Me
            Me.ContStammdaten1.initForm()


        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ArchivStammdatenForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

End Class