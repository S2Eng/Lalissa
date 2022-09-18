



Public Class frmSimulatePMDSQuery

    Public UnvisibleOnClose As Boolean = False
    Public AutoControlsUI1 As New qs2.design.auto.workflowAssist.autoForm.AutoControlsUI()




    Private Sub frmSimulatePMDSQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmSimulatePMDSQuery_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged

    End Sub

    Private Sub frmSimulatePMDSQuery_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If Me.UnvisibleOnClose Then
                Me.Visible = False
                e.Cancel = True
            End If

            If Me.Visible Then
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class