

Public Class frmProtocol

    Public notToClose As Boolean = False



    Private Sub frmProtocol_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl()
        Try
            Me.CancelButton = Me.ContProtocol1.btnClose

            Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.Allgemein.ico_Table, 32, 32)

            Me.ContProtocol1.mainWindow = Me
            Me.ContProtocol1.initControl()

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Public Sub doTitle(ByVal txt As String)
        Try
            Me.Text = "Protokoll" + IIf(txt.Trim() <> "", ": " + txt, "")

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub frmProtocol_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If Me.notToClose Then
                Me.Visible = False
                e.Cancel = True
            End If

        Catch ex As Exception
            QS2.Desktop.Txteditor.generic.getExcept(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class