Imports qs2.core.vb
Imports qs2.Resources



Public Class frmCheckUsercode

    Public abort As Boolean = True
    Public businessFramework1 As New qs2.core.db.ERSystem.businessFramework()
    Public UserIDFound As Integer = -999

    Public _eTypeUI As eTypeUI = eTypeUI.UserCode
    Public Enum eTypeUI
        UserCode = 0
        UsercodeAndKavVidierungPwd = 1
    End Enum






    Private Sub frmCheckUsercode_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl(TypeUI As eTypeUI, IDResTitel As String)
        Try
            Me._eTypeUI = TypeUI

            Me.btnOK.initControl()
            Me.btnCancel.initControl()

            Me.CancelButton = Me.btnCancel
            Me.AcceptButton = Me.btnOK

            Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.Launcher.ico_QS2, 32, 32)
            Me.loadRes()

            If Me._eTypeUI = eTypeUI.UserCode Then
                Me.lblKavVidierungPwd.Visible = False
                Me.txtKavVidierungPwd.Visible = False
                Me.Height = 128
            Else
                Me.lblKavVidierungPwd.Visible = True
                Me.txtKavVidierungPwd.Visible = True
            End If

            Me.Text = qs2.core.language.sqlLanguage.getRes(IDResTitel.Trim())

        Catch ex As Exception
            Throw New Exception("initControl: " + ex.ToString())
        End Try
    End Sub
    Public Sub loadRes()
        Try
            Me.btnOK.Text = qs2.core.language.sqlLanguage.getRes("OK")
            Me.btnCancel.Text = qs2.core.language.sqlLanguage.getRes("Abort")
            Me.lblUsercode.Text = qs2.core.language.sqlLanguage.getRes("Usercode")
            Me.lblKavVidierungPwd.Text = qs2.core.language.sqlLanguage.getRes("KavVidierungPwd")

        Catch ex As Exception
            Throw New Exception("loadRes: " + ex.ToString())
        End Try
    End Sub

    Public Function checkUsercode() As Boolean
        Try
            Dim rObject As PMDS.db.Entities.tblObject = Nothing
            Dim MessageReturn As String = ""
            Dim UsercodeOK As Boolean = businessFramework1.checkUsercode(Me.txtUsercode.Text.Trim(), rObject, MessageReturn)
            If UsercodeOK Then
                Me.UserIDFound = rObject.ID
                Return True
            Else
                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes(MessageReturn) + "!", Windows.Forms.MessageBoxButtons.OK, "")
                Me.txtUsercode.Focus()
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("checkUsercode: " + ex.ToString())
        End Try
    End Function
    Public Function checkKavVidierungPwd() As Boolean
        Try
            Dim Encryption1 As New qs2.license.core.Encryption()
            Dim KavVidierungPwdEncrypted As String = ""
            If Me.txtKavVidierungPwd.Text.Trim() <> "" Then
                KavVidierungPwdEncrypted = Encryption1.StringEncrypt(Me.txtKavVidierungPwd.Text.Trim(), qs2.license.core.Encryption.keyForEncryptingStrings)
            End If
            Dim rObject As PMDS.db.Entities.tblObject = Nothing
            Dim MessageReturn As String = ""
            Dim KavVidierungPwdOK As Boolean = businessFramework1.checkKavVidierungPwd(KavVidierungPwdEncrypted, rObject, MessageReturn)
            If KavVidierungPwdOK Then
                Me.UserIDFound = rObject.ID
                Return True
            Else
                qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes(MessageReturn) + "!", Windows.Forms.MessageBoxButtons.OK, "")
                Me.txtKavVidierungPwd.Focus()
                Return False
            End If

        Catch ex As Exception
            Throw New Exception("checkKavVidierungPwd: " + ex.ToString())
        End Try
    End Function

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Me._eTypeUI = eTypeUI.UserCode Then
                If Me.checkUsercode() Then
                    Me.abort = False
                    Me.Close()
                End If
            ElseIf Me._eTypeUI = eTypeUI.UsercodeAndKavVidierungPwd Then
                If Me.checkUsercode() Then
                    If Me.checkKavVidierungPwd() Then
                        Me.abort = False
                        Me.Close()
                    End If
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.Close()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub frmCheckUsercode_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            Me.txtUsercode.Focus()
            Me.txtUsercode.SelectAll()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub frmCheckUsercode_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Me.Visible Then
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class