Public Class frmInputPwd

    Public abort As Boolean = True
    Public pwdOK As Boolean = False

    Private Sub frmInputPwdvb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.AcceptButton = Me.btnOK3
            Me.CancelButton = Me.btnCancel3
            Me.Text = "QS2 Password (" + DateTime.Now.ToString("G") + ")"
            Me.txtPwdEntered3.Focus()

        Catch ex As Exception
            generic.getExep(ex.ToString())
        End Try
    End Sub

    Private Sub btnCancel3_Click(sender As Object, e As EventArgs) Handles btnCancel3.Click
        Me.Close()
    End Sub

    Private Sub btnOK3_Click(sender As Object, e As EventArgs) Handles btnOK3.Click
        Me.abort = False
        If Me.txtPwdEntered3.Text = Encryption.keyForEncryptingStrings + DateTime.Now.Hour.ToString("0#") Then
            Me.pwdOK = True
            Me.Close()
        Else
            System.Windows.Forms.MessageBox.Show("Password is wrong", "Error")
            Me.txtPwdEntered3.Focus()
        End If
    End Sub

End Class