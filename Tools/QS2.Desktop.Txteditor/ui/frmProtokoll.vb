Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports qs2.core.vb
Imports qs2.pictures





Public Class frmProtokoll

    Public notToClose As Boolean = False



    Private Sub frmProtokoll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            Me.CancelButton = Me.btnClose

            Me.pictureBoxError.Image = getRes.getImage(qs2.pictures.getRes.ePicture.ico_log, qs2.pictures.getRes.ePicTyp.ico)

            Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard
            Me.Icon = qs2.pictures.getRes.getIcon(qs2.pictures.getRes.ePicture.ico_protokoll)

            Me.btnClose.Text = qs2.core.language.sqlLanguage.getRes("Close")
            Me.lblSendMessageAsEMail.Text = qs2.core.language.sqlLanguage.getRes("SendProtocol")

            Dim info As New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            info.ToolTipTitle = qs2.core.language.sqlLanguage.getRes("SendProtocol")
            info.ToolTipText = qs2.core.language.sqlLanguage.getRes("SendProtocolPerEMailToFirm")
            Me.UltraToolTipManager1.SetUltraToolTip(Me.lblSendMessageAsEMail, info)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
        End Try
    End Sub
    Public Sub doTitle(ByVal txt As String)
        Try
            Me.Text = qs2.core.language.sqlLanguage.getRes("Protokoll") + IIf(txt.Trim() <> "", ": " + txt, "")

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub txtProtokoll_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProtokoll.KeyPress
        e.Handled = True
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Try
            Me.Close()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub lblSendMessageAsEMail_Click(sender As System.Object, e As System.EventArgs) Handles lblSendMessageAsEMail.Click
        Try
            Dim sendEMail1 As New qs2.core.EMail()
            Dim msgTxt As String = ""
            msgTxt = qs2.core.language.sqlLanguage.getRes("PleaseAShortDescriptionOfTheError") + vbNewLine + vbNewLine + vbNewLine
            msgTxt += "Title: Send Protocol" + vbNewLine + vbNewLine
            msgTxt += "User: " + qs2.core.vb.actUsr.rUsr.UserName + vbNewLine
            msgTxt += "Time: " + Now.ToString() + vbNewLine
            msgTxt += "Hostname: " + System.Net.Dns.GetHostName().ToString() + vbNewLine + vbNewLine
            msgTxt += "Message: " + vbNewLine + Me.txtProtokoll.Text.Trim() + vbNewLine

            sendEMail1.sendEMail(qs2.core.language.sqlLanguage.getRes("MessageQS2"), msgTxt, qs2.core.ENV.EMailService)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub frmProtokoll_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If Me.notToClose Then
                Me.Visible = False
                e.Cancel = True
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub UFormLinkZurücksetzen_Click(sender As System.Object, e As System.EventArgs) Handles UFormLinkZurücksetzen.Click
        Try
            Clipboard.SetDataObject(Me.txtProtokoll.Text.Trim(), True)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
End Class