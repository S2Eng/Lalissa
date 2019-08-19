

Public Class ControlInfo


    Private Sub ControlInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CancelButton = Me.btnClose
    End Sub

    Public Sub loadData(cont As System.Windows.Forms.Control, ByRef IDRes As String, ByRef IsStandardControl As Boolean)
        Me.lblTypeControl.Text += " " + cont.GetType().ToString()
        Me.lblIDRes.Text += " " + IDRes
        Me.lblIsStandardControl.Text += " " + IsStandardControl.ToString()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


End Class