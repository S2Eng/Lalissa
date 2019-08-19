


Public Class frmDesigner


    Private Sub frmDesigner_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.PMDS_TouchDoku.ico_Bereichsansicht, 32, 32)
    End Sub

    Public Sub initControl()
        Try
            Me.ContDesigner1.mainForm = Me
            Me.ContDesigner1.initControl()

        Catch ex As Exception
            QS2.core.generic.getExep(ex.ToString(), "")
        End Try
    End Sub

    Private Sub frmDesigner_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Visible = False
        e.Cancel = True
    End Sub
End Class