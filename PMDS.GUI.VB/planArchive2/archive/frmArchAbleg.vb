Imports System.Windows.Forms
Imports System.Drawing



Public Class frmArchAbleg

    Private gen As New General
    Public IDOrdnerToSelect As System.Guid




    Private Sub ArchivDokumentAblegenForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.Text = doUI.getRes("StoreADocument")

            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32)

            Me.ContArchAbleg1.mainWindow = Me
            Me.ContArchAbleg1.parentWindow = Me
            Me.ContArchAbleg1.initForm(IDOrdnerToSelect)

            Me.AcceptButton = Me.ContArchAbleg1.btnSave
            Me.CancelButton = Me.ContArchAbleg1.UltraButtonAbbrechen

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub ArchivDokumentAblegenForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            'Me.ContArchAbleg1.ResizeControl(Me.Panel1.Height, Me.Panel1.Width)

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub
    Private Sub ArchivDokumentAblegenForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub

    Public Sub selectOrdnerxy(ByVal IDOrdner As System.Guid)
        Try
            'Me.contArchivDokumentAblegen.selectOrdner(IDOrdner)

        Catch ex As Exception
            Throw New Exception("frmArchAbleg.selectOrdner: " + ex.ToString())
        End Try
    End Sub

    Public Sub showErweitertEinAus(ByVal bOn As Boolean)
        Try
            If Not bOn Then
                Me.Width = 752
                Me.Left = Me.Left - 255
            Else
                Me.Width = 385
                Me.Left = Me.Left + 255
            End If
            Application.DoEvents()
            'Me.ContArchAbleg1.ResizeControl(Me.Panel1.Height, Me.Panel1.Width)

        Catch ex As Exception
            Throw New Exception("frmArchAbleg.showErweitertEinAus: " + ex.ToString())
        End Try
    End Sub

End Class