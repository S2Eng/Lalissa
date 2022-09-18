



Public Class PrintGrid

    Private Sub PrintGrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Public Function print(ByVal grid As Infragistics.Win.UltraWinGrid.UltraGrid) As Boolean
        Try
            Me.UltraGridPrintDocument1.Grid = grid
            Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
            Me.UltraPrintPreviewDialog1.ShowDialog(Me)

        Catch ex As Exception
            Throw New Exception("PrintGrid.printGrid: " + ex.ToString())
        End Try
    End Function

End Class