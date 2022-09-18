

Imports System.Windows.Forms

Public Class frmAdjustmentQTHDb


    Private Sub frmAdjustmentQTHDb_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl()
        Try
            Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.ePicture.ico_Criterias, 32, 32)
            Me.Text = qs2.core.language.sqlLanguage.getRes("AdjustmentQTHDb")

        Catch ex As Exception
            Throw New Exception("frmAdjustmentQTHDb.initControl: " + ex.ToString())
        End Try
    End Sub

    Private Sub btnRunImport_Click(sender As Object, e As EventArgs) Handles btnRunImport.Click
        Try
            Dim b As New qs2.core.vb.businessFramework()
            Dim bOk As Boolean = b.sys_AdjustmentQTHDb()
            qs2.core.generic.showMessageBox(qs2.core.language.sqlLanguage.getRes("ActivityPerformed") + "!", MessageBoxButtons.OK, "")

        Catch ex As Exception
            Throw New Exception("frmAdjustmentQTHDb.initControl: " + ex.ToString())
        End Try
    End Sub

End Class