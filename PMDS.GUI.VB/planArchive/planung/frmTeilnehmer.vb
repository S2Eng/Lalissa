Imports PMDS.Global
Imports Infragistics.Win.UltraWinTree
Imports System.Windows.Forms



Public Class frmTeilnehmer

    Public selList As String = ""
    Private gruppe As New compSql
    Private benutzer As New compSql
    Public apport As Boolean = True

    Public gen As New GeneralArchiv()





    Private Sub frmTeilnehmer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.loadList("")

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub txtSuche_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSuche.ValueChanged
        Try
            Me.loadList(Trim(txtSuche.Text))

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Public Sub loadList(ByVal searchTxt As String)
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.gruppe.dtGruppen.Rows.Clear()
            Me.benutzer.tBenutzer.Rows.Clear()
            Me.UTreeTeilnehmer.Nodes.Clear()

            If Me.UOptionSetArt.Value = "G" Then
                Me.gruppe.alleGruppenLesen(searchTxt)
                For Each r As DataRow In Me.gruppe.dtGruppen.Rows
                    Dim n As UltraTreeNode = Me.UTreeTeilnehmer.Nodes.Add(r("Bezeichnung"), r("Bezeichnung"))
                    n.Override.NodeAppearance.Image = Me.ImageList1.Images(0)
                Next

            ElseIf Me.UOptionSetArt.Value = "B" Then
                Me.benutzer.alleBenutzerLesen(searchTxt)
                For Each r As DataRow In Me.benutzer.tBenutzer.Rows
                    Dim n As UltraTreeNode = Me.UTreeTeilnehmer.Nodes.Add(r("Benutzer"), r("Benutzer"))
                    n.Override.NodeAppearance.Image = Me.ImageList1.Images(1)
                Next

            End If

        Catch ex As Exception
            Throw New Exception("loadList: " + ex.ToString())
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UButtonAbbrechen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonAbbrechen.Click
        Try
            Me.Close()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub
    Private Sub UButtonEinladen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UButtonEinladen.Click
        Try
            For Each n As UltraTreeNode In Me.UTreeTeilnehmer.Nodes
                If n.CheckedState = CheckState.Checked Then
                    Me.selList += n.Text.ToString + ";"
                End If
            Next

            Me.apport = False
            Me.Close()

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

    Private Sub UOptionSetArt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UOptionSetArt.ValueChanged
        Try
            If UOptionSetArt.Focused Then
                txtSuche.Text = ""
                Me.loadList("")
            End If

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        End Try
    End Sub

End Class