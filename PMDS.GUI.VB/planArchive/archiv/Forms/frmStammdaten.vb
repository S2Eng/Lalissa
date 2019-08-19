Imports PMDS.db.Global
Imports PMDS.Global
Imports System.Windows.Forms



Public Class frmStammdaten

    Private gen As New GeneralArchiv


    Private Sub ArchivStammdatenForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Show()

            Me.Cursor = Cursors.WaitCursor
            Dim dbwork As New db()

            Me.ContStammdaten1.mainForm = Me
            Me.ContStammdaten1.initForm()


        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub ArchivStammdatenForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

    End Sub
    Private Sub ArchivStammdatenForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub


End Class