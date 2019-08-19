

Public Class typDef_generic

    Public gen As New GeneralArchiv()



    Public Sub initRow(ByRef r As DataRow)
        Try

            For i As Integer = 0 To r.Table.Columns.Count - 1
                Dim col As New DataColumn
                col = r.Table.Columns(i)
                Dim typ As System.Type
                typ = col.DataType
                If LCase(typ.ToString) = LCase("System.Boolean") Then
                    r(col.ColumnName) = False
                ElseIf LCase(typ.ToString) = LCase("System.Int32") Or LCase(typ.ToString) = LCase("System.Double") Then
                    r(col.ColumnName) = 0
                ElseIf LCase(typ.ToString) = LCase("System.String") Then
                    r(col.ColumnName) = ""
                ElseIf LCase(typ.ToString) = LCase("System.Date") Or LCase(typ.ToString) = LCase("System.DateTime") Then
                    Dim d As New DateTime
                    r(col.ColumnName) = d   'System.DBNull.Value
                ElseIf LCase(typ.ToString) = LCase("System.Guid") Then
                    r(col.ColumnName) = System.Guid.Empty
                ElseIf LCase(typ.ToString) = LCase("System.Int64") Then
                    r(col.ColumnName) = 0
                End If
            Next

        Catch ex As Exception
            gen.GetEcxeptionGeneral(ex)
        Finally
        End Try
    End Sub


End Class