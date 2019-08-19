Partial Class dbCalc
    Partial Public Class KostenKostenträgerDataTable
        Private Sub KostenKostenträgerDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.IDSonderLeistungskatalogColumn.ColumnName) Then
                'Benutzercode hier einfügen
            End If

        End Sub

    End Class

    Partial Class KostenträgerDataTable


        Private Sub KostenträgerDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.UeberweisungsbetragColumn.ColumnName) Then
                'Benutzercode hier einfügen
            End If

        End Sub

    End Class

    Partial Class TagesleistungenDataTable

        Private Sub TagesleistungenDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.TagespreisReduziertNettoColumn.ColumnName) Then
                'Benutzercode hier einfügen
            End If

        End Sub

    End Class

    Partial Class LeistungenDataTable

        Private Sub LeistungenDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.MWStSatzColumn.ColumnName) Then
                'Benutzercode hier einfügen
            End If

        End Sub

    End Class

    Partial Class MonateDataTable

        Private Sub MonateDataTable_MonateRowChanging(ByVal sender As System.Object, ByVal e As MonateRowChangeEvent) Handles Me.MonateRowChanging

        End Sub

    End Class


End Class
