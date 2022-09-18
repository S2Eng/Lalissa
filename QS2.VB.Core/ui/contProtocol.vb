Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports qs2.core.vb
Imports qs2.pictures
Imports qs2.Resources





Public Class contProtocol


    Public mainWindow As frmProtocol = Nothing
    Public funct1 As New qs2.core.vb.funct()

    Public TypeProtocolWindow As eTypeProtocolWindow = eTypeProtocolWindow.normal
    Public Enum eTypeProtocolWindow
        protocol = 0
        monitoring = 1
        normal = 100
    End Enum




    Public Sub initControl()
        Try
            Me.pictureBoxError.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.ePicture.ico_log, 32, 32)
            Me.btnPrintPrieview.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Drucken, 32, 32)

            Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard

            If Me.mainWindow Is Nothing Then
                Me.btnClose.Visible = False
            Else
                Me.btnClose.Visible = True
            End If

            Me.btnClose.Text = qs2.core.language.sqlLanguage.getRes("Close")
            Me.lblSendMessageAsEMail.Text = qs2.core.language.sqlLanguage.getRes("SendProtocol")

            Dim info As New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            info.ToolTipTitle = qs2.core.language.sqlLanguage.getRes("SendProtocol")
            info.ToolTipText = qs2.core.language.sqlLanguage.getRes("SendProtocolPerEMailToFirm")
            Me.UltraToolTipManager1.SetUltraToolTip(Me.lblSendMessageAsEMail, info)

            Me.btnSaveAs.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Speichern, 32, 32)
            Me.btnClear.Appearance.Image = getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)
            Me.btnRefresh.Appearance.Image = getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Rückgängig, 32, 32)

            Dim infoTooltip As New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            infoTooltip.ToolTipText = qs2.core.language.sqlLanguage.getRes("SaveAs")
            infoTooltip.ToolTipTitle = ""
            Me.UltraToolTipManager1.SetUltraToolTip(Me.btnSaveAs, infoTooltip)

            Dim infoRefresh As New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            infoRefresh.ToolTipText = qs2.core.language.sqlLanguage.getRes("Refresh")
            infoRefresh.ToolTipTitle = ""
            Me.UltraToolTipManager1.SetUltraToolTip(Me.btnRefresh, infoRefresh)

            If Me.TypeProtocolWindow = eTypeProtocolWindow.protocol Then
                Me.btnRefresh.Visible = False
                Me.btnClear.Visible = False
            Else
                If qs2.core.vb.actUsr.IsAdminSecureOrSupervisor() Then
                    Me.btnClear.Visible = True
                Else
                    Me.btnClear.Visible = False
                End If
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Try
            Me.mainWindow.Close()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub lblSendMessageAsEMail_Click(sender As System.Object, e As System.EventArgs) Handles lblSendMessageAsEMail.Click
        Try
            Dim sendEMail1 As New qs2.functions.cs.EMail()
            Dim msgTxt As String = ""
            msgTxt = qs2.core.language.sqlLanguage.getRes("PleaseAShortDescriptionOfTheError") + vbNewLine + vbNewLine + vbNewLine
            msgTxt += "Title: Send Protocol" + vbNewLine + vbNewLine
            msgTxt += "User: " + qs2.core.vb.actUsr.rUsr.UserName + vbNewLine
            msgTxt += "Time: " + Now.ToString() + vbNewLine
            msgTxt += "Hostname: " + System.Net.Dns.GetHostName().ToString() + vbNewLine + vbNewLine
            msgTxt += "Message: " + vbNewLine + Me.TextControl1.Text.Trim() + vbNewLine

            sendEMail1.sendEMail(qs2.core.language.sqlLanguage.getRes("MessageQS2"), msgTxt, qs2.core.ENV.EMailService)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub
    Public Sub setText(Txt As String)
        Try
            Me.TextControl1.Text = Txt

        Catch ex As Exception
            Throw New Exception("setTxt: " + ex.ToString())
        End Try
    End Sub
    Public Function getTxt() As String
        Try
            Return Me.TextControl1.Text

        Catch ex As Exception
            Throw New Exception("getTxt: " + ex.ToString())
        End Try
    End Function

    Private Sub UFormLinkZurücksetzen_Click(sender As System.Object, e As System.EventArgs) Handles UFormLinkZurücksetzen.Click
        Try
            Clipboard.SetDataObject(Me.TextControl1.Text.Trim(), True)

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub btnSaveAs_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAs.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Application.DoEvents()
            Dim fil As String = Me.funct1.saveFile(False, qs2.core.vb.funct.TxtFileTxtDialog, "", qs2.core.vb.funct.getFolder(Environment.SpecialFolder.Desktop))
            If fil <> Nothing Then
                Dim StreamWriter1 As New System.IO.StreamWriter(fil)
                StreamWriter1.Write(Me.TextControl1.Text.Trim())
                StreamWriter1.Close()
                MessageBox.Show(qs2.core.language.sqlLanguage.getRes("FileSaved"), qs2.core.language.sqlLanguage.getRes("QS2"))
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.TextControl1.Text = ""
            qs2.core.Protocol.MonitoringOutput = ""

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.TypeProtocolWindow = eTypeProtocolWindow.protocol Then
                'Me.txtProtokoll.Text = qs2.core.Protocol.totalProtocol.Trim()
            ElseIf Me.TypeProtocolWindow = eTypeProtocolWindow.monitoring Then
                Me.TextControl1.Text = qs2.core.Protocol.MonitoringOutput.Trim()
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnPrintPrieview_Click(sender As Object, e As EventArgs) Handles btnPrintPrieview.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.TextControl1.PrintPreview("Protocol")

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub contProtocol_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try


        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub contProtocol_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Me.TextControl1.Refresh()
    End Sub
End Class