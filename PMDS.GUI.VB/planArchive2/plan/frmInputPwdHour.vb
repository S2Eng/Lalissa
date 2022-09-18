
Public Class frmInputPwdHour

    Public abort As Boolean = True
    Public pwdOK As Boolean = False
    Public actTime As New DateTime()
    Public doUI1 As New doUI()





    Private Sub frmInputPwdvb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.Text = doUI.getRes("PMDS") + " - " + doUI.getRes("InputPassword")

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            actTime = System.DateTime.Now
            Me.ultraStatusBar1.Panels(0).Text = doUI.getRes("CurrentTime") + ": " + ": " + actTime.ToString("g")

            Me.AcceptButton = Me.btnOK
            Me.CancelButton = Me.btnAbort
            Me.txtPwdEntered.Focus()

            Me.loadRes()

        Catch ex As Exception
            General.getExep(ex)
        End Try
    End Sub
    Public Sub loadRes()
        Try
            Me.btnOK.Appearance.Image = QS2.Resources.getRes.getImage(QS2.Resources.getRes.Allgemein.ico_OK, 32, 32)
            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32)

        Catch ex As Exception
            Throw New Exception("frmInputPwdHour.loadRes: " + ex.ToString())
        End Try
    End Sub

    Private Sub btnAbort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbort.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.Close()

        Catch ex As Exception
            General.getExep(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Me.abort = False
            If Me.txtPwdEntered.Text.Length > 2 Then
                Dim sActHour As String = IIf(Me.actTime.Hour >= 10, Me.actTime.Hour.ToString(), "0" + Me.actTime.Hour.ToString())
                If Me.txtPwdEntered.Text.Substring(0, Me.txtPwdEntered.Text.Length - 2).Equals(QS2.license.core.Encryption.keyForEncryptingStrings) And Me.txtPwdEntered.Text.Substring(Me.txtPwdEntered.Text.Length - 2, 2).Equals(sActHour) Then
                    Me.pwdOK = True
                    Me.Close()
                Else
                    doUI.doMessageBox2("PasswordIsWrong", "", "!")
                    Me.txtPwdEntered.Focus()
                End If
            End If

        Catch ex As Exception
            General.getExep(ex)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub txtPwdEntered_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles txtPwdEntered.KeyDown
        QS2.core.generic.TogglePassword(sender)
    End Sub
End Class