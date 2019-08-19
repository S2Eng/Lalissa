


Public Class frmImportGibodat


    Private Sub btn_Start_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Start.Click

        Dim doImport As New DoImport
        doImport.RunImport(Me)

        Me.btn_Start.Visible = False
        Me.lblFertig.Text = "Fertig. Bitte das Fenster schließen."
        Me.lblFertig.Visible = True

    End Sub

    Private Sub frmImportGibodat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not DesignMode Then
            Dim ControlManagment1 As New QS2.Desktop.ControlManagment.ControlManagment()
            ControlManagment1.autoTranslateForm(Me)
        End If
    End Sub
End Class