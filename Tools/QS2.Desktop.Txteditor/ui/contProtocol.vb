Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports qs2.Resources





Public Class contProtocol


    Public mainWindow As frmProtocol = Nothing

    Public TypeProtocolWindow As eTypeProtocolWindow = eTypeProtocolWindow.normal
    Public Enum eTypeProtocolWindow
        protocol = 0
        monitoring = 1
        normal = 100
    End Enum




    Public Sub initControl()
        Try
            Me.pictureBoxError.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.ePicture.ico_log, 32, 32)

            Me.UltraTabControl1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Wizard

            Me.btnClose.Visible = True

            Dim info As New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            Me.UltraToolTipManager1.SetUltraToolTip(Me.lblSendMessageAsEMail, info)

            Me.btnSaveAs.Appearance.Image = qs2.Resources.getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Speichern, 32, 32)
            Me.btnClear.Appearance.Image = getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Loeschen, 32, 32)
            Me.btnRefresh.Appearance.Image = getRes.getImage(qs2.Resources.getRes.Allgemein.ico_Rückgängig, 32, 32)

            Dim infoTooltip As New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            infoTooltip.ToolTipTitle = ""
            Me.UltraToolTipManager1.SetUltraToolTip(Me.btnSaveAs, infoTooltip)

            Dim infoRefresh As New Infragistics.Win.UltraWinToolTip.UltraToolTipInfo()
            infoRefresh.ToolTipTitle = ""
            Me.UltraToolTipManager1.SetUltraToolTip(Me.btnRefresh, infoRefresh)

            If Me.TypeProtocolWindow = eTypeProtocolWindow.protocol Then
                Me.btnRefresh.Visible = False
                Me.btnClear.Visible = False
            Else
                Me.btnClear.Visible = True
            End If

        Catch ex As Exception
            Throw New Exception("contProtocol.initControl:" + ex.ToString())
        End Try
    End Sub


    Private Sub txtProtokoll_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProtokoll.KeyPress
        e.Handled = True
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Try
            Me.mainWindow.Close()

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub lblSendMessageAsEMail_Click(sender As System.Object, e As System.EventArgs) Handles lblSendMessageAsEMail.Click
        Try
            Dim sendEMail1 As New QS2.Logging.Win.EMail()
            Dim msgTxt As String = ""
            msgTxt = "Please A Short Description Of The Error" + vbNewLine + vbNewLine + vbNewLine
            msgTxt += "Title: Send Protocol" + vbNewLine + vbNewLine
            msgTxt += "Time: " + Now.ToString() + vbNewLine
            msgTxt += "Hostname: " + System.Net.Dns.GetHostName().ToString() + vbNewLine + vbNewLine
            msgTxt += "Message: " + vbNewLine + Me.txtProtokoll.Text.Trim() + vbNewLine

            sendEMail1.sendEMail("Message QS2", msgTxt, QS2.functions.cs.EMail.EMailService)

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub UFormLinkZurücksetzen_Click(sender As System.Object, e As System.EventArgs) Handles UFormLinkZurücksetzen.Click
        Try
            Clipboard.SetDataObject(Me.txtProtokoll.Text.Trim(), True)

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub btnSaveAs_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveAs.Click
        Try
            Me.Cursor = Cursors.WaitCursor
 
            Application.DoEvents()
            Dim clString As New QS2.functions.vb.funct()
            Dim fil As String = clString.saveFile(False, QS2.functions.vb.funct.fileTypeTxt, "", System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
            If fil <> Nothing Then
                Dim StreamWriter1 As New System.IO.StreamWriter(fil)
                StreamWriter1.Write(Me.txtProtokoll.Text.Trim())
                StreamWriter1.Close()
                MessageBox.Show("File saved", "QS2")
            End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.txtProtokoll.Text = ""

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
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
            End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class