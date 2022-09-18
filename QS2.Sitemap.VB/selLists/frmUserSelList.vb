


Public Class frmUserSelList




    Private Sub frmUserSelList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub initControl(IDSelListEntryQuery As Integer, IDApplication As String, Queryname As String, TitleWindow As String)
        Try
            Me.Icon = qs2.Resources.getRes.getIcon(qs2.Resources.getRes.Allgemein.ico_OK, 32, 32)
            Me.Text = TitleWindow

            Me.ContUserSelList1.mainWindow = Me
            Me.ContUserSelList1.initControl(IDSelListEntryQuery, IDApplication)

        Catch ex As Exception
            Throw New Exception("frmUserSelList.initControl: " + ex.ToString())
        End Try
    End Sub

End Class