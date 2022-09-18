Imports qs2.core.vb
Imports qs2.Resources
Imports System



Public Class frmLockApplication

    Public closeApplication As Boolean = False
    Public Encryption1 As New qs2.license.core.Encryption()
    Public checkSupervisorPwd As Boolean = False
    Public PwdOK As Boolean = False

    Public AutoControlsUI1 As New qs2.design.auto.workflowAssist.autoForm.AutoControlsUI()





    Private Sub frmLockApplication_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.AcceptButton = Me.btnUnlock

            Me.Icon = getRes.getIcon(qs2.Resources.getRes.ePicture.ico_lock, 32, 32)
            Me.btnCloseApp.Appearance.Image = getRes.getIcon(qs2.Resources.getRes.Allgemein.ico_Beenden, 32, 32)
            Me.btnCloseApp.Text = qs2.core.language.sqlLanguage.getRes("Close")

            Me.btnUnlock.initControl()

            Me.loadRes()

            If Me.checkSupervisorPwd Then
                Me.btnCloseApp.Visible = False
                Me.lblTitle.Visible = False
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Private Sub frmLockApplication_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If Not Me.checkSupervisorPwd Then
                If Not Me.closeApplication Then
                    If Not Me.closeLock() Then
                        e.Cancel = True
                    End If
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub loadRes()
        Try
            Me.Text = "QS2 - " + qs2.core.language.sqlLanguage.getRes("Locked")

            Me.lblTitle.Text = qs2.core.language.sqlLanguage.getRes("ApplicationIsLocked") + "!"

            If Not IsNothing(qs2.core.vb.actUsr.rUsr) Then
                Me.lblUserLoggedOn.Text = qs2.core.language.sqlLanguage.getRes("User") + ": " + qs2.core.vb.actUsr.rUsr.UserName + ""
            End If
            Me.lblPassword.Text = qs2.core.language.sqlLanguage.getRes("Password")
            Me.btnUnlock.Text = qs2.core.language.sqlLanguage.getRes("Unlock")

            Dim info As New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            info.ToolTipTitle = ""
            info.ToolTipText = qs2.core.language.sqlLanguage.getRes("CloseApplication2")
            Me.UltraToolTipManager1.SetUltraToolTip(Me.btnCloseApp, info)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Function validateData() As Boolean
        Try
            Me.errorProvider1.SetError(Me.txtPassword, "")

            If Me.checkSupervisorPwd Then
                Return Me.validateDataSupervisor()
            Else
                If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                    Return Me.validateDataSupervisor()
                Else
                    If qs2.core.ENV.LoggedInAsDomainUser Then
                        Dim actUsr1 As New qs2.core.vb.actUsr()
                        Dim checkPwdDomain As Boolean = actUsr1.ValidateActiveDirectoryLogin(actUsr.rUsr.UserNameDomain.Trim(), Me.txtPassword.Text)
                        If Not checkPwdDomain Then
                            Me.errorProvider1.SetError(Me.txtPassword, qs2.core.generic.incorrSel)
                            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("PasswordWrong") + "!", System.Windows.Forms.MessageBoxButtons.OK, "")
                            Me.txtPassword.Focus()
                            Return False
                        End If
                    Else
                        Dim PasswordDBDecrypted As String = Me.Encryption1.StringDecrypt(qs2.core.vb.actUsr.rUsr.Password, qs2.license.core.Encryption.keyForEncryptingStrings)
                        If Not Me.txtPassword.Text.Trim().Equals(PasswordDBDecrypted.Trim()) Then
                            Me.errorProvider1.SetError(Me.txtPassword, qs2.core.generic.incorrSel)
                            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("PasswordWrong") + "!", System.Windows.Forms.MessageBoxButtons.OK, "")
                            Me.txtPassword.Focus()
                            Return False
                        End If
                    End If
                End If
            End If

            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function
    Public Function validateDataSupervisor() As Boolean
        Try
            'Dim sHour As String = Now.Hour.ToString()
            'If sHour.Trim().Length = 1 Then
            '    sHour = "0" + sHour.Trim()
            'End If
            'Dim PasswordSupervisor As String = qs2.license.core.Encryption.keyForEncryptingStrings + sHour.Trim()
            'If Not Me.txtPassword.Text.Trim().Equals(PasswordSupervisor) Then

            If Not Me.txtPassword.Text.Trim().Equals(qs2.license.core.Encryption.keyForEncryptingStrings + DateTime.Now.ToString("HH")) Then
                Me.errorProvider1.SetError(Me.txtPassword, qs2.core.generic.incorrSel)
                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("PasswordWrong") + "!", System.Windows.Forms.MessageBoxButtons.OK, "")
                Me.txtPassword.Focus()
                Return False
            End If

            Return True

        Catch ex As Exception
            Throw New Exception("validateDataSupervisor: " + ex.ToString())
        End Try
    End Function

    Private Sub btnUnlock_Click(sender As System.Object, e As System.EventArgs) Handles btnUnlock.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            If Me.checkSupervisorPwd Then
                If Me.validateData() Then
                    Me.PwdOK = True
                    Me.Close()
                End If
            Else
                Me.Close()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Function closeLock() As Boolean
        Try
            If Not Me.validateData() Then
                Return False
            End If

            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Function

    Private Sub btnCloseApp_Click_1(sender As Object, e As EventArgs) Handles btnCloseApp.Click
        Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            If Me.checkSupervisorPwd Then
                Me.Close()
            Else
                Dim resMsgBox As System.Windows.Forms.DialogResult = qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("CloseApplication") + "?", System.Windows.Forms.MessageBoxButtons.YesNo, "")
                If resMsgBox = System.Windows.Forms.DialogResult.Yes Then
                    Me.closeApplication = True
                    Me.Close()
                End If
            End If


        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub frmLockApplication_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Me.Visible Then
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        qs2.core.generic.TogglePassword(sender)
    End Sub
End Class