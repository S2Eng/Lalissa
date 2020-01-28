Imports System.Windows.Forms


Public Class frmDocuEdit

    Public abort As Boolean = True
    Public _IDDokumenteneintrag As Guid = Nothing
    Public b As New PMDS.db.PMDSBusiness()


    Private Sub frmDocuEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Public Sub initForm(ByVal IDDokumenteneintrag As System.Guid)
        Try
            Me._IDDokumenteneintrag = IDDokumenteneintrag

            Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.Launcher.ico_PMDS, 32, 32)
            Me.AcceptButton = Me.UltraButtonSpeichern
            Me.CancelButton = Me.UltraButtonAbbrechen

            Me.loadData()

        Catch ex As Exception
            Throw New Exception("frmDocuEdit.initForm: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadData()
        Try
            Using db2 As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                Dim r As PMDS.db.Entities.tblDokumenteintrag = b.getDokumenteneintrag(Me._IDDokumenteneintrag, db2)
                Me.txtDocuName.Text = r.Bezeichnung.Trim()
            End Using

        Catch ex As Exception
            Throw New Exception("frmDocuEdit.loadData: " + ex.ToString())
        End Try
    End Sub

    Public Function saveData() As Boolean
        Try
            Me.ErrorProvider1.SetError(Me.txtDocuName, "")

            If Me.txtDocuName.Text.Trim() = "" Then
                Dim txt As String = qs2.Desktop.ControlManagment.ControlManagment.getRes("Dokumentenbezeichnung: Eingabe erforderlich!")
                Me.ErrorProvider1.SetError(Me.txtDocuName, txt)
                qs2.Desktop.ControlManagment.ControlManagment.MessageBox(txt, "PMDS", MessageBoxButtons.OK, True)
                Me.txtDocuName.Focus()
                Return False
            End If

            Using db2 As PMDS.db.Entities.ERModellPMDSEntities = PMDS.db.PMDSBusiness.getDBContext()
                Dim r As PMDS.db.Entities.tblDokumenteintrag = b.getDokumenteneintrag(Me._IDDokumenteneintrag, db2)
                r.Bezeichnung = Me.txtDocuName.Text.Trim()
                db2.SaveChanges()
            End Using

            Return True

        Catch ex As Exception
            Throw New Exception("frmDocuEdit.saveData: " + ex.ToString())
        End Try
    End Function


    Private Sub UltraButtonSpeichern_Click(sender As Object, e As EventArgs) Handles UltraButtonSpeichern.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.saveData() Then
                Me.abort = False
                Me.Close()
            End If

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub UltraButtonAbbrechen_Click(sender As Object, e As EventArgs) Handles UltraButtonAbbrechen.Click
        Dim gen As New GeneralArchiv
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.abort = True
            Me.Close()

        Catch ex As Exception
            gen.GetEcxeptionArchiv(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class