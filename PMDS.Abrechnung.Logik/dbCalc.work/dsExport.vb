

Partial Public Class dsExport
    Partial Class ExportKostentraegerDataTable

        Private Sub ExportKostentraegerDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.MatchcodeColumn.ColumnName) Then
                'Benutzercode hier einfügen
            End If

        End Sub

    End Class

End Class
