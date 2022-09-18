Imports qs2.core.vb
Imports qs2.sitemap
Imports qs2.Resources



Public Class frmTranslateText


    Public IDResToTranslate As String = ""
    Public abort As Boolean = True
    Public Application As String = ""

    Public cTranslate1 As New cTranslate()





    Private Sub frmTranslateText_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.AcceptButton = Me.btnOk
            Me.CancelButton = Me.btnCancel

            Me.loadRes()

            Me.txtTranslationForIDResGerman.SelectAll()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub loadRes()
        Try
            Me.btnOk.initControl()
            Me.btnCancel.initControl()

            Me.Text = qs2.core.language.sqlLanguage.getRes("InputTranslation")

            Me.lblTranslationGerman.Text = qs2.core.language.sqlLanguage.getRes("German")
            Me.lblTranslationEnglish.Text = qs2.core.language.sqlLanguage.getRes("English")
            Me.lblTranslationUser.Text = qs2.core.language.sqlLanguage.getRes("User")

            Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.ePicture.ico_Ressourcen, 32, 32)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Function validateData() As Boolean
        Try
            Me.ErrorProvider1.SetError(Me.txtTranslationForIDResGerman, "")
            Me.ErrorProvider1.SetError(Me.txtTranslationForIDResEnglish, "")
            Me.ErrorProvider1.SetError(Me.txtTranslationForIDResUser, "")

            If Me.txtTranslationForIDResEnglish.Text.Trim() = "" Then
                Dim errTxt As String = qs2.core.language.sqlLanguage.getRes("ErrorInput") + "!"
                Me.txtTranslationForIDResEnglish.Focus()
                Me.ErrorProvider1.SetError(Me.txtTranslationForIDResEnglish, errTxt)
                MsgBox(qs2.core.language.sqlLanguage.getRes("InputRequired") + "!", MsgBoxStyle.Information, "")
                Return False

            ElseIf Me.txtTranslationForIDResGerman.Text.Trim() = "" Then
                Dim errTxt As String = qs2.core.language.sqlLanguage.getRes("ErrorInput") + "!"
                Me.txtTranslationForIDResGerman.Focus()
                Me.ErrorProvider1.SetError(Me.txtTranslationForIDResGerman, errTxt)
                MsgBox(qs2.core.language.sqlLanguage.getRes("InputRequired") + "!", MsgBoxStyle.Information, "")
                Return False

            End If

            Return True

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
        End Try
    End Function

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If Not Me.validateData() Then Exit Sub
            If Me.cTranslate1.saveTranslation(Me.IDResToTranslate, Me.txtTranslationForIDResGerman.Text.Trim(),
                                              Me.txtTranslationForIDResEnglish.Text.Trim(),
                                              Me.txtTranslationForIDResUser.Text.Trim(),
                                              Me.Application, True) Then
                Me.abort = False
                Me.Close()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Me.Close()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub frmTranslateText_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        Try
            Me.txtTranslationForIDResEnglish.Focus()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub frmTranslateText_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Me.Visible Then
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class