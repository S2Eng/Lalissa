Imports Infragistics.Win.UltraWinTree



Public Class frmBiografieAdd


    Public abort As Boolean = True
    Public modalWindow As ucBiografie



    Private Sub frmBiografieAdd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Runtime Then
            Dim ControlManagment1 As New QS2.Desktop.ControlManagment.ControlManagment()
            ControlManagment1.autoTranslateForm(Me)
        End If
        Me.Visible = False
        Me.loadList()
    End Sub
    Public Sub loadList()
        Dim strOp As New clStringOperate

        For Each f As String In System.IO.Directory.GetFiles(PMDS.Global.ENV.path_BiografieVorlagen)
            If LCase(strOp.GetFiletyp(f)) = ".rtf" Then
                Dim nod As UltraTreeNode = Me.uTreeBiografien.Nodes.Add(strOp.GetFileName(f, False), Microsoft.VisualBasic.Left(strOp.GetFileName(f, False), Len(strOp.GetFileName(f, False)) - 4))
                nod.Tag = f
            End If
        Next

    End Sub


    Private Sub btnAbbrechen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbbrechen.Click
        Me.Close()

    End Sub

    Private Sub btnNeu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNeu.Click
        addBiografie()
    End Sub

    Private Sub uTreeBiografien_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles uTreeBiografien.DoubleClick
        addBiografie()
    End Sub


    Private Sub addBiografie()

        If Not Me.uTreeBiografien.ActiveNode Is Nothing Then
            abort = False
            Me.Close()
            Me.modalWindow.loadFormularvorlage(Me.uTreeBiografien.ActiveNode.Tag)
        Else
            QS2.Desktop.ControlManagment.ControlManagment.MessageBoxVB("Keine Biografie ausgewählt!", MsgBoxStyle.Information, "Biografie hinzufügen")
        End If

    End Sub


End Class