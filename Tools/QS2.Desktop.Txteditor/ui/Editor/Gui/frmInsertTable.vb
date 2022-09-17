Public Class frmInsertTable
    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        tx.Tables.Add(CType(updownRows.Value, Integer), CType(updownColumns.Value, Integer))
        Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Close()
    End Sub
End Class