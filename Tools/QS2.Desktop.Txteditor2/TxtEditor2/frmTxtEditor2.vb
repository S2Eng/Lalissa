

Public Class frmTxtEditor2

    Public IsInitialized As Boolean = False



    Private Sub FormMainFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Allgemein.ico_Table, 32, 32)
    End Sub

    Public Sub initControl()
        If Not Me.IsInitialized Then
            Me.contTxtEditor21.mainForm = Me
            Me.IsInitialized = True
        End If
    End Sub


    Private Sub frmTxtEditor2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.contTxtEditor21._fileHandler.DocumentDirty Then
            Dim dlgRes As System.Windows.Forms.DialogResult = MessageBox.Show("Save changes to " & Convert.ToString(Me.contTxtEditor21._fileHandler.DocumentTitle) & "?", "Question", MessageBoxButtons.YesNoCancel)
            If dlgRes = System.Windows.Forms.DialogResult.Yes Then
                Me.contTxtEditor21._fileHandler.FileSave()
                If Me.contTxtEditor21._fileHandler.DocumentFileName = "" Then
                    e.Cancel = True
                End If
            ElseIf dlgRes = System.Windows.Forms.DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If
        Me.contTxtEditor21.SaveAppSettings()
    End Sub
End Class