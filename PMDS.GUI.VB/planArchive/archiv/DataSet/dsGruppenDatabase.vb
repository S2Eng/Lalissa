Partial Class dsGruppenDatabase
    Partial Class tblGruppenDataTable

        Private Sub tblGruppenDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.BezeichnungColumn.ColumnName) Then
                'Benutzercode hier einfügen
            End If

        End Sub

    End Class

End Class
