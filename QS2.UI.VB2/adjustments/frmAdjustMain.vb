Imports qs2.core.vb
Imports qs2.Resources


Public Class frmAdjustMain

    Public AutoControlsUI1 As New qs2.design.auto.workflowAssist.autoForm.AutoControlsUI()
    Public contAdjustMain1 As contAdjustMain = Nothing



    Private Sub frmAdjustMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub initControl()
        Try
            Me.Text = qs2.core.language.sqlLanguage.getRes("Adjustments")

            Me.contAdjustMain1 = New contAdjustMain()
            Me.contAdjustMain1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelToLoad.Controls.Add(Me.contAdjustMain1)
            Me.contAdjustMain1.initControl()

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

    Private Sub frmAdjustMain_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        Try
            If Me.Visible Then
            End If

        Catch ex As Exception
            qs2.core.generic.getExep(ex.ToString(), ex.Message)
        End Try
    End Sub

End Class