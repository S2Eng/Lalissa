Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Shared




Public Class frmSelectDocuName

    Public gen As New General()
    Public doUI1 As New doUI()





    Private Sub frmSelectDocuName_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub initControl(ByRef DocumentnameDefault As String)
        Try
            Me.Text = doUI.getRes("SelectDocumentName")

            Dim newRessourcesAdded As Integer = 0
            Me.doUI1.run(Me, Me.components, Me.UltraToolTipManager1, newRessourcesAdded, True)

            Me.Icon = QS2.Resources.getRes.getIcon(QS2.Resources.getRes.Launcher.ico_PMDS, 32, 32)

            Me.ContSelectDocuName1.mainWindow = Me
            Me.ContSelectDocuName1.initControl(DocumentnameDefault)

        Catch ex As Exception
            Throw New Exception("frmSelectDocuName.initControl: " + ex.ToString())
        End Try
    End Sub

End Class