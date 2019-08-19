

Public Class frmEditDocu

    Public gen As New General()
    Public abort As Boolean = True

    Public IDContract As System.Guid = Nothing

    Public doUI1 As New doUI()




    Private Sub frmEditDocu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl()
        Try
            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.Text = doUI.getRes("EditDocument")
            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32)

            Me.ContEditDocument1.mainWindow = Me
            Me.ContEditDocument1.initControl()

        Catch ex As Exception
            Throw New Exception("frmEditDocu.initControl: " + ex.ToString())
        End Try
    End Sub

End Class