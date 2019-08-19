Imports System.Windows.Forms


Public Class frmArchivAbleg

    Private gen As New GeneralArchiv
    Public contArchivDokumentAblegen As New contArchivAbleg
    Public IDOrdnerToSelect As System.Guid




    Private Sub ArchivDokumentAblegenForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.PanelAll.Controls.Add(Me.contArchivDokumentAblegen)
            Me.contArchivDokumentAblegen.mainWindow = Me
            Me.contArchivDokumentAblegen.parentWindow = Me
            Me.contArchivDokumentAblegen.initForm(IDOrdnerToSelect)

            Me.AcceptButton = Me.contArchivDokumentAblegen.UltraButtonSpeichern
            Me.CancelButton = Me.contArchivDokumentAblegen.UltraButtonAbbrechen

            Me.contArchivDokumentAblegen.ResizeControl(Me.PanelAll.Height, Me.PanelAll.Width)

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub ArchivDokumentAblegenForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Try
            Me.contArchivDokumentAblegen.ResizeControl(Me.PanelAll.Height, Me.PanelAll.Width)

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
        End Try
    End Sub
    Private Sub ArchivDokumentAblegenForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Public Sub selectOrdnerxy(ByVal IDOrdner As System.Guid)
        Try
            'Me.contArchivDokumentAblegen.selectOrdner(IDOrdner)

        Catch ex As Exception
            Throw New Exception("selectOrdner: " + ex.ToString())
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
            Me.contArchivDokumentAblegen.ResizeControl(Me.PanelAll.Height, Me.PanelAll.Width)

        Catch ex As Exception
            Throw New Exception("showErweitertEinAus: " + ex.ToString())
        End Try
    End Sub

End Class